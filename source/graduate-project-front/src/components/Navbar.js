import './Navbar.css'

const Navbar = () =>{
    return(
    <div className="navbar">
        <div style={{display:'flex', width:'100%', alignItems:'center'  }}>
            <img className='logo' alt="src" src="https://www.atomexp.ru/source/pic/logo-white.svg" />
            <ul>
                <a href="MainPage">Главная страница</a>
                <a href="ManageDataEmployees">Сотрудники</a>
                <a href="ManageDataEmployees">Документооборот</a>
                <a href="ManageDataEmployees">База знаний</a>
            </ul>
        </div>
      
    </div>   

    )
 }
export default Navbar;