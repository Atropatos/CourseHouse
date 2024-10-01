import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import Card from './Components/Card/Card';
import CardList from './Components/CardList/CardList';
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
//   const [search,setSearch] = useState<string>();

//   const handleChange = (e:ChangeEvent<HTMLInputElement>) => {
//       setSearch(e.target.value);
//       console.log(e);
//   }

//   const onClick = (e:SyntheticEvent) => {
//       console.log(e);
//   };
//   return (
//     <div className="App">
//       <Search onClick={onClick} search={search} handleChange={handleChange}/>
//       <CardList />
//     </div>
//   );
// }
return (
  <>
  {/* <HomePage/>
  <SearchPage/>
  <p>asd</p>
<UserProvider> 
<ToastContainer/>
</UserProvider> */}
<UserProvider>
<Navbar/>

<Outlet/>
<ToastContainer/>
</UserProvider>

</>
);
}


export default App;
