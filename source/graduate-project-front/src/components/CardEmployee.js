import { useState, useEffect} from 'react';

import axios from "axios";
import { Alert, CCard, CCardHeader, CCardBody, CCardTitle, CCardText, CButton} from '@coreui/react';
import '@coreui/coreui/dist/css/coreui.min.css'
import './CardEmployee.css'
import ModalDetailed from '../Modal/ModalDetailed';

const CardEmployee = () => {
    const [modalActive, setModalActive] = useState(false)
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

    return (
    <>
        {employee.map((employee, index) => (
            <CCard  className='card'>
            <CCardBody >
                <CCardTitle>{employee.fullName}</CCardTitle>
                <CCardText style={{maxWidth:'500px',  marginBottom:'2px'}}>{employee.department}</CCardText>
                <div style={{ width:'100%', display:'flex'}}>
                    <CCardText className='card-duty'>{employee.duty}</CCardText>
                    {/* <CCardText style={{marginLeft:'10%', position:'absolute', left:'20%'}}>Телефон: {employee.phone}</CCardText> */}
                    <CButton className='modalBtn' onClick={() => setModalActive(true)} href="#">Подробнее</CButton>
                </div>
                <ModalDetailed active={modalActive} onClose={() => setModalActive(false)}></ModalDetailed>
            </CCardBody>
            </CCard>
                
        ))}
    </>
    )
}
export default CardEmployee;