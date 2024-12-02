const apiUrl = "http://localhost:8080";  // Ваше API

// Завантаження авторів для дропдауну
async function loadAuthors() {
    try {
        const response = await fetch(`${apiUrl}/authors`);
        const authors = await response.json();
        const select = document.getElementById("bookAuthor");

        // Очищення списку
        select.innerHTML = "";

        authors.forEach(author => {
            const option = document.createElement("option");
            option.value = author.id;
            option.textContent = `${author.name} ${author.surname}`;
            select.appendChild(option);
        });
    } catch (error) {
        console.error("Błąd przy ładowaniu autorów", error);
    }
}

// Додавання автора
async function addAuthor() {
    const name = document.getElementById("authorName").value;
    const surname = document.getElementById("authorSurname").value;

    const response = await fetch(`${apiUrl}/authors`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name, surname })
    });

    if (response.ok) {
        alert("Autor został dodany!");
        loadAuthors();  // Оновлюємо список авторів
    } else {
        alert("Błąd podczas dodawania autora.");
    }

    document.getElementById("authorBookForm").reset();
}

// Додавання книги
async function addBook() {
    const title = document.getElementById("bookTitle").value;
    const genre = document.getElementById("bookGenre").value;
    const publicationYear = document.getElementById("bookYear").value;
    const authorId = document.getElementById("bookAuthor").value;

    const response = await fetch(`${apiUrl}/books`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            title,
            genre,
            publicationYear,
            author: { id: authorId }
        })
    });

    if (response.ok) {
        alert("Książka została dodana!");
    } else {
        alert("Błąd podczas dodawania książki.");
    }

    document.getElementById("bookForm").reset();
}

// Завантаження авторів та книг для відображення
async function loadAuthorsAndBooks() {
    try {
        const authorsResponse = await fetch(`${apiUrl}/authors`);
        const authors = await authorsResponse.json();
        const authorList = document.getElementById("authorList");

        if (authors && Array.isArray(authors)) {
            authorList.innerHTML = "";

            authors.forEach(author => {
                const authorBlock = document.createElement("div");
                authorBlock.classList.add("author-block");
                authorBlock.textContent = `${author.name} ${author.surname}`;
                authorBlock.onclick = () => loadBooks(author);  // Завантаження книг для конкретного автора
                authorList.appendChild(authorBlock);
            });
        } else {
            console.error("Nie poprawne dane autorów", authors);
        }
    } catch (error) {
        console.error("Błąd przy ładowaniu autorów", error);
    }
}

// Завантаження книг для обраного автора
function loadBooks(author) {
    try {
        const bookList = document.getElementById("bookList");
        bookList.innerHTML = "";  // Очищення списку книг

        // Якщо у автора є книги
        if (author.books && Array.isArray(author.books) && author.books.length > 0) {
            author.books.forEach(book => {
                const bookBlock = document.createElement("div");
                bookBlock.classList.add("book-block");
                bookBlock.innerHTML = `<strong>${book.title}</strong><br>Gatunek: ${book.genre}<br>Rok: ${book.publicationYear}`;
                bookList.appendChild(bookBlock);
            });
        } else {
            bookList.innerHTML = "<p>Brak książek dla tego autora.</p>";
        }
    } catch (error) {
        console.error("Błąd przy ładowaniu książek", error);
    }
}

// Завантаження даних при завантаженні сторінки
document.addEventListener("DOMContentLoaded", function() {
    loadAuthorsAndBooks();  // Завантаження авторів та книг
    loadAuthors(); // Завантаження авторів для дропдауну
});
