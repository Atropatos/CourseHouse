import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createCourse, getCategories } from '../Services/courseService';

import { CourseCategory } from '../Models/Course';

const CreateCourse: React.FC = () => {
    const [courseName, setCourseName] = useState('');
    const [coursePrice, setCoursePrice] = useState('');
    const [courseDescription, setCourseDescription] = useState('');
    const [categories, setCategories] = useState<CourseCategory[]>([]);
    const [selectedCategoryIds, setSelectedCategoryIds] = useState<number[]>([]);
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();
  
    useEffect(() => {
      const fetchCategories = async () => {
        try {
          const data = await getCategories();
          setCategories(data);
        } catch (err) {
          setError('Error fetching categories');
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
          categoryIds: [1,2],
        };
  
        await createCourse(course);
        navigate('/');
      } catch (err) {
        setError('Error creating course');
      }
    };
  
    const handleCategoryChange = (categoryId: number) => {
      setSelectedCategoryIds((prev) =>
        prev.includes(categoryId)
          ? prev.filter((id) => id !== categoryId)
          : [...prev, categoryId]
      );
    };
  
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
            <label>Categories</label>
            {categories.map((category) => (
              <div key={category.categoryId}>
                <input
                  type="checkbox"
                  id={`category-${category.categoryId}`}
                  value={category.categoryId}
                  onChange={() => handleCategoryChange(category.categoryId)}
                />
                <label htmlFor={`category-${category.categoryId}`}>{category.categoryName}</label>
              </div>
            ))}
          </div>
          <button type="submit">Create Course</button>
          {error && <p>{error}</p>}
        </form>
      </div>
    );
  };
  
  export default CreateCourse;