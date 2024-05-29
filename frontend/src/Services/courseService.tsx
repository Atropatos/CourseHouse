
import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandler';
import {Course, CourseCategory} from "../Models/Course";

const api = 'http://localhost:5010/api/';

export const getCourses = async (): Promise<Course[]> => {
  try {
    const response = await axios.get<Course[]>(api + 'course');
    return response.data;
  } catch (error) {
    handleError(error);
    return [];  // Return an empty array in case of error to prevent crashing
  }
};

export const getCourseById = async (courseId: number): Promise<Course> => {
  try {
    const response = await axios.get<Course>(`${api}course/${courseId}`);
    return response.data;
  } catch (error) {
    handleError(error);
    throw error;
  }
};

export const createCourse = async (course: Omit<Course, 'courseId' | 'createdBy' | 'courseCategories' | 'enrolledUsers' | 'comments' | 'grades' | 'courseViews'> & { categoryIds: number[] }) => {
  try {
    const response = await axios.post(`${api}course`, course, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};
// export const addCourse = async (course: Course) => {
//   try {
//     const response = await axios.post<Course>(api + 'course');
//     return response.data;
//   } catch (error) {
//     handleError(error);
//   }
// };

export const getCategories = async(): Promise<CourseCategory[]> => {
    try {
        const response = await axios.get<CourseCategory[]>(api + 'course-category');
        return response.data;
    } catch (error) {
        handleError(error);
        return[];
    }
};
