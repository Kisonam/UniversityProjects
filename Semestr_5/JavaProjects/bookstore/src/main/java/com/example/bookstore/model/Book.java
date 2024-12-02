package com.example.bookstore.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;

@Entity
public class Book {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String title;
    private String genre;
    private int publicationYear;

    @ManyToOne
    @JoinColumn(name = "author_id")
    @JsonBackReference  // Додаємо цю анотацію, щоб уникнути рекурсії
    private Author author;

    // Конструктори, геттери та сеттери

    public Book() {
    }

    public Book(String title, String genre, int publicationYear, Author author) {
        this.title = title;
        this.genre = genre;
        this.publicationYear = publicationYear;
        this.author = author;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public int getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(int publicationYear) {
        this.publicationYear = publicationYear;
    }

    public Author getAuthor() {
        return author;
    }

    public void setAuthor(Author author) {
        this.author = author;
    }
}
