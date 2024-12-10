package com.example.bookstore.controller;

import com.example.bookstore.model.Car;
import com.example.bookstore.model.Owner;
import com.example.bookstore.service.CarService;
import com.example.bookstore.service.OwnerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/cars")
public class CarController {

    @Autowired
    private CarService carService;

    @Autowired
    private OwnerService ownerService;

    // Отримання всіх машин
    @GetMapping
    public Iterable<Car> getAllCars() {
        return carService.getAllCars();
    }

    // Отримання машини за її id разом з даними про власника
    @GetMapping("/{id}")
    public ResponseEntity<Car> getCarById(@PathVariable Long id) {
        Optional<Car> car = carService.getCarById(id);
        return car.map(ResponseEntity::ok)
                .orElse(ResponseEntity.status(HttpStatus.NOT_FOUND).build());
    }

    // Створення нової машини
    @PostMapping
    public ResponseEntity<?> createCar(@RequestBody Car car) {
        // Перевірка валідності даних машини
        if (car.getModel() == null || car.getModel().isBlank()) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Invalid car details!");
        }

        // Перевірка наявності власника
        if (car.getOwner() == null || car.getOwner().getId() == null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Owner is required!");
        }

        // Перевірка, чи існує власник
        Optional<Owner> ownerOptional = ownerService.getOwnerById(car.getOwner().getId());
        if (ownerOptional.isEmpty()) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body("Owner not found!");
        }

        // Прив'язка власника до машини
        car.setOwner(ownerOptional.get());
        Car savedCar = carService.saveCar(car);
        return ResponseEntity.status(HttpStatus.CREATED).body(savedCar);
    }

    // Видалення машини за її id
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteCar(@PathVariable Long id) {
        carService.deleteCar(id);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }
}