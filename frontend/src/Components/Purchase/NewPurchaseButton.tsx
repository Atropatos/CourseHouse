import { newStripePurchase } from "../../Services/purchaseService";

type Props = {
  courseId: string | null | undefined;
  creditCardId: string | null;
};

const NewPurchaseButton = ({ courseId, creditCardId }: Props) => {
  const handleNewPurchase = () => {
    if (courseId != null && creditCardId != null) {
      newStripePurchase(courseId, creditCardId);
      console.log(
        "Kupiono kurs " + courseId + " za pomocą karty " + creditCardId
      );
    }
  };
  return (
    <>
      <div className="m-5">
        <button
          className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-600 "
          onClick={() => {
            handleNewPurchase();
          }}
        >
          ZAPŁAĆ
        </button>
      </div>
    </>
  );
};

export default NewPurchaseButton;
