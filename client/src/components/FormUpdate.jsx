import axios from "axios";
import React, { useState, useEffect } from "react";

const FormUpdate = ({ closeModal, id, datas }) => {
  const [data, setData] = useState([]);
  const [info, setInfo] = useState({
    subjectId: datas.subjectId,
    subjectName: datas.subjectName,
    credits: datas.credits,
    startDay: datas.startDay,
    endDay: datas.endDay,
    facultyId: datas.facultyId,
    isOpen: true,
  });

  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Faculty/GetAllFaculties")
      .then((res) => {
        setData(res.data);
      })
      .catch((er) => console.log(er));
  });

  const handleUpdate = (event) => {
    event.preventDefault();
    console.log(info);
    axios
      .put(
        "http://localhost:5146/api/Subject/UpdateSubject?subjectId=" + id,
        info
      )
      .then((res) => {
        console.log(res);
        location.reload();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div className="flex items-center justify-center h-screen">
      <div
        id="crud-modal"
        tabindex="-1"
        aria-hidden="true"
        className=" bg-black bg-opacity-50 flex overflow-y-auto overflow-x-hidden fixed top-1/2  left-1/2 z-50 justify-center items-center w-full md:inset-0 h-[calc(100%-1rem)] max-h-full"
      >
        <div className="relative p-4 w-full max-w-xl max-h-full">
          <div className="relative bg-white rounded-lg shadow ">
            <div className="flex items-center justify-between p-4 md:p-5 border-b rounded-t ">
              <h3 className="text-lg font-semibold text-gray-900 ">
                Update class
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

            <form className="p-4 md:p-5" onSubmit={handleUpdate}>
              <div className="grid gap-4 mb-4 grid-cols-4">
                <div className="col-span-2">
                  <label
                    for="name"
                    className="block mb-2 text-sm font-medium text-gray-900 "
                  >
                    Tên học phần
                  </label>
                  <input
                    type="text"
                    name="name"
                    id="name"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    value={info.subjectName}
                    onChange={(e) =>
                      setInfo({ ...info, subjectName: e.target.value })
                    }
                  />
                </div>
                <div className="col-span-2">
                  <label
                    for="name"
                    className="block mb-2 text-sm font-medium text-gray-900 "
                  >
                    Tín chỉ
                  </label>
                  <input
                    type="number"
                    name="name"
                    id="name"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    required=""
                    value={info.credits}
                    onChange={(e) =>
                      setInfo({ ...info, credits: e.target.value })
                    }
                  />
                </div>

                <div className="col-span-2 ">
                  <label
                    for="price"
                    className="block mb-2 text-sm font-medium text-gray-900 "
                  >
                    Thời gian bắt đầu (YYYY/MM/DD)
                  </label>
                  <input
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    value={info.startDay}
                    onChange={(e) =>
                      setInfo({
                        ...info,
                        startDay: e.target.value + "T14:18:31.774",
                      })
                    }
                  />
                </div>

                <div className="col-span-2 ">
                  <label
                    for="category"
                    className="block mb-2 text-sm font-medium text-gray-900 "
                  >
                    Thời gian kết thúc (YYYY/MM/DD)
                  </label>
                  <input
                    datepicker
                    type="text"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    value={info.endDay}
                    onChange={(e) =>
                      setInfo({
                        ...info,
                        endDay: e.target.value + "T14:18:31.774",
                      })
                    }
                  />
                </div>

                <div className="col-span-2 ">
                  <label
                    for="category"
                    className="block mb-2 text-sm font-medium text-gray-900 "
                  >
                    Khoa
                  </label>
                  {/* <input
                    type="text"
                    name="price"
                    id="price"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5 "
                    required=""
                    onChange={(e) =>
                      setValue({ ...value, facultyId: e.target.value })
                    }
                  /> */}
                  <select
                    onChange={(e) => {
                      setInfo({ ...info, facultyId: e.target.value });
                    }}
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5"
                  >
                    <option className="">Chọn khoa</option>
                    {data?.map((item) => {
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
                onClick={handleUpdate}
              >
                Save
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default FormUpdate;
