import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { deleteCourse, getCourseById } from '../../../Services/courseService';
import { postCourseView } from '../../../Services/courseViewService';
import { Course } from '../../../Models/Course';
import { Content } from '../../../Models/Content/Content';
import ContentDisplay from '../../Content/ContentDisplay/ContentDisplay';
import { useAuth } from '../../../Context/useAuth';
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
    <div className="container mx-auto p-4">
      <button className="mb-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600" onClick={handleBackClick}>
        Powrot do Listy z kursami
      </button>
      <h1 className="text-2xl font-bold mb-4">Nazwa kursu: {course.courseName}</h1>
      <p className="mb-2">Opis kursu: {course.courseDescription}</p>
      <p className="mb-4">Cena: {course.coursePrice.toFixed(2)} PLN</p>

      <h2 className="text-xl font-semibold mb-4">Widok kursu:</h2>
      {course.courseViews.map((view) => (
        <div key={view.viewId} className="mb-4 p-4 border rounded shadow">
          <h3
            onClick={() => handleCourseViewChange(view.viewId)}
            className="cursor-pointer text-blue-600 hover:underline"
          >
            Lekcja {view.courseViewOrder}
          </h3>
          {view.content.map((content: Content) => (
            <div key={content.contentId} className="mt-2">
              <ContentDisplay content={content} />
            </div>
          ))}
        </div>
      ))}
      {roles?.includes("ContentCreator") && (
        <div className="mt-4 space-x-2">
          <button
            className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
            onClick={handleCreateCourseView}
          >
            Utworz nowa lekcje
          </button>
          <button
            className="bg-yellow-500 text-white py-2 px-4 rounded hover:bg-yellow-600"
            onClick={redirectToUpdateCourse}
          >
            Edytuj kurs
          </button>
          <button
            className="bg-red-500 text-white py-2 px-4 rounded hover:bg-red-600"
            onClick={handleDeleteCourse}
          >
            Usuń kurs
          </button>
        </div>
      )}
      {roles?.includes("User") && (
        <>
          <label htmlFor="komentarz" className="block text-gray-700 font-bold mt-4 mb-2">Dodaj Komentarz:</label>
          <textarea
            id="komentarz"
            value={commentContent}
            onChange={(e) => setCommentContent(e.target.value)}
            className="block w-full p-2 border border-gray-300 rounded mb-2"
          />
          <button
            className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
            onClick={handleAddComment}
          >
            Dodaj komentarz
          </button>
        </>
      )}
  
      <h2 className="text-xl font-semibold mt-4 mb-2">Komentarze:</h2>
      <div className="space-y-2">
        {comments.map((comment) => (
          <div key={comment.commentId} className="p-2 border rounded shadow">
            <p className="text-gray-700">{comment.authorName}: {comment.commentContent}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default CourseDetail;
