import '../Modal/ModalDetailed.css'
import { useState, useEffect} from 'react';
import axios from "axios";
const ModalDetailed =({active, onClose}) =>{

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

    if(!active) return null
    return(
      <div className="overlay">
            <div className='modalContainer'>
                <div style={{display:'flex', width:'100%'}}>
                <p>{employee.phone}</p>
                <button onClick={(onClose)} class="icon-button">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24">
                        <path fill="none" d="M0 0h24v24H0z" />
                        <path fill="currentColor" d="M12 10.586l4.95-4.95 1.414 1.414-4.95 4.95 4.95 4.95-1.414 1.414-4.95-4.95-4.95 4.95-1.414-1.414 4.95-4.95-4.95-4.95L7.05 5.636z" />
                    </svg>
			    </button>
                </div>
            </div>
      </div>
    )
}
export default ModalDetailed;