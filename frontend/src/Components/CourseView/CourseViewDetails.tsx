import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import { deleteCourseView, getCourseViewById } from '../../Services/courseViewService';
import { CourseView } from '../../Models/Course/CourseView';
import { Content } from '../../Models/Content/Content';
import { useAuth } from '../../Context/useAuth';
import './CourseViewDetails.css';

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
    <div className="container">
      <div key={courseView?.viewId}>
        <h3>Lekcja {courseView?.courseViewOrder}</h3>
        {courseView?.content.map((content: Content) => (
          <div key={content.contentId} className="content-item">
            <h2
              onClick={() => NavigateToUpdateContent(content.contentId)}
              className="content-title"
            >
              {content.title}
            </h2>
            <p>{content.text}</p>
          </div>
        ))}
      </div>

      {roles?.includes("ContentCreator") && (
        <div className="button-container">
          <button className="add-content-button" onClick={NavigateToAddContent}>Dodaj zawartość lekcji</button>
          <button className="delete-button" onClick={handleDelete}>Usuń lekcję</button>
        </div>
      )}
    </div>
  );
}

export default CourseViewDetails;
