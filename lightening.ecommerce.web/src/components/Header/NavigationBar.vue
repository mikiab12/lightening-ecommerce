<script setup>
import { useWeatherStore } from '@/stores/weather'
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'

const weatherStore = useWeatherStore()
const { weather } = storeToRefs(weatherStore)

const { fetchWeatherData } = weatherStore
onMounted(() => {
  fetchWeatherData()
})
</script>
<template>
  <v-app-bar :elevation="2">
    <template v-slot:prepend>
      <v-app-bar-nav-icon></v-app-bar-nav-icon>
    </template>
    <v-app-bar-title
      ><RouterLink class="header-title" to="/">Lightening Ecommerce</RouterLink></v-app-bar-title
    >

    <div v-if="weather != null">
      <p>Today's Weather in {{ weather.name }}</p>
      <p class="weather_info">
        {{ weather.main.temp }} °F, Max:{{ weather.main.temp_max }} °F, Min:{{
          weather.main.temp_min
        }}
        °F,
      </p>
      <p class="weather_info" v-if="weather.weather && weather.weather.length > 0">
        {{ weather.weather[0].main }}, {{ weather.weather[0].description }}
      </p>
    </div>
  </v-app-bar>
</template>
<style>
.weather_info {
  font-size: 13px;
}
.header-title {
  text-decoration: none;
}
</style>
