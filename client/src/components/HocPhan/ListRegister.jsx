import React,{useState,useEffect} from "react";


const ListRegister = () => {
  const [courses, setCourses] = useState([]);
  const userId='e95b6ed8-b38f-4186-ba40-26eb27d62a06';
  useEffect(() => {
    
    fetchCourses(userId);
  }, []);
  const fetchCourses = async (userId) => {
    try {
      console.log(userId);
      
      const response = await fetch(`http://localhost:5146/api/Student/GetRegisteredSubjectsByStudentId?studentId=${userId}`);
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const data = await response.json();
      setCourses(data.registeredSubjects[0]);
      console.log(data);
    } catch (error) {
      console.error("Error fetching courses:", error);
    }
  };
  return (
    <div>
      <h2 className="text-lg font-bold mt-8 mb-4">Các môn đã đăng kí</h2>
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr>
            <th className="border border-gray-300 p-2">STT</th>
            <th className="border border-gray-300 p-2">Tên LHP</th>
            <th className="border border-gray-300 p-2">STC</th>
            <th className="border border-gray-300 p-2">GV</th>
            <th className="border border-gray-300 p-2">Lịch học</th>
            <th className="border border-gray-300 p-2">Từ ngày</th>
            <th className="border border-gray-300 p-2">Đến ngày</th>
            <th className="border border-gray-300 p-2">Khoa</th>
          </tr>
        </thead>
        <tbody>
          {courses?.map((course, index) => (
            <tr key={index}>
              <td className="border border-gray-300 p-2 text-center">{index+1}</td>
              <td className="border border-gray-300 p-2 text-center">{course.subject.subject}</td>
              <td className="border border-gray-300 p-2 text-center">{course.credits}</td>
              <td className="border border-gray-300 p-2">{course.schedule.teacher.teacherName}</td>
              <td className="border border-gray-300 p-2">{course.classSchedule}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.startDay}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.endDay}</td>
              <td className="border border-gray-300 p-2 text-nowrap">{course.faculty.facultyName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ListRegister;