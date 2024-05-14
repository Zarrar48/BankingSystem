import PaymentsIcon from "@mui/icons-material/Payments";
import HistoryIcon from "@mui/icons-material/History";
import "../styles/side-panel.css";
import Person2Icon from "@mui/icons-material/Person2";
import CreditCardIcon from '@mui/icons-material/CreditCard';
import WidgetsIcon from "@mui/icons-material/Widgets";
import "../styles/dashboard-layout.css";
import { NavLink,Outlet } from "react-router-dom";

const SidePanel = () => {
  return (
    <div className="side-panel-wrapper">
      <div className="side-panel-title">My Account</div>
      <div className="spacer" />
      {/* Option 1 */}
      
      <NavLink to='/dashboard' className="side-panel-link">
      <div className="inner-option">
        <div className="icon-wrapper">
          <WidgetsIcon />
        </div>
        <div className="option-text-wrapper">Home</div>
      </div>
      </NavLink>
   
   
      {/* Option 2 */}
      <NavLink to='/dashboard/transfer-money' className="side-panel-link">
      <div className="inner-option">
    
        <div className="icon-wrapper">
          <PaymentsIcon />
        </div>
        <div className="option-text-wrapper">Transfer Money</div>
      </div>
      </NavLink>
      {/* Option 3 */}
      <NavLink to='/dashboard/transaction-history' className="side-panel-link">

      <div className="inner-option">
        <div className="icon-wrapper">
          <HistoryIcon />
        </div>
        <div className="option-text-wrapper"> Transaction History
      </div>
      </div>
      </NavLink>
      {/* Option 4 */}
      <NavLink to='/dashboard/loans' className="side-panel-link">
      <div className="inner-option">
        <div className="icon-wrapper">
          <CreditCardIcon />
        </div>
        <div className="option-text-wrapper"> Loans</div>
      </div>
      </NavLink>
      {/* Last Row */}
      <NavLink to='/dashboard/profile' className="side-panel-link">
      <div className="inner-option">
        <div className="icon-wrapper">
          <Person2Icon />
        </div>
        <div className="option-text-wrapper"> Profile</div>
      </div>
      </NavLink>
      <Outlet />
    </div>
  );
};

export default SidePanel;
