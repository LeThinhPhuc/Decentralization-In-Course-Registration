import React, { useState } from 'react';
import './LoginForm.css';
import LoginFormService from './LoginFormService';
import { Link, useNavigate } from "react-router-dom";
import { jwtDecode } from 'jwt-decode';
const LoginForm = () => {
    const navigate = useNavigate();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const account = {
          username: username,
          password: password,
      };
 
      const doLogin = async () => {
        const response = await LoginFormService.doLogin(account);
        if (response.status == 200) {
            localStorage.setItem("user", JSON.stringify(response.data));
            if(response.data.token){
                navigate("/home/person")
                window.location.reload();
            }
            const decode = jwtDecode(response.data.token);
            console.log(decode);
        }
       
    };

  return (
      <div className="login-form">
          <h2>Đăng Nhập</h2>
              <div className="input-group">
                  <label htmlFor="username">Tên người dùng:</label>
                  <input
                      id="username"
                      name="username"
                      type="text"
                      value={username}
                      onChange={(e) => setUsername(e.target.value)}
                  />
              </div>
              <div className="input-group">
                  <label htmlFor="password">Mật khẩu:</label>
                  <input
                      id="password"
                      name="password"
                      type="password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                  />
              </div>
              <button className="btn-Login" type="submit"  onClick={() => {
                                doLogin();
                            }}>Đăng nhập</button>
      </div>
  );

};
export default LoginForm;
