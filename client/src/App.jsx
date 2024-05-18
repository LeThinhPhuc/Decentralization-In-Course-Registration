import { useState } from "react";
import React from "react";

import { AppProvider } from "./contexts/AccountContext";
// import TeachingSchedule from "./components/TeachingSchedule/TeachingSchedule";
import TeachingSchedule from "./components/TeachingSchedule/TeachingSchedule";
import { Routes, Route, Router } from "react-router-dom";
import RegisterJubject from './components/HocPhan/final';
import TeacherList from './components/DSGV&lich/dsgv';

import ListClass from "./components/ListClass";
import ChangeInfo from "./components/ChangeInfo/PersonalInfoEditor"
import SideBar from "./components/SideBar/SideBar";
import AnimateRoute from "./components/Animate/AnimateRoute";
function App() {
  return (
    // <AppProvider>
    //   {/* <Router> */}
    //   <Routes>
    //       <Route exact path="/" element={<SideBar/>} />
    //       <Route exact path="/teacher" element={<TeacherList />} />

    //       <Route exact path="/teacher/:id" element={<TeachingSchedule />} />
    //    </Routes>
    //   {/* </Router> */}
    //   {/* <ListClass /> */}
    // </AppProvider>
    // // <ChangeInfo/>


    <AppProvider>
            {/* <Router> */}
                <AnimateRoute />
                {/* <AnimateRoute /> */}
                <ChangeInfo/>
            {/* </Router> */}
     </AppProvider>
  );
}

export default App;
