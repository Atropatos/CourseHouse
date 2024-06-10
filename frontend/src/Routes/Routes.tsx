import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";

import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import CourseDetail from "../Components/Course/CourseDetail/CourseDetail";
import CreateCourse from "../Components/Course/CreateCourse/CreateCourse";
import CourseViewDetails from "../Components/CourseView/CourseViewDetails";
import AddContent from "../Components/Content/AddContent/AddContent";
import UpdateContent from "../Components/Content/UpdateContent/UpdateContent";
import UpdateCourse from "../Components/Course/UpdateCourse/UpdateCourse";
import ChangePassword from "../Components/User/ChangePassword";
import CourseHistory from "../Components/Course/CourseHistory/CourseHistory";



export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children: [
            {path: "", element: <HomePage/>},
            { path: "course/:courseId", element: <CourseDetail/> },
            { path: "course/create", element: <CreateCourse/>},
            { path: "updateCourse/:courseId", element: <UpdateCourse/>},
            
            {path: "login", element: <LoginPage/>},
            {path: "register", element: <RegisterPage/>},
            {path: "search", element: <SearchPage/>},
            {path: "courseView/:viewId", element: <CourseViewDetails/>},
            { path: "courseView/:viewId/addContent", element: <AddContent/>},
        { path: "updateContent/:contentId", element: <UpdateContent/>},
        { path: "change-password", element: <ChangePassword/>},
        { path: "course-history",element: <CourseHistory/>}
        ]
    }
]);