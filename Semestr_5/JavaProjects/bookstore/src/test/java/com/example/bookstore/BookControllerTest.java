package com.example.bookstore;

import com.example.bookstore.controller.BookController;
import com.example.bookstore.model.Author;
import com.example.bookstore.model.Book;
import com.example.bookstore.service.BookService;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import java.util.Collections;
import java.util.Optional;

import static org.mockito.Mockito.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@WebMvcTest(BookController.class)
public class BookControllerTest {

    @Autowired
    private MockMvc mockMvc;

    @MockBean
    private BookService bookService;

    @Autowired
    private ObjectMapper objectMapper;

    @Test
    public void testGetAllBooks() throws Exception {
        // Given
        Author author = new Author("John", "Doe");
        Book book = new Book("Book Title", "Fiction", 2023, author);
        when(bookService.getAllBooks()).thenReturn(Collections.singletonList(book));

        // When & Then
        mockMvc.perform(get("/books")
                        .contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(content().json(objectMapper.writeValueAsString(Collections.singletonList(book))));
    }

    @Test
    public void testGetBookById() throws Exception {
        // Given
        Author author = new Author("John", "Doe");
        Book book = new Book("Book Title", "Fiction", 2023, author);
        when(bookService.getBookById(1L)).thenReturn(Optional.of(book));

        // When & Then
        mockMvc.perform(get("/books/1")
                        .contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(content().json(objectMapper.writeValueAsString(book)));
    }

    @Test
    public void testCreateBook() throws Exception {
        // Given
        Author author = new Author("Jane", "Doe");
        Book book = new Book("New Book", "Sci-Fi", 2024, author);
        when(bookService.saveBook(any(Book.class))).thenReturn(book);

        // When & Then
        mockMvc.perform(post("/books")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(book)))
                .andExpect(status().isOk())
                .andExpect(content().json(objectMapper.writeValueAsString(book)));
    }

    @Test
    public void testUpdateBook() throws Exception {
        // Given
        Author author = new Author("Updated", "Author");
        Book updatedBook = new Book("Updated Title", "Adventure", 2025, author);
        when(bookService.saveBook(any(Book.class))).thenReturn(updatedBook);

        // When & Then
        mockMvc.perform(put("/books/1")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(updatedBook)))
                .andExpect(status().isOk())
                .andExpect(content().json(objectMapper.writeValueAsString(updatedBook)));
    }

    @Test
    public void testDeleteBook() throws Exception {
        // When & Then
        mockMvc.perform(delete("/books/1")
                        .contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());

        // Verify that the service was called
        verify(bookService, times(1)).deleteBook(1L);
    }
}
