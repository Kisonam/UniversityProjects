<?php
include('../db.php');

// Отримуємо ID студента з URL
$id = $_GET['id'];

// Отримуємо інформацію про студента з бази даних
$stmt = $pdo->prepare('SELECT * FROM Students WHERE id = ?');
$stmt->execute([$id]);
$student = $stmt->fetch(PDO::FETCH_ASSOC);

if (!$student) {
    die("Student not found");
}
?>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edytuj Studenta</title>
    <link rel="stylesheet" href="../CSS/style.css">
</head>
<body>
    <div class="container">
        <h1>Edytuj studenta</h1>
        <form id="studentForm">
            <input type="text" id="firstName" value="<?= htmlspecialchars($student['first_name']) ?>" placeholder="Imię" required>
            <input type="text" id="lastName" value="<?= htmlspecialchars($student['last_name']) ?>" placeholder="Nazwisko" required>
            <input type="text" id="studentNumber" value="<?= htmlspecialchars($student['student_number']) ?>" placeholder="Numer studenta" required>
            <input type="email" id="email" value="<?= htmlspecialchars($student['email']) ?>" placeholder="Email" required>
            <input type="hidden" id="studentId" value="<?= $student['id'] ?>">
            <button type="button" onclick="updateData()">Zapisz zmiany</button>
        </form>
    </div>

    <script src="../JavaScript/script.js"></script>
</body>
</html>