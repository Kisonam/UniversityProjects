let score = 0;
let clickOrder = 1;
let numbers = [0, 0, 0];
let correctSequence = []; 
let currentSequence = [];
let gameInProgress = false; 

function generateNumbers() {
    let max = 557;
    numbers[0] = Math.floor(Math.random() * (max - 1)) + 1;
    numbers[1] = Math.floor(Math.random() * (max - 1)) + 1;
    numbers[2] = Math.floor(Math.random() * (max - 1)) + 1;
    numbers.sort((a, b) => b - a);
    correctSequence = [...numbers]; 
}

function updateButtons() {
    document.getElementById('num1').textContent = numbers[0];
    document.getElementById('num2').textContent = numbers[1];
    document.getElementById('num3').textContent = numbers[2];

    document.getElementById('num1').disabled = false;
    document.getElementById('num2').disabled = false;
    document.getElementById('num3').disabled = false;
}

function handleClick(num) {
    if (!gameInProgress) return; 

    const button = document.getElementById(`num${num}`);
    button.disabled = true;
    currentSequence.push(numbers[num - 1]);

    if (currentSequence.length === 3) {
        if (currentSequence.every((val, index) => val === correctSequence[index])) {
            score = 3; 
        } else {
            score = 0; 
        }
        setTimeout(showWinMessage, 10);
    }

    document.getElementById('score').textContent = score;
}

function showWinMessage() {
    if (score === 3) {
        alert('Gratulacje! Pan(i) wygrał(a)');
    } else {
        alert('Niestete! Pan(i) przegrał(a)');
    }
    startNewGame();
}

function startNewGame() {
    gameInProgress = true; 
    score = 0;
    clickOrder = 1;
    currentSequence = [];
    generateNumbers();
    updateButtons();
    document.getElementById('score').textContent = score;
}

document.getElementById('num1').addEventListener('click', () => handleClick(1));
document.getElementById('num2').addEventListener('click', () => handleClick(2));
document.getElementById('num3').addEventListener('click', () => handleClick(3));
document.getElementById('newGameButton').addEventListener('click', startNewGame);

startNewGame();
