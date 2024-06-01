import axios from "axios";
import { Content } from "../Models/Content/Content";

const api = "http:://localhost:5010/api/";

export const postContent = async (content: Omit<Content, "contentId">): Promise<Content> => {
    try {
        const response = await axios.post<Content>(`${api}content`, content);
        return response.data;
    } catch (error) {
      //  console.error('Error details:', error.response ? error.response.data : error.message);
        throw new Error("Error while posting content");
    }
};
    

