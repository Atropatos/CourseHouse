import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandler';
import {Course, CourseCategory} from "../Models/Course";
import { CourseView } from '../Models/Course/CourseView';


const api ="http://localhost:5010/api/";


export const postCourseView = async (courseView: Omit<CourseView, 'viewId'>): Promise<CourseView> => {
    try {
        const response = await axios.post<CourseView>(`${api}courseView`, courseView); // Ensure the endpoint is correct
        return response.data;
    } catch (error) {
        throw new Error('Error posting course view');
    }
};

  export const getCourseViewById = async(viewId: number) => {
        try {
            const response = await axios.get<CourseView>(`${api}courseView/${viewId}`);
            return response.data;
        } catch (error){
            throw new Error("Error while gettigCourseViewById");
        };
    }
        export const deleteCourseView = async (viewId:number) => {
            try {
                await axios.delete(`${api}courseView/${viewId}`);
            } catch(error) {
                throw new Error('Error while deleting course');
            }
        }
        
  
  