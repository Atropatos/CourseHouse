import React, { useState } from "react";
import { CreditCard } from "../../Models/CreditCard";

type CreditCardProp = {
  card: CreditCard;
  selectedCardId: string | null;
  handleToggle: (cardId: string) => void;
};

const CreditCardItem: React.FC<CreditCardProp> = ({
  card,
  selectedCardId,
  handleToggle,
}) => {
  return (
    <div
      className={`m-4 p-4 border rounded-md cursor-pointer w-1/3 flex-1 ${
        selectedCardId == card.creditCardId
          ? "bg-green-200"
          : "hover:bg-green-100"
      }`}
      onClick={() => handleToggle(card.creditCardId.toString())}
    >
      <p>Number: {card.creditCardNumber}</p>
      <p>Expiration Date: {card.expirationDate}</p>
      <p>Cvv: {card.cvv}</p>
      <p>Holder: {card.holderName}</p>
    </div>
  );
};

export default CreditCardItem;
