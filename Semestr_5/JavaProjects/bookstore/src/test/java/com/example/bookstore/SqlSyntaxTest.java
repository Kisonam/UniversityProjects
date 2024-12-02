package com.example.bookstore;

import com.example.bookstore.model.Author;
import com.example.bookstore.model.Book;
import com.example.bookstore.repository.AuthorRepository;
import com.example.bookstore.repository.BookRepository;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

@DataJpaTest
public class SqlSyntaxTest {

    @Autowired
    private AuthorRepository authorRepository;

    @Autowired
    private BookRepository bookRepository;

    @Test
    public void testSqlQuerySyntaxForAuthors() {
        // Given
        Author author = new Author("Test", "Author");
        authorRepository.save(author);

        // When
        List<Author> authors = authorRepository.findAll();

        // Then
        assertThat(authors).isNotEmpty();
        assertThat(authors.get(0).getName()).isEqualTo("Test");
    }

    @Test
    public void testSqlQuerySyntaxForBooks() {
        // Given
        Author author = new Author("Jane", "Doe");
        authorRepository.save(author);

        Book book = new Book("Test Book", "Genre", 2023, author);
        bookRepository.save(book);

        // When
        List<Book> books = bookRepository.findAll();

        // Then
        assertThat(books).isNotEmpty();
        assertThat(books.get(0).getTitle()).isEqualTo("Test Book");
        assertThat(books.get(0).getAuthor().getName()).isEqualTo("Jane");
    }
}
