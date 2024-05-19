// import axios from 'axios'
import axios from 'axios'
let token;
if(localStorage.getItem("user")){
    var user= localStorage.getItem("user");
    let userData = JSON.parse(user);
    console.log(userData.token)
    token =userData.token
}

const teacherService = {
    
    getScheduleByTeachId: (id) => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":token?`Bearer ${token}`:""

        }
    }).get(`api/Teacher/TeacherTeachingSchedule?teacherId=${id}`),
    getAllTeacherByFalculty:(id) => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":token?`Bearer ${token}`:""

        }
    }).get(`api/Faculty/GetAllTeachersByFacultyId?facultyId=${id}`)
}
export default teacherService;