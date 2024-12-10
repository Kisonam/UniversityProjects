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

// Ładowanie autorów i dodawanie przycisków edycji/usuwania
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
                authorBlock.dataset.id = author.id;

                // Informacje o autorze
                const authorInfo = document.createElement("span");
                authorInfo.textContent = `${author.name} ${author.surname}`;
                authorInfo.onclick = () => loadBooks(author);

                // Przycisk edycji
                const editButton = document.createElement("button");
                editButton.textContent = "Edytuj autora";
                editButton.onclick = () => showEditAuthorForm(author);

                // Przycisk usuwania
                const deleteButton = document.createElement("button");
                deleteButton.textContent = "Usuń autora";
                deleteButton.onclick = () => deleteAuthor(author.id);

                authorBlock.appendChild(authorInfo);
                authorBlock.appendChild(editButton);
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

// Ładowanie książek z przyciskami edycji/usuwania
function loadBooks(author) {
    try {
        const bookList = document.getElementById("bookList");
        bookList.innerHTML = ""; // Czyszczenie listy książek

        if (author.books && Array.isArray(author.books) && author.books.length > 0) {
            author.books.forEach(book => {
                const bookBlock = document.createElement("div");
                bookBlock.classList.add("book-block");
                bookBlock.dataset.id = book.id;

                // Informacje o książce
                const bookInfo = document.createElement("div");
                bookInfo.innerHTML = `<strong>${book.title}</strong><br>Gatunek: ${book.genre}<br>Rok: ${book.publicationYear}`;

                // Przycisk edycji
                const editButton = document.createElement("button");
                editButton.textContent = "Edytuj książkę";
                editButton.onclick = () => showEditBookForm(book, author.id);

                // Przycisk usuwania
                const deleteButton = document.createElement("button");
                deleteButton.textContent = "Usuń książkę";
                deleteButton.onclick = () => deleteBook(book.id);

                bookBlock.appendChild(bookInfo);
                bookBlock.appendChild(editButton);
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

// Formularz edycji autora
function showEditAuthorForm(author) {
    const authorBlock = document.querySelector(`.author-block[data-id="${author.id}"]`);
    const editForm = document.createElement("div");
    editForm.classList.add("edit-author-form");

    // Wstawienie formularza edycji
    editForm.innerHTML = `
        <input type="text" id="editAuthorName-${author.id}" value="${author.name}" placeholder="Imię">
        <input type="text" id="editAuthorSurname-${author.id}" value="${author.surname}" placeholder="Nazwisko">
        <button onclick="updateAuthor(${author.id})">Zapisz zmiany</button>
        <button onclick="cancelEdit(this)">Anuluj</button>
    `;

    authorBlock.appendChild(editForm);
}

// Aktualizacja autora
async function updateAuthor(authorId) {
    const name = document.getElementById(`editAuthorName-${authorId}`).value;
    const surname = document.getElementById(`editAuthorSurname-${authorId}`).value;

    try {
        const response = await fetch(`${apiUrl}/authors/${authorId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: authorId, name, surname }),
        });

        if (response.ok) {
            alert("Autor został pomyślnie zaktualizowany!");
            loadAuthorsAndBooks();
        } else {
            alert("Błąd podczas aktualizacji autora.");
        }
    } catch (error) {
        console.error("Błąd podczas aktualizacji autora", error);
    }
}

// Formularz edycji książki
function showEditBookForm(book, authorId) {
    const bookBlock = document.querySelector(`.book-block[data-id="${book.id}"]`);
    const editForm = document.createElement("div");
    editForm.classList.add("edit-book-form");

    // Wstawienie formularza edycji
    editForm.innerHTML = `
        <input type="text" id="editBookTitle-${book.id}" value="${book.title}" placeholder="Tytuł">
        <input type="text" id="editBookGenre-${book.id}" value="${book.genre}" placeholder="Gatunek">
        <input type="text" id="editBookYear-${book.id}" value="${book.publicationYear}" placeholder="Rok wydania">
        <button onclick="updateBook(${book.id}, ${authorId})">Zapisz zmiany</button>
        <button onclick="cancelEdit(this)">Anuluj</button>
    `;

    bookBlock.appendChild(editForm);
}

// Aktualizacja książki
async function updateBook(bookId, authorId) {
    const title = document.getElementById(`editBookTitle-${bookId}`).value;
    const genre = document.getElementById(`editBookGenre-${bookId}`).value;
    const publicationYear = document.getElementById(`editBookYear-${bookId}`).value;

    try {
        const response = await fetch(`${apiUrl}/books/${bookId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: bookId, title, genre, publicationYear, author: { id: authorId } }),
        });

        if (response.ok) {
            alert("Książka została pomyślnie zaktualizowana!");
            loadAuthorsAndBooks();
        } else {
            alert("Błąd podczas aktualizacji książki.");
        }
    } catch (error) {
        console.error("Błąd podczas aktualizacji książki", error);
    }
}

// Anulowanie edycji
function cancelEdit(button) {
    const editForm = button.parentElement;
    editForm.remove();
}

// Inicjalizacja
loadAuthors();
loadAuthorsAndBooks();
