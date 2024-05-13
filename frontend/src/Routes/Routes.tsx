import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import LoginPage from "../Pages/LoginPage/LoginPage";



export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children: [
            {path: "", element: <HomePage/>},
            {path: "login", element: <LoginPage/>},
            {path: "search", element: <SearchPage/>},
            {path: "company/:ticker", element: <CompanyPage/>},
        ],
    },
]);