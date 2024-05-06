function playBeepSound() {
    const audio = document.getElementById("beepAudio");
    if (audio) {
        audio.play();
        stopped = false;
    }
}

function setBeepVolume(volume) {
    const audio = document.getElementById("beepAudio");
    if (audio) {
        audio.volume = volume;
        volumeSet = true;
    }
}

function stopBeepSound() {
    const audio = document.getElementById("beepAudio");
    if (audio) {
        audio.pause();
        audio.currentTime = 0;
        clearInterval(intervalId);
        intervalId = null;
        stopped = true;
    }
}

let stopped = false;
let intervalId;
let volumeSet = false;
function fadeBeepVolume(volume, durationInSeconds = 0) {
    const audio = document.getElementById("beepAudio");
    if (!audio || intervalId || stopped) return;

    const initialVolume = audio.volume;
    const targetVolume = volume;
    const volumeIncrement = (targetVolume - initialVolume) / (durationInSeconds * 1000 / 100);

    let currentVolume = initialVolume;

    volumeSet = false;

    intervalId = setInterval(() => {

        currentVolume += volumeIncrement;

        if (volumeSet == true) {
            clearInterval(intervalId);
            intervalId = null;
            return;
        }

        if ((volumeIncrement > 0 && currentVolume >= targetVolume) || (volumeIncrement < 0 && currentVolume <= targetVolume) || volumeIncrement == 0) {
            console.log("finished!")
            clearInterval(intervalId);
            currentVolume = targetVolume;
            intervalId = null;
            volumeSet = true;
        }
        
        audio.volume = currentVolume;
        console.log(intervalId, currentVolume);
    }, 100);
}

