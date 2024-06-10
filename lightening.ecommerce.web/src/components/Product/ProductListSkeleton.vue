<template>
  <v-container>
    <v-row>
      <v-col v-for="i in [1, 2, 3, 4, 5, 6]" v-bind:key="i">
        <v-skeleton-loader
          class="mx-auto border"
          width="400"
          type="card-avatar, actions"
        ></v-skeleton-loader>
      </v-col>
    </v-row>
  </v-container>
</template>
