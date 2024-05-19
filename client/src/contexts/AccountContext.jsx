import { createContext, useEffect, useState } from "react"
import accountService from "../services/accountService";
import roleService from "../services/roleService";
import teacherService from "../services/teacherService";
import PersonalInfoService from "../components/ChangeInfo/PersonalInfoService";
import { jwtDecode } from 'jwt-decode';
const userId = 'e95b6ed8-b38f-4186-ba40-26eb27d62a06';
export const AccountContext = createContext({});

export const AppProvider = ({children}) =>{
    const [selectAccount, setSelectAccount] = useState([])
    const [check, setCheck] = useState(false)
    // const roleId = "truongphokhoa"
    const [roleId, setRoleId]=useState("")
    const [decode, setDecode]=useState()
    const [getToken, setGetToken]= useState("")
  
    // const khoaId = "455a615d-f12c-403e-8b1e-a03c15ee1bc8"
    const [khoaId, setKhoaId]=useState("")
    const [accounts, setAccounts] = useState(
        []
    )
    var ktra= localStorage.getItem("user");
    const [roles, setRoles] = useState([])
    const [scheduleTeacher,setScheduleTeacher] = useState([])
    const [teacherFalculty, setTeacherFalculty]= useState([])
    const [register, setRegister] = useState([])

    const [personInfo, setPersonInfo] = useState();
    const deleteAccount = async (id) =>{
        console.log(id)

        await accountService.deleteAccount(id);
        await fetchAccounts()
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
    // const fetchRegister = async ()=>{
    //   const response = await fetch(`http://localhost:5146/api/Student/GetRegisteredSubjectsByStudentId?studentId=${userId}`);
    //   if (!response.ok) {
    //     throw new Error("Network response was not ok");
    //   }
    //   const data = await response.json();
    //   setRegister(data.registeredSubjects || []);
    // }
    const fetchTeacherFalculty = async () =>{
        const tmp = await teacherService.getAllTeacherByFalculty(khoaId)
        setTeacherFalculty(tmp.data.teachers)
        console.log(teacherFalculty)
    }
    const GetInfo = async (personId) => {
        const response =await  PersonalInfoService.GetInfo(personId);
        console.log(response);
        setPersonInfo(response.data)
    }
    const getDecode = () =>{
        var user= localStorage.getItem("user");
        let userData = JSON.parse(user);
        setGetToken(userData.token)
        console.log("userDate", userData)

        setDecode(jwtDecode(userData.token))
        setKhoaId(jwtDecode(userData.token)?.facultyId)
        setRoleId(jwtDecode(userData.token)?.roles)
        //  decode = jwtDecode(userData.token);
    }
    // let decode ;
    // let personInfo;
 
  
   
   
            
           
    if(ktra){
        useEffect(()=>{
            fetchAccounts()
            fetchRoles()
            // fetchRegister()
            fetchTeacherFalculty()
            getDecode()
            GetInfo(decode?.personId)
         


             console.log(decode)
            // personInfo =  GetInfo(decode.personId);
            // console.log("ca nhan : ", personInfo)
        },[])
    }
    


    // console.log(roleId);

    return(
        <AccountContext.Provider value={{accounts, selectAccount, setSelectAccount, check, setCheck, setAccounts, deleteAccount, roleId, khoaId, roles, fetchAccounts, fetchSchedule, scheduleTeacher, teacherFalculty, fetchTeacherFalculty,decode,personInfo, getToken}}>
            {children}
        </AccountContext.Provider>
    )

}