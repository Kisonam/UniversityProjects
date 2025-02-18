<<<<<<< HEAD
=======
//package com.example.bookstore;
//
//import com.example.bookstore.controller.BookController;
//import com.example.bookstore.model.Author;
//import com.example.bookstore.model.Book;
//import com.example.bookstore.service.AuthorService;
//import com.example.bookstore.service.BookService;
//import com.fasterxml.jackson.databind.ObjectMapper;
//import org.junit.jupiter.api.Test;
//import org.mockito.Mock;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
//import org.springframework.boot.test.mock.mockito.MockBean;
//import org.springframework.http.MediaType;
//import org.springframework.test.web.servlet.MockMvc;
//
//import java.util.Collections;
//import java.util.Optional;
//
//import static org.mockito.Mockito.*;
//import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
//import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;
//
//@WebMvcTest(BookController.class)
//public class BookControllerTest {
//
//    @Autowired
//    private MockMvc mockMvc;
//
//    @MockBean
//    private BookService bookService;
//
//    @MockBean
//    private AuthorService authorService;
//
//    @Autowired
//    private ObjectMapper objectMapper;
//
//    @Test
//    public void testGetAllBooks() throws Exception {
//        Author author = new Author("John", "Doe");
//        Book book = new Book("Book Title", "Fiction", 2023, author);
//        when(bookService.getAllBooks()).thenReturn(Collections.singletonList(book));
//
//        mockMvc.perform(get("/books")
//                        .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(content().json(objectMapper.writeValueAsString(Collections.singletonList(book))));
//    }
//
////    @Test
////    public void testGetBookById() throws Exception {
////        Author author = new Author("John", "Doe");
////        Book book = new Book("Book Title", "Fiction", 2023, author);
////        when(bookService.getBookById(1L)).thenReturn(Optional.of(book));
////
////        mockMvc.perform(get("/books/1")
////                        .contentType(MediaType.APPLICATION_JSON))
////                .andExpect(status().isOk())
////                .andExpect(content().json(objectMapper.writeValueAsString(book)));
////    }
//
//    @Test
//    public void testGetBooksByAuthor_AuthorNotFound() throws Exception {
//        Long authorId = 1L;
//
//        when(bookService.getBooksByAuthor(any(Author.class))).thenReturn(Collections.emptyList());
//        when(authorService.getAuthorById(authorId)).thenReturn(Optional.empty());
//
//        mockMvc.perform(get("/books/author/" + authorId)
//                        .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(content().json("[]"));
//    }
//
//    @Test
//    public void testCreateBook() throws Exception {
//        Author author = new Author("Jane", "Doe");
//        Book book = new Book("New Book", "Sci-Fi", 2024, author);
//        when(bookService.saveBook(any(Book.class))).thenReturn(book);
//
//        mockMvc.perform(post("/books")
//                        .contentType(MediaType.APPLICATION_JSON)
//                        .content(objectMapper.writeValueAsString(book)))
//                .andExpect(status().isCreated())
//                .andExpect(content().json(objectMapper.writeValueAsString(book)));
//    }
//
////    @Test
////    public void testUpdateBook() throws Exception {
////        Author author = new Author("Updated", "Author");
////        Book updatedBook = new Book("Updated Title", "Adventure", 2025, author);
////        when(bookService.saveBook(any(Book.class))).thenReturn(updatedBook);
////
////        mockMvc.perform(put("/books/1")
////                        .contentType(MediaType.APPLICATION_JSON)
////                        .content(objectMapper.writeValueAsString(updatedBook)))
////                .andExpect(status().isOk())
////                .andExpect(content().json(objectMapper.writeValueAsString(updatedBook)));
////    }
//
//    @Test
//    public void testDeleteBook() throws Exception {
//        mockMvc.perform(delete("/books/1")
//                        .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//
//        verify(bookService, times(1)).deleteBook(1L);
//    }
//}
>>>>>>> 1601e430ea51704dca7871fc5aec86189838b283
