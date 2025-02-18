
const inputDataSection61986 = document.getElementById('inputDataSection61986');
const clientDataSection61986 = document.getElementById('clientDataSection61986');
const clientInput61986 = document.getElementById('clientInput61986');
const registerClientBtn61986 = document.getElementById('registerClientBtn61986');
const editClientBtn61986 = document.getElementById('editClientBtn61986');
const clientOutput61986 = document.getElementById('clientOutput61986');
const nav61986 = clientDataSection61986.querySelector('nav');

registerClientBtn61986.addEventListener('click', () => {
    let clientData61986 = clientInput61986.value.trim();

    if (clientData61986 === '') {
        clientData61986 = 'Artem Radovskyi 61986';
    }

    clientOutput61986.textContent = clientData61986;

    inputDataSection61986.classList.add('hidden61986');
    clientDataSection61986.classList.remove('hidden61986');
    nav61986.style.display = 'block';
});

editClientBtn61986.addEventListener('click', () => {
    inputDataSection61986.classList.remove('hidden61986');
    clientDataSection61986.classList.add('hidden61986');
    nav61986.style.display = 'none';
    clientInput61986.focus();
});

