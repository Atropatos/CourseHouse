import { UserProfile } from "../User";
import { CourseCategory } from "./CourseCategory";
import { CourseComment } from "./CourseComment";
import { CourseGrade } from "./CourseGrade";
import { CourseView } from "./CourseView";

// src/models/Course.ts
export interface Course {
  courseId: number;
  courseName: string;
  coursePrice: number;
  courseDescription: string;
  createdBy: string;
  courseCategories: CourseCategory[];
  enrolledUsers: UserProfile[];
  comments: CourseComment[];  
  grades: CourseGrade[]; 
  courseViews: CourseView[];  
}


