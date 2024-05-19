
import React, { useState, useEffect, useContext } from "react";
import { AccountContext } from "../../contexts/AccountContext";
import { Await } from "react-router-dom";

const ListRegister = () => {
  const [courses, setCourses] = useState([]);
  const [message, setMessage] = useState(null); // State to store the message
  const userId = 'e95b6ed8-b38f-4186-ba40-26eb27d62a06';
  const {register,fetchRegister} = useContext(AccountContext);
  useEffect(() => {
    // fetchCourses(userId);
    setCourses(register);
  }, [register]);

  // const fetchCourses = async (userId) => {
  //   try {
  //     const response = await fetch(`http://localhost:5146/api/Student/GetRegisteredSubjectsByStudentId?studentId=${userId}`);
  //     if (!response.ok) {
  //       throw new Error("Network response was not ok");
  //     }
  //     const data = await response.json();
  //     setCourses(data.registeredSubjects || []);
  //   } catch (error) {
  //     console.error("Lỗi khi lấy dữ liệu khóa học:", error);
  //   }
  // };

  const handleDelete = async (course) => {
    try {
      console.log({
        studentId: "e95b6ed8-b38f-4186-ba40-26eb27d62a06",
        subjectId: course.subject.subjectId,
        classroomId: course.classroom.classRoomId,
        teacherId: course.teacher.teacherId,
        timeId: course.time.timeId
      });
      const response = await fetch("http://localhost:5146/api/Student/DeleleRegisteredSubject", {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          studentId: "e95b6ed8-b38f-4186-ba40-26eb27d62a06",
          subjectId: course.subject.subjectId,
          classroomId: course.classroom.classRoomId,
          teacherId: course.teacher.teacherId,
          timeId: course.time.timeId
        })
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      await fetchRegister()
      // Xóa học phần khỏi state sau khi xóa thành công
      setCourses(courses.filter(c => c.subject.subjectId !== course.subject.subjectId));
      setMessage('Hủy đăng ký thành công!'); 
      setTimeout(() => setMessage(null), 3000); 
    } catch (error) {
      console.error("Error deleting course:", error);
    }
  };

  return (
    <div>
      <h2 className="text-lg font-bold mt-8 mb-4">Các môn đã đăng ký</h2>
      {message && <div className="mb-4 p-2 bg-green-200 text-green-800 rounded">{message}</div>}
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr>
            <th className="border border-gray-300 p-2">STT</th>
            <th className="border border-gray-300 p-2">Tên LHP</th>
            <th className="border border-gray-300 p-2">Phòng học</th>
            <th className="border border-gray-300 p-2">Giảng viên</th>
            <th className="border border-gray-300 p-2">Từ ngày</th>
            <th className="border border-gray-300 p-2">Đến ngày</th>
            <th className="border border-gray-300 p-2"></th>
          </tr>
        </thead>
        <tbody>
          {courses?.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{index + 1}</td>
              <td className="border border-gray-300 p-2 text-center">{course.subject.subjectName}</td>
              <td className="border border-gray-300 p-2 text-center">{course.classroom.classroomName}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.teacher.teacherName}</td>
              <td className="border border-gray-300 p-2">{course.date.startDay}</td>
              <td className="border border-gray-300 p-2">{course.date.endDay}</td>
              <td className="border border-gray-300 p-2 text-center">
                <button
                  className="bg-red-500 text-white py-1 px-2 rounded"
                  onClick={() => handleDelete(course)}
                >
                  Hủy
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListRegister;