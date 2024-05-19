import axios from "axios";
import React, { useState, useEffect } from "react";

const FormSchedule = ({ closeModal, id }) => {
  const [data, setData] = useState([]);
  const [teacherData, setTeacherData] = useState([]);
  const [timeData, setTimeData] = useState([]);
  const [classroomData, setClassroomData] = useState([]);

  const [schedule, setSchedule] = useState({
    teacherId: "",
    timeId: "",
    subjectId: id,
    classRoomId: "",
  });

  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Teacher/GetAllTeachers")
      .then((res) => {
        setTeacherData(res.data);
      })
      .catch((er) => console.log(er));
  });

  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Time/GetAllTime")
      .then((res) => {
        setTimeData(res.data);
      })
      .catch((er) => console.log(er));
  });

  useEffect(() => {
    axios
      .get("http://localhost:5146/api/Classroom/GetAllClassrooms")
      .then((res) => {
        setClassroomData(res.data);
      })
      .catch((er) => console.log(er));
  });

  const handleUpdate = (event) => {
    event.preventDefault();
    console.log(schedule);
    axios
      .put("http://localhost:5146/api/Schedule/AddNewSchedule", schedule)
      .then((res) => {
        console.log(res);
        location.reload();
      })
      .catch((err) => console.log(err));
  };

  const renderSwitch = (param) => {
    switch (param) {
      case 1:
        return "Thứ hai";
      case 2:
        return "Thứ ba";
      case 3:
        return "Thứ tư";
      case 4:
        return "Thứ năm";
      case 5:
        return "Thứ sáu";
      case 7:
        return "Thứ bảy";
      default:
        return "foo";
    }
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
                Schedule this classs
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
                <div className="col-span-4 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Phòng học
                  </label>

                  <select
                    onChange={(e) => {
                      setSchedule({ ...schedule, classRoomId: e.target.value });
                    }}
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5"
                  >
                    <option>Chọn lớp học</option>
                    {classroomData.map((item) => {
                      return (
                        <option
                          key={item.classroomId}
                          value={item.classroomId}
                          className=""
                        >
                          {item.classroomName} (SL: {item.maxQuantity})
                        </option>
                      );
                    })}
                  </select>
                </div>
                <div className="col-span-4 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Giáo viên
                  </label>

                  <select
                    onChange={(e) => {
                      setSchedule({ ...schedule, teacherId: e.target.value });
                    }}
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5"
                  >
                    <option>Chọn giáo viên</option>
                    {teacherData.map((item) => {
                      return (
                        <option
                          key={item.teacherId}
                          value={item.teacherId}
                          className=""
                        >
                          {item.teacherName}
                        </option>
                      );
                    })}
                  </select>
                </div>
                <div className="col-span-4 ">
                  <label className="block mb-2 text-sm font-medium text-gray-900 ">
                    Tiết học
                  </label>

                  <select
                    onChange={(e) => {
                      setSchedule({ ...schedule, timeId: e.target.value });
                    }}
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg  block w-full p-2.5"
                  >
                    <option>Chọn thời gian học</option>
                    {timeData.map((item) => {
                      return (
                        <option
                          key={item.timeId}
                          value={item.timeId}
                          className=""
                        >
                          {renderSwitch(item.dayOfWeek)} ({item.startTime} -{" "}
                          {item.endTIme})
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

export default FormSchedule;
