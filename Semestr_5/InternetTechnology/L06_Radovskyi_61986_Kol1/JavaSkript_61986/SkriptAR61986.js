function registerClient_AR61986() {
    const clientName = document.getElementById('clientName_AR61986').value;
    document.getElementById('registeredClient_AR61986').innerText = `Zarejestrowany klient: ${clientName}`;
    document.getElementById('inputData_AR61986').style.display = 'none';
    document.getElementById('clientData_AR61986').style.display = 'block';
}

function editClient_AR61986() {
    document.getElementById('clientData_AR61986').style.display = 'none';
    document.getElementById('inputData_AR61986').style.display = 'block';
}

function playAudio_AR61986() {
    const audio = document.getElementById('audio_AR61986');
    audio.play();
}
function playAudioCarBroken_AR61986() {
    const audio = document.getElementById('audioBroken_AR61986');
    audio.play();
}

function startNewGame_AR61986() {
    const id = 61986; 
    const range = id % 10000; 
    const num1 = Math.floor(Math.random() * range) + 1;
    const num2 = Math.floor(Math.random() * range) + 1;

    if (id % 2 === 0) {
        
        document.getElementById('gameResult_AR61986').innerText = `Wylosowane liczby: ${num1} i ${num2}. Zgadnij mniejszą!`;
    } else {
        document.getElementById('gameResult_AR61986').innerText = `Wylosowane liczby: ${num1} i ${num2}. Zgadnij większą!`;
    }
}