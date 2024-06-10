import React, { useEffect, useState } from 'react';
import { Course } from '../../../Models/Course/Course';
import { getCourseById, getLastFiveVisitedCourses } from '../../../Services/courseService';
import { LastVisited } from '../../../Models/LastVisited';
import { useNavigate } from 'react-router';

const CourseHistory: React.FC = () => {
  const [lastVisited, setLastVisited] = useState<LastVisited[]>([]);
  const [courseHistory, setCourseHistory] = useState<Course[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCourseHistory = async () => {
      try {
        const fetchedLastVisited = await getLastFiveVisitedCourses();
        setLastVisited(fetchedLastVisited);

        const courseDetails = await Promise.all(
            fetchedLastVisited.map(async (visit:LastVisited) => {
                const course = await getCourseById(visit.lastVisitedCourse);
                return course;
            })
        )

        setCourseHistory(courseDetails);
      } catch (err) {
        console.log(err);
      }
    };

    fetchCourseHistory();
  }, []);

  const handleBackClick = () => {
    navigate('/');
  }

  return (
    <div>
        <button className="mb-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600" onClick={handleBackClick}>
        Powrot do Listy z kursami
      </button>
      <h1 className="text-2xl font-bold mb-4">Lista z kursami:</h1>
      <ul className="list-disc pl-5 space-y-4">
        {courseHistory.map((course) => (
          <li key={course.courseId} className="border p-4 rounded shadow">
            <h2
            //   onClick={() => handleCourseClick(course.courseId)}
              className="text-xl font-semibold cursor-pointer text-blue-600 hover:underline"
            >
              Nazwa kursu: {course.courseName}
            </h2>
            <p className="mt-2">Opis kursu: {course.courseDescription}</p>
            <p className="mt-2">Cena: {course.coursePrice.toFixed(2)} PLN</p>
            <p className="mt-2">Kategoria: {course.courseCategories.map(category => category.categoryName).join(', ')}</p>
          </li>
        ))}
      </ul>
      {/* {lastVisited.length > 0 ? (
        lastVisited.map((visit, index) => (
          <div key={index}>
            Last Visited Course ID: {visit.lastVisitedCourse}
          </div>
        ))
      ) : (
        <div>No recently visited courses.</div>
      )} */}
    </div>
  );
};

export default CourseHistory;
