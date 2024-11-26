document.addEventListener('DOMContentLoaded', () => {
    const tripsContainer = document.getElementById('trips-container');
    const bookingModal = document.getElementById('booking-modal');
    const bookingForm = document.getElementById('booking-form');
    const closeModal = document.querySelector('.close');
    let trips = [];
    let bookings = [];

    // Load trips from JSON
    async function loadTrips() {
        try {
            const response = await fetch('trips.json');
            trips = await response.json();
            displayTrips();
        } catch (error) {
            tripsContainer.innerHTML = '<p>Niebawem będziemy podróżować!</p>';
            console.error('Błąd ładowania wycieczek:', error);
        }
    }

    function loadBookings() {
        const storedBookings = localStorage.getItem('bookings');
        bookings = storedBookings ? JSON.parse(storedBookings) : [];
        console.log('Załadowane rezerwacje:', bookings);
    }

    function saveBookings() {
        try {
            localStorage.setItem('bookings', JSON.stringify(bookings));
            console.log('Rezerwacje zapisane:', bookings);
        } catch (error) {
            console.error('Błąd zapisu rezerwacji:', error);
            alert('Nie udało się zapisać rezerwacji');
        }
    }

    function displayTrips() {
        if (trips.length === 0) {
            tripsContainer.innerHTML = '<p>Niebawem będziemy podróżować!</p>';
            return;
        }

        tripsContainer.innerHTML = trips.map(trip => `
            <div class="trip-card">
                <h3>${trip.name}</h3>
                <p>Z: ${trip.from}</p>
                <p>Do: ${trip.to}</p>
                <p>Czas: ${trip.hours} godz.</p>
                <p>Opis: ${trip.description}</p>
                <p>Cena: ${trip.price} PLN</p>
                <button onclick="openBookingModal('${trip.name}')">Zarezerwuj</button>
            </div>
        `).join('');
    }

    window.openBookingModal = (tripName) => {
        window.selectedTrip = tripName;
        bookingModal.style.display = 'block';
    }

    closeModal.onclick = () => {
        bookingModal.style.display = 'none';
    }

    bookingForm.onsubmit = (e) => {
        e.preventDefault();
        
        // Перевірка заповнення всіх полів
        const firstName = e.target[0].value.trim();
        const lastName = e.target[1].value.trim();
        const phone = e.target[2].value.trim();

        if (!firstName || !lastName || !phone) {
            alert('Proszę wypełnić wszystkie pola!');
            return;
        }

        const formData = {
            id: Date.now(), 
            trip: window.selectedTrip,
            firstName: firstName,
            lastName: lastName,
            phone: phone
        };

        // Додаємо нове бронювання
        bookings.push(formData);

        // Зберігаємо бронювання
        saveBookings();
        
        alert('Rezerwacja została przyjęta!');
        bookingModal.style.display = 'none';
        e.target.reset();

        // Додаткова перевірка
        console.log('Aktualne rezerwacje:', JSON.parse(localStorage.getItem('bookings')));
    }

    // Завантаження даних при старті
    loadTrips();
    loadBookings();
});