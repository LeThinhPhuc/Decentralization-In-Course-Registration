import React, { useState ,useEffect} from "react";

const ListSubject = () => {
  const [courses, setCourses] = useState([]);
  const [registeredCourses, setRegisteredCourses] = useState([]); // Thêm registeredCourses và setRegisteredCourses
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
      console.log({studentId: "e95b6ed8-b38f-4186-ba40-26eb27d62a06", 
        subjectId: course.subjectId ,
        classroomId: course.classroomId,
        teacherId: course.teacherId,
        timeId: course.timeId});
      const response = await fetch("http://localhost:5146/api/Student/RegisterSubject", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        
        body: JSON.stringify({
          studentId: "e95b6ed8-b38f-4186-ba40-26eb27d62a06", 
          subjectId: course.subjectId ,
          classroomId: course.schedule[0].classroom.classroomId,
          teacherId: course.schedule[0].teacher.teacherId,
          timeId: course.schedule[0].time.timeId
        })
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      // Nếu request thành công, cập nhật danh sách môn đã đăng ký
      setRegisteredCourses([...registeredCourses, course]);
    } catch (error) {
      console.error("Error registering course:", error);
    }
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
            <th className="border border-gray-300 p-2">Ngày bắt đầu</th>
            <th className="border border-gray-300 p-2">Ngày kết thúc</th>
            <th className="border border-gray-300 p-2"></th>
          </tr>
        </thead>
        <tbody>
          {courses.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{index + 1}</td>
              <td className="border border-gray-300 p-2 text-center">{course.subjectName}</td>
              <td className="border border-gray-300 p-2">{course.subjectName}</td>
              <td className="border border-gray-300 p-2 text-center">{course.credits}</td>
              <td className="border border-gray-300 p-2 text-center">{course.startDay}</td>
              <td className="border border-gray-300 p-2 text-center">{course.endDay}</td>
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
    </div>
  );
};

export default ListSubject;