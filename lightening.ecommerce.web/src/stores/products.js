import { defineStore } from 'pinia'
import productService from '../services/products.service'

export const useProductsStore = defineStore('products', {
  state: () => ({
    products: [],
    pageSize: 30,
    totalCount: 0,
    currentPage: 1,
    loadingProducts: false,
    product: null,
    loadingProductDetail: true,
    currentProduct: null
  }),
  actions: {
    async fetchProducts(page) {
      this.loadingProducts = true
      const { data: result } = await productService.getProductsSummary(page, this.$state.pageSize)
      this.products = result.data
      this.totalCount = result.totalCount
      this.currentPage = result.currentPage
      this.pageSize = result.pageSize
      this.loadingProducts = false
    },
    async fetchProduct(id) {
      this.$state.loadingProductDetail = true
      const { data: result } = await productService.getProductDetail(id)
      this.product = result
      this.loadingProductDetail = false
      this.currentProduct = result.products[0]
    }
  }
})
