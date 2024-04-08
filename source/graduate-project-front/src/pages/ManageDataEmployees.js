import './ManageDataEmployees.css'
import CardEmployee from "../components/CardEmployee";

import Navbar from '../components/Navbar';
import { CButton, CForm, CFormInput, CCol,CRow, CContainer, CFormSelect} from '@coreui/react';
const ManageDataEmployees =() =>{
    return(
    < >
   
    <CContainer>
        <CRow className="row mt-3 ">
            <CCol xs={3}>
            <CFormSelect  >
                <option value="1">Без сортировки</option>
                <option value="1">По фамилии</option>
                <option value="2">По должности </option>
                <option value="3">По отделу</option>
            </CFormSelect>
            </CCol>
            <CCol xs={5}>
                <CFormInput type='text' placeholder='Поиск' />        
            </CCol>
            <CCol xs={1}>
                <CButton className='btn_sub' color='primary' type='submit'> <p>Подтвердить</p> </CButton>
            </CCol>
        </CRow>
    </CContainer>
        <div className="container-employee" >
           <CardEmployee></CardEmployee>
        </div>
    </>
    )
}
export default ManageDataEmployees;