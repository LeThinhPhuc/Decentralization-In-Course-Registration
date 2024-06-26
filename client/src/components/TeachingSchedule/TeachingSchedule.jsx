import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { AccountContext } from "../../contexts/AccountContext";

const TeachingSchedule = () => {
  const { id } = useParams();
  const [search, setSearch] = useState("");
  const { scheduleTeacher, fetchSchedule } = useContext(AccountContext);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      await fetchSchedule(id);
      console.log("mon: ", scheduleTeacher);
    };
    fetchData();
  }, [id, fetchSchedule, scheduleTeacher]);

  useEffect(() => {
    setData(scheduleTeacher.Subject);
  }, [scheduleTeacher]);

  return (
    <div>
      <h2 className="text-base font-semibold leading-7 text-gray-900 text-center pt-5 pb-5">
        Teaching Schedule
      </h2>
      <div className="flex justify-center items-center pb-2">
        <input
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          type="search"
          id="default-search"
          className="block w-1/2 p-2 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          placeholder="Search..."
          required
        />
      </div>
      <div className="relative m-auto overflow-x-auto border-[1.5px] w-[130%]">
        <table className="w-full text-sm text-center text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-500 bg-gray-100 border-b-[1.5px] dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-3 py-3 font-semibold">
                Ten Mon
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                So Tin Chi
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                Ngay Bat Dau
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                Ngay Ket Thuc
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                Phong
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                So Luong Toi Da
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                Gio Hoc
              </th>
              <th scope="col" className="px-3 py-3 font-semibold">
                Giao Vien
              </th>
              <th scope="col" className="px-3 py-3 font-semibold"></th>
            </tr>
          </thead>
          <tbody>
            {data?.map((item) => (
              <tr key={item.id}>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500">{item?.subject.subjectName}</td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500"></td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500"></td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500"></td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500">{item?.classroom.classroomName}</td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500"></td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500">{item?.time.startTime} - {item?.time.endTime}</td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500">{item?.time.startTime} - {item?.time.endTime}</td>
                <td className="border-t-slate-500 border-b-slate-500 border-l-slate-500">🧾</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TeachingSchedule;
