import React, { useState } from 'react';

import Button from '../../component/Button/Button';
import { UserLogin } from '../../../model/User/index';
import backendConnector from '../../api';

function SignInPage() {
  const [userData, setUserData] = useState<UserLogin>({
    Email: '',
    Password: '',
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUserData(prev => ({ ...prev, [name]: value }));
  };

  const handleLogin = async () => {
    try {
      const token = await backendConnector.user.login(userData);
      // console.log(token)
      localStorage.setItem('token', token);
    } catch (err) {
      console.log('Login error');
      console.error(err);
    }
  };

  return (
    <div className="bg-[#DADADA] h-[55vh] m-3 p-3 grid grid-flow-col grid-rows-3 gap-4">
      <strong className="text-4xl row-span-1 flex justify-center items-center">SIGN IN</strong>

      <div className="row-span-1 flex flex-col items-center space-y-2">
        <input
          type="text"
          name="Email"
          placeholder="Email"
          className="p-2 rounded w-3/5 bg-white"
          value={userData.Email}
          onChange={handleChange}
        />
        <input
          type="password"
          name="Password"
          placeholder="Password"
          className="p-2 rounded w-3/5 bg-white"
          value={userData.Password}
          onChange={handleChange}
        />
      </div>

      <div className="row-span-1 flex flex-col items-center space-y-2">
        <div className="w-3/5">
          <Button label={'Sign In'} className="w-full" onClick={handleLogin} />
        </div>
        <div className="w-3/5">
          <Button label={'Sign Up'} className="w-full" />
        </div>
      </div>
    </div>
  );
}

export default SignInPage;
