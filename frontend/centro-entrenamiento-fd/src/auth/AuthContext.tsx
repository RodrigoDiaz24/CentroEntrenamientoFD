import { createContext, useState, useEffect } from "react";
import type { ReactNode } from "react";
import axiosClient from "../api/axiosClient";

interface AuthContextType {
  user: { token: string } | null;
  login: (email: string, password: string) => Promise<void>;
  logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<{ token: string } | null>(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) setUser({ token });
  }, []);

  const login = async (email: string, password: string) => {
    const res = await axiosClient.post("/auth/login", { email, password });
    localStorage.setItem("token", res.data.token);
    const { token } = res.data;

    localStorage.setItem("token", token);
    setUser({ token });
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
