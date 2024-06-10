<script setup>
import { onMounted } from 'vue'
import ProductListing from '../components/Product/ProductListing.vue'
import ProductListSkeleton from '../components/Product/ProductListSkeleton.vue'

import { useProductsStore } from '../stores/products'
import { storeToRefs } from 'pinia'
import { watch } from 'vue'

const productStore = useProductsStore()
const { totalCount, products, currentPage, pageSize, loadingProducts } = storeToRefs(productStore)
const { fetchProducts } = productStore

onMounted(() => {
  if (products.value.length == 0) fetchProducts(currentPage.value)
})

watch(currentPage, async (newPage) => {
  fetchProducts(newPage)
})
</script>
<template class="product-listings">
  <ProductListSkeleton v-if="loadingProducts" />
  <v-container class="product-container">
    <v-row
      class="product-listings"
      align="start"
      v-if="!loadingProducts && products && products.length > 0"
    >
      <v-col v-for="product in products" :key="product.productModelId" class="ma-2 pa-2">
        <ProductListing :product="product" />
      </v-col>
    </v-row>
    <v-row>
      <div class="text-center">
        <v-pagination
          v-model="currentPage"
          :length="Math.ceil(totalCount / pageSize)"
          :total-visible="10"
        ></v-pagination>
      </div>
    </v-row>
  </v-container>
</template>
<style>
.product-listings {
  background-color: #eceff7 !important;
  margin-top: 50px !important;
}
</style>
