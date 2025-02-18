const leftImage = document.getElementById('leftImage');
const centerImage = document.getElementById('centerImage');
const rightImage = document.getElementById('rightImage');

const leftAudio = document.getElementById('leftAudio');
const centerAudio = document.getElementById('centerAudio');
const rightAudio = document.getElementById('rightAudio');

const images = [
    { src: '../Img_61986/kinopage2.jpg', audio: rightAudio },
    { src: '../Img_61986/main-photo.jpg', audio: leftAudio },
    { src: '../Img_61986/setpage1.jpg', audio: centerAudio }
];

let currentIndex = 1;

function updateGallery() {
    leftImage.querySelector('img').src = images[(currentIndex + 2) % 3].src;
    centerImage.querySelector('img').src = images[currentIndex % 3].src;
    rightImage.querySelector('img').src = images[(currentIndex + 1) % 3].src;
}

leftImage.addEventListener('click', () => {
    currentIndex = (currentIndex + 2) % 3;
    updateGallery();
    playAudio(images[currentIndex].audio);
});

rightImage.addEventListener('click', () => {
    currentIndex = (currentIndex + 1) % 3;
    updateGallery();
    playAudio(images[currentIndex].audio);
});

function playAudio(audio) {
    leftAudio.pause();
    leftAudio.currentTime = 0;
    centerAudio.pause();
    centerAudio.currentTime = 0;
    rightAudio.pause();
    rightAudio.currentTime = 0;

    // Play the selected audio
    audio.play();
}

document.querySelectorAll('.image-container61986').forEach(image => {
    image.addEventListener('click', () => {
        const clickedImage = image.querySelector('img').src;
        const audioToPlay = images.find(img => img.src === clickedImage).audio;
        playAudio(audioToPlay);
    });
});
