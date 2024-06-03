import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router'
import { deleteCourseView, getCourseViewById } from '../Services/courseViewService';
import { CourseView } from '../Models/Course/CourseView';
import ContentDisplay from './ContentDisplay';
import { Content } from '../Models/Content/Content';
import { log } from 'console';
import { useAuth } from '../Context/useAuth';


const CourseViewDetails: React.FC = () => {
    const {viewId} = useParams<{viewId:string}>();
    const [courseView,setCourseView] = useState<CourseView | null>(null);
   //const [selectedContent, setSelectedContent] = useState<Content | null>(null);
    const navigate = useNavigate();
    const {roles,fetchUserRoles} = useAuth();
    useEffect( () => {
        const fetchCourseView = async() => {
            if(viewId) {
                const viewIdNumber = Number(viewId);
               
                const data = await getCourseViewById(viewIdNumber);
                
                setCourseView(data);
                
            };
        }
        fetchCourseView();
    }, [viewId]);
    

    const handleDelete = async() => {
      if(viewId) {
        const courseId = courseView?.courseId;
        console.log(courseView?.viewId);
        console.log(courseView?.courseId);
        const viewIdNumber = Number(viewId);
        await deleteCourseView(viewIdNumber);
        navigate(-1);
      }
    }
    
    const NavigateToAddContent = async () => {
      navigate(`/courseView/${courseView?.viewId}/addContent`)
    }

    const NavigateToUpdateContent = (contentId:number) => {
      navigate(`/updateContent/${contentId}`);
    }

    //{ path: "updateContent/:contentId", element: <UpdateContent/>}
    return (
      <div>
        <div key={courseView?.viewId}>
          <h3>Lekcja {courseView?.courseViewOrder}</h3>
          {courseView?.content.map((content: Content) => (
            <div key={content.contentId}>
              <h2
                onClick={() => NavigateToUpdateContent(content.contentId)}
                style={{ cursor: 'pointer', textDecoration: 'underline', color: 'blue' }}
              >
                {content.title}
              </h2>
              <p>{content.text}</p>
            </div>
          ))}
        </div>

          {roles?.includes("ContentCreator")
          && (<div>
             <button onClick= {NavigateToAddContent}>Dodaj zawartość lekcji</button>
            <button onClick={(handleDelete)}>Usun lekcje</button>
            </div>
          )}
   
    </div>
  )
}

export default CourseViewDetails