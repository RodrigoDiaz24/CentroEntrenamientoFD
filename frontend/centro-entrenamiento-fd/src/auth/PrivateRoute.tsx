import { useContext } from "react";
import type { ReactNode } from "react";
import { AuthContext } from "./AuthContext";
import { Navigate } from "react-router-dom";

export default function PrivateRoute({ children }: { children: ReactNode }) {
  const auth = useContext(AuthContext);
  return auth?.user ? <>{children}</> : <Navigate to="/" />;
}
