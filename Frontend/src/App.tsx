// import { useState } from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import ClientLayout from './component/ClientLayout/ClientLayout';
import HomePage from './page/Client/HomePage';

function App() {
  return (
    <Routes>
      <Route path="/" element={<ClientLayout />}>
        <Route path="/" element={<HomePage />} />
      </Route>
    </Routes>
  );
}

export default App;
