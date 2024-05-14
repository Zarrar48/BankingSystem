import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"

import "../styles/transfer-money.css"

const TransferMoney = () => {
  return <div className="tm-body-wrapper">
    <div className="single-column items-end mr-5">
    <Card className=" w-80 card">
  <CardHeader >
    <CardTitle>Source Account </CardTitle>
    <CardDescription>Source Account Details</CardDescription>
  </CardHeader>
  <CardContent>
    <p className="mb-3">Account Number</p>
    <Input type="Account Number" placeholder="Account Number" className="mb-3" />
    <p className="mb-3">Name</p>
    <Input type="Name" placeholder="Name"  className="mb-3"/>
    <p className="mb-3">Amount</p>
    <Input type="Amount" placeholder="Amount"  className="mb-3"/>
  </CardContent>
  <CardFooter>
  <div className="account-balance">Available Balance * :</div>
  </CardFooter>
</Card>

    </div>
    <div className="single-column ">
        
    <Card className="w-96 card">
  <CardHeader>
    <CardTitle>Beneficiary Account</CardTitle>
    <CardDescription>Beneficiary AccountDetails</CardDescription>
  </CardHeader>
  <CardContent>
    <p className="mb-3">Benficiary Account Number</p>
    <div className="flex-line mb-3">
      <Input type="email" placeholder="Account Number" />
      <Button type="submit">Search</Button>
    </div>
    <p className="mb-3">Beneficiary Name</p>
    <Input type="Name" placeholder="Name"  className="mb-3"/>
    <p className="mb-3">Transaction Details</p>
    <Input type="Amount" placeholder="Amount"  />
  </CardContent>
  <CardFooter>
  <div className="flex-line">
    <Button type="submit">Transfer</Button>
    <Button type="reset">Reset</Button>
    </div>
  </CardFooter>
</Card>
    </div>
  </div>;
};

export default TransferMoney;
