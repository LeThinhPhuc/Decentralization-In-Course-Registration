using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BMCSDL.Services.Implements
{
    public class ClassroomService : IClassroomService
    {
        private readonly CourseRegistraionManagementContext context;

        public ClassroomService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }

        public async Task<object> AddNewClassroomAsync(NewClassroomDTO newClassRoom)
        {
            var isExistedRoomName = await  context.Classroom
                .FirstOrDefaultAsync(c => c.ClassRoomId == newClassRoom.ClassroomName);

            if(isExistedRoomName != null)
            {
                return null;
            }

            string classroomId = Guid.NewGuid().ToString(); 
            var newClass = new Classroom()
            {
                ClassRoomId = classroomId,  
                ClassroomName = newClassRoom.ClassroomName,
                MaxQuantity = newClassRoom.MaxQuantity, 
            };

            context.Classroom.Add(newClass);
            await context.SaveChangesAsync();

            var dataToReturn = new
            {
                ClassroomId = classroomId,
                ClassroomName = newClassRoom.ClassroomName,
                MaxQuantity = newClassRoom.MaxQuantity
            };

            return dataToReturn;
        }

        public async Task<IEnumerable<object>> GetAllClassroomsAsync()
        {
            var classrooms = await context.Classroom.ToListAsync();

            var dataToReturn = classrooms.Select(x => new { 
                ClassroomId = x.ClassRoomId,
                ClassroomName = x.ClassroomName,
                MaxQuantity = x.MaxQuantity,
            });

            return dataToReturn;
        }

        public async Task<object> RemoveClassroomAsync(string ClassroomId)
        {
            var isExistedClassroom = await context.Classroom
                .FirstOrDefaultAsync(c => c.ClassRoomId == ClassroomId);
        
            if (isExistedClassroom == null)
            {
                return null;
            }

            context.Classroom.Remove(isExistedClassroom);
            await context.SaveChangesAsync();

            return new
            {
                ClassroomId = ClassroomId,
                ClassroomName = isExistedClassroom.ClassroomName,
                MaxQuantity = isExistedClassroom.MaxQuantity
            };
        }

        public async Task<object> UpdateClassroomAsync(NewClassroomDTO newInfoClassroom)
        {
            var classroom = await context.Classroom
                .FirstOrDefaultAsync(c => c.ClassRoomId == newInfoClassroom.ClassRoomId);

            if(classroom == null)
            {
                return null;
            }


            if (classroom.ClassroomName == newInfoClassroom.ClassroomName)
            {
                return null;
            }


            if (!String.IsNullOrEmpty(newInfoClassroom.ClassroomName))
            {
                classroom.ClassroomName = newInfoClassroom.ClassroomName;
            }

            if(!String.IsNullOrEmpty(newInfoClassroom.MaxQuantity.ToString()))
            {
                classroom.MaxQuantity = newInfoClassroom.MaxQuantity;
            }



            context.Classroom.Update(classroom);

            context.SaveChanges();

            return newInfoClassroom;
        }
    }
}
