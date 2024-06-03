import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { deleteCourse, getCourseById } from '../../../Services/courseService';
import { postCourseView } from '../../../Services/courseViewService';
import { Course } from '../../../Models/Course';
import { Content } from '../../../Models/Content/Content';
import ContentDisplay from '../../Content/ContentDisplay/ContentDisplay';
import { useAuth } from '../../../Context/useAuth';
import './CourseDetail.css';
import { postComment, getComments } from '../../../Services/commentService';
import { Comment } from '../../../Models/Comment';

const CourseDetail: React.FC = () => {
  const { courseId } = useParams<{ courseId: string }>();
  const [courseViewOrder, setCourseViewOrder] = useState<number>(0);
  const [content, setContent] = useState<Content[]>([]);
  const [course, setCourse] = useState<Course | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [commentContent, setCommentContent] = useState<string>(''); // Use `commentContent` to avoid conflict
  const [comments, setComments] = useState<Comment[]>([]);
  const { roles, fetchUserRoles } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCourse = async () => {
      if (courseId) {
        const courseIdNumber = Number(courseId);
        if (!isNaN(courseIdNumber)) {
          try {
            const data = await getCourseById(courseIdNumber);
            setCourse(data);
            const commentsData = await getComments(courseIdNumber);
            setComments(commentsData);
          } catch (err) {
            setError('Error fetching course details');
          } finally {
            setLoading(false);
          }
        } else {
          setError('Invalid course ID');
          setLoading(false);
        }
      } else {
        setError('No course ID provided');
        setLoading(false);
      }
    };
    fetchCourse();
  }, [courseId]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (!course) {
    return <div>No course found</div>;
  }

  const handleBackClick = () => {
    navigate('/');
  };

  const handleCourseViewChange = (viewId: number) => {
    navigate(`/courseView/${viewId}`);
  };

  const redirectToUpdateCourse = () => {
    navigate(`/updateCourse/${course.courseId}`);
  };

  const handleDeleteCourse = async () => {
    try {
      await deleteCourse(course.courseId);
      navigate(-1);
    } catch (error) {
      console.log(error);
    }
  };

  const handleCreateCourseView = async () => {
    if (courseId) {
      const courseIdNumber = Number(courseId);
      try {
        const newCourseView = {
          courseId: courseIdNumber,
          courseViewOrder,
          content
        };
        await postCourseView(newCourseView);
        const updatedCourse = await getCourseById(courseIdNumber);
        setCourse(updatedCourse);
      } catch (error) {
        setError("Error creating course view");
      }
    }
  };

  const handleAddComment = async () => {
    const courseIdNumber = Number(courseId);
    if (!isNaN(courseIdNumber) && commentContent.trim()) {
      try {
        await postComment(courseIdNumber, commentContent);
        const updatedComments = await getComments(courseIdNumber);
        setComments(updatedComments);
        setCommentContent(''); // Clear the textarea after successful post
      } catch (error) {
        console.log(error);
      }
    } else {
      setError('Comment content cannot be empty');
    }
  };

  return (
    <div className="container">
      <button className="back-button" onClick={handleBackClick}>Powrot do Listy z kursami</button>
      <h1>Nazwa kursu: {course.courseName}</h1>
      <p>Opis kursu: {course.courseDescription}</p>
      <p>Cena: {course.coursePrice.toFixed(2)} PLN</p>

      <h2>Widok kursu:</h2>
      {course.courseViews.map((view) => (
        <div key={view.viewId} className="course-view">
          <h3 onClick={() => handleCourseViewChange(view.viewId)} style={{ cursor: "pointer" }}>
            Lekcja {view.courseViewOrder}
          </h3>
          {view.content.map((content: Content) => (
            <div key={content.contentId} className="content-item">
              <ContentDisplay content={content} />
            </div>
          ))}
        </div>
      ))}
      {roles?.includes("ContentCreator") && (
        <div className="button-container">
          <button className="green-button" onClick={handleCreateCourseView}>Utworz nowa lekcje</button>
          <button className="green-button" onClick={redirectToUpdateCourse}>Edytuj kurs</button>
          <button className="red-button" onClick={handleDeleteCourse}>Usuń kurs</button>
        </div>
      )}
      {roles?.includes("User") && (
        <>
            <label htmlFor="komentarz">Dodaj Komentarz: </label>
      <textarea 
        id="komentarz" 
        value={commentContent} 
        onChange={(e) => setCommentContent(e.target.value)} 
      />
      <button className="green-button" onClick={handleAddComment}>Dodaj komentarz</button>

        </>

      )}
  
      <h2>Komentarze:</h2>
  
      <div className="comments">
        {comments.map((comment) => (
          <div key={comment.commentId} className="comment">
            <p>{comment.authorName}: {comment.commentContent}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default CourseDetail;
