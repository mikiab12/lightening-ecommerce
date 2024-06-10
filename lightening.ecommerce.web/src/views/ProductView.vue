<script setup>
import { onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useProductsStore } from '../stores/products'
import { storeToRefs } from 'pinia'

import ProductDetailTable from '../components/Product/ProductDetailTable.vue'

const route = useRoute()
const { id: productModelId } = route.params

const productStore = useProductsStore()
const { product, loadingProductDetail, currentProduct } = storeToRefs(productStore)
const { fetchProduct } = productStore

const baseUrl = import.meta.env.VITE_API_ENDPOINT

onMounted(async () => {
  await fetchProduct(productModelId)
})
</script>

<template class="product-details">
  <v-container class="product-details-container" v-if="!loadingProductDetail && product">
    <v-row class="product-details">
      <v-col cols="6">
        <v-card variant="elevated" height="550">
          <div>
            <v-img
              :src="`${baseUrl}api/v1/products/largePhoto/${currentProduct.productProductPhotos[0].productPhotoId}`"
              max-height="500"
            ></v-img>
            <v-card-title> {{ product.name }} </v-card-title>
            <v-card-subtitle>{{
              product.productModelProductDescriptionCultures[0].productDescription.description
            }}</v-card-subtitle>
          </div>
        </v-card>
      </v-col>
      <v-col cols="6">
        <v-select
          v-model="currentProduct"
          :items="product.products"
          item-title="name"
          item-value="productId"
          label="Select"
          persistent-hint
          return-object
          single-line
        ></v-select>
        <v-row>
          <ProductDetailTable :product="currentProduct" />
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<style>
.product-details {
  background-color: #eceff7 !important;
  margin-top: 50px !important;
  height: 100%;
}
</style>
