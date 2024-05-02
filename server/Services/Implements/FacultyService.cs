using BMCSDL.DTOs;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMCSDL.Services.Implements
{
    public class FacultyService : IFacultyService
    {
        private CourseRegistraionManagementContext context;

        public FacultyService(CourseRegistraionManagementContext context)
        {
            this.context = context;
        }
        public async Task<object> AddNewFacultyAsync(FacultyDTO newFaculty)
        {
            string faculyId = Guid.NewGuid().ToString();    
            var newF = new Faculty()
            {
                FacultyId = faculyId,
                FacultyName = newFaculty.FacultyName,
                ContactInformation = newFaculty.ContactInformation
            };

            await context.Faculty.AddAsync(newF);
            await context.SaveChangesAsync();

            return new
            {
                FacultyId = faculyId,
                FacultyName = newFaculty.FacultyName,
                ContactInformation = newFaculty.ContactInformation
            };
        }

        public async Task<IEnumerable<object>> GetAllFacultiesAsync()
        {
            var faculties = await context.Faculty.ToListAsync();
            if (faculties == null || faculties.Count() == 0) {
                return null;    
            }

            var dataToReturn = faculties.Select(f => new
            {
                FacultyId = f.FacultyId,
                FacultyName = f.FacultyName,
                ContactInformation = f.ContactInformation
            });

            return dataToReturn;
        }

        public async Task<IEnumerable<object>> GetAllFacultiesWithSubjectsAsync()
        {
            var faculties = await context.Faculty
                .Include(f => f.Subject)
                .ToListAsync();

            if (faculties == null || faculties.Count() == 0)
            {
                return null;
            }

            var dataToReturn = faculties.Select(f => new
            {
                FacultyId = f.FacultyId,
                FacultyName = f.FacultyName,
                ContactInformation = f.ContactInformation,
                Subjects = f.Subject.Select(s => new
                {
                    SubjectId = s.SubjectId,
                    SubjectName = s.SubjectName,
                    Credits = s.Credits,
                    StarDay = s.StartDay,
                    EndDay = s.EndDay,
                    IsOpen = s.isOpen
                })
            });;

            return dataToReturn;
        }

        public async Task<object> GetFacultyWithSubjectsByIdAsync(string facultyId)
        {
            var faculty = await context.Faculty
                .Include(f => f.Subject)
                .FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if (faculty == null )
            {
                return null;
            }

            var dataToReturn =  new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName,
                ContactInformation = faculty.ContactInformation,
                Subjects = faculty.Subject.Select(s => new
                {
                    SubjectId = s.SubjectId,
                    SubjectName = s.SubjectName,
                    Credits = s.Credits,
                    StarDay = s.StartDay,
                    EndDay = s.EndDay,
                    IsOpen = s.isOpen
                })
            }; ;

            return dataToReturn;
        }

        public async Task<object> GetFacultyByIdAsync(string facultyId)
        {
            var faculty = await context.Faculty.FirstOrDefaultAsync(f => f.FacultyId == facultyId);
            if (faculty == null)
            {
                return null;
            }

            var dataToReturn = new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName,
                ContactInformation = faculty.ContactInformation
            };

            return dataToReturn;
        }

        public async Task<object> RemoveFacultyAsync(string facultyId)
        {
            var faculty = await context.Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if(faculty == null)
            {
                return null;
            }

            context.Faculty.Remove(faculty);
            context.SaveChanges();

            return new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName,
                ContactInformation = faculty.ContactInformation
            };

        }

        public async Task<object> UpdateFacultyAsync(FacultyDTO newInfo)
        {
            var faculty = await context.Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == newInfo.FacultyId);

            if(faculty == null)
            {
                return null;
            }

            if(!String.IsNullOrEmpty(newInfo.FacultyName))
            {
                faculty.FacultyName = newInfo.FacultyName;
            }

            if(!String.IsNullOrEmpty(newInfo.ContactInformation))
            {
                faculty.ContactInformation = newInfo.ContactInformation;    
            }

            context.Faculty.Update(faculty);    
            context.SaveChanges();

            var dataToReturn = new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = newInfo.FacultyName,
                ContactInformation = newInfo.ContactInformation
            };

            return dataToReturn;
        }
    }
}
