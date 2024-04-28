using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace BMCSDL.Models
{
    public static class DbInitializer
    {
        static byte[] GenerateSalt()
        {
            using var hmac = new HMACSHA256();

            return hmac.Key;
        }

        static byte[] CaculatePassword(string password, byte[] salt)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return hashBytes;
            }
        }
        public static void Initialize(CourseRegistraionManagementContext context)
        {
            var ma1 = Guid.NewGuid().ToString();//Khoa CNTT
            var ma2 = Guid.NewGuid().ToString();//Khoa Toán
            var ma3 = Guid.NewGuid().ToString();//Khoa Lý
            var ma4 = Guid.NewGuid().ToString();//Khoa Hóa

            if (!context.Faculty.Any())
            {
                List<Faculty> faculties = new List<Faculty>()
                {
                    new Faculty()
                    {
                        FacultyId = ma1,
                        FacultyName = "Khoa CNTT",
                        ContactInformation = "khoacntt@hcmue.edu.vn"
                    },

                     new Faculty()
                    {
                        FacultyId = ma2,
                        FacultyName = "Khoa Toán",
                        ContactInformation = "khoatoan@hcmue.edu.vn"
                    },

                      new Faculty()
                    {
                        FacultyId = ma3,
                        FacultyName = "Khoa Lý",
                        ContactInformation = "khoaly@hcmue.edu.vn"
                    },

                    new Faculty()
                    {
                        FacultyId = ma4,
                        FacultyName = "Khoa Hóa",
                        ContactInformation = "khoahoa@hcmue.edu.vn"
                    },
                };

                context.Faculty.AddRange(faculties);
                context.SaveChanges();

            }


            if (!context.Role.Any())
            {
                var roles = new List<Role>()
                {
                    new Role() { RoleId = "sinhvien", RoleName="Sinh Viên"},
                    new Role() { RoleId = "truongphokhoa", RoleName="Trưởng Phó Khoa"},
                    new Role() { RoleId = "truongbomon", RoleName="Trưởng Bộ Môn"},
                    new Role() { RoleId = "giaovu", RoleName="Giáo Vụ"},
                    new Role() { RoleId = "giaovien", RoleName="Giáo Viên"}
                };
                context.Role.AddRange(roles);
                context.SaveChanges();
            }


            if (!context.Account.Any())
            {
                var accounts = new List<Account>();

                var accountId1 = Guid.NewGuid().ToString();
                var personId1 = Guid.NewGuid().ToString();
                var salt1 = GenerateSalt();
                var account1 = new Account()
                {
                    AccountId = accountId1,
                    UserName = "Test1",
                    PasswordHash = CaculatePassword("12345", salt1),
                    PasswordSalt = salt1,
                    RoleId = "sinhvien",
                    Person = new Person
                    {
                        PersonId = personId1,
                        FullName = "Lê Phúc Thịnh",
                        Gender = "Nam",
                        PhoneNumber = "1234567890",
                        DateOfBirth = DateTime.Now,
                        Address = "Tây Ning",
                        FacultyId = ma1,
                        AccountId = accountId1,
                        Student = new Student()
                        {
                            StudentId = personId1,
                            PersonId = personId1,
                        }
                    }
                };

                var accountId2 = Guid.NewGuid().ToString();
                var personId2 = Guid.NewGuid().ToString();
                var salt2 = GenerateSalt();
                var account2 = new Account()
                {
                    AccountId = accountId2,
                    UserName = "Test2",
                    PasswordHash = CaculatePassword("12345", salt2),
                    PasswordSalt = salt2,
                    RoleId = "truongphokhoa",
                    Person = new Person
                    {
                        PersonId = personId2,
                        FullName = "Nguyễn Hoàng Nam",
                        Gender = "Nam",
                        PhoneNumber = "1234567890",
                        DateOfBirth = DateTime.Now,
                        Address = "Tây Ning",
                        FacultyId = ma2,
                        AccountId = accountId2,
                        TruongPhoKhoa = new TruongPhoKhoa()
                        {
                            TruongPhoKhoaId = personId2,
                            PersonId = accountId2,
                        }
                    }
                };


                var accountId3 = Guid.NewGuid().ToString();
                var personId3 = Guid.NewGuid().ToString();
                var salt3 = GenerateSalt();
                var account3 = new Account()
                {
                    AccountId = accountId3,
                    UserName = "Test3",
                    PasswordHash = CaculatePassword("12345", salt3),
                    PasswordSalt = salt3,
                    RoleId = "truongbomon",
                    Person = new Person
                    {
                        PersonId = personId3,
                        FullName = "Nguyễn Duy Tân",
                        Gender = "Nam",
                        PhoneNumber = "1234567890",
                        DateOfBirth = DateTime.Now,
                        Address = "Tây Ning",
                        FacultyId = ma3,
                        AccountId = accountId3,
                        TruongBoMon = new TruongBoMon()
                        {
                            TruongBoMonId = personId3,
                            PersonId = personId3
                        }
                    }
                };


                var accountId4 = Guid.NewGuid().ToString();
                var personId4 = Guid.NewGuid().ToString();
                var salt4 = GenerateSalt();
                var account4 = new Account()
                {
                    AccountId = accountId4,
                    UserName = "Test4",
                    PasswordHash = CaculatePassword("12345", salt4),
                    PasswordSalt = salt4,
                    RoleId = "giaovu",
                    Person = new Person
                    {
                        PersonId = accountId4,
                        FullName = "Phạm Thanh Chiều",
                        Gender = "Nam",
                        PhoneNumber = "1234567890",
                        DateOfBirth = DateTime.Now,
                        Address = "Tây Ning",
                        FacultyId = ma4,
                        AccountId = accountId4,
                        GiaoVu = new GiaoVu()
                        {
                            GiaoVuId = personId4,
                            PersonId = personId4
                        }
                    }
                };


                var accountId5 = Guid.NewGuid().ToString();
                var personId5 = Guid.NewGuid().ToString();
                var salt5 = GenerateSalt();
                var account5 = new Account()
                {
                    AccountId = accountId5,
                    UserName = "Test5",
                    PasswordHash = CaculatePassword("12345", salt5),
                    PasswordSalt = salt5,
                    RoleId = "giaovien",
                    Person = new Person
                    {
                        PersonId = personId5,
                        FullName = "Chấn bé đù",
                        Gender = "Nam",
                        PhoneNumber = "1234567890",
                        DateOfBirth = DateTime.Now,
                        Address = "Tây Ning",
                        FacultyId = ma4,
                        AccountId = accountId5,
                        Teacher = new Teacher()
                        {
                            TeacherId = personId5,
                            PersonId = personId5
                        }
                    }
                };

                accounts.Add(account1);
                accounts.Add(account2);
                accounts.Add(account3);
                accounts.Add(account4);
                accounts.Add(account5);

                context.Account.AddRange(accounts);

                context.SaveChanges();
            }


            var mon1 = Guid.NewGuid().ToString();//Lập trình cơ bản
            var mon2 = Guid.NewGuid().ToString();//Giải tích 3
            var mon3 = Guid.NewGuid().ToString();//Vật lý lượng tử
            var mon4 = Guid.NewGuid().ToString();//Hóa đại cương
            if (!context.Subject.Any())
            {
                List<Subject> subjects = new List<Subject>()
                {
                    new Subject()
                    {
                        SubjectId = mon1,
                        SubjectName = "Lập trình cơ bản",
                        Credits = 3,
                        StartDay = DateTime.Now,
                        EndDay = DateTime.Now.AddMonths(3) ,
                        FacultyId = ma1
                    },

                    new Subject()
                    {
                        SubjectId= mon2,
                        SubjectName = "Giải tích 3",
                        Credits = 3,
                        StartDay = DateTime.Now,
                        EndDay= DateTime.Now.AddMonths(3),
                        FacultyId = ma2
                    },

                    new Subject()
                    {
                        SubjectId = mon3,
                        SubjectName = "Vật lý lượng tử",
                        Credits = 3,
                        StartDay = DateTime.Now,
                        EndDay= DateTime.Now.AddMonths(3),
                        FacultyId = ma3
                    },

                    new Subject()
                    {
                        SubjectId = mon4,
                        SubjectName = "Hóa đại cương",
                        Credits = 3,
                        StartDay = DateTime.Now,
                        EndDay = DateTime.Now.AddMonths(3),
                        FacultyId = ma4
                    }
                };

                context.Subject.AddRange(subjects);
                context.SaveChanges();
            }

            var classroom1 = Guid.NewGuid().ToString();//B101
            var classroom2 = Guid.NewGuid().ToString();//B102
            var classroom3 = Guid.NewGuid().ToString();//I102
            var classroom4 = Guid.NewGuid().ToString();//A302
            var classroom5 = Guid.NewGuid().ToString();//C201

            //dữ liệu lớp
            if (!context.Classroom.Any())
            {

                List<Classroom> classrooms = new List<Classroom>()
                {
                    new Classroom()
                    {
                        ClassRoomId = classroom1,
                        ClassroomName = "B101",
                        Quantity = 40,
                    },

                    new Classroom()
                    {
                        ClassRoomId = classroom2,
                        ClassroomName = "B102",
                        Quantity = 40,
                    },

                    new Classroom()
                    {
                        ClassRoomId = classroom3,
                        ClassroomName = "I102",
                        Quantity = 40,
                    },
                    new Classroom()
                    {
                        ClassRoomId = classroom4,
                        ClassroomName = "A302",
                        Quantity = 40,
                    },

                    new Classroom()
                    {
                        ClassRoomId = classroom5,
                        ClassroomName = "C201",
                        Quantity = 40,
                    },
                };

                context.Classroom.AddRange(classrooms);
                context.SaveChanges();
            }

            var time1 = Guid.NewGuid().ToString(); //7-9
            var time2 = Guid.NewGuid().ToString();//9h15-11h15
            var time3 = Guid.NewGuid().ToString();//13-15
            var time4 = Guid.NewGuid().ToString();//15h15-17h15
            var time5 = Guid.NewGuid().ToString();//19-21

            //dữ liệu các khoảng thời gian
            if (!context.Time.Any())
            {
                List<Time> times = new List<Time>()
                {
                    new Time()
                    {
                        TimeId = time1,
                        TimeName = "Sáng 1",
                        StartTime = new TimeSpan(7,0,0),
                        EndTime = new TimeSpan(9,0,0),
                    },
                    new Time()
                    {
                        TimeId = time2,
                        TimeName = "Sáng 2",
                        StartTime = new TimeSpan(9,15,0),
                        EndTime = new TimeSpan(11,15,0),
                    },

                    new Time()
                    {
                        TimeId = time3,
                        TimeName = "Chiều 1",
                        StartTime = new TimeSpan(13,0,0),
                        EndTime = new TimeSpan(15,0,0),
                    },

                    new Time()
                    {
                        TimeId = time4,
                        TimeName = "Chiều 2",
                        StartTime = new TimeSpan(15,15,0),
                        EndTime = new TimeSpan(17,15,0),
                    },
                    new Time()
                    {
                        TimeId = time5,
                        TimeName = "Tối 1",
                        StartTime = new TimeSpan(19,0,0),
                        EndTime = new TimeSpan(21,0,0),
                    },

                };

                context.Time.AddRange(times);
                context.SaveChanges();
            }

            //dữ liệu 1 lớp thì có các khoảng thời gian nào
            if (!context.ClassTime.Any())
            {
                List<ClassTime> classes = new List<ClassTime>()
                {
                    new ClassTime() { ClassroomId = classroom1,TimeId = time3},
                    new ClassTime() { ClassroomId = classroom1,TimeId = time2},
                    new ClassTime() { ClassroomId = classroom2,TimeId = time1},
                    new ClassTime() { ClassroomId = classroom2,TimeId = time2},
                    new ClassTime() { ClassroomId = classroom3,TimeId = time4},
                    new ClassTime() { ClassroomId = classroom3,TimeId = time1},
                    new ClassTime() { ClassroomId = classroom4,TimeId = time1},
                    new ClassTime() { ClassroomId = classroom4,TimeId = time3},
                    new ClassTime() { ClassroomId = classroom5,TimeId = time1},
                    new ClassTime() { ClassroomId = classroom5,TimeId = time3},
                };

                context.ClassTime.AddRange(classes);
                context.SaveChanges();
            }

            if (!context.SubjectClass.Any())
            {
                List<SubjectClass> subjectClasses = new List<SubjectClass>()
                {
                    new SubjectClass() {SubjectId = mon1,ClassroomId = classroom3,TimeId = time1},

                    new SubjectClass() {SubjectId = mon2,ClassroomId = classroom2,TimeId = time2},

                    new SubjectClass() {SubjectId = mon3,ClassroomId = classroom1,TimeId = time3},

                    new SubjectClass() {SubjectId = mon3,ClassroomId = classroom5,TimeId = time1},

                    new SubjectClass() {SubjectId = mon4,ClassroomId = classroom4,TimeId = time1},
                };

                context.SubjectClass.AddRange(subjectClasses);
                context.SaveChanges();
            }

        }
    }
}
