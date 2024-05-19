import axios from 'axios'
var user= localStorage.getItem("user");
let userData = JSON.parse(user);
console.log(userData.token)
const token =userData.token

const roleService = {
    getAll: () => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":`Bearer ${token}` 

        }
    }).get("api/Role/GetAllRoles"),
    updateRoleAccount: (info) =>axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
            "Authorization":`Bearer ${token}` 

        }
    }).post("/api/Role/UpdateAccountRoles",info)
}
export default roleService;