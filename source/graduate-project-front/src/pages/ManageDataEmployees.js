import './ManageDataEmployees.css'
import CardEmployee from "../components/CardEmployee";
import { useState, useEffect} from 'react';

import Navbar from '../components/Navbar';
import { CButton, CForm, CFormInput, CCol,CRow, CContainer, CFormSelect} from '@coreui/react';
const ManageDataEmployees =() =>{


    const [searchEmployee, setSearchEmployee] = useState("");
    const [sortEmployee, setSortEmployee] = useState("отсутствует");


    const handleSortChange = (event) => {
        setSortEmployee(event.target.value);
    };

    return(
    < >
   
    <CContainer>
        <CRow className="row mt-3 ">
            <CCol xs={3}>
            <CFormSelect value={sortEmployee} onChange={handleSortChange}>
                <option value="Без сортировки">Без сортировки</option>
                <option value="По фамилии">По фамилии</option>
                <option value="По должности">По должности</option>
                <option value="По отделу">По отделу</option>
            </CFormSelect>
            </CCol>
            <CCol xs={5}>
                <CFormInput onChange={(event) => setSearchEmployee(event.target.value)} type='text' placeholder='Поиск' />        
            </CCol>
            <CCol xs={1}>
                <CButton className='btn_sub' color='primary' type='submit'> <p>Подтвердить</p> </CButton>
            </CCol>
        </CRow>
    </CContainer>
        <div className="container-employee" >
           <CardEmployee searchEmployee={searchEmployee} sortEmployee={sortEmployee}></CardEmployee>
        </div>
    </>
    )
}
export default ManageDataEmployees;