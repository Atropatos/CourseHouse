import React from "react";
import { Link, Outlet } from "react-router-dom";

type Props = {};

const HomePage = (props: Props) => {
  return (
    <>
      <div className="text-3xl font-bold underline text-red-600">HomePage</div>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/login">Login</Link>
          </li>
          <li>
            <Link to="/register">Register</Link>
          </li>
        </ul>
      </nav>
      <div>
        <Outlet />
      </div>
    </>
  );
};

export default HomePage;
