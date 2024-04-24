import React, { useState } from "react";
import { Users } from "../../users";

const ListAccount = () => {
  const [query, setQuery] = useState("");
  return (
    <div className=" text-center ">
      <div
        id="static-modal"
        data-modal-backdrop="static"
        tabindex="-1"
        aria-hidden="true"
        class=" overflow-y-auto overflow-x-auto fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full"
      >
        <div class="relative p-4 w-full max-w-[70vw] ">
          <div class="relative bg-gray-100 rounded-lg shadow-xl ">
            <div class="flex items-center justify-between p-4 md:p-5 border-b border-gray-300 rounded-t ">
              <h3 class="text-xl font-semibold text-gray-900 ">
                Danh sách học sinh
              </h3>
              <button
                type="button"
                class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ms-auto inline-flex justify-center items-center "
                data-modal-hide="static-modal"
              >
                <svg
                  class="w-3 h-3"
                  aria-hidden="true"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 14 14"
                >
                  <path
                    stroke="currentColor"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"
                  />
                </svg>
                <span class="sr-only">Close</span>
              </button>
            </div>

            <form class="max-w-md mx-auto">
              <label
                for="default-search"
                class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
              >
                Search
              </label>
              <div class="relative">
                <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                  <svg
                    class="w-4 h-4 text-gray-500 dark:text-gray-400"
                    aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 20 20"
                  >
                    <path
                      stroke="currentColor"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
                    />
                  </svg>
                </div>
                <input
                  type="search"
                  id="default-search"
                  class="block w-full p-4 ps-10 text-sm text-gray-900  border-gray-300 rounded-lg bg-gray-100 focus:ring-blue-500 focus:border-blue-500   "
                  placeholder="Search Mockups, Logos..."
                  required
                  onChange={(e) => setQuery(e.target.value)}
                />
                {/* <button
                  type="submit"
                  class="text-white absolute end-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
                >
                  Search
                </button> */}
              </div>
            </form>

            <div class="relative overflow-x-auto">
              <table class="w-full text-sm text-left rtl:text-right text-gray-500 ">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50 ">
                  <tr>
                    <th scope="col" class="px-6 py-3">
                      MSSV
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Họ và tên
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Số điện thoại
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Điểm hệ số 1
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Diểm hệ số 2
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Diểm hệ số 3
                    </th>
                    <th scope="col" class="px-6 py-3">
                      Diểm trung bình
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {Users.filter(
                    (item) =>
                      item.Name.toLowerCase().includes(query) ||
                      item.MSSV.toLowerCase().includes(query)
                  ).map((item) => (
                    <tr class="bg-white border-b " key={item.id}>
                      <th
                        scope="row"
                        class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap "
                      >
                        {item.MSSV}
                      </th>
                      <td class="px-6 py-4">{item.Name}</td>
                      <td class="px-6 py-4">{item.SDT}</td>
                      <td>
                        <input
                          type="grade"
                          class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                          placeholder=" "
                          required
                        />
                      </td>
                      <td>
                        <input
                          type="grade"
                          class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                          placeholder=" "
                          required
                        />
                      </td>
                      <td>
                        <input
                          type="grade"
                          class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                          placeholder=" "
                          required
                        />
                      </td>
                      <td class="px-6 py-4">""</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>

            <div class="flex items-center p-4 md:p-5 border-t border-gray-300 rounded-b ">
              <button
                data-modal-hide="static-modal"
                type="button"
                class="text-white bg-green-300 hover:bg-green-400 focus:ring-4 focus:outline-none focus:ring-green-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center "
              >
                Save
              </button>
              <button
                data-modal-hide="static-modal"
                type="button"
                class="py-2.5 px-5 ms-3 text-sm font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200  hover:bg-red-500 hover:text-white focus:z-10 focus:ring-4 focus:ring-gray-100 "
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default ListAccount;
