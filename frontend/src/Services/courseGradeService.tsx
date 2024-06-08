import axios from "axios";
import { CourseGrade } from "../Models/Course/CourseGrade";

const api = "http://localhost:5010/api/";


export const postGrade = async (courseId: number, grade: number) => {
    try {
        const response = await axios.post(`${api}grade`, { courseId, grade });
        return response.data;
    } catch (error) {
        if (axios.isAxiosError(error) && error.response) {
            if (error.response.status === 400) {
                throw new Error("User has already submitted a grade for this course.");
            }
        }
        throw new Error("Error while posting grade");
    }
}
    export const getGradesFromCourse = async (courseId:number) => {

        try{
            const response = await axios.get<CourseGrade[]>(`${api}grade/course/${courseId}`);
            return response.data;
        } catch(error) {
            throw new Error("error while getting grades from course");
        }
    }

    export const getAverageGrade = async (courseId: number) => {
         try {
            const response = await axios.get<number>(`${api}grade/course/${courseId}/average`);
            return response.data;
         } catch (error) {
            throw new Error("error while getting average grade");
         }
    }
