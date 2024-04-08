import { useState, useEffect} from 'react';
import axios from "axios";
import { Alert, CCard, CCardHeader, CCardBody, CCardTitle, CCardText, CButton} from '@coreui/react';
import '@coreui/coreui/dist/css/coreui.min.css';
import './CardEmployee.css';
import ModalDetailed from '../Modal/ModalDetailed';

const CardEmployee = ()  => {
    const [modalActive, setModalActive] = useState(null); 
    const [employees, setEmployees] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`https://localhost:7017/api/ControllerEmployee`);
                setEmployees(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }           
        };
        fetchData();
    }, []); 

    return (
    <>
        {employees.map((employee, index) => (
            <CCard key={index} className='card'>
                <CCardBody >
                    <CCardTitle>{employee.fullName}</CCardTitle>
                    <CCardText style={{maxWidth:'500px',  marginBottom:'2px'}}>{employee.department}</CCardText>
                    <div style={{ width:'100%', display:'flex'}}>
                        <CCardText className='card-duty'>{employee.duty}</CCardText>
                        <CButton className='modalBtn' onClick={() => setModalActive(employee.id)} href="#">Подробнее</CButton>
                    </div>
                </CCardBody>
            </CCard>
        ))}
       
        {modalActive !== null && (
            <ModalDetailed
                employeeId={modalActive}
                employee={employees.find(emp => emp.id === modalActive)}
                active={modalActive !== null}
                onClose={() => setModalActive(null)}
            />
        )}
    </>
    )
}

export default CardEmployee;
