import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createCourse, getCategories } from '../Services/courseService';

import { CourseCategory } from '../Models/Course';
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
      <div>
        <h1>Create Course</h1>
        <form onSubmit={handleSubmit}>
          <div>
            <label htmlFor="courseName">Course Name</label>
            <input
              type="text"
              id="courseName"
              value={courseName}
              onChange={(e) => setCourseName(e.target.value)}
              required
            />
          </div>
          <div>
            <label htmlFor="coursePrice">Course Price</label>
            <input
              type="number"
              id="coursePrice"
              value={coursePrice}
              onChange={(e) => setCoursePrice(e.target.value)}
              required
            />
          </div>
          <div>
            <label htmlFor="courseDescription">Course Description</label>
            <textarea
              id="courseDescription"
              value={courseDescription}
              onChange={(e) => setCourseDescription(e.target.value)}
              required
            />
          </div>
          <div>
            <label htmlFor="courseCategories">Categories</label>
            <select id="courseCategories" multiple onChange={handleCategoryChange}>
              {categories.map(({ label, value }) => (
                <option key={value} value={value}>
                  {label}
                </option>
              ))}
            </select>
          </div>
          <button type="submit">Create Course</button>
          {error && <p>{error}</p>}
        </form>
      </div>
    );
  };
  
  export default CreateCourse;