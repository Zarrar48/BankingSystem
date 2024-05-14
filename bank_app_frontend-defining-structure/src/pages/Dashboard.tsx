// Dashboard.js
import SidePanel from "@/components/SidePanel";
import TopBar from "@/components/TopBar";
import "../styles/dashboard-layout.css";
import Home from "@/components/Home";
import TransferMoney from "@/components/TransferMoney";
import TransactionHistory from "@/components/TransactionHistory/TransactionHistory";
import Loans from "@/components/Loans/Loans";
import { Route, Routes } from "react-router-dom";
import Profile from "@/components/Profile";

const Dashboard = () => {
  return (
    <div className="page-wrapper">
      <div className="side-panel-wrapper">
        <SidePanel />
      </div>
      <div className="remaining-screen-wrapper">
        <TopBar />
        <div className="dash-layout-body-wrapper">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="transfer-money" element={<TransferMoney />} />
            <Route
              path="transaction-history"
              element={<TransactionHistory accountId={15} />}
            />
            <Route path="loans" element={<Loans />} />
            <Route path="profile" element={<Profile />} />
          </Routes>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
