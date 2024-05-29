// src/components/CourseDetail.tsx
import React, { useEffect, useState } from 'react';

import { Course } from '../../Models/Course';
import { CourseView } from '../../Models/Course/CourseView';
import { Content } from '../../Models/Content/Content';
import { getCourseById } from '../../Services/courseService';
import ContentDisplay from '../ContentDisplay';
import { useNavigate, useParams } from 'react-router-dom';



const CourseDetail: React.FC = () => {
  const {courseId} = useParams<{courseId:string}>();
  const [course, setCourse] = useState<Course | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();
  useEffect(() => {
    const fetchCourse = async () => {
      if (courseId) {
        const courseIdNumber = Number(courseId);
        if (!isNaN(courseIdNumber)) {
          try {
            const data = await getCourseById(courseIdNumber);
            setCourse(data);
          } catch (err) {
            setError('Error fetching course details');
          } finally {
            setLoading(false);
          }
        } else {
          setError('Invalid course ID');
          setLoading(false);
        }
      } else {
        setError('No course ID provided');
        setLoading(false);
      }
    };
    fetchCourse();
  }, [courseId]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (!course) {
    return <div>No course found</div>;
  }

  const handleBackClick = () => {
    navigate('/');
  }
  return (
    <div>
      <button onClick={handleBackClick}> Powrot do Listy z kursami</button>
      <p>-------------------------</p>
      <h1>Nazwa kursu: {course.courseName}</h1>
      <p>Opis kursu: {course.courseDescription}</p>
      <p>Cena:{course.coursePrice.toFixed(2)}PLN </p>

      <h2>Widok kursu:</h2>
      {course.courseViews.map((view) => (
        <div key={view.viewId}>
          <h3>Widok {view.courseViewOrder}</h3>
          {view.content.map((content: Content) => (
            <ContentDisplay key={content.contentId} content={content} />
          ))}
        </div>
      ))}
    </div>
  );
};

export default CourseDetail;