// import axios from 'axios'
import axios from 'axios'
const teacherService = {
    getScheduleByTeachId: (id) => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
        }
    }).get(`api/Teacher/TeacherTeachingSchedule?teacherId=${id}`)
}
export default teacherService;