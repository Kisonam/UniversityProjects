<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formularz dodawania studenta</title>
    <link rel="stylesheet" href="../CSS/style.css"> <!-- Підключення стилів -->
</head>
<body>
    <div class="container">
        <h1>Dodaj studenta</h1>
        <form id="studentForm">
            <input type="text" id="firstName" placeholder="Imię" required>
            <input type="text" id="lastName" placeholder="Nazwisko" required>
            <input type="text" id="studentNumber" placeholder="Numer studenta" required>
            <input type="email" id="email" placeholder="Email" required>
            <button type="button" onclick="saveData()">Zapisz</button> <!-- Кнопка для збереження -->
        </form>
    </div>
    <script src="../JavaScript/script.js"></script> <!-- Підключення JS -->
</body>
</html>