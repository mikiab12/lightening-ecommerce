import axios from 'axios'

async function getWeatherData() {
  const baseUrl = import.meta.env.VITE_OPEN_WEATHER_MAP_API_KEY
  const location = 'Washington'
  const url = `https://api.openweathermap.org/data/2.5/weather?q=${location}&units=imperial&&appid=${baseUrl}`
  return await axios.get(url)
}

export default {
  getWeatherData
}
