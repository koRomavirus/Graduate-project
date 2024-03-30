import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import './App.css';
import MainPage from './pages/MainPage';
import ManageDataEmployees from './pages/ManageDataEmployees';
import Navbar from './components/Navbar';
import Test from './components/Test';

function App() {
  return (
    <div>
      
      <Navbar></Navbar>
      <Router>
        <Routes>
          <Route path='/ManageDataEmployees' element={<ManageDataEmployees/>}/>
          <Route path='/MainPage' element={<MainPage/>}/>
          
        </Routes>
      </Router>
      
    </div>
  );
}

export default App;
