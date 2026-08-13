export function startCountdown(dotNetRef, seconds) {
    setTimeout(() => dotNetRef.invokeMethodAsync("CountDownFinished"), seconds * 1000);
}