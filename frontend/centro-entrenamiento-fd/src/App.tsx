import Login from "./pages/Login";
import Register from "./pages/Register";
import Dashboard from "./pages/Dashboard";

import { AuthProvider } from "./auth/AuthContext";
import PrivateRoute from "./auth/PrivateRoute";

import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

function App() {

  return (
    <AuthProvider>

      <BrowserRouter>

        <Routes>

          {/* Public routes */}

          <Route path="/" element={<Login />} />

          <Route path="/register" element={<Register />} />

          {/* Protected routes */}

          <Route element={<PrivateRoute />}>

            <Route path="/dashboard" element={<Dashboard />} />

          </Route>

          <Route path="*" element={<Navigate to="/" />} />


        </Routes>

      </BrowserRouter>

    </AuthProvider>
  );
}

export default App;
