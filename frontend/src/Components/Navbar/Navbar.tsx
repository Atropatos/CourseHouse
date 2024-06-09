import React, { useState } from "react";
import logo from "./logo.webp";
import profilePicture from "./profile_picture.png";
import "./Navbar.css";
import { useAuth } from "../../Context/useAuth";
import { Link, useNavigate } from "react-router-dom";

interface Props {}

const Navbar = (props: Props) => {
  const { isLoggedIn, user, logout } = useAuth();
  const [dropdownVisible, setDropdownVisible] = useState(false);
  const navigate = useNavigate();

  const toggleDropdown = () => {
    setDropdownVisible(!dropdownVisible);
  };

  const handleProfileClick = () => {
    // Handle profile click
  };

  const handleChangePasswordClick = () => {};

  return (
    <nav className="relative container w-full mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <Link to="/" className="text-2xl font-bold text-darkBlue">
            <img src={logo} alt="" className="w-16" />
          </Link>
        </div>
        {isLoggedIn() ? (
          <div className="flex items-center space-x-6 text-black">
            <div className="hover:text-darkBlue">Witaj, {user?.userName}</div>
            <div className="relative">
              <img
                src={profilePicture}
                alt="Profile"
                className="w-10 h-10 rounded-full cursor-pointer"
                onClick={toggleDropdown}
              />
              {dropdownVisible && (
                <div className="absolute right-0 mt-2 w-48 bg-white border border-gray-300 rounded shadow-lg">
                  <Link
                    to="/profile"
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-100"
                    onClick={handleProfileClick}
                  >
                    Profil
                  </Link>
                  <Link
                    to="/change-password"
                    className="block px-4 py-2 text-gray-800 hover:bg-gray-100"
                    onClick={handleChangePasswordClick}
                  >
                    Zmień hasło
                  </Link>
                </div>
              )}
            </div>
            <a
              onClick={logout}
              className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70 cursor-pointer"
            >
              Wyloguj się
            </a>
          </div>
        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-black">
            <Link to="/login" className="hover:text-darkBlue">
              Logowanie
            </Link>
            <Link
              to="/register"
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
