// Функція для збереження даних студента
function saveData() {
    const studentData = {
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        studentNumber: document.getElementById('studentNumber').value,
        email: document.getElementById('email').value
    };

    fetch('../PHP/saveStudent.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(studentData)
    })
    .then(response => {
        console.log('Response:', response);  // Логування відповіді від сервера

        // Перевірка на помилку HTTP перед парсингом
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        // Перевіряємо, чи відповідь є HTML
        return response.text().then(text => {
            try {
                return JSON.parse(text);
            } catch (e) {
                throw new Error('Невірний формат відповіді: ' + e.message);
            }
        });
    })
    .then(data => {
        console.log('Data:', data); // Логування даних, що надійшли з сервера

        if (data.message) {
            alert(data.message);
            window.location.href = 'view.php';  // Перехід на сторінку перегляду після успішного збереження
        } else {
            alert('Помилка: ' + (data.error || 'Не вдалося зберегти студента'));
        }
    })
    .catch(error => {
        console.error('Error:', error); // Логування помилки
        alert('Виникла помилка при збереженні даних. Перевірте консоль для деталей.');
    });
}

// Функція для оновлення даних студента
function updateData() {
    const studentData = {
        id: document.getElementById('studentId').value,
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        studentNumber: document.getElementById('studentNumber').value,
        email: document.getElementById('email').value
    };

    fetch('../PHP/updateStudent.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(studentData)
    })
    .then(response => {
        // Логування відповіді для діагностики
        console.log('Response:', response);

        // Перевірка на помилку HTTP перед парсингом
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        // Перетворення відповіді в JSON
        return response.json();
    })
    .then(data => {
        // Логування отриманих даних для діагностики
        console.log('Data:', data);

        if (data.message) {
            alert(data.message);
            window.location.href = 'view.php';  // Перехід на сторінку перегляду після успішного оновлення
        } else {
            alert('Помилка: ' + (data.error || 'Не вдалося оновити студента'));
        }
    })
    .catch(error => {
        // Логування помилки
        console.error('Error:', error);
        alert('Виникла помилка при оновленні даних. Перевірте консоль для деталей.');
    });
}