import { useState } from "react";
import styles from "./Login.module.css";
import axiosClient from "../api/axiosClient";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async () => {
    try {
      await axiosClient.post("/auth/register", { email, fullName, password });
      alert("Cuenta creada 🎉");
      navigate("/");
    } catch {
      alert("Error al registrar");
    }
  };

  return (
    <div className={styles.container}>
      <div className={styles.card}>
        <h2 className={styles.title}>Crear Cuenta</h2>

        <input
          className={styles.input}
          placeholder="Nombre completo"
          onChange={(e) => setFullName(e.target.value)}
        />

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

        <button className={styles.button} onClick={handleRegister}>
          Registrarme
        </button>
      </div>
    </div>
  );
}