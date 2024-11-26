<?php
ini_set('display_errors', 1);
error_reporting(E_ALL);

header('Content-Type: application/json');

include('../db.php');

// Читання вхідних даних
$data = json_decode(file_get_contents('php://input'), true);

// Перевірка, чи є всі необхідні дані
if (isset($data['firstName'], $data['lastName'], $data['studentNumber'], $data['email'])) {
    try {
        // Підготовка запиту до бази даних для додавання студента
        $stmt = $pdo->prepare("INSERT INTO Students (first_name, last_name, student_number, email) 
                               VALUES (:first_name, :last_name, :student_number, :email)");

        // Виконання запиту
        $stmt->execute([
            ':first_name' => $data['firstName'],
            ':last_name' => $data['lastName'],
            ':student_number' => $data['studentNumber'],
            ':email' => $data['email']
        ]);

        // Повернення відповіді у форматі JSON
        echo json_encode(['message' => 'Student added successfully']);
    } catch (PDOException $e) {
        // Обробка помилок під час виконання запиту до бази даних
        echo json_encode(['error' => 'Unable to add student: ' . $e->getMessage()]);
    }
} else {
    // Якщо дані неповні, повернути помилку
    echo json_encode(['error' => 'Missing data']);
}
error_log("Received data: " . print_r($data, true));

if (isset($data['firstName'], $data['lastName'], $data['studentNumber'], $data['email'])) {
    // Ваш код для додавання студента
} else {
    error_log("Missing data fields");
    echo json_encode(['error' => 'Missing data']);
}
?>