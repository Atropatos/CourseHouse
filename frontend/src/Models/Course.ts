import { UserProfile } from "./User";

// src/models/Course.ts
export interface Course {
  courseId: number;
  courseName: string;
  coursePrice: number;
  courseDescription: string;
  createdBy: string;
  courseCategories: CourseCategory[];
  enrolledUsers: UserProfile[];
  comments: any[];  // Define more specific types if available
  grades: any[];  // Define more specific types if available
  courseViews: any[];  // Define more specific types if available
}

export interface CourseCategory {
  categoryId: number;
  categoryName: string;
  courseCategoryMappings: CourseCategoryMapping[];
}

export interface CourseCategoryMapping {
  courseId: number;
  categoryId: number;
}