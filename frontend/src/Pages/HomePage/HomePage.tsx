import React from 'react'
import CourseList from '../../Components/Course/CourseList';
import { Link } from 'react-router-dom';

interface Props {}

const HomePage = (props: Props) => {
  return (
    <>
    <CourseList />
    <Link to="course/create">Utworz kurs</Link>
    </>
  )
};

export default HomePage;