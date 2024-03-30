import { useState, useEffect } from "react";
import axios from "axios";
const Test = () =>{

    const[employee, setEmployee] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`https://localhost:7017/api/ControllerEmployee`);
                setEmployee(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }           
        };
        fetchData();
    }, []); 

    return(
        <>
         {employee.map((employee, index) => (
                 <p>
                    {employee.fullName}
                 </p>
                       
                    ))}
        </>
    )
}
export default Test