import Login from "./pages/Login";
import { AuthProvider } from "./auth/AuthContext";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import PrivateRoute from "./auth/PrivateRoute";
import Register from "./pages/Register";

function App() {
  return (
     <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route
            path="/dashboard"
            element={
              <PrivateRoute>
                <Dashboard />
              </PrivateRoute>
            }
          />
          <Route path="/register" element={<Register />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
