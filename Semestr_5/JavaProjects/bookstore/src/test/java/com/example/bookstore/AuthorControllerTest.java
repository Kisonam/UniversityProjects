package com.example.bookstore;

import com.example.bookstore.controller.AuthorController;
import com.example.bookstore.model.Author;
import com.example.bookstore.service.AuthorService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.http.ResponseEntity;

import java.util.List;
import java.util.Optional;

import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

public class AuthorControllerTest {

    @Mock
    private AuthorService authorService;

    @InjectMocks
    private AuthorController authorController;

    @BeforeEach
    public void setUp() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void testCreateAuthor_WhenAuthorDoesNotExist() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        when(authorService.saveAuthor(author)).thenReturn(author);

        ResponseEntity<?> response = authorController.createAuthor(author);

        assertEquals(201, response.getStatusCodeValue());
        assertNotNull(response.getBody());
        assertTrue(response.getBody() instanceof Author);
        verify(authorService, times(1)).saveAuthor(author);
    }

    @Test
    public void testCreateAuthor_WhenAuthorExists() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        when(authorService.saveAuthor(author)).thenThrow(new IllegalArgumentException("Taki autor już istnieje!"));

        ResponseEntity<?> response = authorController.createAuthor(author);

        assertEquals(409, response.getStatusCodeValue());
        assertEquals("Taki autor już istnieje!", response.getBody());
        verify(authorService, times(1)).saveAuthor(author);
    }

    @Test
    public void testCreateAuthor_ValidationError() {
        // Некоректний об'єкт Author (порожнє ім'я та прізвище)
        Author invalidAuthor = new Author();

        ResponseEntity<?> response = authorController.createAuthor(invalidAuthor);

        assertEquals(409, response.getStatusCodeValue());
        assertEquals("Invalid author details!", response.getBody());
        // Перевірка, що метод saveAuthor не викликається
        verify(authorService, never()).saveAuthor(any(Author.class));
    }

    @Test
    public void testGetAllAuthors_WithBooks() {
        Author author1 = new Author();
        author1.setName("Jan");
        author1.setSurname("Kowalski");

        Author author2 = new Author();
        author2.setName("Anna");
        author2.setSurname("Nowak");

        when(authorService.getAllAuthors()).thenReturn(List.of(author1, author2));

        List<Author> authors = authorController.getAllAuthors();

        assertEquals(2, authors.size());
        assertEquals("Jan", authors.get(0).getName());
        assertEquals("Anna", authors.get(1).getName());
        verify(authorService, times(1)).getAllAuthors();
    }

    @Test
    public void testGetAuthorById_WithBooks() {
        Long authorId = 1L;

        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        when(authorService.getAuthorById(authorId)).thenReturn(Optional.of(author));

        Optional<Author> response = authorController.getAuthorById(authorId);

        assertTrue(response.isPresent());
        assertEquals("Jan", response.get().getName());
        verify(authorService, times(1)).getAuthorById(authorId);
    }

    @Test
    public void testGetAuthorById_NotFound() {
        Long authorId = 1L;

        when(authorService.getAuthorById(authorId)).thenReturn(Optional.empty());

        Optional<Author> response = authorController.getAuthorById(authorId);

        assertTrue(response.isEmpty());
        verify(authorService, times(1)).getAuthorById(authorId);
    }

    @Test
    public void testUpdateAuthor() {
        Long authorId = 1L;
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        when(authorService.saveAuthor(author)).thenReturn(author);

        Author updatedAuthor = authorController.updateAuthor(authorId, author);

        assertEquals("Jan", updatedAuthor.getName());
        assertEquals("Kowalski", updatedAuthor.getSurname());
        verify(authorService, times(1)).saveAuthor(author);
    }

    @Test
    public void testDeleteAuthor() {
        Long authorId = 1L;

        doNothing().when(authorService).deleteAuthor(authorId);

        authorController.deleteAuthor(authorId);

        verify(authorService, times(1)).deleteAuthor(authorId);
    }
}
