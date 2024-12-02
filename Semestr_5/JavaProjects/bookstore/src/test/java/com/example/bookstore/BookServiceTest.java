package com.example.bookstore;

import com.example.bookstore.model.Author;
import com.example.bookstore.model.Book;
import com.example.bookstore.repository.BookRepository;
import com.example.bookstore.service.BookService;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.*;

public class BookServiceTest {

    @Mock
    private BookRepository bookRepository;

    @InjectMocks
    private BookService bookService;

    public BookServiceTest() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void testGetAllBooks() {
        // Given
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", "Genre", 2023, author);
        when(bookRepository.findAll()).thenReturn(Collections.singletonList(book));

        // When
        List<Book> books = bookService.getAllBooks();

        // Then
        assertThat(books).hasSize(1);
        assertThat(books.get(0).getTitle()).isEqualTo("Test Book");
        verify(bookRepository, times(1)).findAll();
    }

    @Test
    public void testGetBookById() {
        // Given
        Author author = new Author("John", "Doe");
        Book book = new Book("Test Book", "Genre", 2023, author);
        when(bookRepository.findById(1L)).thenReturn(Optional.of(book));

        // When
        Optional<Book> foundBook = bookService.getBookById(1L);

        // Then
        assertThat(foundBook).isPresent();
        assertThat(foundBook.get().getTitle()).isEqualTo("Test Book");
        verify(bookRepository, times(1)).findById(1L);
    }
}
