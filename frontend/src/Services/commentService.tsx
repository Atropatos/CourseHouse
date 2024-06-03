


import axios from "axios";

import { Comment } from "../Models/Comment";

const api = "http://localhost:5010/api/";

export const postComment = async (courseId: number, commentContent: string): Promise<Comment> => {
    try {
        const response = await axios.post<Comment>(`${api}comment`, { courseId, commentContent });
        return response.data;
    } catch (error) {
        throw new Error("Error while posting comment");
    }
}


export const getComments = async (courseId:number): Promise<Comment[]> => {
    try {
        const response = await axios.get<Comment[]>(`${api}comment/course/${courseId}`);
        return response.data;
    } catch (error) {
        throw new Error("Error while getting comments");
    }
}