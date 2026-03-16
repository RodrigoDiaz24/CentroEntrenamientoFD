import { Link } from "react-router-dom"

function Sidebar() {

  return (
    <aside>

      <nav>

        <Link to="/dashboard">
          Dashboard
        </Link>

        <Link to="/clients">
          Clientes
        </Link>

        <Link to="/routines">
          Rutinas
        </Link>

      </nav>

    </aside>
  )
}

export default Sidebar