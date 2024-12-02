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
    private AuthorService authorService; // Мок сервісу

    @InjectMocks
    private AuthorController authorController; // Мок контролера

    @BeforeEach
    public void setUp() {
        MockitoAnnotations.openMocks(this); // Ініціалізація моків
    }

    @Test
    public void testCreateAuthor_WhenAuthorDoesNotExist() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Вказуємо, що автор не існує
        when(authorService.saveAuthor(author)).thenReturn(author);

        ResponseEntity<?> response = authorController.createAuthor(author);

        assertEquals(201, response.getStatusCodeValue()); // Статус Created
        assertNotNull(response.getBody());
        assertTrue(response.getBody() instanceof Author);
    }

    @Test
    public void testCreateAuthor_WhenAuthorExists() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Вказуємо, що такий автор вже існує
        when(authorService.saveAuthor(author)).thenThrow(new IllegalArgumentException("Taki autor już istnieje!"));

        ResponseEntity<?> response = authorController.createAuthor(author);

        assertEquals(409, response.getStatusCodeValue()); // Статус Conflict
        assertEquals("Taki autor już istnieje!", response.getBody());
    }
    @Test
    public void testGetAllAuthors() {
        Author author1 = new Author();
        author1.setName("Jan");
        author1.setSurname("Kowalski");

        Author author2 = new Author();
        author2.setName("Anna");
        author2.setSurname("Nowak");

        // Вказуємо, що при виклику сервісу повертається список авторів
        when(authorService.getAllAuthors()).thenReturn(List.of(author1, author2));

        List<Author> authors = authorController.getAllAuthors();

        assertEquals(2, authors.size()); // Перевірка, що кількість авторів відповідає очікуваному
        assertEquals("Jan", authors.get(0).getName()); // Перевірка імені першого автора
        assertEquals("Anna", authors.get(1).getName()); // Перевірка імені другого автора
    }
    @Test
    public void testGetAuthorById_WhenAuthorExists() {
        Long authorId = 1L;
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Вказуємо, що автор з таким ID існує
        when(authorService.getAuthorById(authorId)).thenReturn(Optional.of(author));

        Optional<Author> response = authorController.getAuthorById(authorId);

        assertTrue(response.isPresent()); // Перевірка, що автор знайдений
        assertEquals("Jan", response.get().getName()); // Перевірка імені автора
    }

    @Test
    public void testGetAuthorById_WhenAuthorDoesNotExist() {
        Long authorId = 1L;

        // Вказуємо, що автор з таким ID не існує
        when(authorService.getAuthorById(authorId)).thenReturn(Optional.empty());

        Optional<Author> response = authorController.getAuthorById(authorId);

        assertFalse(response.isPresent()); // Перевірка, що автор не знайдений
    }

    @Test
    public void testUpdateAuthor() {
        Long authorId = 1L;
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Вказуємо, що автор оновлюється
        when(authorService.saveAuthor(author)).thenReturn(author);

        Author updatedAuthor = authorController.updateAuthor(authorId, author);

        assertEquals("Jan", updatedAuthor.getName()); // Перевірка оновленого імені автора
        assertEquals("Kowalski", updatedAuthor.getSurname()); // Перевірка оновленого прізвища
    }
    @Test
    public void testDeleteAuthor() {
        Long authorId = 1L;

        // Викликаємо метод видалення
        doNothing().when(authorService).deleteAuthor(authorId);

        // Перевірка, що метод deleteAuthor викликається
        authorController.deleteAuthor(authorId);
        verify(authorService, times(1)).deleteAuthor(authorId); // Перевірка, що метод був викликаний один раз
    }

}
