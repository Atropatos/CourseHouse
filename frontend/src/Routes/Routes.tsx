import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import CourseDetail from "../Components/Course/CourseDetail";
import CreateCourse from "../Components/CreateCourse";



export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children: [
            {path: "", element: <HomePage/>},
            { path: "course/:courseId", element: <CourseDetail/> },
            { path: "course/create", element: <CreateCourse/>},
            {path: "login", element: <LoginPage/>},
            {path: "register", element: <RegisterPage/>},
            {path: "search", element: <SearchPage/>},
            {path: "company/:ticker", element: <CompanyPage/>}
            
        ],
    },
]);