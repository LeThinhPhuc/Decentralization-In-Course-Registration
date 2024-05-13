import { PhotoIcon, UserCircleIcon } from "@heroicons/react/24/solid";
import { useContext, useState, useEffect } from "react";
import { AccountContext } from "../../../contexts/AccountContext";
import uuid4 from "uuid4";
import accountService from "../../../services/accountService";
import roleService from "../../../services/roleService";

const AddAccount = () => {
  const {
    selectAccount,
    check,
    accounts,
    setCheck,
    setAccounts,
    khoaId,
    roles,
    fetchAccounts,
  } = useContext(AccountContext);
  const initialValues = {
    userName: "",
    password: "",
    roleId: [],
    personInfo: {
      fullName: "None",
      gender: "None",
      phoneNumber: "None",
      dateOfBirth: `2024-05-14T05:01:41.327Z`,
      address: "None",
      facultyId: khoaId,
    },
  };
  const [accountForm, setAccountForm] = useState(initialValues);
  const [noti, setNoti] = useState("");

  useEffect(() => {
    if (check && selectAccount) {
      // If check is true and selectAccount exists, use selectAccount's values
      setAccountForm(selectAccount);
      console.log(accountForm);
    } else {
      // Otherwise, use default values
      setAccountForm(initialValues);
    }
  }, [check, selectAccount]);

  const handleText = (e) => {
    const { name, value } = e.target;
    setAccountForm({
      ...accountForm,
      [name]: value,
    });
  };

  const onChange = (e) => {
    setAccountForm({ ...accountForm, roleId: [e] });
    console.log(accountForm);
  };

  const handleSave = async () => {
    // Create a copy of the accounts array
    // const updatedAccounts = [...accounts];
    // Update the account at the found index with new values
    // updatedAccounts[index] = { ...updatedAccounts[index], ...accountForm };
    console.log({
      accountId: accountForm.accountId,
      roleIds: accountForm.roleId[0],
    });
    await roleService.updateRoleAccount({
      accountId: accountForm.accountId,
      roleIds: accountForm.roleId,
    });

    // Set the state with the updated array
    // setAccounts(updatedAccounts);
    await fetchAccounts();

    setCheck(false);
  };

  const handleAdd = async () => {
    if (accountForm.password && accountForm.roleId && accountForm.roleId) {
      await accountService.createAccount(accountForm);
      console.log("them: ", accountForm);
      await fetchAccounts();
      // setAccounts(updatedAccounts); // Update the accounts state
      setAccountForm(initialValues); // Clear the form after adding
      setNoti("");
    } else {
      setNoti("Vui long dien du thong tin");
      console.log(noti);
    }
  };
  const handleCancel = () => {
    setAccountForm(initialValues);
    setCheck(false);
    setNoti("");
  };

  return (
    <div>
      <div className="space-y-12 w-[40vw]">
        <div className="border-b border-gray-900/10 pb-12">
          <h2 className="text-base font-semibold leading-7 text-gray-900">
            Add New Accounts
          </h2>
          <p className="mt-1 text-sm leading-6 text-gray-600">
            Use your role to do
          </p>

          <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
            <div className="sm:col-span-3">
              <label
                htmlFor="first-name"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Username
              </label>
              <div className="mt-2">
                <input
                  type="text"
                  value={accountForm.userName}
                  onChange={(e) => handleText(e)}
                  name="userName"
                  id="first-name"
                  autoComplete="given-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>

            <div className="sm:col-span-3">
              <label
                htmlFor="last-name"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Password
              </label>
              <div className="mt-2">
                <input
                  type="text"
                  value={accountForm.password}
                  onChange={(e) => handleText(e)}
                  name="password"
                  id="last-name"
                  autoComplete="family-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>

            <div className="sm:col-span-3">
              <label
                htmlFor="country"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Role
              </label>
              <div className="mt-2">
                <select
                  id="country"
                  name="roleId"
                  value={accountForm.roleId}
                  onChange={(e) => onChange(e.target.value)}
                  autoComplete="country-name"
                  className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:max-w-xs sm:text-sm sm:leading-6"
                >
                  <option>Role</option>

                  {roles.map((item) => {
                    return (
                      <option value={`${item.roleId}`} id={`${item.roleName}`}>
                        {item.roleName}
                      </option>
                    );
                  })}
                </select>
              </div>
            </div>
          </div>
        </div>
      </div>
      <h2>{noti}</h2>

      <div className="mt-6 flex items-center justify-end gap-x-6">
        <button
          type="button"
          className="text-sm font-semibold leading-6 text-gray-900"
          onClick={handleCancel}
        >
          Cancel
        </button>
        {check ? (
          <button
            type="submit"
            onClick={handleSave}
            className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Save
          </button>
        ) : (
          <button
            type="submit"
            onClick={handleAdd}
            className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Add
          </button>
        )}
      </div>
    </div>
  );
};
export default AddAccount;
