import axios from './api'

async function getProductsSummary(page, pageSize) {
  return await axios.get('/api/v1/products', {
    params: {
      page,
      pageSize
    }
  })
}

async function getProductDetail(productModelId) {
  return await axios.get(`/api/v1/products/${productModelId}`)
}

export default {
  getProductsSummary,
  getProductDetail
}
