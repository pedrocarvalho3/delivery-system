import { Link } from "react-router-dom";

export default function PublicHeader() {
  return (
    <header className="public-header">
      <Link className="brand" to="/">
        Cia Oriental
      </Link>
      <Link className="admin-link" to="/admin/login">
        Admin
      </Link>
    </header>
  );
}
