import React, { useState } from 'react';
const TeacherList = () => {
  const [teachers, setTeachers] = useState([
    { id: 1, name: "John Doe", phone: "123-456-7890", schedule: {  } },
    { id: 2, name: "Jane Smith", phone: "098-765-4321", schedule: {  } },
    // Thêm thông tin về giáo viên khác nếu cần
  ]);
  const [selectedTeacher, setSelectedTeacher] = useState(null);
  const [searchName, setSearchName] = useState('');

  const handleViewSchedule = (teacher) => {
    setSelectedTeacher(teacher);
  }

  const handleCloseModal = () => {
    setSelectedTeacher(null);
  }

  const handleSearchChange = (e) => {
    setSearchName(e.target.value);
  }

  // Lọc danh sách giáo viên dựa trên tên tìm kiếm
  const filteredTeachers = teachers.filter(teacher =>
    teacher.name.toLowerCase().includes(searchName.toLowerCase())
  );

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
            <th className="p-2 border">STT</th>
            <th className="p-2 border">Họ và Tên</th>
            <th className="p-2 border">Số điện thoại</th>
            <th className="p-2 border">Lịch học</th>
          </tr>
        </thead>
        <tbody>
          {filteredTeachers.map(teacher => (
            <tr key={teacher.id}>
              <td className="p-2 border"> {teacher.id}</td>
              <td className="p-2 border"> {teacher.name}</td>
              <td className="p-2 border">{teacher.phone}</td>
              <td className="p-2 border">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" >Xem lịch</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default TeacherList;