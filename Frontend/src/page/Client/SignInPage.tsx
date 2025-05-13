import Button from '../../component/Button/Button';

function SignInPage() {
  return (
    <div className="bg-[#DADADA] h-[55vh] m-3 p-3 grid grid-flow-col grid-rows-3 gap-4">
      <strong className="text-4xl row-span-1 flex justify-center items-center">SIGN IN</strong>

      <div className="row-span-1 flex flex-col items-center space-y-2">
        <input type="text" placeholder="Email" className="p-2 rounded w-3/5 bg-white" />
        <input type="password" placeholder="Password" className="p-2 rounded w-3/5 bg-white" />
      </div>

      <div className="row-span-1 flex flex-col items-center space-y-2">
        <div className="w-3/5">
          <Button label={'Sign In'} className="w-full" />
        </div>
        <div className="w-3/5">
          <Button label={'Sign Up'} className="w-full" />
        </div>
      </div>
    </div>
  );
}

export default SignInPage;
