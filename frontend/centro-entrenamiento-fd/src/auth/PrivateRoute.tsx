import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "./useAuth";

function PrivateRoute() {

  const { user } = useAuth();

  if (!user) {
    return <Navigate to="/" />;
  }

  return <Outlet />;
}

export default PrivateRoute;