
import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandler';
import { Course } from '../Models/Course/Course';
import { CourseCategory } from '../Models/Course/CourseCategory';
const api = 'http://localhost:5010/api/';

export const getCourses = async (): Promise<Course[]> => {
  try {
    const response = await axios.get<Course[]>(api + "course");
    return response.data;
  } catch (error) {
    handleError(error);
    return []; // Return an empty array in case of error to prevent crashing
  }
};

export const getCoursesByUser = async (): Promise<Course[]> => {
  try {
    const response = await axios.get<Course[]>(api + "course/user-courses");
    console.log(response.data);
    return response.data;
  } catch (error) {
    handleError(error);
    return [];
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

export const createCourse = async (
  course: Omit<
    Course,
    | "courseId"
    | "createdBy"
    | "courseCategories"
    | "enrolledUsers"
    | "comments"
    | "grades"
    | "courseViews"
  > & { categoryIds: number[] }
) => {
  try {
    const response = await axios.post(`${api}course`, course, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const updateCourse = async (
  course: Omit<
    Course,
    | "createdBy"
    | "courseCategories"
    | "enrolledUsers"
    | "comments"
    | "grades"
    | "courseViews"
  >
): Promise<Course> => {
  try {
    const response = await axios.put<Course>(
      `${api}course/${course.courseId}`,
      course
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const deleteCourse = async (courseId: number) => {
  try {
    const response = await axios.delete(`${api}course/${courseId}`);
  } catch (error) {
    handleError(error);
  }
};
export const getCategories = async(): Promise<CourseCategory[]> => {
    try {
        const response = await axios.get<CourseCategory[]>(api + 'course-category');
        return response.data;
    } catch (error) {
        handleError(error);
        return[];
    }
    }


export const postLastVisited = async (lastVisitedCourseId: number) => {
    try {
      const response = await axios.post(`http://localhost:5010/api/lastVisited`, { lastVisitedCourseId});
    return response.data;
    }
 catch(error) {
  handleError(error);

}
}
export const getLastFiveVisitedCourses = async () => {
    const response = await axios.get(`http://localhost:5010/api/lastFive`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
        }
    });
    return response.data;
};