import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createCourse, getCategories } from '../../../Services/courseService';
import { CourseCategory } from '../../../Models/Course/CourseCategory';

interface MappedCategory {
  label: string;
  value: number;
}

const CreateCourse: React.FC = () => {
  const [courseName, setCourseName] = useState('');
  const [coursePrice, setCoursePrice] = useState('');
  const [courseDescription, setCourseDescription] = useState('');
  const [categories, setCategories] = useState<MappedCategory[]>([]);
  const [selectedCategoryIds, setSelectedCategoryIds] = useState<number[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const data = await getCategories();
        console.log('Fetched categories:', data);

        // Map the fetched categories to the format expected by the dropdown
        const formattedCategories = data.map((category: any) => ({
          label: category.courseCategoryName,
          value: category.courseCategoryId,
        }));

        console.log('Formatted categories:', formattedCategories);
        setCategories(formattedCategories);
        setIsLoading(false);
      } catch (err) {
        setError('Error fetching categories');
        setIsLoading(false);
      }
    };

    fetchCategories();
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setError(null);

    try {
      const course = {
        courseName,
        coursePrice: parseFloat(coursePrice),
        courseDescription,
        categoryIds: selectedCategoryIds,
      };

      await createCourse(course);
      navigate('/');
    } catch (err) {
      setError('Error creating course');
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
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Tworzenie kursu</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label htmlFor="courseName" className="block text-gray-700 font-bold mb-2">Nazwa kursu:</label>
          <input
            type="text"
            id="courseName"
            value={courseName}
            onChange={(e) => setCourseName(e.target.value)}
            required
            className="block w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <div>
          <label htmlFor="coursePrice" className="block text-gray-700 font-bold mb-2">Cena kursu:</label>
          <input
            type="number"
            id="coursePrice"
            value={coursePrice}
            onChange={(e) => setCoursePrice(e.target.value)}
            required
            className=" block w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <div>
          <label htmlFor="courseDescription" className="block text-gray-700 font-bold mb-2">Opis kursu:</label>
          <textarea
            id="courseDescription"
            value={courseDescription}
            onChange={(e) => setCourseDescription(e.target.value)}
            required
            className="block w-full p-2 border border-gray-300 rounded"
          />
        </div>
        <div>
          <label htmlFor="courseCategories" className="block text-gray-700 font-bold mb-2">Kategorie:</label>
          <select
            id="courseCategories"
            multiple
            onChange={handleCategoryChange}
            className="block w-full p-2 border border-gray-300 rounded"
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
          className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600"
        >
          Stwórz kurs
        </button>
        {error && <p className="text-red-500 mt-2">{error}</p>}
      </form>
    </div>
  );
};

export default CreateCourse;
