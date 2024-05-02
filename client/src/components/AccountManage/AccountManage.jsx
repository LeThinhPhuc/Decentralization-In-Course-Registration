import AddAccount from "./AddAccount/ListAccount";
import TableAccount from "./TableAccount/TableAccount";

const AccountManage = () =>{
    return(
        <div>
            <div className="flex justify-center items-center pb-5">
                <AddAccount />

            </div>
            <div className="flex justify-center items-center">
                <TableAccount/>

            </div>
        </div>
    )
}
export default AccountManage;