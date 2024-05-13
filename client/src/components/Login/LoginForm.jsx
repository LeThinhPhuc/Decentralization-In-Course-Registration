import React, { useState } from 'react';
import './LoginForm.css';
import LoginFormService from './LoginFormService';
const LoginForm = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
      e.preventDefault();
  
      const account = {
          username: username,
          password: password,
      };

      const response = await LoginFormService.doLogin(account);
      console.log(account);
      if (response.status === 200) {
          localStorage.setItem("user", JSON.stringify(response.data));
         // Chuyển hướng tới trang dashboard sau khi đăng nhập thành công
      }
  };

  return (
      <div className="login-form">
          <h2>Đăng Nhập</h2>
          <form onSubmit={handleSubmit}>
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
          </form>
      </div>
  );
};

export default LoginForm;
