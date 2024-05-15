import { useEffect, useState } from "react";
import jwt_decode from "jwt-decode";

const LoginContext = () => {
    const [decodedToken, setDecodedToken] = useState(null);
    const [token, setToken] = useState("");

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
