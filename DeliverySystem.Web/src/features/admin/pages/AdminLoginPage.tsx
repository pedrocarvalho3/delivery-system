import { Link } from "react-router-dom";
import AdminLoginForm from "../components/AdminLoginForm.tsx";

export default function AdminLoginPage() {
  return (
    <main className="admin-page">
      <Link className="admin-back-link" to="/">
        Cia Oriental
      </Link>
      <AdminLoginForm />
    </main>
  );
}
