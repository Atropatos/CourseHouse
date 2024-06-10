import React from "react";
import { useNavigate } from "react-router";

type Props = {};

const PurchaseSuccess = (props: Props) => {
  const navigate = useNavigate();
  return (
    <>
      <div className="text-green-500 font-bold text-xl">
        BRAWO UDAŁO CI SIĘ ZAKUPIĆ NOWY KURS!
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

export default PurchaseSuccess;
