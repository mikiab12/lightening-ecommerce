<script setup>
import { onMounted, watch, computed } from 'vue'
import { useRoute } from 'vue-router'
import { storeToRefs } from 'pinia'

import ProductListing from '../components/Product/ProductListing.vue'
import ProductListSkeleton from '../components/Product/ProductListSkeleton.vue'

import { useProductsStore } from '../stores/products'

const productStore = useProductsStore()
const { totalCount, products, currentPage, pageSize, loadingProducts } = storeToRefs(productStore)
const { fetchProducts } = productStore

const startItem = computed(() => {
  return (currentPage.value - 1) * pageSize.value + 1
})

const endItem = computed(() => {
  return Math.min(currentPage.value * pageSize.value, totalCount.value)
})

const route = useRoute()

onMounted(() => {
  const { categoryId, subcategoryId } = route.params
  fetchProducts(currentPage.value, categoryId, subcategoryId)
})

watch(currentPage, async (newPage) => {
  const { categoryId, subcategoryId } = route.params
  fetchProducts(newPage, categoryId, subcategoryId)
})

watch(route, async (newRoute) => {
  const { categoryId, subcategoryId } = newRoute.params
  fetchProducts(1, categoryId, subcategoryId)
})
</script>
<template class="product-listings">
  <ProductListSkeleton v-if="loadingProducts" />
  <v-container class="product-container product-listings">
    <v-row justify="center">
      <span>{{ startItem }} to {{ endItem }} of {{ totalCount }} Items</span>
    </v-row>
    <v-row
      class="product-listings"
      align="start"
      v-if="!loadingProducts && products && products.length > 0"
    >
      <v-col v-for="product in products" :key="product.productModelId" class="ma-2 pa-2">
        <ProductListing :product="product" />
      </v-col>
    </v-row>
    <v-row justify="center">
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
}
</style>
