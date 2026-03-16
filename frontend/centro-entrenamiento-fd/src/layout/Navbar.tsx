import { useAuth } from "../auth/useAuth"

function Navbar() {

  const { user, logout } = useAuth()

  return (
    <header>

      <h2>Centro Entrenamiento FD</h2>

      <div>

        <span>{user?.email}</span>

        <button onClick={logout}>
          Logout
        </button>

      </div>

    </header>
  )
}

export default Navbar