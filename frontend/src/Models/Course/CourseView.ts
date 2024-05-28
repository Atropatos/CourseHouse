import { Content } from "../Content/Content";

export interface CourseView {
    viewId: number;
    courseId:number;
    courseViewOrder:number;
    content:Content[];
}