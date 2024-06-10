<script setup>
import { RouterView } from 'vue-router'
import NavigationBar from './components/Header/NavigationBar.vue'
</script>

<template>
  <v-app>
    <NavigationBar />
    <RouterView />
  </v-app>
</template>

<style>
.v-container {
  width: 100% !important;
  max-width: 100% !important;
}
</style>
