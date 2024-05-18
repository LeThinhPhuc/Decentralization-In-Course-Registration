import React, { useEffect, useState } from "react";
import axios from "axios";

const ListAccount = ({ closeModal, id }) => {
  const [query, setQuery] = useState("");
  const [data, dataSet] = useState([]);
  const [editID, setEditId] = useState(-1);
  const [grade1, setGrade1] = useState(0);
  const [grade2, setGrade2] = useState(0);
  const [grade3, setGrade3] = useState(0);

  useEffect(() => {
    axios
      .get(
        "http://localhost:5146/api/Subject/ListStudentsRegisterSubject?SubjectId=" +
          id
      )
      .then((res) => dataSet(res.data))
      .catch((er) => console.log(er));
  });
  const handleEdit = (id) => {
    // axios
    //   .get(
    //     "http://localhost:5146/api/Subject/ListStudentsRegisterSubject?subjectId=" +
    //       id
    //   )
    //   .then((res) => {
    //     console.log(res.data);
    //     setGrade1(res.data.grade1);
    //     setGrade2(res.data.grade2);
    //     setGrade3(res.data.grade3);
    //   });
    // setEditId(id);
  };

  const handleUpdate = () => {
    // const user = axios.get("" + editID).then((r) => r.data);
    // axios
    //   .patch("" + editID, {
    //     Grade1: grade1,
    //     Grade2: grade2,
    //     Grade3: grade3,
    //   })
    //   .then((res) => {
    //     console.log(user);
    //     console.log(res);
    //     location.reload();
    //     setEditId(-1);
    //   })
    //   .catch((err) => console.log(err));
  };
  return (
    <div className=" text-center ">
      <div
        id="static-modal"
        data-modal-backdrop="static"
        tabindex="-1"
        aria-hidden="true"
        className=" bg-black bg-opacity-50 flex overflow-y-auto overflow-x-hidden fixed top-1/2  left-1/2 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full"
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
                onClick={() => closeModal(false)}
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
                  class="block w-full p-4 ps-10 text-sm text-gray-900  border-gray-300 rounded-lg bg-gray-100  "
                  placeholder="Search Mockups, Logos..."
                  required
                  onChange={(e) => setQuery(e.target.value)}
                />
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
                    <th scope="col" class="px-6 py-3"></th>
                  </tr>
                </thead>
                <tbody>
                  {data
                    .filter((item) => {
                      item.StudentName.toLowerCase().includes(query) ||
                        item.Username.toLowerCase().includes(query);
                    })
                    .map((item, index) =>
                      item.id === editID ? (
                        <tr class="bg-white border-b ">
                          <th
                            scope="row"
                            class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap "
                          >
                            {item.Username}
                          </th>
                          <td class="px-6 py-4">{item.StudentName}</td>
                          <td>
                            <input
                              type="number"
                              id="company"
                              min="0"
                              max="10"
                              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5  "
                              required
                              onChange={(e) => setGrade1(e.target.value)}
                            />
                          </td>
                          <td>
                            <input
                              type="number"
                              id="company"
                              min="0"
                              max="10"
                              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5  "
                              onChange={(e) => setGrade2(e.target.value)}
                            />
                          </td>
                          <td>
                            <input
                              type="number"
                              id="company"
                              min="0"
                              max="10"
                              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5  "
                              required
                              onChange={(e) => setGrade3(e.target.value)}
                            />
                          </td>
                          <td class="px-6 py-4">
                            {(
                              (parseFloat(item.Mark1) +
                                parseFloat(item.Mark2) * 2 +
                                parseFloat(item.Mark3) * 3) /
                              6
                            ).toFixed(2)}
                          </td>
                          <td class="px-6 py-4 flex">
                            <button
                              data-modal-hide="static-modal"
                              type="button"
                              class="text-white bg-green-300 hover:bg-green-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                              onClick={handleUpdate}
                            >
                              Save
                            </button>
                            <button
                              data-modal-hide="static-modal"
                              type="button"
                              class="text-white bg-red-300 hover:bg-red-400   font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                              onClick={() => handleEdit(-1)}
                            >
                              Cancel
                            </button>
                          </td>
                        </tr>
                      ) : (
                        <tr class="bg-white border-b " key={index}>
                          <th
                            scope="row"
                            class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap "
                          >
                            {item.Username}
                          </th>
                          <td class="px-6 py-4">{item.StudentName}</td>
                          <td class="px-6 py-4">{item.Mark1}</td>
                          <td class="px-6 py-4">{item.Mark2}</td>
                          <td class="px-6 py-4">{item.Mark3}</td>
                          <td class="px-6 py-4">
                            {(
                              (parseFloat(item.Mark1) +
                                parseFloat(item.Mark2) * 2 +
                                parseFloat(item.Mark3) * 3) /
                              6
                            ).toFixed(2)}
                          </td>
                          <td class="px-6 py-4 flex">
                            <button
                              data-modal-hide="static-modal"
                              type="button"
                              class="text-white bg-blue-300 hover:bg-blue-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                              onClick={() => handleEdit(item.id)}
                            >
                              Edit
                            </button>
                            <button
                              data-modal-hide="static-modal"
                              type="button"
                              class="text-white bg-red-300 hover:bg-red-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                            >
                              Delete
                            </button>
                          </td>
                        </tr>
                      )
                    )}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default ListAccount;
