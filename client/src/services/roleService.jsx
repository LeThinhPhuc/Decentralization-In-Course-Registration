import axios from 'axios'
const roleService = {
    getAll: () => axios.create({
        baseURL: "http://localhost:5146/",
        timeout: 5000,
        headers:{
            "Content-Type": "application/json",
            "Access-Control-Allow-Headers": "*",
            Accept: "application/x-www-form-urlencoded, text/plain",
        }
    }).get("api/Role/GetAllRoles")
}
export default roleService;