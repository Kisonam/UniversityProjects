<?php
$host = 'localhost'; // Хост бази даних
$db = 'StudentDB';   // Ваша база даних
$user = 'root';      // Користувач MySQL
$pass = '';          // Пароль (якщо є)

try {
    // Підключення до бази даних
    $pdo = new PDO("mysql:host=$host;dbname=$db", $user, $pass);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    // Обробка помилки підключення
    echo "Помилка підключення до бази даних: " . $e->getMessage();
}
?>