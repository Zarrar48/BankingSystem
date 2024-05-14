import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Button } from "@/components/ui/button";
import "../../styles/loans.css";

import {
    Table,
    TableBody,
    TableCaption,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
  } from "@/components/ui/table"
  
const Loans = () => {
  return (
    <div className="loans-body-wrapper">
        <Card className="due-loan-card">
        <CardTitle className="text-purple-600 font-bold mb-3 text-center ">
        Amount Payable : 250 RS
        </CardTitle>
        </Card>
      <Card className="loan-card">
        <CardHeader>
          <CardTitle className="text-purple-600 font-bold mb-3">
            Request A Loan
          </CardTitle>{" "}
          <CardDescription>* Terms and Conditions Apply</CardDescription>
        </CardHeader>
        <CardContent>
          <p className="mb-6">Select Amount : </p>
          <Select >
            <SelectTrigger className="w-[180px]">
              <SelectValue placeholder="500" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="250">250</SelectItem>
              <SelectItem value="500">500</SelectItem>
              <SelectItem value="750">750</SelectItem>
              <SelectItem value="1000">1000</SelectItem>
            </SelectContent>
          </Select>
        </CardContent>
        <CardFooter>
        <Button type="submit">Request</Button>
        </CardFooter>
      </Card>


      <Card className='prev-loan-card'>
      <CardTitle className="text-purple-600 font-bold mb-3 text-center">
            Previous loans
          </CardTitle>

          <Table>
  <TableCaption>A list of your previous loans</TableCaption>
  <TableHeader>
    <TableRow>
      <TableHead className="w-[100px]">Original Amount</TableHead>
      <TableHead>Payable Amount</TableHead>
      <TableHead>Date of Issuance</TableHead>
      <TableHead>Due Date</TableHead>
      <TableHead className="text-right">Status</TableHead>
    </TableRow>
  </TableHeader>
  <TableBody>
    <TableRow>
      <TableCell className="font-medium">200</TableCell>
      <TableCell>250</TableCell>
      <TableCell>12-4-24</TableCell>
      <TableCell className="text-right">12-5-24</TableCell>
      <TableCell>Unpaid</TableCell>
    </TableRow>

    <TableRow>
      <TableCell className="font-medium">500</TableCell>
      <TableCell>1000</TableCell>
      <TableCell>11-1-24</TableCell>
      <TableCell className="text-right">12-2-24</TableCell>
      <TableCell>Paid</TableCell>
    </TableRow>
  </TableBody>
</Table>
      </Card>

    </div>
  );
};

export default Loans;
