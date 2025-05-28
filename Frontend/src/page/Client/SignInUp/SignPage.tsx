import React, { useState } from 'react';

import Button from '../../../component/Button/Button';
import SignInPage from './SignInPage';
import SignUpPage from './SignUpPage';
function SignPage() {
  const [status, SetStatus] = useState<string>('SignIn');

  return (
    <div className="bg-[#DADADA] h-[65vh] m-3 p-3 grid grid-flow-col grid-rows-3 gap-4">
      {status == 'SignIn' && <SignInPage SetStatus={SetStatus} />}
      {status == 'SignUp' && <SignUpPage />}
    </div>
  );
}

export default SignPage;
