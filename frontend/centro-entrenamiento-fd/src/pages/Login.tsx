import { useState, useContext, useEffect } from "react";
import { AuthContext } from "../auth/AuthContext";
import styles from "./Login.module.css";
import { useNavigate } from "react-router-dom";
import axiosClient from "../api/axiosClient";

declare global {
  interface Window {
    google: any;
  }
}

export default function Login() {
  const auth = useContext(AuthContext);
  const navigate = useNavigate();

  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const handleLogin = async () => {
    try {
      await auth?.login(email, password);
      navigate("/dashboard");
    } catch {
      alert("Error en login");
    }
  };

  const handleGoogleResponse = async (response: any) => {
    try {
      const res = await axiosClient.post("/auth/google", {
        idToken: response.credential,
      });

      localStorage.setItem("token", res.data.token);
      navigate("/dashboard");
    } catch (error) {
      console.error(error);
      alert("Error con Google Login");
    }
  };

  useEffect(() => {
    if (window.google) {
      window.google.accounts.id.initialize({
        client_id: "793591185630-7faqin22nn50689mkoiutk962har944r.apps.googleusercontent.com",
        callback: handleGoogleResponse,
      });

      window.google.accounts.id.renderButton(
        document.getElementById("googleButton"),
        {
          theme: "outline",
          size: "large",
          width: 300,
        }
      );
    }
  }, []);

  return (
    <div className={styles.container}>
      <div className={styles.card}>
        <h2 className={styles.title}>Centro de Entrenamiento FD</h2>

        <input
          className={styles.input}
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
        />

        <input
          className={styles.input}
          type="password"
          placeholder="Contraseña"
          onChange={(e) => setPassword(e.target.value)}
        />

        <button className={styles.button} onClick={handleLogin}>
          Ingresar
        </button>

        <div style={{ marginTop: "15px", textAlign: "center" }}>
          <div id="googleButton"></div>
        </div>

        <button
          className={styles.secondaryButton}
          onClick={() => navigate("/register")}
        >
          Crear cuenta
        </button>
      </div>
    </div>
  );
}