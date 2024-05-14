import AccountBalanceIcon from '@mui/icons-material/AccountBalance';
import CompareArrowsIcon from '@mui/icons-material/CompareArrows';
import Person4Icon from '@mui/icons-material/Person4';
import '../styles/home.css'; 
import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger,
} from "@/components/ui/hover-card";
  import { NavLink,Outlet } from 'react-router-dom';
const Home = () => {
  return (
    <div className='home-body-wrapper'>
      <div className='relative'>
        <HoverCard>
          <HoverCardTrigger>
            <div className='option-tag bg-purple-500 hover:bg-purple-400'>
              <div className='tag-icon'><AccountBalanceIcon sx={{ width: 200, height: 200 }}/></div>
              <div className='tag-small-text'>Current Balance</div>
            </div>
          </HoverCardTrigger>
          <HoverCardContent className="italic">Balance: 5000</HoverCardContent>
        </HoverCard>
      </div>
      <NavLink to='/dashboard/transfer-money'>
      <div className='option-tag bg-violet-400 hover:bg-violet-300'>
        <div className='tag-icon'><CompareArrowsIcon sx={{ width: 200, height: 200 }}/></div>
        <div className='tag-small-text'>Transfer Money</div>
      </div>
      </NavLink>
      <NavLink to='/dashboard/profile'>
      <div className='option-tag bg-pink-400 hover:bg-pink-300'>
        <div className='tag-icon'><Person4Icon sx={{ width: 200, height: 200 }}/></div>
        <div className='tag-small-text'>Profile</div>
      </div>
      </NavLink>
      <Outlet />
    </div>
  );
}

export default Home;
