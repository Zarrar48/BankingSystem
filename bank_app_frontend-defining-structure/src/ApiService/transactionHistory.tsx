import { Transactions } from "@/components/TransactionHistory/columns";
import axios from "axios";

export const transaction_history = async (
  accountId: number
): Promise<Transactions[]> => {
  try {
    let url = `http://localhost:5030/api/Transaction/history/${accountId}`;

    const res = await axios.get(url);
    return res.data;
  } catch (error) {
    console.error("Error fetching transaction history:", error);
    throw error; // You may want to throw the error for handling in the caller function
  }
};
