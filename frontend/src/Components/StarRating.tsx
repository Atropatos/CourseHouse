import React, { useState } from 'react';

interface StarRatingProps {
  rating: number;
  onRatingChange: (rating: number) => void;
}

const StarRating: React.FC<StarRatingProps> = ({ rating, onRatingChange }) => {
  const [hoverRating, setHoverRating] = useState<number>(0);

  return (
    <div className="flex space-x-1">
      {[1, 2, 3, 4, 5].map((star) => (
        <svg
          key={star}
          onClick={() => onRatingChange(star)}
          onMouseEnter={() => setHoverRating(star)}
          onMouseLeave={() => setHoverRating(0)}
          className={`w-8 h-8 cursor-pointer ${
            (hoverRating || rating) >= star ? 'text-yellow-500' : 'text-gray-300'
          }`}
          fill="currentColor"
          viewBox="0 0 24 24"
          stroke="currentColor"
          strokeWidth={2}
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l2.118 6.57a1 1 0 00.95.69h6.905c.969 0 1.371 1.24.588 1.81l-5.588 4.06a1 1 0 00-.364 1.118l2.118 6.57c.3.921-.755 1.688-1.538 1.118l-5.588-4.06a1 1 0 00-1.175 0l-5.588 4.06c-.783.57-1.838-.197-1.538-1.118l2.118-6.57a1 1 0 00-.364-1.118l-5.588-4.06c-.783-.57-.381-1.81.588-1.81h6.905a1 1 0 00.95-.69l2.118-6.57z"
          />
        </svg>
      ))}
    </div>
  );
};

export default StarRating;
