import React, { useState } from 'react';

import Button from '../../../component/Button/Button';
import { userCreate } from '../../../../model/User/index';
import backendConnector from '../../../api';

type SignUpPageProps = {
  SetStatus: React.Dispatch<React.SetStateAction<string>>;
};

function SignUpPage({ SetStatus }: SignUpPageProps) {
  const [userData, setUserData] = useState<userCreate>({
    UserEmail: '',
    PasswordHash: '',
    UserFullName: '',
    UserPreferName: '',
    UserPhone: '',
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUserData(prev => ({ ...prev, [name]: value }));
  };

  const handleCreate = async () => {
    try {
      const response = await backendConnector.user.AddNewUser(userData);
      // console.log(token)
      if (response) {
        console.log('create success');
        ToSignIn();
      }
    } catch (err) {
      console.log('Login error');
      console.error(err);
    }
  };

  const ToSignIn = () => {
    SetStatus('SignIn');
  };

  return (
    <>
      <strong className="text-4xl row-span-1 flex justify-center items-center">SIGN UP</strong>

      <div className=" space-y-2">
        <div className="row-span-1 flex flex-col items-center space-y-2">
          <input
            type="text"
            name="UserEmail"
            placeholder="Email"
            className="p-2 rounded w-3/5 bg-white"
            value={userData.UserEmail}
            onChange={handleChange}
          />
          <input
            type="password"
            name="PasswordHash"
            placeholder="Password"
            className="p-2 rounded w-3/5 bg-white"
            value={userData.PasswordHash}
            onChange={handleChange}
          />
        </div>
        <input
          type="text"
          name="UserFullName"
          placeholder="userName"
          className="p-2 rounded w-3/5 bg-white"
          value={userData.UserFullName}
          onChange={handleChange}
        />
        <input
          type="text"
          name="UserPhone"
          placeholder="phone"
          className="p-2 rounded w-3/5 bg-white"
          value={userData.UserPhone}
          onChange={handleChange}
        />
      </div>

      <div className="row-span-1 flex flex-col items-center space-y-2">
        <div className="w-3/5">
          <Button label={'Create Account'} className="w-full" onClick={handleCreate} />
        </div>
        <div className="w-3/5">
          <Button label={'Back to Sign In'} className="w-full" />
        </div>
      </div>
    </>
  );
}

export default SignUpPage;
