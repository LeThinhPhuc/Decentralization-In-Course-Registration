import React from "react";
import ListSubject from "./ListSubject";
import ListRegister from "./ListRegister";

const registerJubject=()=>{
  return(
    <div>
        <div>
          <ListSubject/>
        </div>
        <div>
          <ListRegister/>
        </div>

    </div>

  );
}
export default registerJubject;