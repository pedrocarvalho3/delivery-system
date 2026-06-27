import { Navigate, Outlet, useLocation } from "react-router-dom";
import { isAccessTokenValid, removeAccessToken } from "../../../services/authToken.ts";

export default function ProtectedAdminRoute() {
  const location = useLocation();

  if (!isAccessTokenValid()) {
    removeAccessToken();

    return (
      <Navigate
        to="/admin/login"
        replace
        state={{ from: location.pathname }}
      />
    );
  }

  return <Outlet />;
}
