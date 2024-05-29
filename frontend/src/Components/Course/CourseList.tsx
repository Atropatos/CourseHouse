// src/components/CourseList.tsx
import React, { useEffect, useState } from 'react';

import { getCourses } from '../../Services/courseService';
import { Course } from '../../Models/Course';
import CourseDetail from './CourseDetail';
import { useNavigate } from 'react-router';

const CourseList: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);
 // const [selectedCourseId,setSelectedCourseId] = useState<number |null>(null);
  // const [selectedCourseId, setSelectedCourseId] = useState<number | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();
  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const data = await getCourses();
        setCourses(data);
      } catch (err) {
        setError('Error fetching courses');
      } finally {
        setLoading(false);
      }
    };

    fetchCourses();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  const handleCourseClick = (courseId:number) =>{
    navigate(`/course/${courseId}`);
  };




  // const handleCourseClick = (courseId: number) => {
  //   setSelectedCourseId(courseId);
  // };

  // const handleBackClick = () => {
  //   setSelectedCourseId(null);
  // };

  return (
    <div>
       
          <h1>Lista z kursami:</h1>
           <p>-------------------------</p>
          <ul>
            {courses.map((course) => (
              <li key={course.courseId}>
                <h2 
                  onClick={() => handleCourseClick(course.courseId)} 
                  style = {{cursor: 'pointer'}}
                  className="course-name"
                >
                  Nazwa kursu: {course.courseName}
                </h2>
                <p>Opis kursu: {course.courseDescription}</p>
                <p>Cena: {course.coursePrice.toFixed(2)}PLN</p>
                <p>Kategoria: {course.courseCategories.map(category => category.categoryName).join(', ')}</p>
                <p>-------------------------</p>
              </li>
            ))}
          </ul>
       
      
    </div>
  );
};

export default CourseList;