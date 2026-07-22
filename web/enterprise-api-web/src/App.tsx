import { useEffect, useState } from 'react'
import type { Product } from './types/Product'
import { getProductById, getProducts } from './api/productsApi'

function App() {
  const [products, setProducts] = useState<Product[]>([])
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null)

  const [loading, setLoading] = useState(true)
  const [detailsLoading, setDetailsLoading] = useState(false)

  const [error, setError] = useState<string | null>(null)
  const [detailsError, setDetailsError] = useState<string | null>(null)

  useEffect(() => {
    async function loadProducts() {
      try {
        setError(null)

        const data = await getProducts()

        setProducts(data)
      } catch (err) {
        setError(
          err instanceof Error
            ? err.message
            : 'An unexpected error occurred while loading products.'
        )
      } finally {
        setLoading(false)
      }
    }

    void loadProducts()
  }, [])

  async function handleProductClick(id: number) {
    try {
      setDetailsLoading(true)
      setDetailsError(null)

      const product = await getProductById(id)

      setSelectedProduct(product)
    } catch (err) {
      setSelectedProduct(null)

      setDetailsError(
        err instanceof Error
          ? err.message
          : 'An unexpected error occurred while loading product details.'
      )
    } finally {
      setDetailsLoading(false)
    }
  }

  return (
    <main style={{ padding: '2rem', fontFamily: 'Arial, sans-serif' }}>
      <h1>Enterprise API Demo</h1>

      <p>
        React frontend connected to a .NET 10 Clean Architecture backend.
      </p>

      <h2>Products</h2>

      {loading && <p>Loading products...</p>}

      {error && (
        <div>
          <h3>Unable to load products</h3>
          <p>{error}</p>
        </div>
      )}

      {!loading && !error && (
        <>
          <p>Products loaded: {products.length}</p>

          <ul>
            {products.map((product) => (
              <li key={product.id}>
                <button
                  type="button"
                  onClick={() => void handleProductClick(product.id)}
                  style={{
                    background: 'none',
                    border: 'none',
                    padding: 0,
                    cursor: 'pointer',
                    textDecoration: 'underline',
                    font: 'inherit',
                  }}
                >
                  {product.name}
                </button>

                {' — $'}
                {product.price}

                {' — '}
                {product.category}
              </li>
            ))}
          </ul>
        </>
      )}

      <hr />

      <section>
        <h2>Product Details</h2>

        {detailsLoading && <p>Loading product details...</p>}

        {detailsError && (
          <div>
            <h3>Unable to load product details</h3>
            <p>{detailsError}</p>
          </div>
        )}

        {!detailsLoading && !detailsError && selectedProduct && (
          <div>
            <p>
              <strong>ID:</strong> {selectedProduct.id}
            </p>

            <p>
              <strong>Name:</strong> {selectedProduct.name}
            </p>

            <p>
              <strong>Description:</strong> {selectedProduct.description}
            </p>

            <p>
              <strong>Price:</strong> ${selectedProduct.price}
            </p>

            <p>
              <strong>Category:</strong> {selectedProduct.category}
            </p>

            <p>
              <strong>Created:</strong>{' '}
              {new Date(selectedProduct.createdUtc).toLocaleString()}
            </p>
          </div>
        )}

        {!detailsLoading && !detailsError && !selectedProduct && (
          <p>Select a product to view details.</p>
        )}
      </section>
    </main>
  )
}

export default App