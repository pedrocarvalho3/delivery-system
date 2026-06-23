import { Navigate, Route, Routes } from 'react-router-dom';
import AdminLoginPage from './features/admin/pages/AdminLoginPage.tsx';
import LandingPage from './features/public/pages/LandingPage.tsx';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<LandingPage />} />
      <Route path="/admin/login" element={<AdminLoginPage />} />
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  );
}
