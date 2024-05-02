import { createContext, useState } from "react"

export const AccountContext = createContext({});
export const AppProvider = ({children}) =>{
    const [selectAccount, setSelectAccount] = useState([])
    const [check, setCheck] = useState(false)
    const [accounts, setAccounts] = useState(
        [
        {
            id:1,
            userName: "Thinh Phuc",
            phoneNumber: "0123292233",
            role: "Truong Pho Khoa",
            passWord:"111456"
        },
        {
            id:2,
            userName: "Hieu Han",
            phoneNumber: "0987889911",
            role: "Truong Bo Mon",
            passWord:"123999"

        },
        {
            id:3,
            userName: "Thanh Trieu",
            phoneNumber: "0335544448",
            role: "Sinh Vien",
            passWord:"212121"

        },
        {
            id:4,
            userName: "Minh Tuan",
            phoneNumber: "0132244448",
            role: "Giao Vien",
            passWord:"212121"

        },
        {
            id:5,
            userName: "Kim Len",
            phoneNumber: "0132243338",
            role: "Giao Vien",
            passWord:"212121"

        }
    
    ]
    )

    const deleteAccount = (id) =>{
        const tmp = accounts.filter((item) =>{
            return item.id!=id
        })
        setAccounts(tmp)
    }

    return(
        <AccountContext.Provider value={{accounts, selectAccount, setSelectAccount, check, setCheck, setAccounts, deleteAccount}}>
            {children}
        </AccountContext.Provider>
    )
}