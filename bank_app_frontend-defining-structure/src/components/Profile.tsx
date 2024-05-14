import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
  } from "@/components/ui/card"
  
import '../styles/profile.css';
const Profile = () => {
  return (
    <div className='profile-body-wrapper'>
    <Card className="card">
  <CardHeader>
    <CardTitle className=" text-purple-500">CustomerDetails </CardTitle>
  </CardHeader>
  <CardContent>
    <p>Name</p>
    <CardDescription className="mb-5">Mohammad Ali</CardDescription>
    <p>Email</p>
    <CardDescription className="mb-5">Ali123@gmail.com</CardDescription>
    <p>Phone Number</p>
    <CardDescription className="mb-5">XXXXXXXXXX</CardDescription>
    <p>Address</p>
    <CardDescription className="mb-5">ABCD</CardDescription>
  </CardContent>
</Card>

    </div>
  )
}

export default Profile