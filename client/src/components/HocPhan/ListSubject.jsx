
import React, { useState, useEffect, useContext } from "react";
import { AccountContext } from "../../contexts/AccountContext";

const ListSubject = () => {
  const [courses, setCourses] = useState([]);
  const [registeredCourses, setRegisteredCourses] = useState([]);
  const [message, setMessage] = useState(null);
  const userId = "e95b6ed8-b38f-4186-ba40-26eb27d62a06";
  const {register,fetchRegister} = useContext(AccountContext);
  useEffect(() => {
    fetchCourses();
  }, []);

  const fetchCourses = async () => {
    try {
      
      const response = await fetch("http://localhost:5146/api/Subject/GetAllOpenedSubjects");
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const data = await response.json();
      setCourses(data);
    } catch (error) {
      console.error("Error fetching courses:", error);
    }
  };

  const handleRegister = async (course) => {
    try {
      console.log({
        studentId: userId,
        subjectId: course.subjectId,
        classroomId: course.schedule[0].classroom.classroomId,
        teacherId: course.schedule[0].teacher.teacherId,
        timeId: course.schedule[0].time.timeId
      });
      const response = await fetch("http://localhost:5146/api/Student/RegisterSubject", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          studentId: userId,
          subjectId: course.subjectId,
          classroomId: course.schedule[0].classroom.classroomId,
          teacherId: course.schedule[0].teacher.teacherId,
          timeId: course.schedule[0].time.timeId
        })
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      await fetchRegister();
      setRegisteredCourses([...registeredCourses, course]);
      setMessage('Đăng ký thành công!'); 
      setTimeout(() => setMessage(null), 3000);
    } catch (error) {
      console.error("Error registering course:", error);
      setMessage('Đăng ký thất bại!'); 
      setTimeout(() => setMessage(null), 3000);
    }
  };

  return (
    <div>
      <h2 className="text-lg font-bold mb-4">Các học phần đang được mở</h2>
      {message && (
        <div className="fixed top-4 right-4 bg-green-200 text-green-800 p-2 rounded shadow-lg">
          {message}
        </div>
      )}
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr>
            <th className="border border-gray-300 p-2 w-24">STT</th>
            <th className="border border-gray-300 p-2">Tên học phần</th>
            <th className="border border-gray-300 p-2">Khoa</th>
            <th className="border border-gray-300 p-2 w-24">Số tín chỉ</th>
            <th className="border border-gray-300 p-2 w-24">Số lượng tối đa</th>
            <th className="border border-gray-300 p-2 w-24">Đã đăng ký</th>
            <th className="border border-gray-300 p-2 w-96">Lịch học</th>
            <th className="border border-gray-300 p-2"></th>
          </tr>
        </thead>
        <tbody>
          {courses.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{index + 1}</td>
              <td className="border border-gray-300 p-2 text-center">{course.subjectName}</td>
              <td className="border border-gray-300 p-2 text-center">{course.faculty.facultyName}</td>
              <td className="border border-gray-300 p-2 text-center">{course.credits}</td>
              <td className="border border-gray-300 p-2 text-center">{course.schedule[0].classroom.maxQuantity}</td>
              <td className="border border-gray-300 p-2 text-center">{course.schedule[0].classroom.currentQuantity}</td>
              <td className="border border-gray-300 p-2 text-center">Từ ngày: {course.startDay} <br/> đến ngày:{course.endDay}</td>
              <td className="border border-gray-300 p-2 text-center">
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
    </div>
  );
};

export default ListSubject;