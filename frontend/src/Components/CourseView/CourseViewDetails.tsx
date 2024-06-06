import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import { deleteCourseView, getCourseViewById } from '../../Services/courseViewService';
import { CourseView } from '../../Models/Course/CourseView';
import { Content } from '../../Models/Content/Content';
import { useAuth } from '../../Context/useAuth';

const CourseViewDetails: React.FC = () => {
  const { viewId } = useParams<{ viewId: string }>();
  const [courseView, setCourseView] = useState<CourseView | null>(null);
  const navigate = useNavigate();
  const { roles, fetchUserRoles } = useAuth();

  useEffect(() => {
    const fetchCourseView = async () => {
      if (viewId) {
        const viewIdNumber = Number(viewId);
        const data = await getCourseViewById(viewIdNumber);
        setCourseView(data);
      }
    };
    fetchCourseView();
  }, [viewId]);

  const handleDelete = async () => {
    if (viewId) {
      const viewIdNumber = Number(viewId);
      await deleteCourseView(viewIdNumber);
      navigate(-1);
    }
  };

  const NavigateToAddContent = async () => {
    navigate(`/courseView/${courseView?.viewId}/addContent`);
  };

  const NavigateToUpdateContent = (contentId: number) => {
    navigate(`/updateContent/${contentId}`);
  };

  return (
    <div className="container mx-auto p-4">
      <div key={courseView?.viewId}>
        <h3 className="text-xl font-bold mb-4">Lekcja {courseView?.courseViewOrder}</h3>
        {courseView?.content.map((content: Content) => (
          <div key={content.contentId} className="content-item mb-4 p-4 border rounded shadow">
            <h2
              onClick={() => NavigateToUpdateContent(content.contentId)}
              className="content-title text-lg font-semibold cursor-pointer text-blue-500"
            >
              {content.title}
            </h2>
            <p>{content.text}</p>
          </div>
        ))}
      </div>

      {roles?.includes("ContentCreator") && (
        <div className="flex space-x-4 mt-4">
          <button
            className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
            onClick={NavigateToAddContent}
          >
            Dodaj zawartość lekcji
          </button>
          <button
            className="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600"
            onClick={handleDelete}
          >
            Usuń lekcję
          </button>
        </div>
      )}
    </div>
  );
}

export default CourseViewDetails;
