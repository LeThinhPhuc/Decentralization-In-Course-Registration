import { Outlet } from "react-router-dom";
import SideBar from "../SideBar/SideBar";

const MainPage = () =>{
    return(
        <>
            <SideBar></SideBar>
            <Outlet></Outlet>
        </>
    )
}
export default MainPage;