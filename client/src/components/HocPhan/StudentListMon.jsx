import React, { useState } from "react";

const OpenCourses = ({ courses }) => {
  const [registeredCourses, setRegisteredCourses] = useState([]);

  const handleRegister = (course) => {
    setRegisteredCourses([...registeredCourses, course]);
  };

  return (
    <div>
      <h2 className="text-lg font-bold mb-4">Các học phần đang được mở</h2>
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr>
            <th className="border border-gray-300 p-2">STT</th>
            <th className="border border-gray-300 p-2">Mã học phần</th>
            <th className="border border-gray-300 p-2">Tên học phần</th>
            <th className="border border-gray-300 p-2">Số tín chỉ</th>
            <th className="border border-gray-300 p-2">Số lượng lớp mở</th>
            <th className="border border-gray-300 p-2"></th>
          </tr>
        </thead>
        <tbody>
          {courses.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{index + 1}</td>
              <td className="border border-gray-300 p-2 text-center">{course.courseCode}</td>
              <td className="border border-gray-300 p-2">{course.courseName}</td>
              <td className="border border-gray-300 p-2 text-center">{course.credit}</td>
              <td className="border border-gray-300 p-2 text-center">{course.numClasses}</td>
              <td className="border border-gray-300 p-2">
                <button
                  className="bg-blue-500 text-white py-1 px-2 rounded"
                  onClick={() => handleRegister(course)}
                >
                  Đăng ký
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Danh sách các môn đã đăng kí */}
      <h2 className="text-lg font-bold mt-8 mb-4">Các môn đã đăng kí</h2>
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr>
            <th className="border border-gray-300 p-2">Loại</th>
            <th className="border border-gray-300 p-2">Mã LHP</th>
            <th className="border border-gray-300 p-2">Tên LHP</th>
            <th className="border border-gray-300 p-2">STC</th>
            <th className="border border-gray-300 p-2">GV</th>
            <th className="border border-gray-300 p-2">Lịch học</th>
            <th className="border border-gray-300 p-2">Từ ngày</th>
            <th className="border border-gray-300 p-2">Đến ngày</th>
          </tr>
        </thead>
        <tbody>
          {registeredCourses.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{course.classType}</td>
              <td className="border border-gray-300 p-2 text-center">{course.classCode}</td>
              <td className="border border-gray-300 p-2">{course.className}</td>
              <td className="border border-gray-300 p-2 text-center">{course.credit}</td>
              <td className="border border-gray-300 p-2 text-center">{course.classTeacher}</td>
              <td className="border border-gray-300 p-2">{course.classSchedule}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.classStartDate}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.classEndDate}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default OpenCourses;