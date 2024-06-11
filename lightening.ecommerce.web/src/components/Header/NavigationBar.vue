<script setup>
import { useWeatherStore } from '@/stores/weather'
import { useProductsStore } from '@/stores/products'
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'

const weatherStore = useWeatherStore()
const productStore = useProductsStore()

const { weather } = storeToRefs(weatherStore)
const { categories } = storeToRefs(productStore)

const { fetchWeatherData } = weatherStore
const { fetchCategories } = productStore

onMounted(() => {
  fetchWeatherData()
  fetchCategories()
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
  <v-container fluid>
    <v-row class="categories-row" justify="center">
      <v-col cols="auto" class="category-col">
        <RouterLink class="category-link" :to="`/`">
          <span>All Items</span>
        </RouterLink>
      </v-col>
      <v-col
        v-for="category in categories"
        :key="category.productCategoryId"
        cols="auto"
        class="category-col"
      >
        <v-menu open-on-hover>
          <template v-slot:activator="{ props }">
            <RouterLink class="category-link" :to="`/category/${category.productCategoryId}`">
              <span color="primary" v-bind="props" class="category-name">
                {{ category.name }}
              </span></RouterLink
            >
          </template>
          <v-list>
            <v-list-item key="all-link"> </v-list-item>
            <v-list-item
              v-for="subcategory in category.productSubcategories"
              :key="subcategory.productSubcategoryId"
            >
              <RouterLink
                class="category-link"
                :to="`/category/${category.productCategoryId}/${subcategory.productSubcategoryId}`"
              >
                <v-list-item-title>{{ subcategory.name }}</v-list-item-title>
              </RouterLink>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.weather_info {
  font-size: 13px;
}
.header-title {
  text-decoration: none;
}
.categories-row {
  background-color: #f5f5f5;
  margin-top: 40px;
  margin-bottom: -20px !important;
  cursor: pointer;
}
.category-name {
  font-size: 15px;
  font-weight: 400;
  color: 'primary';
}
.category-link {
  text-decoration: none;
  color: black;
}
</style>
