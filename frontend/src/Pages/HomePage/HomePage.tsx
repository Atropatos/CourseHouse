import React, { useEffect, useState } from 'react';
import CourseList from '../../Components/Course/CourseList';
import { Link } from 'react-router-dom';
import { useAuth } from '../../Context/useAuth';
import CreateCourse from '../../Components/CreateCourse';

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
    console.log('Roles in HomePage:', roles); // Log roles in HomePage to see what is being fetched
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
        <div>No access</div>
      )}
    </>
  );
};

const UserDashboard = () => {
  return <div><CourseList/></div>;
};

const ContentCreatorDashboard = () => {
  return <div><CreateCourse/></div>;
}

export default HomePage;
