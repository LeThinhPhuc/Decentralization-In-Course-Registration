using BMCSDL.DTOs;
using BMCSDL.Migrations;
using BMCSDL.Models;
using BMCSDL.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Data;

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
            if (faculties == null || faculties.Count() == 0)
            {
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
            }); ;

            return dataToReturn;
        }

        public async Task<object> GetFacultyWithSubjectsByIdAsync(string facultyId)
        {
            var faculty = await context.Faculty
                .Include(f => f.Subject)
                .FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if (faculty == null)
            {
                return null;
            }

            var dataToReturn = new
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

            if (faculty == null)
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

            if (faculty == null)
            {
                return null;
            }

            if (!String.IsNullOrEmpty(newInfo.FacultyName))
            {
                faculty.FacultyName = newInfo.FacultyName;
            }

            if (!String.IsNullOrEmpty(newInfo.ContactInformation))
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

        public async Task<object> GetAllAccountsByFacultyIdAsync(string facultyId)
        {
            var isExistedFaculty =  await context
                .Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if(isExistedFaculty == null)
            {
                return null;
            }

            var accounts = await context.Account
                .Include(a => a.Person)
                .ThenInclude(p => p.Faculty)
                .Where(a => a.Person.FacultyId == facultyId)
                .Include(a => a.RoleAccount)
                .ThenInclude(ra => ra.Role)
                .ToListAsync();

            if (accounts == null || accounts.Count == 0)
            {
                return null;
            }

            var accountsToReturn = new
            {
                FacultyId = isExistedFaculty.FacultyId,
                FacultyName = isExistedFaculty.FacultyName,
                Accounts = accounts.Select(a => new
                {
                    AccountId = a.AccountId,
                    UserName = a.UserName,
                    passwordHash = a.PasswordHash,
                    passwordSalt = a.PasswordSalt,
                    PersonalInfor = new
                    {
                        FullName = a.Person.FullName
                    },
                    roleAccount = a.RoleAccount.Select(ra => new
                    {
                        role = new
                        {
                            roleId = ra.Role.RoleId,
                            roleName = ra.Role.RoleName
                        }
                    })
                }).ToList()
            };
               
            return accountsToReturn;

        }

        public async Task<object> GetAllTeachersByFacultyId(string facultyId)
        {
            var faculty = await context.Faculty.FirstOrDefaultAsync(f => f.FacultyId == facultyId);
            
            if(faculty == null )
            {
                return null;
            }

            var teacher = await context.Teacher
                .Include(t => t.Person)
                .Where(t => t.Person.FacultyId == facultyId)
                .ToListAsync();

            if(teacher == null || teacher.Count() == 0)
            {
                return null;
            }

            return new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName,
                teachers = teacher.Select(t => new
                {
                    TeacherId = t.TeacherId,
                    TeacherInfo = new
                    {
                        FullName = t.Person.FullName,
                        Gender = t.Person.Gender,
                        PhoneNumer = t.Person.PhoneNumber,
                        Address = t.Person.Address,
                    }
                })
            };
        }

        public async Task<object> GetAllStudentsByFacultyId(string facultyId)
        {
            var faculty = await context.Faculty.FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if (faculty == null)
            {
                return null;
            }

            var teacher = await context.Student
                .Include(t => t.Person)
                .Where(t => t.Person.FacultyId == facultyId)
                .ToListAsync();

            if (teacher == null || teacher.Count() == 0)
            {
                return null;
            }

            return new
            {
                FacultyId = faculty.FacultyId,
                FacultyName = faculty.FacultyName,
                students = teacher.Select(t => new
                {
                    StudentId = t.StudentId,
                    StudentInfo = new
                    {
                        FullName = t.Person.FullName,
                        Gender = t.Person.Gender,
                        PhoneNumer = t.Person.PhoneNumber,
                        Address = t.Person.Address,
                    }
                })
            };
        }
    }
}
