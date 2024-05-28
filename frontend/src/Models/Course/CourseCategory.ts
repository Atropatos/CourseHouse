import { CourseCategoryMapping } from "./CourseCategoryMapping";

export interface CourseCategory {
    categoryId: number;
    categoryName: string;
    courseCategoryMappings: CourseCategoryMapping[];
  }