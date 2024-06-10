import axios from "axios";
import { Purchase } from "../Models/Purchase";
import { handleError } from "../Helpers/ErrorHandler";
import { CreditCard } from "../Models/CreditCard";
import { loadStripe } from "@stripe/stripe-js";

const api = "http://localhost:5010/api/";

export const getPurchasedByUser = async (): Promise<Purchase[]> => {
  try {
    const response = await axios.get<Purchase[]>(api + "user/purchases");
    console.log(response.data);
    return response.data;
  } catch (error) {
    handleError(error);
    return [];
  }
};

export const newPurchase = async (courseId: string, creditCardId: string) => {
  try {
    const response = await axios.post(
      `${api}purchase`,
      { courseId, creditCardId },
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getUserCreditCards = async (): Promise<CreditCard[]> => {
  try {
    const response = await axios.get<CreditCard[]>(api + "user/creditcards");
    console.log(response.data);
    return response.data;
  } catch (error) {
    handleError(error);
    return [];
  }
};

export const newCreditCard = async (
  card: Omit<CreditCard, "userId" | "creditCardId">
) => {
  try {
    const response = await axios.post(`${api}creditcard`, card, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};

const publicKey =
  "pk_test_51PPfPvBUTpA67SLTckGgo6Hcgdtoi7DmXRssMP77NMjSeuWxfAkyGhPMztgVWs6GfjFlVj1PAs2cCy7u0scvcHnZ00GdEoMhW3";

export const newStripePurchase = async (
  courseId: string,
  creditCardId: string
) => {
  const stripePromise = loadStripe(publicKey);
  const body = { courseId: courseId, creditCardId: creditCardId };

  try {
    const response = await axios.post(`${api}purchase/stripePurchase`, body, {
      headers: {
        "Content-Type": "application/json",
      },
    });

    const { sessionId } = response.data;

    const stripe = await stripePromise;
    const { error } = await stripe!.redirectToCheckout({ sessionId });

    if (error) {
      console.error("Stripe Checkout error", error);
    }
  } catch (error) {
    console.error("Error creating Stripe Checkout session", error);
  }
};
