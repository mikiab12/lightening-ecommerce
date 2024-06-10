<script setup>
import { defineProps } from 'vue'
defineProps({
  product: {
    type: Object,
    required: true
  }
})
</script>
<template>
  <v-table>
    <thead>
      <tr></tr>
    </thead>
    <tbody>
      <tr>
        <td>Product Number</td>
        <td>{{ product.productNumber }}</td>
      </tr>
      <tr>
        <td>List Price</td>
        <td>${{ product.listPrice }}</td>
      </tr>
      <tr>
        <td>Standard Cost</td>
        <td>${{ product.standardCost }}</td>
      </tr>
      <tr>
        <td>Category</td>
        <td>{{ product.productSubcategory.name }}</td>
      </tr>
      <tr>
        <td>Color</td>
        <td>{{ product.color }}</td>
      </tr>
      <tr>
        <td>Size</td>
        <td>{{ product.size }} {{ product.sizeUnitMeasureCode }}</td>
      </tr>
      <tr>
        <td>Weight</td>
        <td>{{ product.weight }} {{ product.weightUnitMeasureCode }}</td>
      </tr>
      <tr>
        <td>Days To Manufacture</td>
        <td>{{ product.daysToManufacture }}</td>
      </tr>
      <tr>
        <td>Sale Start Date</td>
        <td>{{ product.sellStartDate }}</td>
      </tr>
      <tr>
        <td>Sale End Date</td>
        <td>{{ product.sellEndDate }}</td>
      </tr>
    </tbody>
  </v-table>
</template>
