import axios from 'axios'
const accountService = {
    getAll: (id) => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
        }
    }).get(`api/Faculty/GetAllAccountsByFacultyId?facultyId=${id}`),
    createAccount: (infor) =>axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
        }
    }).post("api/Auth/Register", infor),
    deleteAccount:(id)=>axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
        }
    }).delete(`api/Auth/DeleteAccount?accountId=${id}`)
}
export default accountService;