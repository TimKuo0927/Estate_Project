import './App.css';
import { useEffect, useState } from 'react';
import { Routes, Route } from 'react-router-dom';

import ClientLayout from './component/ClientLayout/ClientLayout';
import HomePage from './page/Client/HomePage';
import SignPage from './page/Client/SignInUp/SignPage';
import backendConnector from './api';
import { userData } from '../model/User';

function App() {
  const [isLogin, setIsLogin] = useState(false);
  const [userData, setUserData] = useState<userData>({
    Userid: 0,
    UserFullName: '',
    UserPreferName: '',
    UserEmail: '',
    UserPhone: '',
  });

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      const fetchData = async () => {
        try {
          const data = await backendConnector.user.GetUserData();
          setUserData(data);
          // await new Promise(f => setTimeout(f, 1000));
          setIsLogin(true);
        } catch (error) {
          console.error('Error fetching user data:', error);
          setIsLogin(false);
        }
      };

      fetchData();
    }
  }, []);

  useEffect(() => {
    console.log('Updated userData:', userData);
  }, [userData]);
  return (
    <Routes>
      <Route path="/" element={<ClientLayout isLogin={isLogin} userData={userData} />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/signIn" element={<SignPage />} />
      </Route>
    </Routes>
  );
}

export default App;
