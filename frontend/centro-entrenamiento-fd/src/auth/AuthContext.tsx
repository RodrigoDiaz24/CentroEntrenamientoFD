import { createContext, useState, useEffect } from "react";
import type { ReactNode } from "react";
import axiosClient from "../api/axiosClient";
import { jwtDecode } from "jwt-decode";

interface User {
  token: string
  email: string 
  role: string
}

interface AuthContextType {
  user: User | null;
  login: (email: string, password: string) => Promise<void>;
  logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {

  const [user, setUser] = useState<User | null>(null);

   useEffect(() => {

    const token = localStorage.getItem("token");

    if (token) {

      const decoded: any = jwtDecode(token);

      setUser({
        token,
        email: decoded.email,
        role: decoded.role
      });

    }
  }, []);


  const login = async (email: string, password: string) => {

    const res = await axiosClient.post("/auth/login", { email, password });

    const { token } = res.data;

    localStorage.setItem("token", token);

    if (token) {

      const decoded: any = jwtDecode(token);

      setUser({
        token,
        email: decoded.email,
        role: decoded.role
      });

    }
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