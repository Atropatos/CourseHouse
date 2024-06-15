import React, { useEffect, useState } from "react";
import CourseList from "../../Components/Course/CourseList/CourseList";
import { Link } from "react-router-dom";
import { useAuth } from "../../Context/useAuth";
import CreateCourse from "../../Components/Course/CreateCourse/CreateCourse";

interface Props {}

const HomePage = (props: Props) => {
  const { roles, fetchUserRoles } = useAuth();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchRoles = async () => {
      await fetchUserRoles();
      setLoading(false); // Set loading to false after roles are fetched
    };
    fetchRoles();
  }, []);

  useEffect(() => {
    console.log("Roles in HomePage:", roles); // Log roles in HomePage to see what is being fetched
  }, [roles]);

  if (loading) {
    return <div>Loading...</div>; // Display loading while roles are being fetched
  }

  return (
    <>
      {roles?.includes("User") ? (
        <UserDashboard />
      ) : roles?.includes("ContentCreator") ? (
        <ContentCreatorDashboard />
      ) : (
        <div className="flex justify-center h-400">
          <div className="bg-gray-200 rounded-lg shadow-lg p-6">
            <h1 className="text-2xl font-bold text-gray-800">No access</h1>
            <p className="text-gray-600 mt-2">
              Sorry, you don't have access to view this content.
            </p>
          </div>
        </div>
      )}
    </>
  );
};

const UserDashboard = () => {
  return (
    <div>
      <CourseList />
    </div>
  );
};

const ContentCreatorDashboard = () => {
  return (
    <div>
      <CourseList />
    </div>
  );
};

export default HomePage;
