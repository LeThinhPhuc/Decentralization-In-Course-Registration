import { useState } from "react";
import React from "react";

import AccountManage from "./components/AccountManage/AccountManage";
import { AppProvider } from "./contexts/AccountContext";
import TeachingSchedule from "./components/TeachingSchedule/TeachingSchedule";
import { Routes, Route, Router } from "react-router-dom";
import RegisterJubject from './components/HocPhan/final';
import TeacherList from './components/DSGV&lich/dsgv';

function App() {
  return (
    <AppProvider>
      {/* <Router> */}
        <Routes>
          <Route exact path="/" element={<AccountManage />} />
          <Route exact path="/TeacherList" element={<TeacherList />}/>
          <Route exact path="/ListRegister" element={<RegisterJubject />}/>
          <Route exact path="/teacher/:id" element={<TeachingSchedule />}/>
        </Routes>
      {/* </Router> */}
    </AppProvider>
  );
}

export default App;
