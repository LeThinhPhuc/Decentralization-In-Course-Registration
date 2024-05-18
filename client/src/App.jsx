import { useState } from "react";
import React from "react";

import { AppProvider } from "./contexts/AccountContext";
import ChangeInfo from "./components/ChangeInfo/ChangeInfo";

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
                {/* <AnimateRoute /> */}
                <ChangeInfo/>
            {/* </Router> */}
     </AppProvider>
  );
}

export default App;
