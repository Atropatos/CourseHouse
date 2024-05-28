// src/components/CourseList.tsx
import React, { useEffect, useState } from 'react';

import { getCourses } from '../../Services/courseService';
import { Course } from '../../Models/Course';
import CourseDetail from './CourseDetail';

const CourseList: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);
  const [selectedCourseId, setSelectedCourseId] = useState<number | null>(null);
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

  const handleCourseClick = (courseId: number) => {
    setSelectedCourseId(courseId);
  };

  const handleBackClick = () => {
    setSelectedCourseId(null);
  };

  return (
    <div>
      {selectedCourseId === null ? (
        <>
          <h1>Course List</h1>
          <ul>
            {courses.map((course) => (
              <li key={course.courseId}>
                <h2 
                  onClick={() => handleCourseClick(course.courseId)} 
                  style = {{cursor: 'pointer'}}
                  className="course-name"
                >
                  {course.courseName}
                </h2>
                <p>{course.courseDescription}</p>
                <p>Price: ${course.coursePrice.toFixed(2)}</p>
                <p>Categories: {course.courseCategories.map(category => category.categoryName).join(', ')}</p>
              </li>
            ))}
          </ul>
        </>
      ) : (
        <>
          <button onClick={handleBackClick}>Back to Course List</button>
          <CourseDetail courseId={selectedCourseId} />
        </>
      )}
    </div>
  );
};

export default CourseList;