const apiUrl = "http://localhost:8080"; // Twoje API

// Ładowanie autorów do rozwijanej listy
async function loadAuthors() {
    try {
        const response = await fetch(`${apiUrl}/authors`);
        const authors = await response.json();
        const select = document.getElementById("bookAuthor");

        // Czyszczenie listy
        select.innerHTML = "";

        authors.forEach(author => {
            const option = document.createElement("option");
            option.value = author.id;
            option.textContent = `${author.name} ${author.surname}`;
            select.appendChild(option);
        });
    } catch (error) {
        console.error("Błąd podczas ładowania autorów", error);
    }
}

// Dodawanie autora
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
        alert("Autor został pomyślnie dodany!");
        loadAuthors(); // Odświeżanie listy autorów
        loadAuthorsAndBooks(); // Odświeżanie autorów i książek
    } else {
        alert("Błąd podczas dodawania autora.");
    }

    document.getElementById("authorBookForm").reset();
}

// Dodawanie książki
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
        alert("Książka została pomyślnie dodana!");
        loadAuthorsAndBooks(); // Odświeżanie autorów i książek
    } else {
        alert("Błąd podczas dodawania książki.");
    }

    document.getElementById("bookForm").reset();
}

// Usuwanie autora
async function deleteAuthor(authorId) {
    const confirmed = confirm("Czy na pewno chcesz usunąć tego autora?");
    if (!confirmed) return;

    try {
        const response = await fetch(`${apiUrl}/authors/${authorId}`, {
            method: 'DELETE',
        });

        if (response.ok) {
            alert("Autor został pomyślnie usunięty!");
            loadAuthorsAndBooks(); // Odświeżanie listy autorów i książek
        } else {
            alert("Błąd podczas usuwania autora.");
        }
    } catch (error) {
        console.error("Błąd podczas usuwania autora", error);
    }
}

// Usuwanie książki
async function deleteBook(bookId) {
    const confirmed = confirm("Czy na pewno chcesz usunąć tę książkę?");
    if (!confirmed) return;

    try {
        const response = await fetch(`${apiUrl}/books/${bookId}`, {
            method: 'DELETE',
        });

        if (response.ok) {
            alert("Książka została pomyślnie usunięta!");
            loadAuthorsAndBooks(); // Odświeżanie listy autorów i książek
        } else {
            alert("Błąd podczas usuwania książki.");
        }
    } catch (error) {
        console.error("Błąd podczas usuwania książki", error);
    }
}

// Ładowanie autorów i dodawanie przycisków usuwania
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

                // Dodawanie informacji o autorze
                const authorInfo = document.createElement("span");
                authorInfo.textContent = `${author.name} ${author.surname}`;
                authorInfo.onclick = () => loadBooks(author);

                // Dodawanie przycisku usuwania
                const deleteButton = document.createElement("button");
                deleteButton.textContent = "Usuń autora";
                deleteButton.onclick = () => deleteAuthor(author.id);

                authorBlock.appendChild(authorInfo);
                authorBlock.appendChild(deleteButton);
                authorList.appendChild(authorBlock);
            });
        } else {
            console.error("Nieprawidłowe dane autorów", authors);
        }
    } catch (error) {
        console.error("Błąd podczas ładowania autorów", error);
    }
}

// Ładowanie książek i dodawanie przycisków usuwania
function loadBooks(author) {
    try {
        const bookList = document.getElementById("bookList");
        bookList.innerHTML = ""; // Czyszczenie listy książek

        // Jeśli autor ma książki
        if (author.books && Array.isArray(author.books) && author.books.length > 0) {
            author.books.forEach(book => {
                const bookBlock = document.createElement("div");
                bookBlock.classList.add("book-block");

                // Dodawanie informacji o książce
                const bookInfo = document.createElement("div");
                bookInfo.innerHTML = `<strong>${book.title}</strong><br>Gatunek: ${book.genre}<br>Rok: ${book.publicationYear}`;

                // Dodawanie przycisku usuwania
                const deleteButton = document.createElement("button");
                deleteButton.textContent = "Usuń książkę";
                deleteButton.onclick = () => deleteBook(book.id);

                bookBlock.appendChild(bookInfo);
                bookBlock.appendChild(deleteButton);
                bookList.appendChild(bookBlock);
            });
        } else {
            bookList.innerHTML = "<p>Brak książek dla tego autora.</p>";
        }
    } catch (error) {
        console.error("Błąd podczas ładowania książek", error);
    }
}

// Ładowanie danych przy załadowaniu strony
document.addEventListener("DOMContentLoaded", function() {
    loadAuthorsAndBooks(); // Ładowanie autorów i książek
    loadAuthors(); // Ładowanie autorów do rozwijanej listy
});
