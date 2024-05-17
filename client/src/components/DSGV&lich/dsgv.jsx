import React, { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { AccountContext } from '../../contexts/AccountContext';
const TeacherList = () => {
  const navigate = useNavigate()
  const {teacherFalculty} = useContext(AccountContext)
  const [teachers, setTeachers] = useState([]);
  useEffect(()=>{
    setTeachers(teacherFalculty)
    console.log(teacherFalculty)
  }, [teachers, teacherFalculty])
  const [selectedTeacher, setSelectedTeacher] = useState(null);
  const [searchName, setSearchName] = useState('');
  const handleViewSchedule = (teacher) => {
    setSelectedTeacher(teacher);
  }
  const handleSearchChange = (e) => {
    setSearchName(e.target.value);
  }
  // Lọc danh sách giáo viên dựa trên tên tìm kiếm
  const filteredTeachers = teachers?.filter(teacher =>
    teacher?.teacherInfo.fullName?.toLowerCase().includes(searchName.toLowerCase())
  );
  useEffect(() => {
    fetchTeachers();
  }, []);
  const fetchTeachers = async () => {
    try {
      const response = await fetch('http://localhost:5146/api/Teacher/GetAllTeachers');
      const data = await response.json();
      setTeachers(data);
    } catch (error) {
      console.error('Error fetching teachers:', error);
    }
  };
  

  const handleClick = (id) =>{
    navigate(`/teacher/${id}`)
}
  return (
    <div className="p-4">
      <h2 className="text-2xl mb-4">Teacher List</h2>

      {/* Trường tìm kiếm */}
      <input
        type="text"
        className="border border-gray-300 rounded-md p-2 mb-4"
        placeholder="Search by name"
        value={searchName}
        onChange={handleSearchChange}
      />

      <table className="w-full border-collapse border">
        <thead>
          <tr>
            <th className="p-2 border">Họ và Tên</th>
            <th className="p-2 border">Số điện thoại</th>
            <th className="p-2 border">Giới tính</th>
            <th className="p-2 border">Lịch học</th>
          </tr>
        </thead>
        <tbody>
          {filteredTeachers?.map(teacher => (
            <tr key={teacher?.teacherId}>
              <td className="p-2 border"> {teacher.teacherInfo.fullName}</td>
              <td className="p-2 border">{teacher.teacherInfo.phoneNumber}</td>
              <td className="p-2 border"> {teacher.teacherInfo.gender}</td>

              <td className="p-2 border">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={()=>{handleClick(teacher.teacherId)}}>Xem lịch</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default TeacherList;