import React, { useEffect, useState } from 'react';
import { getCategories, getCourses, getCoursesByUser } from '../../../Services/courseService';
import { Course } from '../../../Models/Course/Course';
import { useNavigate } from 'react-router';
import { useAuth } from '../../../Context/useAuth';

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
  const [sortOrder, setSortOrder] = useState<string>('asc'); // New state for sorting order
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

  const handleSortOrderChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSortOrder(event.target.value);
  };

  const redirectToCreateCourse = () => {
    navigate(`/course/create`);
  }

  // Filter and sort courses based on selected category IDs, search term, and sort order
  const filteredCourses = courses
    .filter(course =>
      (selectedCategoryIds.length === 0 || course.courseCategories.some(category => selectedCategoryIds.includes(category.categoryId))) &&
      course.courseName.toLowerCase().includes(searchTerm.toLowerCase())
    )
    .sort((a, b) => sortOrder === 'asc' ? a.coursePrice - b.coursePrice : b.coursePrice - a.coursePrice);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="container mx-auto p-4">
      <label htmlFor="courseCategories" className="block text-gray-700 font-bold mb-2">Kategorie:</label>
      <select
        id="courseCategories"
        multiple
        onChange={handleCategoryChange}
        className="block w-full p-2 border border-gray-300 rounded mb-4"
      >
        {categories.map(({ label, value }) => (
          <option key={value} value={value}>
            {label}
          </option>
        ))}
      </select>

      <label htmlFor="courseSearch" className="block text-gray-700 font-bold mb-2">Szukaj:</label>
      <input
        type="text"
        id="courseSearch"
        value={searchTerm}
        onChange={handleSearchChange}
        placeholder="Szukaj po nazwie kursu"
        className="block w-full p-2 border border-gray-300 rounded mb-4"
      />

      <label htmlFor="sortOrder" className="block text-gray-700 font-bold mb-2">Sortuj wg ceny:</label>
      <select
        id="sortOrder"
        value={sortOrder}
        onChange={handleSortOrderChange}
        className="block w-full p-2 border border-gray-300 rounded mb-4"
      >
        <option value="asc">Rosnąco</option>
        <option value="desc">Malejąco</option>
      </select>

      <h1 className="text-2xl font-bold mb-4">Lista z kursami:</h1>
      <ul className="list-disc pl-5 space-y-4">
        {filteredCourses.map((course) => (
          <li key={course.courseId} className="border p-4 rounded shadow">
            <h2
              onClick={() => handleCourseClick(course.courseId)}
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

      {roles?.includes("ContentCreator") && (
        <button
          className="mt-4 bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
          onClick={redirectToCreateCourse}
        >
          Stworz Kurs
        </button>
      )}
    </div>
  );
};

export default CourseList;
