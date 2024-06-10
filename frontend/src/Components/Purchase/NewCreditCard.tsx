import React, { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { newCreditCard } from "../../Services/purchaseService";
import { CreditCard } from "../../Models/CreditCard";

const NewCreditCard = () => {
  const navigate = useNavigate();
  const { courseId } = useParams();
  const [formData, setFormData] = useState({
    creditCardNumber: "",
    expirationDate: "",
    cvv: "",
    holderName: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const newCard: Omit<CreditCard, "userId" | "creditCardId"> = {
      creditCardNumber: formData.creditCardNumber,
      expirationDate: formData.expirationDate,
      cvv: formData.cvv,
      holderName: formData.holderName,
    };
    await newCreditCard(newCard);
    console.log(formData);
    navigate(`/course/buy/${courseId}`);
  };

  return (
    <div className="max-w-md mx-auto">
      <h1 className="text-xl font-bold mb-4">Dodaj nową kartę kredytową!</h1>
      <form onSubmit={handleSubmit} className="space-y-4" autoComplete="off">
        <div className="mb-4">
          <label htmlFor="creditCardNumber" className="block">
            Numer karty:
          </label>
          <input
            type="text"
            id="creditCardNumber"
            name="creditCardNumber"
            value={formData.creditCardNumber}
            onChange={handleChange}
            className="w-full border rounded-md shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50 px-4 py-2"
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="expirationDate" className="block">
            Data ważności:
          </label>
          <input
            type="text"
            id="expirationDate"
            name="expirationDate"
            value={formData.expirationDate}
            onChange={handleChange}
            className="w-full border rounded-md shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50 px-4 py-2"
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="cvv" className="block">
            CVV:
          </label>
          <input
            type="text"
            id="cvv"
            name="cvv"
            value={formData.cvv}
            onChange={handleChange}
            className="w-full border rounded-md shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50 px-4 py-2"
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="holderName" className="block">
            Imię i nazwisko posiadacza:
          </label>
          <input
            type="text"
            id="holderName"
            name="holderName"
            value={formData.holderName}
            onChange={handleChange}
            className="w-full border rounded-md shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50 px-4 py-2"
            required
          />
        </div>
        <button
          type="submit"
          className="bg-blue-500 text-white font-bold py-2 px-4 rounded"
        >
          Dodaj kartę
        </button>
      </form>
    </div>
  );
};

export default NewCreditCard;
