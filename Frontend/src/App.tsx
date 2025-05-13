// import { useState } from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import ClientLayout from './component/ClientLayout/ClientLayout';
import HomePage from './page/Client/HomePage';
import SignInPage from './page/Client/SignInPage';

function App() {
  return (
    <Routes>
      <Route path="/" element={<ClientLayout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/signIn" element={<SignInPage />} />
      </Route>
    </Routes>
  );
}

export default App;
