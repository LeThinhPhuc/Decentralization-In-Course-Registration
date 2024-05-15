import { useState } from "react";
import React from "react";

import AccountManage from "./components/AccountManage/AccountManage";
import { AppProvider } from "./contexts/AccountContext";
import TeachingSchedule from "./components/TeachingSchedule/TeachingSchedule";
import { Routes, Route, Router } from "react-router-dom";
import ListClass from "./components/ListClass";

function App() {
  return (
    <AppProvider>
      {/* <Router> */}
      {/* <Routes>
          <Route exact path="/" element={<AccountManage />} />
          <Route exact path="/teacher/:id" element={<TeachingSchedule />} />
        </Routes> */}
      {/* </Router> */}
      <ListClass />
    </AppProvider>
  );
}

export default App;
