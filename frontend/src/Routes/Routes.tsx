import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import CourseDetail from "../Components/Course/CourseDetail";
import CreateCourse from "../Components/CreateCourse";
import CourseViewDetails from "../Components/CourseViewDetails";
import AddContent from "../Components/AddContent";
import UpdateContent from "../Components/UpdateContent";



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
            {path: "company/:ticker", element: <CompanyPage/>},
            {path: "courseView/:viewId", element: <CourseViewDetails/>},
            { path: "courseView/:viewId/addContent", element: <AddContent/>},
        { path: "updateContent/:contentId", element: <UpdateContent/>}
        ]
    }
]);