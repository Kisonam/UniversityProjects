<?php
include('../db.php');

// Читання вхідних даних
$data = json_decode(file_get_contents('php://input'), true);

// Перевірка, чи є необхідні дані
if (isset($data['id'], $data['firstName'], $data['lastName'], $data['studentNumber'], $data['email'])) {
    // Підготовка запиту для оновлення студента
    $stmt = $pdo->prepare("UPDATE Students 
                           SET first_name = :first_name, last_name = :last_name, student_number = :student_number, email = :email
                           WHERE id = :id");

    // Виконання запиту
    $stmt->execute([
        ':id' => $data['id'],
        ':first_name' => $data['firstName'],
        ':last_name' => $data['lastName'],
        ':student_number' => $data['studentNumber'],
        ':email' => $data['email']
    ]);

    echo json_encode(['message' => 'Student updated successfully']);
} else {
    echo json_encode(['error' => 'Missing data']);
}
?>