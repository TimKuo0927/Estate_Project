import Button from '../Button/Button';

function Header() {
  return (
    <div className="w-full bg-[#8E8E8E] h-[100px] grid grid-cols-6 gap-3 p-3 place-content-center">
      <strong className="col-start-1 col-end-3 text-5xl">Fake Estate</strong>
      <div className="col-span-2 col-end-7 grid grid-cols-3  items-center justify-items-center ">
        <a className="text-xl hover:underline">Home</a>
        <a className="text-xl hover:underline">List</a>
        <Button label="Sign In" variant="secondary"></Button>
      </div>
    </div>
  );
}

export default Header;
