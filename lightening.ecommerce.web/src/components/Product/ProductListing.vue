<script setup>
import { defineProps } from 'vue'
defineProps({
  product: {
    type: Object,
    required: true
  }
})
const baseUrl = import.meta.env.VITE_API_ENDPOINT
</script>
<template>
  <v-card width="240" height="370" variant="elevated" rounded="">
    <div>
      <v-img
        :src="`${baseUrl}api/v1/products/thumbnail/${product.productThumbnailId}`"
        height="150"
      ></v-img>
      <v-card-title> {{ product.name }} </v-card-title>
      <v-card-subtitle>${{ product.productListPrice }}</v-card-subtitle>
      <v-card-text class="product-description-text" v-if="product.description">
        {{ product.description.substring(0, 80) }}...
      </v-card-text>
    </div>

    <v-card-actions>
      <RouterLink class="product-link" :to="`/product/${product.productModelId}`"
        ><v-btn block variant="elevated" base-color="primary">View</v-btn></RouterLink
      >
    </v-card-actions>
  </v-card>
</template>
<style>
.v-card {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 100%;
}
.v-card-actions {
  margin-top: auto;
}
.product-link {
  width: 100%;
}
.product-description-text {
  font-size: 12px;
}
</style>
