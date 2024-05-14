import { useState, useEffect } from "react";
import { transaction_history } from "@/ApiService/transactionHistory";
import { DataTable } from "./dataTable";
import { Transactions, columns } from "./columns";
import "../../styles/transaction-history.css";

interface TransactionHistoryProps {
  accountId: number;
}
const TransactionHistory: React.FC<TransactionHistoryProps> = ({
  accountId,
}) => {
  const [data, setData] = useState<Transactions[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        if (!accountId) {
          console.error("Account ID is required to fetch transaction history.");
          return;
        }

        const res = await transaction_history(accountId);
        console.log(res);
        setData(res);
      } catch (error) {
        console.error("Error fetching transaction history:", error);
      }
    };

    fetchData(); // Call fetchData after defining it
  }, [accountId]); // Add accountId as a dependency to run effect when accountId changes

  return (
    <div className="th-body-wrapper">
      <div className="title-wrapper">Transaction History</div>
      <div className="th-data-wrapper">
        <DataTable columns={columns} data={data} />
      </div>
    </div>
  );
};

export default TransactionHistory;
