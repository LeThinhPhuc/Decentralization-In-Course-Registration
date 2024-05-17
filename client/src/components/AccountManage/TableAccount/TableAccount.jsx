import { useContext, useState, useEffect } from "react";
import { AccountContext } from "../../../contexts/AccountContext";
import { useNavigate } from "react-router-dom";

const TableAccount = () => {

    const navigate = useNavigate()
   const {accounts, setSelectAccount, setCheck, check, deleteAccount, roles} = useContext(AccountContext)
   const [search,setSearch] = useState("");
   const [selRole, setSelRole]=useState("");
   const [filteredAccounts, setFilteredAccounts] = useState(accounts);

    useEffect(() => {
        setFilteredAccounts(accounts);
    }, [accounts]);
 
   console.log("acc ; ", accounts)
   
    return (
        <div className="rounded-lg w-[50vw]">
          <div className="pb-3">
          <div className="w-full flex justify-center items-center">
                <div className="relative w-4/5">
                  <div className=" absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                    <svg
                      aria-hidden="true"
                      className="w-5 h-5 text-gray-500 dark:text-gray-400"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
                      />
                    </svg>
                  </div>
                  <input
                    value={search}
                    onChange={(e)=>setSearch(e.target.value)}
                    type="search"
                    id="default-search"
                    className=" block w-4/5 p-2 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="Search..."
                    required
                  />
                </div>
               
                <select
                  value={selRole}
                  onChange={(e)=>setSelRole(e.target.value)}
                  id="countries"
                  className="bg-gray-50 border mr-[5%] border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 w-2/5"
                >
                  <option selected value="">
                    Role
                  </option>
                  {
                    roles.map((item)=>{
                      return <option id={`${item.roleId}`} value={`${item.roleName}`}>{item.roleName}</option>
                    })
                  }
                </select>
               
              </div>
          </div>
        <table className="w-full text-sm text-center text-gray-500 dark:text-gray-400 rounded-lg border-collapse">
          <thead className="text-xs text-white bg-sky-400 border-b-0 dark:bg-sky-200 dark:text-gray-500">
            <tr>
              <th
                scope="col"
                className="w-3/8 px-3 py-3 font-semibold rounded-tl-lg"
              >
                Username
              </th>
              {/* <th scope="col" className="w-1/8 px-3 py-3 font-semibold">
                Phone Number
              </th> */}
              <th scope="col" className="w-1/8 px-3 py-3 font-semibold">
                Role
              </th>
              <th scope="col" className="w-1/8 px-3 py-3 font-semibold">
              </th>
              <th scope="col" className="w-1/8 px-3 py-3 font-semibold">
              </th>
              {/* <th
                scope="col"
                className="w-1/8 px-3 py-3 font-semibold rounded-tr-lg"
              >
                &nbsp;
              </th> */}
            </tr>
          </thead>
          <tbody className="border-[1.5px] border-t-0 border-sky-200">
          {
                    filteredAccounts?.filter((item)=>{
                        return(
                            item?.userName
                        ).toLowerCase().includes(search.toLowerCase())&&(selRole==""||item?.roleAccount[0].role.roleName?.toLowerCase().includes(selRole.toLowerCase()))
                    })?.map((item) => {
                        const tmp ={accountId:item.accountId, roleId:[`${item.roleAccount[0].role.roleId}`]}
                        return (
                            <tr key={item.accountId}>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.userName}</td>
                                {/* <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.phoneNumber}</td> */}
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.roleAccount[0].role.roleName}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500" onClick={()=>{setSelectAccount(tmp); setCheck(true)}}>✏️</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-r-slate-500" onClick={()=>{deleteAccount(item.accountId)}}>❌</td>
                                {/* {
                                    item.roleAccount[0].role.roleName=='Giáo Viên'?(<td class=" border-t-slate-500 border-b-slate-500 border-r-slate-500" onClick={()=>handleClick(item.accountId)}>📖</td>):""

                                    
                                } */}
                            </tr>
                        )
                    })
                }
          </tbody>
        </table>

      
      </div>
    )
}
export default TableAccount;