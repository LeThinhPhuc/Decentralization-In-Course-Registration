import React, { useState } from 'react';
import './LoginForm.css'; // Đảm bảo bạn đã import file CSS của mình

const LoginForm = () => {
  const [loginInfo, setLoginInfo] = useState({
    username: '',
    password: '',
    userType: 'TPK',
    rememberMe: false, // Thêm trạng thái cho ghi nhớ đăng nhập
  });

  const handleInputChange = (event) => {
    const { name, value, type, checked } = event.target;
    const newValue = type === 'checkbox' ? checked : value;
    setLoginInfo({ ...loginInfo, [name]: newValue });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    // Thêm logic xử lý đăng nhập tại đây
    console.log(loginInfo);
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
            value={loginInfo.username}
            onChange={handleInputChange}
          />
        </div>
        <div className="input-group">
          <label htmlFor="password">Mật khẩu:</label>
          <input
            id="password"
            name="password"
            type="password"
            value={loginInfo.password}
            onChange={handleInputChange}
          />
        </div>
        <div className="user-type">
          <span>Loại người dùng:</span>
          {['TPK', 'TBM', 'GVU', 'VIEN', 'SV'].map((type) => (
            <label key={type}>
              <input
                type="radio"
                name="userType"
                value={type}
                checked={loginInfo.userType === type}
                onChange={handleInputChange}
              />
              {type}
            </label>
          ))}
        </div>
        <div className="remember-me">
          <label>
            <input
              type="checkbox"
              name="rememberMe"
              checked={loginInfo.rememberMe}
              onChange={handleInputChange}
            />
            Ghi nhớ đăng nhập
          </label>
        </div>
        <button type="submit">Đăng nhập</button>
      </form>
    </div>
  );
};

export default LoginForm;
