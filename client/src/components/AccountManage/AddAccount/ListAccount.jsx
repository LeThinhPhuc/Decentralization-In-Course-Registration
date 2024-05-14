import { PhotoIcon, UserCircleIcon } from '@heroicons/react/24/solid'
import { useContext, useState, useEffect } from 'react';
import { AccountContext } from '../../../contexts/AccountContext';
import uuid4 from "uuid4";
const initialValues = {
 id:"",userName:"",passWord:"",role:""
};
const AddAccount = () =>{
  const { selectAccount, check, accounts, setCheck, setAccounts } = useContext(AccountContext);
  const [accountForm, setAccountForm] = useState(initialValues);
  const [noti, setNoti] = useState("")

  useEffect(() => {
    if (check && selectAccount) {
      // If check is true and selectAccount exists, use selectAccount's values
      setAccountForm(selectAccount);
    } else {
      // Otherwise, use default values
      setAccountForm(initialValues);
    }
  }, [check, selectAccount]);

  const handleText = (e) => {
    const { name, value } = e.target;
    setAccountForm({
      ...accountForm,
      [name]: value
    });
  };

  const handleSave = () =>{
    const index = accounts.findIndex(account => account.id === selectAccount.id);
    if (index !== -1) {
      // Create a copy of the accounts array
      const updatedAccounts = [...accounts];
      // Update the account at the found index with new values
      updatedAccounts[index] = { ...updatedAccounts[index], ...accountForm };
      // Set the state with the updated array
      setAccounts(updatedAccounts);
    }
    setCheck(false)
  }

  const handleAdd = () =>{
    if(accountForm.passWord&&accountForm.role&&accountForm.role){
      const id = uuid4(); // Generate a new UUID for the id
      const newAccount = { ...accountForm, id }; // Create a new account object with the id
      const updatedAccounts = [...accounts, newAccount]; // Add the new account to the accounts array
      setAccounts(updatedAccounts); // Update the accounts state
      setAccountForm(initialValues); // Clear the form after adding
      setNoti("")
    }else{
      
      setNoti("Vui long dien du thong tin")
      console.log(noti)
    }
    
    
  }
  const handleCancel = () =>{
    setAccountForm(initialValues)
    setCheck(false)
    setNoti("")

  }



    return(
<div>
      <div className="space-y-12 w-[40vw]">
     

        <div className="border-b border-gray-900/10 pb-12">
          <h2 className="text-base font-semibold leading-7 text-gray-900">Add New Accounts</h2>
          <p className="mt-1 text-sm leading-6 text-gray-600">Use your role to do</p>

          <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
            <div className="sm:col-span-3">
              <label htmlFor="first-name" className="block text-sm font-medium leading-6 text-gray-900">
                Username
              </label>
              <div className="mt-2">
                <input
                  type="text"
                  value={accountForm.userName}
                  onChange={(e)=>handleText(e)}

                  name="userName"
                  id="first-name"
                  autoComplete="given-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>

            <div className="sm:col-span-3">
              <label htmlFor="last-name" className="block text-sm font-medium leading-6 text-gray-900">
                Password
              </label>
              <div className="mt-2">
                <input
                  type="text"
                  value={accountForm.passWord}

                  onChange={(e)=>handleText(e)}

                  name="passWord"
                  id="last-name"
                  autoComplete="family-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>

      

            <div className="sm:col-span-3">
              <label htmlFor="country" className="block text-sm font-medium leading-6 text-gray-900">
                Role
              </label>
              <div className="mt-2">
                <select
                  id="country"
                  name="role"
                  value={accountForm.role}
                  
                  onChange={(e)=>handleText(e)}

                  autoComplete="country-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:max-w-xs sm:text-sm sm:leading-6"

                >
                  <option>Role</option>

                  <option value="Truong Pho Khoa">Trưởng Phó Khoa</option>
                  <option value="Truong Bo Mon">Trưởng Bộ Môn</option>
                  <option value="Giao Vu">Giáo Vụ</option>
                  <option value="Giao Vien">Giáo Viên</option>
                  <option value="Sinh Vien">Sinh Viên</option>

                </select>
              </div>
            </div>

            
          </div>
        </div>

       
      </div>
      <h2>{noti}</h2>

      <div className="mt-6 flex items-center justify-end gap-x-6">
        <button type="button" className="text-sm font-semibold leading-6 text-gray-900"
        onClick={handleCancel}
        >
          Cancel
        </button>
        {
          check?(
            <button
          type="submit"
          onClick={handleSave}
          className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
          Save
        </button>
          ):(
            <button
          type="submit"
          onClick={handleAdd}
          className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
          Add
        </button>
          )
        }
      </div>
    </div>    )
}
export default AddAccount;