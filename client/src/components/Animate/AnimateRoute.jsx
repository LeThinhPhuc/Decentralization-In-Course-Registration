import { Routes, Route } from "react-router-dom";
import MainPage from "../MainPage/MainPage";
import AccountManage from "../AccountManage/AccountManage";
import TeacherList from "../DSGV&lich/dsgv";
import TeachingSchedule from "../TeachingSchedule/TeachingSchedule";
const AnimateRoute = () => {
    return (
        <Routes>
            <Route path="/" element={<div>Login</div>} />
            <Route path="/home" element={<MainPage />}>
                <Route exact path="/home/add" element={< AccountManage />} />
                <Route exact path="/home/person" element={<div className="ml-[300px]">Trang ca nhan</div>} />
                <Route
                    exact
                    path="/home/addsubject"
                    element={<div>Them mon va xem danh sach mon trong khoa</div>}
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
                <Route exact path="/home/subjectopen" element={<div>Danh sach mon cho hoc sinh dang ky va hien mon da dang ky</div>} />
                
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