package com.example.bookstore.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;

@Entity
public class Owner {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;
    private String street;

    @OneToOne(mappedBy = "owner", cascade = CascadeType.ALL)
    @JsonIgnoreProperties("owner") // Уникає рекурсії
    private Car car;

    // Конструктори, геттери, і сеттери
    public Owner() {}

    public Owner(String name, String street) {
        this.name = name;
        this.street = street;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getStreet() {
        return street;
    }

    public void setStreet(String street) {
        this.street = street;
    }

    public Car getCar() {
        return car;
    }

    public void setCar(Car car) {
        this.car = car;
        if (car != null) {
            car.setOwner(this);
        }
    }
}