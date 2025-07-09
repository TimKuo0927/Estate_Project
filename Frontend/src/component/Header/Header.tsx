import { userData } from '../../../model/User';
import Button from '../Button/Button';

interface HeaderProps {
  HomeOnClick?: () => void;
  ListOnClick?: () => void;
  SignOnClick?: () => void;
  isLogin: boolean;
  userData: userData;
}

function Header({ HomeOnClick, ListOnClick, SignOnClick, isLogin, userData }: HeaderProps) {
  return (
    <div className="w-full bg-[#8E8E8E] h-[100px] grid grid-cols-7 gap-3 p-3 place-content-center">
      <strong className="col-start-1 col-end-3 text-5xl">Fake Estate</strong>
      <div className="col-span-2 col-end-7 grid grid-cols-4 items-center justify-items-center">
        {isLogin && <div className="text-xl">{userData.UserFullName}</div>}
        <button className="text-xl hover:underline" onClick={HomeOnClick}>
          Home
        </button>
        <button className="text-xl hover:underline" onClick={ListOnClick}>
          List
        </button>
        {!isLogin && <Button label="Sign In" variant="secondary" onClick={SignOnClick} />}
        {isLogin && <Button label="Sign Out" variant="secondary" />}
      </div>
    </div>
  );
}

export default Header;
