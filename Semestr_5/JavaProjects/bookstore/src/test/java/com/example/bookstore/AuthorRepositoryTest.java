package com.example.bookstore;

import com.example.bookstore.model.Author;
import com.example.bookstore.repository.AuthorRepository;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

@DataJpaTest
public class AuthorRepositoryTest {

    @SuppressWarnings("SpringJavaInjectionPointsAutowiringInspection")
    @Autowired
    private AuthorRepository authorRepository;

    @Test
    public void testSaveAndFindAllAuthors() {
        // Given
        Author author = new Author();
        author.setName("John");
        author.setSurname("Doe");
        authorRepository.save(author);

        // When
        List<Author> authors = authorRepository.findAll();

        // Then
        assertThat(authors).hasSize(1);
        assertThat(authors.get(0).getName()).isEqualTo("John");
    }
}
