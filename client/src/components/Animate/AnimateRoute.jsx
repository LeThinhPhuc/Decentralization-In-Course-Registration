import { Routes, Route } from "react-router-dom";
import MainPage from "../MainPage/MainPage";
import AccountManage from "../AccountManage/AccountManage";
import TeacherList from "../DSGV&lich/dsgv";
import TeachingSchedule from "../TeachingSchedule/TeachingSchedule";
import FormCreate from "../FormCreate";
import ListClass from "../ListClass";
import ChangeInfo from "../ChangeInfo/ChangeInfo";
import ListRegister from "../HocPhan/ListRegister";
import RegisterJubject from "../HocPhan/final";
import LoginForm from "../Login/LoginForm";
const AnimateRoute = () => {
    return (
        <Routes>
            <Route path="/" element={<LoginForm/>} />
            <Route path="/home" element={<MainPage />}>
                <Route exact path="/home/add" element={< AccountManage />} />
                <Route exact path="/home/person" element={<ChangeInfo></ChangeInfo>} />
                <Route
                    exact
                    path="/home/addsubject"
                    element={
                    <div className="flex justify-center items-center">
                         <ListClass/>
                    </div>
                    }
                />
                <Route exact path="/home/registersubject" element={<div>Danh sach sinh vien da dang ky mon</div>} />
                <Route exact path="/home/teacher" element={
                    <div className="flex justify-center items-center">
                    <TeacherList />
                </div>
                } />
                <Route exact path="/home/teacher/:id" element={
                    <div className="flex justify-center items-center">
                        <TeachingSchedule />
                    </div>
                } />
                <Route exact path="/home/teacherschedule" element={<div>Danh sach lich day cua mot giao vien cu the khi dang nhap</div>} />
                <Route exact path="/home/subjectopen" element={
                <div className="flex justify-center items-center">
                                <RegisterJubject/>

            </div>
                } />
                
                <Route
                    path="*"
                    element={
                        <div className="text-center text-[100px]">
                            PAGE NOT FOUND
                        </div>
                    }
                />
            </Route>
        </Routes>
    )
}
export default AnimateRoute;