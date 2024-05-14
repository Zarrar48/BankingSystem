import LogoutIcon from '@mui/icons-material/Logout';
import '../styles/top-bar.css';
import { NavLink } from 'react-router-dom';

const TopBar = () => {
  return (
    <div className='top-bar-wrapper'>
      <NavLink to='/' className="flex items-center gap-1">
        <LogoutIcon />
        Logout
      </NavLink>
    </div>
  );
};

export default TopBar;
