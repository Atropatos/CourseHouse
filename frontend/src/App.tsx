import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import logo from './logo.svg';
import './App.css';

import Search from './Components/Search/Search';
import "react-toastify/dist/ReactToastify.css";
import { ToastContainer } from 'react-toastify';
import { UserProvider } from './Context/useAuth';
import HomePage from './Pages/HomePage/HomePage';
import SearchPage from './Pages/SearchPage/SearchPage';
import { Outlet } from 'react-router';
import Navbar from './Components/Navbar/Navbar';
import CourseList from './Components/Course/CourseList';
function App() {

return (
  <>

<UserProvider>
<Navbar/>

<Outlet/>
<ToastContainer/>
</UserProvider>

</>
);
}


export default App;
