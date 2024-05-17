import { createContext, useEffect, useState } from "react"
import accountService from "../services/accountService";
import roleService from "../services/roleService";
import teacherService from "../services/teacherService";
const userId = 'e95b6ed8-b38f-4186-ba40-26eb27d62a06';
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
    const [register, setRegister] = useState([])
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
    const fetchRegister = async ()=>{
      const response = await fetch(`http://localhost:5146/api/Student/GetRegisteredSubjectsByStudentId?studentId=${userId}`);
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const data = await response.json();
      setRegister(data.registeredSubjects || []);
    const fetchTeacherFalculty = async () =>{
        const tmp = await teacherService.getAllTeacherByFalculty(khoaId)
        setTeacherFalculty(tmp.data.teachers)
        console.log(teacherFalculty)
    }
    useEffect(()=>{
        fetchAccounts()
        fetchRoles()
        fetchRegister()
        fetchTeacherFalculty()
    },[])
  
   
   
    return(
        <AccountContext.Provider value={{accounts, selectAccount, setSelectAccount, check, setCheck, setAccounts, deleteAccount, roleId, khoaId, roles, fetchAccounts, fetchSchedule, scheduleTeacher, teacherFalculty, fetchTeacherFalculty}}>
            {children}
        </AccountContext.Provider>
    )
}