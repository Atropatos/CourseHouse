import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getCourseById } from '../../../Services/courseService';
import { getAverageGrade, postGrade } from '../../../Services/courseGradeService';
import { Course } from '../../../Models/Course/Course';
import { Comment } from '../../../Models/Comment';
import { getComments, postComment } from '../../../Services/commentService';
import { useAuth } from '../../../Context/useAuth';
import StarRating from '../../StarRating'; // Adjust the import path as necessary

const CourseDetail: React.FC = () => {
  const { courseId } = useParams<{ courseId: string }>();
  const [course, setCourse] = useState<Course | null>(null);
  const [comments, setComments] = useState<Comment[]>([]);
  const [rating, setRating] = useState<number>(0);
  const [averageRating, setAverageRating] = useState<number>(0);

  const [commentContent, setCommentContent] = useState<string>('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const { roles } = useAuth();
  const navigate = useNavigate();


  const fetchCourse = async () => {
    if (courseId) {
      try {
        const data = await getCourseById(Number(courseId));
        setCourse(data);
        const commentsData = await getComments(Number(courseId));
        setComments(commentsData);
        const averageRatingData = await getAverageGrade(Number(courseId));
        setAverageRating(averageRatingData);
      } catch (err) {
        setError('Error fetching course details');
      } finally {
        setLoading(false);
      }
    }
  }

  useEffect(() => {
    fetchCourse();
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
      <h1 className="text-2xl font-bold mb-4">Nazwa kursu: {course.courseName}</h1>
      <p className="mb-2">Opis kursu: {course.courseDescription}</p>
      <p className="mb-4">Cena: {course.coursePrice.toFixed(2)} PLN</p>
      <p className="mb-4">Średnia ocena: {averageRating > 0 ? averageRating.toFixed(2) : "brak ocen"}</p>

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
