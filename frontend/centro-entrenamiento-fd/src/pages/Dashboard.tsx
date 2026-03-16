import { useAuth } from "../auth/useAuth"
import CoachDashboard from "../dashboard/CoachDashboard"
import ClientDashboard from "../dashboard/ClientDashboard"

function Dashboard() {

  const { user } = useAuth()

  if (user?.role === "Coach") {
    return <CoachDashboard />
  }

  return <ClientDashboard />
}

export default Dashboard