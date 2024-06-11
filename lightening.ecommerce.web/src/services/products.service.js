import axios from './api'

async function getProductsSummary(page, pageSize, categoryId, subCategoryId) {
  return await axios.get('/api/v1/products', {
    params: {
      page,
      pageSize,
      categoryId,
      subCategoryId
    }
  })
}

async function getProductDetail(productModelId) {
  return await axios.get(`/api/v1/products/${productModelId}`)
}

async function getProductCategories() {
  return await axios.get(`/api/v1/products/categories`)
}

export default {
  getProductsSummary,
  getProductDetail,
  getProductCategories
}
