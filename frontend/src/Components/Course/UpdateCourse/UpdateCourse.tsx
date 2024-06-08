import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getCategories, getCourseById, updateCourse } from '../../../Services/courseService';
import { CourseCategory } from '../../../Models/Course/CourseCategory';

interface MappedCategory {
  label: string;
  value: number;
}

const UpdateCourse: React.FC = () => {
  const { courseId } = useParams<{ courseId: string }>();
  const [courseName, setCourseName] = useState('');
  const [coursePrice, setCoursePrice] = useState('');
  const [courseDescription, setCourseDescription] = useState('');
  const [categories, setCategories] = useState<MappedCategory[]>([]);
  const [selectedCategoryIds, setSelectedCategoryIds] = useState<number[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCategoriesAndCourse = async () => {
      try {
        const fetchedCategories = await getCategories();
        const formattedCategories = fetchedCategories.map((category: any) => ({
          label: category.courseCategoryName,
          value: category.courseCategoryId,
        }));
        setCategories(formattedCategories);

        if (courseId) {
          const fetchedCourse = await getCourseById(parseInt(courseId));
          setCourseName(fetchedCourse.courseName);
          setCoursePrice(fetchedCourse.coursePrice.toString());
          setCourseDescription(fetchedCourse.courseDescription);
          // setCategories(fetchedCourse.courseCategories.map((category: CourseCategory) => ({
          //   label: category.categoryName,
          //   value: category.courseCategoryId,
          // })));
          setSelectedCategoryIds(fetchedCourse.courseCategories.map((cat: CourseCategory) => cat.categoryId));
          
        }
      } catch (err) {
        setError('Error fetching data');
      } finally {
        setIsLoading(false);
      }
    };

    fetchCategoriesAndCourse();
  }, [courseId]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setError(null);

    try {
      const course = {
        courseId: parseInt(courseId!), // Ensure courseId is a number
        courseName,
        coursePrice: parseFloat(coursePrice),
        courseDescription,
        categoryIds: selectedCategoryIds,
      };

      await updateCourse(course);
      navigate(`/course/${courseId}`);
    } catch (err) {
      setError('Error updating course');
    }
  };

  const handleCategoryChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedOptions = Array.from(event.target.selectedOptions).map(option => parseInt(option.value));
    setSelectedCategoryIds(selectedOptions);
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <div className="max-w-2xl mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Edytuj kurs</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label htmlFor="courseName" className="block text-gray-700">Nazwa kursu</label>
          <input
            type="text"
            id="courseName"
            value={courseName}
            onChange={(e) => setCourseName(e.target.value)}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="coursePrice" className="block text-gray-700">Cena kursu</label>
          <input
            type="number"
            id="coursePrice"
            value={coursePrice}
            onChange={(e) => setCoursePrice(e.target.value)}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="courseDescription" className="block text-gray-700">Opis kursu</label>
          <textarea
            id="courseDescription"
            value={courseDescription}
            onChange={(e) => setCourseDescription(e.target.value)}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="courseCategories" className="block text-gray-700">Kategorie</label>
          <select
            id="courseCategories"
            multiple
            onChange={handleCategoryChange}
            value={selectedCategoryIds.map(String)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          >
            {categories.map(({ label, value }) => (
              <option key={value} value={value}>
                {label}
              </option>
            ))}
          </select>
        </div>
        <button
          type="submit"
          className="w-full py-2 px-4 bg-blue-500 hover:bg-blue-700 text-white font-bold rounded focus:outline-none focus:shadow-outline"
        >
          Zatwierdź
        </button>
        {error && <p className="text-red-500">{error}</p>}
      </form>
    </div>
  );
};

export default UpdateCourse;
