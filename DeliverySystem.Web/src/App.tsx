import { Navigate, Route, Routes } from "react-router-dom";
import AdminLoginPage from "./features/admin/pages/AdminLoginPage.tsx";
import LandingPage from "./features/public/pages/LandingPage.tsx";
import AdminDashboardPage from "./features/admin/pages/AdminDashboard.tsx";
import ProtectedAdminRoute from "./features/admin/components/ProtectedAdminRoute.tsx";
import AdminProductsPage from "./features/admin/pages/AdminProducts.tsx";

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<LandingPage />} />
      <Route path="/admin/login" element={<AdminLoginPage />} />
      <Route element={<ProtectedAdminRoute />}>
        <Route path="/admin/dashboard" element={<AdminDashboardPage />} />
        <Route path="/admin/products" element={<AdminProductsPage />} />
      </Route>
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  );
}
