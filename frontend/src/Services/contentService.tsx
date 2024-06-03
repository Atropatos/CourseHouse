import axios from "axios";
import { Content } from "../Models/Content/Content";

const api = "http://localhost:5010/api/";

export const postContent = async (content: Omit<Content, "contentId">): Promise<Content> => {
    try {
        const response = await axios.post<Content>(`${api}content`, content);
        return response.data;
    } catch (error) {
      //  console.error('Error details:', error.response ? error.response.data : error.message);
        throw new Error("Error while posting content");
    }
};

export const getContent = async(contentId:number): Promise<Content> => {
    try {
        const response = await axios.get<Content>(`${api}content/${contentId}`);
        return response.data;
    } catch( error) {
        throw new Error("error while getting content");
    }

    
}



    
export const updateContent = async (content:Content): Promise<Content> => {
    try {
        const response = await axios.put<Content>(`${api}content/${content.contentId}`, content);
        return response.data;
    } catch (error) {
        throw new Error("Error while updating content");
    }
}


export const deleteContent = async(contentId:number) => {
    try {
        const response = await axios.delete(`${api}content/${contentId}`);
    } catch(error) {
        throw new Error("Error while deleting content");
    }
}