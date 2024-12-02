document.addEventListener("DOMContentLoaded", () => {
    const addAuthorForm = document.getElementById("add-author-form");
    const addBookForm = document.getElementById("add-book-form");
    const authorSelect = document.getElementById("author-id");
    const booksContainer = document.getElementById("books-container");

    // Załadowanie autorów do dropdown
    const loadAuthors = () => {
        fetch("/authors")
            .then(response => response.json())
            .then(authors => {
                // Wyczyść dropdown przed dodaniem nowych autorów
                authorSelect.innerHTML = "";
                authors.forEach(author => {
                    const option = document.createElement("option");
                    option.value = author.id;
                    option.textContent = `${author.name} ${author.surname}`;
                    authorSelect.appendChild(option);
                });
            })
            .catch(error => console.error("Błąd podczas pobierania autorów:", error));
    };

    // Załadowanie książek na stronie autorów
    const loadBooks = () => {
        fetch("/books")
            .then(response => {
                if (!response.ok) {
                    throw new Error("Błąd podczas pobierania książek: " + response.status);
                }
                return response.json();
            })
            .then(books => {
                // Pobranie autorów
                fetch("/authors")
                    .then(response => response.json())
                    .then(authors => {
                        const authorsMap = new Map(authors.map(author => [author.id, `${author.name} ${author.surname}`]));

                        books.forEach(book => {
                            const bookCard = document.createElement("div");
                            bookCard.className = "book-card";
                            bookCard.innerHTML = `
                                <div class="book-title">${book.title}</div>
                                <div class="book-author">
                                    Autor: ${authorsMap.get(book.author?.id) || "Nieznany"}
                                </div>
                                <div class="book-genre">Gatunek: ${book.genre}</div>
                                <div class="book-year">Rok publikacji: ${book.publicationYear}</div>
                            `;
                            booksContainer.appendChild(bookCard);
                        });
                    })
                    .catch(error => console.error("Błąd podczas pobierania autorów:", error));
            })
            .catch(error => console.error("Błąd podczas pobierania książek:", error));
    };

    // Załaduj książki i autorów po załadowaniu strony
    if (booksContainer) {
        loadBooks();
    }

    // Dodawanie nowego autora
    if (addAuthorForm) {
        addAuthorForm.addEventListener("submit", function (event) {
            event.preventDefault();
            const name = document.getElementById("author-name").value;
            const surname = document.getElementById("author-surname").value;

            // Sprawdzamy, czy autor już istnieje
            fetch("/authors")
                .then(response => response.json())
                .then(authors => {
                    const existingAuthor = authors.find(author => author.name === name && author.surname === surname);
                    if (existingAuthor) {
                        alert("Taki autor już istnieje!");
                    } else {
                        // Jeśli autora nie ma, dodajemy go
                        fetch("/authors", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify({ name, surname })
                        }).then(response => {
                            if (response.ok) {
                                alert("Autor dodany!");
                                // Wyczyść pola formularza
                                document.getElementById("author-name").value = '';
                                document.getElementById("author-surname").value = '';
                                loadAuthors();  // Przeładuj listę autorów w dropdown
                            } else {
                                alert("Błąd podczas dodawania autora!");
                            }
                        }).catch(error => {
                            alert("Wystąpił błąd!");
                            console.error("Błąd podczas dodawania autora:", error);
                        });
                    }
                })
                .catch(error => {
                    alert("Błąd podczas sprawdzania autorów!");
                    console.error("Błąd podczas sprawdzania autorów:", error);
                });
        });
    }

    // Dodawanie nowej książki
    if (addBookForm) {
        addBookForm.addEventListener("submit", function (event) {
            event.preventDefault();
            const title = document.getElementById("book-title").value;
            const genre = document.getElementById("book-genre").value;
            const publicationYear = document.getElementById("publication-year").value;
            const authorId = document.getElementById("author-id").value;

            fetch("/books", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ title, genre, publicationYear, author: { id: authorId } })
            }).then(response => {
                if (response.ok) {
                    alert("Książka dodana!");
                } else {
                    alert("Błąd podczas dodawania książki!");
                }
            }).catch(error => {
                alert("Wystąpił błąd!");
                console.error("Błąd podczas dodawania książki:", error);
            });
        });
    }

    // Pobieranie autorów i ich książek na stronie autorów
    if (window.location.pathname.includes("authors.html")) {
        fetch("/authors")
            .then(response => response.json())
            .then(authors => {
                authors.forEach(author => {
                    const authorDiv = document.createElement("div");
                    authorDiv.classList.add("author-card");

                    const authorName = document.createElement("h2");
                    authorName.textContent = `${author.name} ${author.surname}`;
                    authorDiv.appendChild(authorName);

                    if (author.books && author.books.length > 0) {
                        const booksList = document.createElement("ul");
                        author.books.forEach(book => {
                            const bookItem = document.createElement("li");
                            bookItem.textContent = `${book.title} (${book.genre}, ${book.publicationYear})`;
                            booksList.appendChild(bookItem);
                        });
                        authorDiv.appendChild(booksList);
                    } else {
                        const noBooksMessage = document.createElement("p");
                        noBooksMessage.textContent = "Ten autor nie ma książek.";
                        authorDiv.appendChild(noBooksMessage);
                    }

                    booksContainer.appendChild(authorDiv);
                });
            })
            .catch(error => console.error("Błąd podczas pobierania autorów:", error));
    }

    // Załaduj autorów do dropdown przy załadowaniu strony
    loadAuthors();
});
