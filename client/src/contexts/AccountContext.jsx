import { createContext, useEffect, useState } from "react"
import accountService from "../services/accountService";
import roleService from "../services/roleService";
import teacherService from "../services/teacherService";

export const AccountContext = createContext({});
export const AppProvider = ({children}) =>{
    const [selectAccount, setSelectAccount] = useState([])
    const [check, setCheck] = useState(false)
    const roleId = "truongphokhoa"
  
    const khoaId = "455a615d-f12c-403e-8b1e-a03c15ee1bc8"
    const [accounts, setAccounts] = useState(
        []
    )
    const [roles, setRoles] = useState([])
    const [scheduleTeacher,setScheduleTeacher] = useState([])
    const deleteAccount = (id) =>{
        const tmp = accounts.filter((item) =>{
            return item.id!=id
        })
        setAccounts(tmp)
    }

    const fetchAccounts = async ( ) =>{
        const tmp = await accountService.getAll(khoaId);
        
       setAccounts(tmp.data.accounts)
       console.log(tmp.data)
    }
    const fetchRoles = async () =>{
        const tmp = await roleService.getAll();
        setRoles(tmp.data);
        console.log(tmp.data)
    }
    const fetchSchedule = async (id) =>{
        const tmp = await teacherService.getScheduleByTeachId(id)
        setScheduleTeacher(tmp.data)
        console.log("sche", tmp)
    }
   
    useEffect(()=>{
        fetchAccounts()
        fetchRoles()
    },[])
    return(
        <AccountContext.Provider value={{accounts, selectAccount, setSelectAccount, check, setCheck, setAccounts, deleteAccount, roleId, khoaId, roles, fetchAccounts, fetchSchedule, scheduleTeacher}}>
            {children}
        </AccountContext.Provider>
    )
}