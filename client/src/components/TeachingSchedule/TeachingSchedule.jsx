import { useState } from "react"
import { useParams } from "react-router-dom"

const TeachingSchedule = () =>{
    const param = useParams()
    const {id} = param
    const [search, setSearch] = useState("")
    const arrSubject = [
        {
            id:"COMP1",
            name:"LTCB",
            tc:3,
            dateStart:"02/07/2024",
            dateEnd:"07/08/2024",
            tiet:"7-10",
            soLuongToiDa:40,
            idTeach:4
        },
        {
            id:"COMP2",
            name:"LTNC",
            tc:3,
            dateStart:"01/07/2024",
            dateEnd:"03/08/2024",
            tiet:"2-6",
            soLuongToiDa:40,
            idTeach:4

        },
        {
            id:"COMP3",
            name:"LTHDT",
            tc:3,
            dateStart:"04/07/2024",
            dateEnd:"10/08/2024",
            tiet:"1-5",
            soLuongToiDa:40,
            idTeach:5

        }
        ,
        {
            id:"COMP4",
            name:"LTDD",
            tc:3,
            dateStart:"12/07/2024",
            dateEnd:"17/08/2024",
            tiet:"7-10",
            soLuongToiDa:40,
            idTeach:4

        }
    ]


   
    return(
        <div >
            <h2 className="text-base font-semibold leading-7 text-gray-900 text-center pt-5 pb-5">Teaching Schedule</h2>
            <div className="flex justify-center items-center pb-2">
            <input
                    value={search}
                    onChange={(e)=>setSearch(e.target.value)}
                    type="search"
                    id="default-search"
                    className="block w-1/3 p-2 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="Search..."
                    required
                  />
            </div>
        <div className="relative m-auto overflow-x-auto border-[1.5px]  w-[80%]">

            <table className="w-full   text-sm text-center text-gray-500 dark:text-gray-400">
              <thead className="text-xs text-gray-500  bg-gray-100 border-b-[1.5px] dark:bg-gray-700 dark:text-gray-400">
                <tr>
                  <th scope="col" className="px-3 py-3 font-semibold">
                    Ma Mon
                  </th>
                  <th scope="col" className="px-3 py-3 font-semibold">
                    Ten Mon
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                    So Tin Chi
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                    Ngay Bat Dau
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                    Ngay Ket Thuc
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                    Tiet Hoc
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                    So Luong Toi Da
                  </th>
                  <th scope="col" class="px-3 py-3 font-semibold">
                  </th>
                </tr>
              </thead>
              <tbody>
                {arrSubject.filter((item)=>{
                    return(item.name).toLowerCase().includes(search)
                })?.filter((item)=>{return(item.idTeach==id)})?.map((item) => {
                  return (
                    <tr key={item.id}>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.id}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.name}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.tc}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.dateStart}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.dateEnd}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.tiet}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">{item.soLuongToiDa}</td>
                                <td class=" border-t-slate-500 border-b-slate-500 border-l-slate-500">🧾</td>



                            </tr>
                  )
                })}
              </tbody>
            </table>
            {/* <nav
              className="flex items-center justify-between py-2 pt-1 pl-2"
              aria-label="Table navigation"
            >
              <span className="text-xs font-normal text-gray-500 dark:text-gray-400">
                Showing{" "}
                <span className="font-semibold text-gray-900 dark:text-white">
                  {endOffset >= user?.length
                    ? `${itemOffset + 1}-${user?.length}`
                    : `${itemOffset + 1}-${endOffset}`}
                </span>{" "}
                of{" "}
                <span className="font-semibold text-gray-900 dark:text-white">
                  {user?.length}
                </span>
              </span>
            </nav> */}
          </div>
          </div>
    )
}
export default TeachingSchedule