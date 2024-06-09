import React from "react";
import { Navigate, useNavigate } from "react-router-dom";

type Props = {};

const PurchaseFail = (props: Props) => {
  const navigate = useNavigate();
  return (
    <>
      <div className="text-red-500 font-bold text-xl">
        Nie udało się kupić kursu!
      </div>
      <button
        onClick={() => navigate("/")}
        className="mt-4 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
      >
        Powrót do kursów
      </button>
    </>
  );
};

export default PurchaseFail;
