import { LockClosedIcon } from '@heroicons/react/24/solid';
import { useState } from 'react';
import PersonalInfoService from './PersonalInfoService';
export default function Example() {
    const [formData,setFormData]=useState(
    {
      personId:'2',
      fullName:'Pham Thanh Trieu',
      gender:'Male',
      phoneNumber:'0907795988',
      dateOfBirth:'2003/07/03',
      address:'GO CONG',
     
    });


    const handleChange = (e) => {
      setFormData({ ...formData, [e.target.name]: e.target.value });
    };
  
    const handleSubmit = async (e) => {
      e.preventDefault();
      try {
      reponse = await PersonalInfoService.ChangeInfo(formData);
      console.log(formData);
      if(reponse.status == 200)
        alert('Thông tin đã được cập nhật thành công!');
      } catch (error) {
        console.error('Error updating information:', error);
        console.log(formData);
        alert('Đã có lỗi xảy ra, vui lòng thử lại sau!');
      }
    };
  
    const handleCancel = () => {
      // Đóng form
      // Xóa dữ liệu đã nhập bằng cách cập nhật lại state formData với dữ liệu mặc định
      setFormData({
        personId: '',
        fullName: '',
        gender: '',
        phoneNumber: '',
        dateOfBirth: '',
        address: '',
        facultyId: '',
      });
    };

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-500 to-purple-600 flex justify-center items-center">
      <div className="bg-white shadow-md rounded-md p-8 max-w-md w-full">
        <h2 className="text-xl font-bold mb-4">Change infomation</h2>
        <form className="space-y-6">
          <div>
          <label htmlFor="personId" className="block text-sm font-medium leading-5 text-gray-900">
              Person ID
            </label>
            <div className="mt-1 relative rounded-md shadow-sm">
              <input
                id="personId"
                name="personId"
                type="text"
                className="form-input block w-full sm:text-sm sm:leading-5"
                placeholder="Enter Person ID"
                value={formData.personId}
                onChange={handleChange}
              />
            </div>
            <label htmlFor="fullname" className="block text-sm font-medium leading-5 text-gray-900">
              Full Name
            </label>
            <div className="mt-1 relative rounded-md shadow-sm">
              <input
                id="fullname"
                name="fullname"
                type="text"
                className="form-input block w-full sm:text-sm sm:leading-5"
                placeholder="John Doe"
                value={formData.fullName}
                onChange={handleChange}
              />
            </div>
          </div>
          <div>
            <label htmlFor="gender" className="block text-sm font-medium leading-5 text-gray-900">
              Gender
            </label>
            <select
              id="gender"
              name="gender"
              className="form-select block w-full mt-1 pl-3 pr-10 py-2 text-base leading-6 border-gray-300 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm sm:leading-5"
              value={formData.gender}
              onChange={handleChange}          
           >
              <option>Male</option>
              <option>Female</option>
              <option>Other</option>
            </select>
          </div>
          <div>
            <label htmlFor="phone" className="block text-sm font-medium leading-5 text-gray-900">
              Phone Number
            </label>
            <div className="mt-1 relative rounded-md shadow-sm">
              <input
                id="phone"
                name="phone"
                type="text"
                className="form-input block w-full sm:text-sm sm:leading-5"
                placeholder="123-456-7890"
                value={formData.phoneNumber}
                onChange={handleChange}
              />
            </div>
          </div>
          <div>
            <label htmlFor="birthdate" className="block text-sm font-medium leading-5 text-gray-900">
              Date of Birth
            </label>
            <div className="mt-1 relative rounded-md shadow-sm">
              <input
                id="birthdate"
                name="birthdate"
                type="date"
                className="form-input block w-full sm:text-sm sm:leading-5"
              />
            </div>
          </div>
          <div>
            <label htmlFor="address" className="block text-sm font-medium leading-5 text-gray-900">
              Address
            </label>
            <div className="mt-1 relative rounded-md shadow-sm">
              <input
                id="address"
                name="address"
                type="text"
                className="form-input block w-full sm:text-sm sm:leading-5"
                placeholder="123 Main St, City, Country"
                value={formData.address}
                onChange={handleChange}
              />
            </div>
          </div>

          <div className="flex justify-end">
            <button
              type="button"
              className="mr-2 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-gray-900 bg-gray-200 hover:bg-gray-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-gray-500"
              onClick={handleCancel}
>
              Cancel
            </button>
            <button
              type="submit"
              className="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-500 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
              onClick={handleSubmit}
            >
              Save
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
