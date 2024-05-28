import { ContentType } from "./ContentType";

export interface Content {
    contentId: number;
    order: number;
    courseViewId: number;
    title: string;
    text: string;
    contentUrl: string;
    correct: boolean;
    contentType: ContentType; 
  }

