import Navbar from "./Navbar"
import Sidebar from "./Sidebar"
import styles from "./MainLayout.module.css"

interface Props {
  children: React.ReactNode
}

function MainLayout({ children }: Props) {
  return (
    <div className={styles.container}>

      <Navbar />

      <div className={styles.body}>

        <Sidebar />

        <main className={styles.content}>
          {children}
        </main>

      </div>

    </div>
  )
}

export default MainLayout