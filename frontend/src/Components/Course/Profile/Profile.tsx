import React, { useEffect, useState } from "react";
import { getPurchasedByUser } from "../../../Services/purchaseService";
import { Purchase } from "../../../Models/Purchase";
import { getCategories, getCourses } from "../../../Services/courseService";
import { Course } from "../../../Models/Course/Course";
import { useNavigate } from "react-router";

const Profile = () => {
  const [userPurchasedCourses, setUserPurchasedCourses] = useState<Purchase[]>(
    []
  );
  const [courses, setCourses] = useState<Course[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchPurchases();
    fetchCourses();
  }, []);

  const fetchPurchases = async () => {
    try {
      let purchases = await getPurchasedByUser();
      setUserPurchasedCourses(purchases);
    } catch (error) {
      console.error("Error fetching purchases:", error);
    }
  };

  const fetchCourses = async () => {
    try {
      let fetchedCourses = await getCourses();
      setCourses(fetchedCourses);
    } catch (err) {
      console.log("Error fetching courses");
    }
  };

  const navitageToCourse = (courseId: number) => {
    navigate(`/course/${courseId}`);
  };

  return (
    <div className="flex justify-center">
      <div className="max-w-lg mx-auto">
        <h1 className="text-3xl font-bold text-green-600 mb-6">Profile</h1>
        <div>
          <h2 className="text-xl font-bold text-blue-600 mb-4">
            Zakupione kursy
          </h2>
          {userPurchasedCourses.map((purchase, index) => (
            <div
              key={index}
              className="bg-gray-100 shadow-lg rounded-lg p-6 mb-6"
            >
              <p className="font-bold text-green-700">
                ID KURSU: {purchase.courseId}
              </p>
              <p className="text-gray-600">
                DATA ZAKUPU: {new Date(purchase.purchasedOn).toLocaleString()}
              </p>
              <p className="text-gray-600">WYDANO: {purchase.spend}</p>
              {courses
                .filter((course) => course.courseId === purchase.courseId)
                .map((course, index) => (
                  <div key={index} className="mt-4">
                    <p className="font-bold text-blue-600">
                      Nazwa: {course.courseName}
                    </p>
                    <p className="text-gray-700">
                      Opis: {course.courseDescription}
                    </p>
                    <p className="text-gray-700">
                      Kategorie:{" "}
                      {course.courseCategories
                        .map((category) => category.categoryName)
                        .join(", ")}
                    </p>
                  </div>
                ))}
              <button
                className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 mt-4"
                onClick={() => navitageToCourse(purchase.courseId)}
              >
                Przejdź do kursu
              </button>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Profile;
