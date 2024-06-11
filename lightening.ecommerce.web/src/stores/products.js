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
    currentProduct: null,
    categories: []
  }),
  actions: {
    async fetchProducts(page, categoryId, subCategoryId) {
      this.loadingProducts = true
      const { data: result } = await productService.getProductsSummary(
        page,
        this.$state.pageSize,
        categoryId,
        subCategoryId
      )
      this.products = result.data
      this.totalCount = result.totalCount
      this.currentPage = result.currentPage
      this.pageSize = result.pageSize
      this.loadingProducts = false
    },
    async fetchProduct(id) {
      const { data: result } = await productService.getProductDetail(id)
      this.product = result
      this.loadingProductDetail = false
      this.currentProduct = result.products[0]
    },
    async fetchCategories() {
      const { data: result } = await productService.getProductCategories()
      this.categories = result
    }
  }
})
