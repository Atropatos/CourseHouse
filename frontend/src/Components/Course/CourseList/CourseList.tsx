import React, { useEffect, useState } from 'react';
import { getCategories, getCourses, getCoursesByUser } from '../../../Services/courseService';
import { Course } from '../../../Models/Course';
import CourseDetail from '../CourseDetail/CourseDetail';
import { useNavigate } from 'react-router';
import { useAuth } from '../../../Context/useAuth';
import './CourseList.css';

interface MappedCategory {
  label: string;
  value: number;
};

const CourseList: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);
  const [categories, setCategories] = useState<MappedCategory[]>([]);
  const [selectedCategoryIds, setSelectedCategoryIds] = useState<number[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const { roles, fetchUserRoles } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        let fetchedCourses;
        if (roles?.includes("ContentCreator")) {
          fetchedCourses = await getCoursesByUser();
        } else {
          fetchedCourses = await getCourses();
        }
        setCourses(fetchedCourses);

        const fetchedCategories = await getCategories();
        const formattedCategories = fetchedCategories.map((category: any) => ({
          label: category.courseCategoryName,
          value: category.courseCategoryId,
        }));
        setCategories(formattedCategories);

        await fetchUserRoles();

      } catch (err) {
        setError('Error fetching courses');
      } finally {
        setLoading(false);
      }
    };
    fetchCourses();
  }, []);

  const handleCourseClick = (courseId: number) => {
    navigate(`/course/${courseId}`);
  };

  const handleCategoryChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedOptions = Array.from(event.target.selectedOptions).map(option => parseInt(option.value));
    setSelectedCategoryIds(selectedOptions);
  };

  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  const redirectToCreateCourse = () => {
    navigate(`/course/create`);
  }

  // Filter courses based on selected category IDs and search term
  const filteredCourses = courses.filter(course =>
    (selectedCategoryIds.length === 0 || course.courseCategories.some(category => selectedCategoryIds.includes(category.categoryId))) &&
    course.courseName.toLowerCase().includes(searchTerm.toLowerCase())
  );

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="container">
      <label htmlFor="courseCategories">Kategorie:</label>
      <select id="courseCategories" multiple onChange={handleCategoryChange}>
        {categories.map(({ label, value }) => (
          <option key={value} value={value}>
            {label}
          </option>
        ))}
      </select>

      <label htmlFor="courseSearch">Szukaj:</label>
      <input
        type="text"
        id="courseSearch"
        value={searchTerm}
        onChange={handleSearchChange}
        placeholder="Szukaj po nazwie kursu"
      />

      <h1>Lista z kursami:</h1>
      <ul>
        {filteredCourses.map((course) => (
          <li key={course.courseId}>
            <h2
              onClick={() => handleCourseClick(course.courseId)}
              className="course-name"
            >
              Nazwa kursu: {course.courseName}
            </h2>
            <p>Opis kursu: {course.courseDescription}</p>
            <p>Cena: {course.coursePrice.toFixed(2)} PLN</p>
            <p>Kategoria: {course.courseCategories.map(category => category.categoryName).join(', ')}</p>
          </li>
        ))}
      </ul>

      {roles?.includes("ContentCreator") && (
        <button className="green-button" onClick={redirectToCreateCourse}>Stworz Kurs</button>
      )}
    </div>
  );
};

export default CourseList;
