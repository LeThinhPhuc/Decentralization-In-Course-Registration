import React, { useEffect, useState } from "react";
import axios from "axios";
import FormCreate from "./FormCreate";
import FormUpdate from "./FormUpdate";
import FormSchedule from "./FormSchedule";
import ListSubjectStudent from "./ListSubjectStudent";

const ListClass = () => {
  const [query, setQuery] = useState("");
  const [data, dataSet] = useState([]);
  const [openAddModal, setOpenAddModal] = useState(false);
  const [openEditModal, setOpenEditModal] = useState(false);
  const [openViewModal, setOpenViewModal] = useState(false);
  const [openScheduleModal, setOpenScheduleModal] = useState(false);
  const [editID, setEditId] = useState(-1);
  const [editData, setEditData] = useState([]);
  const [value, setValue] = useState({
    subjectId: "",
    isOpen: true,
  });
  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Subject/GetAllSubjectsWithSchedule")
      .then((res) => {
        dataSet(res.data);
      })
      .catch((er) => console.log(er));
  });
  const handleDelete = (id) => {
    const confirm = window.confirm("Would you like to delete this class?");
    if (confirm) {
      axios
        .delete(
          "http://localhost:5146/api/Subject/DeleteSubject?subjectId=" + id
        )
        .then((res) => {
          location.reload();
        })
        .catch((err) => console.log(err));
    }
  };
  const handleEdit = (id, datas) => {
    setEditId(id);

    setEditData(datas);
  };

  const handleOpen = () => {
    axios
      .put("http://localhost:5146/api/Subject/OpenOrCloseSubject", value)
      .then((res) => {
        console.log(res);
        location.reload();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div>
      <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <form className="max-w-full mx-auto">
          <label
            for="default-search"
            className="mb-2 text-sm font-medium text-gray-900 sr-only "
          >
            Search
          </label>
          <div className="relative">
            <div className="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
              <svg
                className="w-4 h-4 text-gray-500 "
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
              className="block w-full p-4 ps-10 text-sm text-gray-900  border-gray-300 rounded-lg bg-gray-100  "
              placeholder="Search Mockups, Logos..."
              required
              onChange={(e) => setQuery(e.target.value)}
            />
          </div>
        </form>
        <table className="w-full text-sm text-left rtl:text-right text-gray-500 ">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 ">
            <tr>
              <th scope="col" className="px-6 py-3">
                Tên học phần
              </th>
              <th scope="col" className="px-6 py-3">
                Số tín chỉ
              </th>
              <th scope="col" className="px-6 py-3">
                Thời gian bắt đầu và kết thúc
              </th>
              <th scope="col" className="px-6 py-3">
                Tình trạng
              </th>
              <th scope="col" className="px-6 py-3">
                Khoa
              </th>
              {/* <th scope="col" className="px-6 py-3">
                Phòng học
              </th>
              <th scope="col" className="px-6 py-3">
                Số lượng hiện tại
              </th>
              <th scope="col" className="px-6 py-3">
                Sĩ số lớp
              </th>
              <th scope="col" className="px-6 py-3">
                Thời gian học
              </th>
              <th scope="col" className="px-6 py-3">
                Giảng viên hướng dẫn
              </th> */}

              <th scope="col" className="px-6 py-3"></th>
            </tr>
          </thead>

          <tbody>
            {data
              .filter((item) => item.subjectName.toLowerCase().includes(query))
              .map((item, index) => (
                <tr className="odd:bg-white  even:bg-gray-50 " key={index}>
                  <th
                    scope="row"
                    className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap "
                  >
                    {item.subjectName}
                  </th>

                  <td className="px-6 py-4">{item.credits}</td>
                  <td className="px-6 py-4">
                    {item.startDay} - {item.endDay}
                  </td>
                  <td className="px-6 py-4">{item.isOpen ? "Mở" : "Đóng"}</td>
                  <td className="px-6 py-4">{item.faculty.facultyName}</td>

                  {/* <td className="px-6 py-4">
                    {item.subjectClass[0].classroom.classroomName}
                  </td>
                  <td className="px-6 py-4">
                    {item.subjectClass[0].classroom.currentQuantity}
                  </td>
                  <td className="px-6 py-4">
                    {item.subjectClass[0].classroom.maxQuantity}
                  </td>
                  <td className="px-6 py-4">
                    {item.subjectClass[0].time.startTime}-
                    {item.subjectClass[0].time.endTime}
                  </td>
                  <td className="px-6 py-4">
                    {item.subjectClass[0].teacher.teacherName}
                  </td> */}

                  <td className="px-6 py-4 flex">
                    <button
                      data-modal-hide="static-modal"
                      type="button"
                      className="text-white bg-green-300 hover:bg-green-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                      onClick={() => {
                        setOpenViewModal(true);
                        setEditId(item.subjectId);
                      }}
                    >
                      View
                    </button>
                    <button
                      data-modal-hide="static-modal"
                      type="button"
                      className="text-white bg-blue-300 hover:bg-blue-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                      onClick={() => {
                        setOpenEditModal(true);
                        handleEdit(item.subjectId, item);
                      }}
                    >
                      Edit
                    </button>
                    <button
                      data-modal-hide="static-modal"
                      type="button"
                      className="text-white bg-orange-300 hover:bg-orange-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                      onClick={() => {
                        setOpenScheduleModal(true);
                        handleEdit(item.subjectId);
                      }}
                    >
                      Schedule
                    </button>
                    <button
                      data-modal-hide="static-modal"
                      type="button"
                      className="text-white bg-red-300 hover:bg-red-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                      onClick={() => handleDelete(item.subjectId)}
                    >
                      Delete
                    </button>
                    {item.isOpen ? (
                      <button
                        data-modal-hide="static-modal"
                        type="button"
                        className="text-white bg-purple-300 hover:bg-purple-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                        onClick={() => {
                          setValue({
                            isOpen: false,
                            subjectId: item.subjectId,
                          });
                          console.log(value);
                          handleOpen();
                        }}
                      >
                        Close
                      </button>
                    ) : (
                      <button
                        data-modal-hide="static-modal"
                        type="button"
                        className="text-white bg-purple-300 hover:bg-purple-400  font-medium rounded-lg text-sm px-5 py-2.5 text-center mx-1"
                        onClick={() => {
                          setValue({
                            isOpen: true,
                            subjectId: item.subjectId,
                          });
                          console.log(value);
                          handleOpen(); // Corrected function call
                        }}
                      >
                        Open
                      </button>
                    )}
                  </td>
                </tr>
              ))}
          </tbody>
        </table>
        <div className="flex items-center p-4 md:p-5 border-t border-gray-300 rounded-b ">
          <button
            data-modal-hide="static-modal"
            type="button"
            className="text-white bg-green-600    font-medium rounded-lg text-sm px-5 py-2.5 text-center "
            onClick={() => {
              setOpenAddModal(true);
            }}
          >
            Create
          </button>

          {openAddModal && <FormCreate closeModal={setOpenAddModal} />}
          {openEditModal && (
            <FormUpdate
              closeModal={setOpenEditModal}
              id={editID}
              datas={editData}
            />
          )}

          {openViewModal && (
            <ListSubjectStudent
              closeModal={setOpenViewModal}
              subjectID={editID}
            />
          )}

          {openScheduleModal && (
            <FormSchedule closeModal={setOpenScheduleModal} id={editID} />
          )}
        </div>
      </div>
    </div>
  );
};

export default ListClass;
