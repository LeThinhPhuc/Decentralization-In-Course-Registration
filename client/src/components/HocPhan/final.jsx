import React from "react";
import ListSubject from "./ListSubject";
import ListRegister from "./ListRegister";

const RegisterJubject=()=>{
  return(
    <div className="w-[70%]">
        <div>
          <ListSubject/>
        </div>
        <div>
          <ListRegister/>
        </div>

    </div>

  );
}
export default RegisterJubject;