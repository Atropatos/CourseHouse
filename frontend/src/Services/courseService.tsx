
import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandler';
import {Course} from "../Models/Course";

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

