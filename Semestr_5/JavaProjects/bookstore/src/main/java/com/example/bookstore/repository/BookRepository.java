package com.example.bookstore.repository;

import com.example.bookstore.model.Author;
import com.example.bookstore.model.Book;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface BookRepository extends JpaRepository<Book, Long> {
    // Метод для отримання книг по автору
    List<Book> findByAuthor(Author author);
}