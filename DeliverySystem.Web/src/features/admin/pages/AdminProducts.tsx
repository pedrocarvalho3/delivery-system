import { Link } from "react-router-dom";

export default function AdminProductsPage() {
  return (
    <main className="admin-page">
      <div className="admin-header">
        <h1>Admin Products</h1>

        <Link className="admin-back-link" to="/admin/dashboard">
          Admin
        </Link>
      </div>
    </main>
  );
}
