package com.example.bookstore;

import com.example.bookstore.model.Author;
import com.example.bookstore.repository.AuthorRepository;
import com.example.bookstore.service.AuthorService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

import java.util.Optional;

public class AuthorServiceTest {

    @Mock
    private AuthorRepository authorRepository; // Мок репозиторія

    @InjectMocks
    private AuthorService authorService; // Мок сервісу

    @BeforeEach
    public void setUp() {
        MockitoAnnotations.openMocks(this); // Ініціалізація моків
    }

    @Test
    public void testSaveAuthor_WhenAuthorDoesNotExist() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Немає такого автора в базі
        when(authorRepository.existsByNameAndSurname("Jan", "Kowalski")).thenReturn(false);
        when(authorRepository.save(author)).thenReturn(author);

        Author savedAuthor = authorService.saveAuthor(author);

        assertNotNull(savedAuthor);
        assertEquals("Jan", savedAuthor.getName());
        assertEquals("Kowalski", savedAuthor.getSurname());

        verify(authorRepository).save(author); // Перевірка виклику save
    }

    @Test
    public void testSaveAuthor_WhenAuthorExists() {
        Author author = new Author();
        author.setName("Jan");
        author.setSurname("Kowalski");

        // Автор вже існує в базі
        when(authorRepository.existsByNameAndSurname("Jan", "Kowalski")).thenReturn(true);

        IllegalArgumentException exception = assertThrows(IllegalArgumentException.class, () -> {
            authorService.saveAuthor(author);
        });

        assertEquals("Taki autor już istnieje!", exception.getMessage());
        verify(authorRepository, never()).save(any(Author.class)); // Перевірка, що save не був викликаний
    }
}
