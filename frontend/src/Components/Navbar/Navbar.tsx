import React from "react";
import logo from "./logo.webp";
import "./Navbar.css";
import { useAuth } from "../../Context/useAuth";
import { Link } from "react-router-dom";

interface Props {}

const Navbar = (props: Props) => {
  const { isLoggedIn, user,logout} = useAuth();
  return (
    <nav className="relative container w-16 mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <img src={logo} alt="" />
          <div className="hidden font-bold lg:flex">
            {/* <a href="" className="text-black hover:text-darkBlue ml-8">
              Dashboard
            </a> */}
          </div>
        </div>
        {isLoggedIn() ? (
           <div className="hidden lg:flex items-center space-x-6 text-back">
           <div className="hover:text-darkBlue ">Witaj, {user?.userName}</div>
           <a
             onClick={logout}
             className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
           >
             Wyloguj się
           </a>
         </div>

        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-back">
          <Link to="/login" className="hover:text-darkBlue ">Logowanie</Link>
          <Link to="/register"
            className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
          >
            Rejestracja
          </Link>
        </div>

          
        )}

      </div>
    </nav>
  );
};

export default Navbar;