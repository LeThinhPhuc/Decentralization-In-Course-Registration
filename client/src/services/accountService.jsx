import axios from 'axios'
let token;
if(localStorage.getItem("user")){
    var user= localStorage.getItem("user");
    let userData = JSON.parse(user);
    console.log(userData.token)
    token =userData.token
}

const accountService = {
    getAll: (id) => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":token?`Bearer ${token}`:""

        }
    }).get(`api/Faculty/GetAllAccountsByFacultyId?facultyId=${id}`),
    createAccount: (infor) =>axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":token?`Bearer ${token}`:""

        }
    }).post("api/Auth/Register", infor),
    deleteAccount:(id)=>axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":token?`Bearer ${token}`:""

        }
    }).delete(`api/Auth/DeleteAccount?accountId=${id}`)
}
export default accountService;