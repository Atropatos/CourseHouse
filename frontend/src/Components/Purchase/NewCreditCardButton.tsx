import React from "react";
import { useNavigate } from "react-router-dom";

type Props = {
  courseId: string | undefined;
};

const NewCreditCardButton = ({ courseId }: Props) => {
  const navigate = useNavigate();
  const handleNewCardClick = () => {
    navigate(`/course/addNewCrediCard/${courseId}`);
  };
  return (
    <>
      <div className="m-5">
        <button
          className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 "
          onClick={() => {
            handleNewCardClick();
          }}
        >
          Dodaj nową kartę
        </button>
      </div>
    </>
  );
};

export default NewCreditCardButton;
