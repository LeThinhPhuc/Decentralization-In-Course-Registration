import { useEffect, useState } from "react";
import jwt_decode from "jwt-decode";

const LoginContext = () => {
    const [decodedToken, setDecodedToken] = useState(null);
    const [token, setToken] = useState("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6WyJUZXN0MSIsIjI0NjYzNmI0LTkzN2ItNGJlYS05MDVkLWY1NTYwYzg2OTA1ZiJdLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTMOqIFBow7pjIFRo4buLbmgiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJzaW5odmllbiIsImV4cCI6MTcxNTYxNTIyMywiaXNzIjoiaHR0cHM6Ly9waTUuY291bnRlcmxvZ2ljLmNsaWNrIiwiYXVkIjoiaHR0cHM6Ly9waTUuY291bnRlcmxvZ2ljLmNsaWNrIn0.CZ7zlbkx9UyJ_sm_EC3Ln5xky40wxRzbRskMJrBv4mg"
);

    useEffect(() => {
        // Giải mã token khi component được render
        if (token) {
            try {
                const decoded = jwt_decode(token);
                setDecodedToken(decoded);
            } catch (error) {
                console.error("Error decoding token:", error);
            }
        }
    }, [token]); // Chạy lại effect khi giá trị token thay đổi

    return (
        <div>
            <h2>Decoded Token:</h2>
            <pre>{JSON.stringify(decodedToken, null, 2)}</pre>
        </div>
    );
};

export default LoginContext;
