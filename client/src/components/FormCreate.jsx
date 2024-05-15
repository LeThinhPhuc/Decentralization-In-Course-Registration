import axios from "axios";
import React, { useState, useEffect } from "react";

const FormCreate = ({ closeModal }) => {
  const [data, setData] = useState([]);
  const [value, setValue] = useState({
    subjectName: "",
    credits: "",
    startDay: "",
    endDay: "",
    facultyId: "",
  });
  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Faculty/GetAllFaculties")
      .then((res) => {
        setData(res.data);
      })
      .catch((er) => console.log(er));
  });
  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(value);
    axios
      .post("http://localhost:5146/api/Subject/AddNewSubject", value)
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  };
  return (
    <div>
      <div
        id="crud-modal"
        tabindex="-1"
        aria-hidden="true"
        className=" overflow-y-auto overflow-x-hidden fixed top-0 right-0 left-0 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full"
      >
        <div className="relative p-4 w-full max-w-xl max-h-full">
          <div className="relative bg-white rounded-lg shadow ">
            <div className="flex items-center justify-between p-4 md:p-5 border-b rounded-t ">
              <h3 className="text-lg font-semibold text-gray-900 ">
                Add new classes
              </h3>
              <button
                type="button"
                className="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 ms-auto inline-flex justify-center items-center "
                data-modal-toggle="crud-modal"
                onClick={() => closeModal(false)}
              >
                <svg
                  className="w-3 h-3"
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
                <span className="sr-only">Close modal</span>
              </button>
            </div>

            <form className="p-4 md:p-5" onSubmit={handleSubmit}>
              <div className="grid gap-4 mb-4 grid-cols-4">
                <div className="col-span-2">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Tên học phần
                  </label>
                  <input
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    required=""
                    onChange={(e) => {
                      setValue({ ...value, subjectName: e.target.value });
                    }}
                  />
                </div>
                <div className="col-span-2">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Tín chỉ
                  </label>
                  <input
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    required=""
                    onChange={(e) =>
                      setValue({ ...value, credits: e.target.value })
                    }
                  />
                </div>

                <div className="col-span-2 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Thời gian bắt đầu
                  </label>
                  <input
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    required=""
                    onChange={(e) =>
                      setValue({ ...value, startDay: e.target.value })
                    }
                  />
                </div>

                <div className="col-span-2 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Thời gian kết thúc
                  </label>
                  <input
                    datepicker
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    onChange={(e) =>
                      setValue({ ...value, endDay: e.target.value })
                    }
                  />
                </div>

                <div className="col-span-4 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Khoa
                  </label>

                  <select
                    onChange={(e) => {
                      setValue({ ...value, facultyId: e.target.value });
                    }}
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5"
                  >
                    {data.map((item) => {
                      return (
                        <option
                          key={item.facultyId}
                          value={item.facultyId}
                          className=""
                        >
                          {item.facultyName}
                        </option>
                      );
                    })}
                  </select>
                </div>
              </div>
              <button
                type="submit"
                className="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800  font-medium rounded-lg text-sm px-5 py-2.5 text-center "
                onClick={handleSubmit}
              >
                <svg
                  className="me-1 -ms-1 w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    fill-rule="evenodd"
                    d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                    clip-rule="evenodd"
                  ></path>
                </svg>
                Save
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default FormCreate;
