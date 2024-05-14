import { ColumnDef } from "@tanstack/react-table";
import '../../styles/transaction-history.css'
export type Transactions = {
  account_id: number;
  name: string;
  credit: number|null|string;
  debit: number|null|string;
  balance: number;
  description: string|null;
  date: string;
};
export const columns: ColumnDef<Transactions>[] = [
  {
    accessorKey: "account_id",
    header: () => <span className="header">Account Number</span>,
  },
  {
    accessorKey: "name",
    header: () => <span className="header">Name</span>,
  },
  {
    accessorKey: "credit",
    header: () => <span className="header">Credit</span>,
  },
  {
    accessorKey: "debit",
    header: () => <span className="header">Debit</span>,
  },
  {
    accessorKey: "balance",
    header: () => <span className="header">Balance</span>,
  },
  {
    accessorKey: "description",
    header: () => <span className="header">Description</span>,
  },
  {
    accessorKey: "date",
    header: () => <span className="header">Date</span>,
  },
];
