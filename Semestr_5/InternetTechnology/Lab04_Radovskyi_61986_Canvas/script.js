const canvas = document.getElementById("myCanvas");
const ctx = canvas.getContext("2d");

function getRandomColor() {
    const letters = "0123456789ABCDEF";
    let color = "#";
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function drawRandomRectangles() {
    const rectSize = 50;
    const positions = [
        { x: 0, y: 0 },
        { x: canvas.width - rectSize, y: 0 },
        { x: 0, y: canvas.height - rectSize },
        { x: canvas.width - rectSize, y: canvas.height - rectSize }
    ];

    positions.forEach(pos => {
        ctx.fillStyle = getRandomColor();
        ctx.fillRect(pos.x, pos.y, rectSize, rectSize);
        drawTrianglesOnInnerEdges(pos.x, pos.y, rectSize);
    });

}

function drawPolyline() {
    ctx.strokeStyle = getRandomColor();
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(150, 200);
    ctx.lineTo(250, 100);
    ctx.lineTo(350, 200);
    ctx.lineTo(450, 100);
    ctx.stroke();

    ctx.strokeStyle = getRandomColor();
    ctx.beginPath();
    ctx.moveTo(150, 200 + 100);
    ctx.lineTo(250, 100 + 200);
    ctx.lineTo(350, 200 + 100);
    ctx.lineTo(450, 100 + 200);
    ctx.stroke();
}

function drawCircle() {
    const gradient = ctx.createRadialGradient(500, 300, 10, 500, 300, 50);
    gradient.addColorStop(0, "red");
    gradient.addColorStop(1, "white");

    ctx.fillStyle = gradient;
    ctx.beginPath();
    ctx.arc(500, 300, 50, 0, 2 * Math.PI);
    ctx.fill();
}

function drawText() {
    ctx.font = "20px Arial";
    ctx.fillStyle = "#000";
    ctx.fillText("ARTEM RADOVSKYI 61986", 180, 50);
}

function drawTrianglesOnInnerEdges(x, y, size) {
    const triangleHeight = 100;
    const halfBase = 20;

    ctx.fillStyle = getRandomColor();
    ctx.beginPath();

    if (x === 0 && y === 0) {
        ctx.moveTo(x, y);
        ctx.lineTo(x + halfBase, y - triangleHeight);
        ctx.lineTo(x + halfBase, y);
    } else if (x === canvas.width - size && y === 0) {
        ctx.moveTo(x + size, y);
        ctx.lineTo(x + size - halfBase, y - triangleHeight);
        ctx.lineTo(x + size - halfBase, y);
    } else if (x === 0 && y === canvas.height - size) {
        ctx.moveTo(x, y + size);
        ctx.lineTo(x + halfBase, y + size + triangleHeight);
        ctx.lineTo(x + halfBase, y + size);
    } else if (x === canvas.width - size && y === canvas.height - size) {
        ctx.moveTo(x + size, y + size);
        ctx.lineTo(x + size - halfBase, y + size + triangleHeight);
        ctx.lineTo(x + size - halfBase, y + size);
    }

    ctx.closePath();
    ctx.fill();
}

function drawAll() {
    drawRandomRectangles();
    drawPolyline();
    drawCircle();
    drawText();
}

window.onload = drawAll;

