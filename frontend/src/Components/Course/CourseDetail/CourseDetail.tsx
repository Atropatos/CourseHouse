import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteCourse, getCourseById, getCourseVisitCount } from '../../../Services/courseService';
import { getAverageGrade, postGrade } from '../../../Services/courseGradeService';
import { Course } from '../../../Models/Course/Course';
import { Comment } from '../../../Models/Comment';
import { getComments, postComment } from '../../../Services/commentService';
import { useAuth } from '../../../Context/useAuth';
import StarRating from '../../StarRating'; // Adjust the import path as necessary
import { Content } from '../../../Models/Content/Content';
import { postCourseView } from '../../../Services/courseViewService';
import ContentDisplay from '../../Content/ContentDisplay/ContentDisplay';

const CourseDetail: React.FC = () => {
  const { courseId } = useParams<{ courseId: string }>();
  const [courseViewOrder, setCourseViewOrder] = useState<number>(0);
  const [content, setContent] = useState<Content[]>([]);
  const [course, setCourse] = useState<Course | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [commentContent, setCommentContent] = useState<string>('');
  const [comments, setComments] = useState<Comment[]>([]);
  const { roles } = useAuth();
  const navigate = useNavigate();
  const [rating, setRating] = useState<number>(0);
  const [averageRating, setAverageRating] = useState<number>(0);
  const[courseVisitedNumber, setCourseVisitedNumber] = useState<number>(0);


  
 



  const fetchCourse = async () => {
    if (courseId) {
      try {
        const courseIdNumber = Number(courseId);
        const data = await getCourseById(courseIdNumber);
        setCourse(data);
        const commentsData = await getComments(courseIdNumber);
        setComments(commentsData);
        const averageRatingData = await getAverageGrade(courseIdNumber);
        setAverageRating(averageRatingData);
      } catch (err) {
        setError('Error fetching course details');
      } finally {
        setLoading(false);
      }
    }
  }

  const fetchCourseVisitedNumber = async() => {
    if(courseId) {
      try {
        const courseIdNumber = Number(courseId);
        const visitCounter = await getCourseVisitCount(courseIdNumber);
        setCourseVisitedNumber(visitCounter);
      
      }
      catch (error) {
        setError("error fetching coursevisitNumber");
      }
    }
  }

  useEffect(() => {
    fetchCourse();
    fetchCourseVisitedNumber();
  }, [courseId]);

  const handleGradeSubmit = async () => {
    if (courseId && rating > 0) {
      const courseIdNumber = Number(courseId);
      try {
        console.log(rating);
        console.log(Number(courseIdNumber));
        await postGrade(Number(courseIdNumber), rating);
        await fetchCourse();
       
      } catch (error: any) {
        if (error.message === "User has already submitted a grade for this course.") {
            setError(error.message);
        } else {
            setError('Error submitting grade');
        }
    }
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
    if (courseId && commentContent.trim()) {
      try {
        await postComment(Number(courseId), commentContent);
        const updatedComments = await getComments(Number(courseId));
        setComments(updatedComments);
        setCommentContent('');
      } catch (error) {
        setError('Error adding comment');
      }
    }
  };
  const redirectToUpdateCourse = () => {
    if(course?.courseId) {
      navigate(`/updateCourse/${course.courseId}`);

    }
  };

  const handleDeleteCourse = async () => {
    try {
      if(course?.courseId) {
        await deleteCourse(course.courseId);
        navigate(-1);
      }
      
    } catch (error) {
      console.log(error);
    }
  };
  const handleCourseViewChange = (viewId: number) => {
    navigate(`/courseView/${viewId}`);
  };
  const handleBackClick = () => {
    navigate('/');
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  if (!course) {
    return <div>No course found</div>;
  }

  return (
    <div className="container mx-auto p-4">
      <button className="mb-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600" onClick={handleBackClick}>
        Powrot do Listy z kursami
      </button>
      <h1 className="text-2xl font-bold mb-4">Nazwa kursu: {course.courseName}</h1>
      <p className="mb-2">Opis kursu: {course.courseDescription}</p>
      <p className="mb-4">Cena: {course.coursePrice.toFixed(2)} PLN</p>
      <p className="mb-4">Średnia ocena: {averageRating > 0 ? averageRating.toFixed(2) : "brak opinii"}</p>
      {roles?.includes("ContentCreator") && (<p className="mb-4">Popularność: {courseVisitedNumber} odwiedzeń</p>) }
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
        <div>
          <label className="block text-gray-700 font-bold mb-2">Dodaj ocenę:</label>
          <StarRating rating={rating} onRatingChange={setRating} />
          <button
            className="mt-2 bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600"
            onClick={handleGradeSubmit}
          >
            Dodaj ocenę
          </button>
        </div>
      )}
      

      <h2 className="text-xl font-semibold mt-4 mb-2">Komentarze:</h2>
      <div className="space-y-2">
        {comments.map((comment) => (
          <div key={comment.commentId} className="p-2 border rounded shadow">
            <p className="text-gray-700">{comment.authorName}: {comment.commentContent}</p>
          </div>
        ))}
      </div>
      
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
    </div>
  );
};

export default CourseDetail;
