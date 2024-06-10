import { useEffect, useState } from "react";
import { CreditCard } from "../../Models/CreditCard";
import { getUserCreditCards } from "../../Services/purchaseService";
import CreditCardItem from "./CreditCardItem";
import NewCreditCardButton from "./NewCreditCardButton";
import { useParams } from "react-router-dom";
import NewPurchaseButton from "./NewPurchaseButton";

type Props = {};

const Purchase = (props: Props) => {
  const { courseId } = useParams<{ courseId: string }>();
  const [userCreditCards, setUserCreditCards] = useState<CreditCard[]>([]);
  const [selectedCardId, setSelectedCardId] = useState<string | null>("1");
  useEffect(() => {
    fetchUserCreditCards();
  }, []);

  const fetchUserCreditCards = async () => {
    const cards = await getUserCreditCards();
    setUserCreditCards(cards);
    if (cards.length > 0) setSelectedCardId(cards[0].creditCardId);
  };

  const handleToggle = (cardId: string) => {
    if (selectedCardId === cardId) {
      setSelectedCardId(null);
    } else {
      setSelectedCardId(cardId);
    }
  };
  return (
    <>
      <h1>Credit Cards! {selectedCardId}</h1>
      <h1>COURSE ID! {courseId}</h1>
      <NewCreditCardButton courseId={courseId} />
      <div className="flex flex-wrap">
        {userCreditCards.map((card, index) => {
          return (
            <CreditCardItem
              key={index}
              card={card}
              selectedCardId={selectedCardId}
              handleToggle={handleToggle}
            />
          );
        })}
      </div>
      <NewPurchaseButton creditCardId={selectedCardId} courseId={courseId} />
    </>
  );
};

export default Purchase;
