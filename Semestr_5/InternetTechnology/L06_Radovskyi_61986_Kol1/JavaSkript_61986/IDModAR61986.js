const studentID_AR61986 = 61986;

function calculateIDmod80_AR61986(id) {
    return id % 80;
}

function calculateIDmod4_AR61986(id) {
    return (id % 3) + 1;
}

function updateValues_AR61986() {
    const idMod80_AR61986 = calculateIDmod80_AR61986(studentID_AR61986);
    const idMod4_AR61986 = calculateIDmod4_AR61986(studentID_AR61986);

    document.getElementById('idMod80_AR61986').textContent = idMod80_AR61986;
    document.getElementById('idMod4_AR61986').textContent = idMod4_AR61986;

    drawOnCanvas_AR61986(idMod80_AR61986, idMod4_AR61986);
}

function drawOnCanvas_AR61986(idMod80_AR61986, idMod4_AR61986) {
    const canvas_AR61986 = document.getElementById("canvas_AR61986");
    const context_AR61986 = canvas_AR61986.getContext("2d");

    const angle_AR61986 = Math.PI / 2 * idMod4_AR61986;  


    context_AR61986.clearRect(0, 0, canvas_AR61986.width, canvas_AR61986.height);

    // Сохранение состояния и настройка поворота
    context_AR61986.save();
    context_AR61986.translate(canvas_AR61986.width / 2, canvas_AR61986.height / 2);
    context_AR61986.rotate(angle_AR61986);
    context_AR61986.translate(-canvas_AR61986.width / 2, -canvas_AR61986.height / 2);

    // Отрисовка "VistulaRawShield" - Простой блок с квадратами
    context_AR61986.fillStyle = "lightgray";
    drawRawShield(context_AR61986);

    // Восстановление состояния после поворота
    context_AR61986.restore();

    // Создание градиента для "VistulaShield"
    let gradient_AR61986 = context_AR61986.createLinearGradient(0, 0, canvas_AR61986.width, canvas_AR61986.height);
    gradient_AR61986.addColorStop(0, "#00" + String(studentID_AR61986).slice(1, 3) + "00");  
    gradient_AR61986.addColorStop(1, "#0000" + String(studentID_AR61986).slice(-2));         

    context_AR61986.fillStyle = gradient_AR61986;
    drawShield(context_AR61986); 
}

document.addEventListener('DOMContentLoaded', updateValues_AR61986);

function drawRawShield(context) {
    context.fillRect(100, 50, 50, 50);
    context.fillRect(150, 50, 50, 50);
    context.fillRect(200, 50, 50, 50);
    context.fillRect(150, 100, 50, 50);
    context.fillRect(100, 150, 50, 50);
}
function drawShield(context) {
    context.beginPath();
    context.moveTo(100, 50);
    context.lineTo(150, 50);
    context.lineTo(150, 100);
    context.lineTo(200, 100);
    context.lineTo(200, 150);
    context.lineTo(100, 150);
    context.closePath();
    context.fill();
}
