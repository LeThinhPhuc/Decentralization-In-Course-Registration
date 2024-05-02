using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BMCSDL.Services.Implements
{
    public class PersonService : IPersonService
    {
        private readonly CourseRegistraionManagementContext context;

        public PersonService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }
        public async Task<object> UpdatePersonInformationAsync(UpdatePersonInfo updatePersonInfo)
        {

            if(!String.IsNullOrEmpty(updatePersonInfo.FacultyId))
            {
                var isExistedFaculty = await context.Faculty
                    .FirstOrDefaultAsync(f => f.FacultyId == updatePersonInfo.FacultyId);

                if(isExistedFaculty == null)
                {
                    return null;
                }
            }


            var person = await context.Person
                .FirstOrDefaultAsync(p => p.PersonId == updatePersonInfo.PersonId);
            
            if(person != null)
            {
                if(!String.IsNullOrEmpty(updatePersonInfo.FullName))
                {
                    person.FullName = updatePersonInfo.FullName;
                }

                if(!String.IsNullOrEmpty(updatePersonInfo.Gender))
                {
                    person.Gender = updatePersonInfo.Gender;
                }

                if(!String.IsNullOrEmpty(updatePersonInfo.PhoneNumber))
                {
                    person.PhoneNumber = updatePersonInfo.PhoneNumber;
                }

                if(updatePersonInfo.DateOfBirth != default(DateTime))
                {
                    person.DateOfBirth = updatePersonInfo.DateOfBirth;
                }

                if(!String.IsNullOrEmpty(updatePersonInfo.Address))
                {
                    person.Address = updatePersonInfo.Address;  
                }

                if(!string.IsNullOrEmpty(updatePersonInfo.FacultyId))
                {
                    person.FacultyId = updatePersonInfo.FacultyId;  
                }

                context.Person.Update(person);
                context.SaveChanges();

                return updatePersonInfo;
            }

            return null;
        }
    }
}
