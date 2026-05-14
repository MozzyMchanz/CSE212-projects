// Get current year and last modified date
document.getElementById('current-year').textContent = new Date().getFullYear();
document.getElementById('last-modified').textContent = document.lastModified;

// Wind chill calculation
function calculateWindChill(temp, windSpeed) {
    // Formula for Celsius
    return 13.12 + 0.6215 * temp - 11.37 * Math.pow(windSpeed, 0.16) + 0.3965 * temp * Math.pow(windSpeed, 0.16);
}

// Static values
const temperature = 25; // °C
const windSpeed = 5; // km/h

let windChill = 'N/A';
if (temperature <= 10 && windSpeed > 4.8) {
    windChill = calculateWindChill(temperature, windSpeed).toFixed(1) + '°C';
}

document.getElementById('wind-chill').textContent = windChill;