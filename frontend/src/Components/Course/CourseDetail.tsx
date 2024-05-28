// src/components/CourseDetail.tsx
import React, { useEffect, useState } from 'react';

import { Course } from '../../Models/Course';
import { CourseView } from '../../Models/Course/CourseView';
import { Content } from '../../Models/Content/Content';
import { getCourseById } from '../../Services/courseService';
import ContentDisplay from '../ContentDisplay';

interface CourseDetailProps {
  courseId: number;
}

const CourseDetail: React.FC<CourseDetailProps> = ({ courseId }) => {
  const [course, setCourse] = useState<Course | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        const data = await getCourseById(courseId);
        setCourse(data);
      } catch (err) {
        setError('Error fetching course details');
      } finally {
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

  return (
    <div>
      <h1>{course.courseName}</h1>
      <p>{course.courseDescription}</p>
      <p>Price: ${course.coursePrice.toFixed(2)}</p>

      <h2>Course Views</h2>
      {course.courseViews.map((view) => (
        <div key={view.viewId}>
          <h3>View {view.courseViewOrder}</h3>
          {view.content.map((content: Content) => (
            <ContentDisplay key={content.contentId} content={content} />
          ))}
        </div>
      ))}
    </div>
  );
};

export default CourseDetail;