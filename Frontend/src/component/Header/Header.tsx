function Header() {
  return (
    <div className="w-full bg-[#8E8E8E] h-[100px] grid grid-cols-6 gap-4">
      <div className="col-start-1 col-end-3">Fake Estate</div>
      <div className="col-span-2 col-end-7 gap-2">
        <a>Home</a>
        <a>List</a>
      </div>
    </div>
  );
}

export default Header;
