import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import HomePage from "./pages/HomePage";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import ErrorPage from "./pages/ErrorPage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import ProfilePage from "./pages/ProfilePage";
import CourseDemoPage from "./pages/CoursePage/CourseDemoPage";
import CoursePage from "./pages/CoursePage/CoursePage";
import DeleteCoursePage from "./pages/CoursePage/DeleteCoursePage";
import EditCoursePage from "./pages/CoursePage/EditCoursePage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
    errorElement: <ErrorPage />,
    children: [
      { errorElement: <ErrorPage /> },
      {
        path: "/login",
        element: <LoginPage />,
      },
      {
        path: "/register",
        element: <RegisterPage />,
      },
      {
        path: "/profile",
        element: <ProfilePage />,
      },
      {
        path: "/courseDemo/:courseId",
        element: <CourseDemoPage />,
      },
      {
        path: "/course/:courseId/page/:pageId",
        element: <CoursePage />,
      },
      {
        path: "/course/delete/:courseId",
        element: <DeleteCoursePage />,
      },
      {
        path: "/course/edit/:courseId",
        element: <EditCoursePage />,
      },
      {
        path: "/profile",
        element: <ProfilePage />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RouterProvider router={router}></RouterProvider>
  </React.StrictMode>
);
