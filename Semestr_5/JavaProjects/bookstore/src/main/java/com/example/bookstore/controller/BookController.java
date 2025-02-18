package com.example.bookstore.controller;

import com.example.bookstore.model.Author;
import com.example.bookstore.model.Book;
import com.example.bookstore.service.AuthorService;
import com.example.bookstore.service.BookService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/books")
public class BookController {

    @Autowired
    private BookService bookService;

    @Autowired
    private AuthorService authorService;

    @GetMapping
    public List<Book> getAllBooks() {
        return bookService.getAllBooks();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Book> getBookById(@PathVariable Long id) {
        Optional<Book> book = bookService.getBookById(id);
        if (book.isPresent()) {
            return ResponseEntity.ok(book.get());
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(null);
    }

    // Новий метод для отримання книг по автору
    @GetMapping("/author/{authorId}")
    public ResponseEntity<List<Book>> getBooksByAuthor(@PathVariable Long authorId) {
        // Перевіряємо чи існує автор з таким ID
        Optional<Author> author = authorService.getAuthorById(authorId);
        if (author.isPresent()) {
            // Повертаємо книги цього автора
            return ResponseEntity.ok(bookService.getBooksByAuthor(author.get()));
        }
        // Якщо автора не знайдено, повертаємо порожній список
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new ArrayList<>());
    }

    @PostMapping
    public ResponseEntity<?> createBook(@RequestBody Book book) {
        // Перевірка на валідність даних книги
        if (book.getTitle() == null || book.getTitle().isBlank() ||
                book.getGenre() == null || book.getGenre().isBlank() ||
                book.getPublicationYear() <= 0) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Invalid book details!");
        }

        // Перевірка на наявність автора
        if (book.getAuthor() == null || book.getAuthor().getId() == null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Author is required!");
        }

        // Шукаємо автора за ID
        Optional<Author> authorOptional = authorService.getAuthorById(book.getAuthor().getId());
        if (authorOptional.isEmpty()) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Author not found!");
        }

        // Прив'язуємо автора до книги
        book.setAuthor(authorOptional.get());

        // Зберігаємо книгу
        Book savedBook = bookService.saveBook(book);

        // Повертаємо збережену книгу з усіма даними (включаючи автора)
        return ResponseEntity.status(HttpStatus.CREATED).body(savedBook);
    }

    @PutMapping("/{id}")
<<<<<<< HEAD
    public ResponseEntity<Book> updateBook(@PathVariable Long id, @RequestBody Book book) {
        Optional<Book> existingBook = bookService.getBookById(id);
        if (existingBook.isPresent()) {
            book.setId(id);  // Підтверджуємо, що ID книги не змінюється
            Book updatedBook = bookService.saveBook(book);  // Оновлюємо книгу
            return ResponseEntity.ok(updatedBook);  // Повертаємо оновлену книгу зі статусом 200 OK
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).build();  // Якщо книга не знайдена, повертаємо 404
=======
    public Book updateBook(@PathVariable Long id, @RequestBody Book book) {
        return bookService.saveBook(book);
>>>>>>> 1601e430ea51704dca7871fc5aec86189838b283
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteBook(@PathVariable Long id) {
        bookService.deleteBook(id);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }
}
