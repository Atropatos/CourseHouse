// src/components/CourseList.tsx
import React, { useEffect, useState } from 'react';
import { getCourses } from '../../Services/courseService';
import { Course } from '../../Models/Course';

const CourseList: React.FC = () => {
    const [courses, setCourses] = useState<Course[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
  
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
  
    return (
      <div>
        <h1>Lista kursów:</h1>
        <ul>
          {courses.map((course) => (
            <li key={course.courseId}>
              <h2>Nazwa kursu: {course.courseName}</h2>
              <p>Opis: {course.courseDescription}</p>
              <p>koszt: {course.coursePrice.toFixed(2)} PLN</p>
              <p>kategoria: {course.courseCategories.map(category => category.categoryName).join(', ')}</p>
              <p>------------------------------</p>
              {/* Add more fields as needed */}
            </li>
          ))}
        </ul>
      </div>
    );
  };
  
  export default CourseList;
