
import { useState } from 'react';
import React from "react";

import AccountManage from './components/AccountManage/AccountManage';
import { AppProvider } from './contexts/AccountContext';
import TeachingSchedule from './components/TeachingSchedule/TeachingSchedule';
import { Routes, Route, Router } from "react-router-dom";
import TeacherList from './components/DSGV&lich/dsgv';
import ListSubject from './components/HocPhan/ListSubject';
import RegisterJubject from './components/HocPhan/axios';


function App() {
  return (
    <AppProvider>
      {/* <Router> */}
        <Routes>
          <Route exact path="/" element={<AccountManage />} />
          <Route exact path="/teacher/:id" element={<TeachingSchedule />} />
          <Route exact path="/TeacherList" element={<TeacherList />} />
          <Route exact path="/ListSubject" element={<RegisterJubject/>} />
        </Routes>
      {/* </Router> */}
    </AppProvider>
  );
}

export default App;
