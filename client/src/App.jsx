import { useState } from 'react'
import ListAccount from './components/ListAccount/ListAccount'
import CourseList from './components/HocPhan/ListHocPhan'
import OpenCourses from './components/HocPhan/StudentListMon';
function App() {
  const data = [
    {
      courseCode: "COMP1015",
      courseName: "Nhập môn mạng máy tính",
      credit: 3,
      numClasses: 2,
      classType: "Lý thuyết",
      classCode: "COMP101501",
      className: "Nhập môn mạng máy tính-01",
      classTeacher: "Nguyễn Duy Tân",
      classSchedule: "Từ ngày 5/1/2024 đến ngày 16/5/2024",
      classStartDate: "5/1/2024",
      classEndDate: "16/05/2024"
    },
    {
      courseCode: "MAT201",
      courseName: "Calculus",
      credit: 4,
      numClasses: 1,
      classType: "Elective",
      classCode: "MAT201-L01",
      className: "Calculus - Lecture 01",
      classTeacher: "Prof. Jane Smith",
      classSchedule: "Tue/Thu 10:00 AM - 12:00 PM",
      classStartDate: "2024-04-03",
      classEndDate: "2024-06-03"
    }
    // Thêm dữ liệu mẫu khác nếu cần
  ];

  return (
    <div className="container mx-auto p-4">
      <OpenCourses courses={data} />
    </div>
  )
}

export default App
