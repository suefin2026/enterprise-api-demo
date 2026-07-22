import type { Product } from '../types/Product'

const API_BASE_URL = 'http://localhost:5032'

export async function getProducts(): Promise<Product[]> {
  const response = await fetch(`${API_BASE_URL}/api/products`)

  if (!response.ok) {
    throw new Error(
      `Failed to load products: ${response.status} ${response.statusText}`
    )
  }

  return response.json()
}

export async function getProductById(id: number): Promise<Product> {
  const response = await fetch(`${API_BASE_URL}/api/products/${id}`)

  if (!response.ok) {
    throw new Error(
      `Failed to load product ${id}: ${response.status} ${response.statusText}`
    )
  }

  return response.json()
}