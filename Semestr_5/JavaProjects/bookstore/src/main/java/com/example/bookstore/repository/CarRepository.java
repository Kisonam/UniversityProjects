package com.example.bookstore.repository;

import com.example.bookstore.model.Car;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CarRepository extends JpaRepository<Car, Long> {}