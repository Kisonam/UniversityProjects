<?php include('../db.php'); ?>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Podgląd Studentów</title>
    <link rel="stylesheet" href="../CSS/style.css">
</head>
<body>
    <div class="container">
        <h1>Lista studentów</h1>
        <table>
            <thead>
                <tr>
                    <th>Imię</th>
                    <th>Nazwisko</th>
                    <th>Numer Studenta</th>
                    <th>Email</th>
                    <th>Akcja</th>
                </tr>
            </thead>
            <tbody>
                <?php
                // Отримуємо список студентів з бази даних
                $stmt = $pdo->query('SELECT * FROM Students');
                while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
                    echo "<tr>";
                    echo "<td>" . htmlspecialchars($row['first_name']) . "</td>";
                    echo "<td>" . htmlspecialchars($row['last_name']) . "</td>";
                    echo "<td>" . htmlspecialchars($row['student_number']) . "</td>";
                    echo "<td>" . htmlspecialchars($row['email']) . "</td>";
                    echo "<td><a href='edit.php?id=" . $row['id'] . "'>Edytuj</a></td>";
                    echo "</tr>";
                }
                ?>
            </tbody>
        </table>
        <a href="index.php">Dodaj nowego studenta</a>
    </div>
</body>
</html>