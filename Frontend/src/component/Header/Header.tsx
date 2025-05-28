import Button from '../Button/Button';

interface HeaderProps {
  HomeOnClick?: () => void;
  ListOnClick?: () => void;
  SignOnClick?: () => void;
}

function Header({ HomeOnClick, ListOnClick, SignOnClick }: HeaderProps) {
  return (
    <div className="w-full bg-[#8E8E8E] h-[100px] grid grid-cols-6 gap-3 p-3 place-content-center">
      <strong className="col-start-1 col-end-3 text-5xl">Fake Estate</strong>
      <div className="col-span-2 col-end-7 grid grid-cols-3  items-center justify-items-center ">
        <a className="text-xl hover:underline" onClick={HomeOnClick}>
          Home
        </a>
        <a className="text-xl hover:underline" onClick={ListOnClick}>
          List
        </a>
        <Button label="Sign In" variant="secondary" onClick={SignOnClick}></Button>
      </div>
    </div>
  );
}

export default Header;
