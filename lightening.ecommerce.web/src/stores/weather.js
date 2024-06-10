import { defineStore } from 'pinia'
import weatherService from '@/services/weather.service'

export const useWeatherStore = defineStore('weather', {
  state: () => ({
    weather: null
  }),
  actions: {
    async fetchWeatherData() {
      const { data } = await weatherService.getWeatherData()
      this.weather = data
      console.log(data)
    }
  }
})
