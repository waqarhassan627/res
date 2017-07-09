using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectWork.Models
{
    public class MyDBService
    {


        public void SaveQuery(QueriesDTO q_dto)
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Queries.Add(q_dto);
                ctx.SaveChanges();
            }
        }

        public void SaveCourse(CoursesDTO c_dto)
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Courses.Add(c_dto);
                ctx.SaveChanges();
            }
        }

        public List<CoursesDTO> getCourseResult( int id )
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Courses.Where(c => c.UserID == id).ToList();
                return obj;
            }
        }

        public int AttendQuery(int id)
        {
            using (var Ctx = new MyDBContext())
            {
                var obj = Ctx.Queries.Where(i => i.QueryID == id).FirstOrDefault();
                if (obj != null)
                {
                    obj.isAttended = true;
                    Ctx.SaveChanges();
                }

                return id;
            }
        }

        public int GetUnattendedQueriesCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Queries.Where(q => q.isAttended == false).ToList().Count;
            }
        }

        public List<QueriesDTO> GetUnattendedQueries()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Queries.Where(q => q.isAttended == false).ToList();
            }
        }

        public int GetQueriesCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Queries.ToList().Count;
            }
        }
        
        public int EditUser(UserDTO user)
        {
            using (var Ctx = new MyDBContext())
            {
                var obj = Ctx.Users.Where(i => i.UserID == user.UserID).FirstOrDefault();

                obj.Username = user.Username;
                obj.FullName = user.FullName;
                obj.Address = user.Address;
                obj.ContactNo = user.ContactNo;
                obj.Email = user.Email;
                obj.UserType = user.UserType;
                obj.Password = user.Password;

                Ctx.SaveChanges();

                return user.UserID;
            }
        }

        public int ToogleStatus(UserDTO user)
        {
            using (var Ctx = new MyDBContext())
            {
                var obj = Ctx.Users.Where(i => i.UserID == user.UserID).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.isActive == true)
                        obj.isActive = false;
                    else
                        obj.isActive = true;

                    Ctx.SaveChanges();
                }
                return user.UserID;
            }
        }

        public int GetUserCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.ToList().Count;
            }
        }

        public int GetUniversityStudentsCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 1).ToList().Count;
            }
        }

        public int GetOutsiderStudentsCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 2).ToList().Count;
            }
        }

        public int GetDisabledCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.isActive == false).ToList().Count;
            }
        }

        public int GetTeachersCount()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 3).ToList().Count;
            }
        }

        public List<UserDTO> GetTeachers()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 3).ToList();
            }
        }

        public List<QueriesDTO> GetQueries()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Queries.ToList();
            }
        }

        public List<UserDTO> GetOutsiderStudents()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 2).ToList();
            }
        }

        public List<UserDTO> GetUniversityStudents()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.UserType == 1).ToList();
            }
        }

        public List<UserDTO> GetDisabled()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.Where(i => i.isActive == false).ToList();
            }
        }

        public UserDTO GetUserById(int id)
        {
            using (var dbctx = new MyDBContext())
            {
                var obj = dbctx.Users.Where(i => i.UserID == id).FirstOrDefault();
                return obj;
            }

        }

        //Users Controller
        public int SaveUser(UserDTO user)
        {
            using (var ctx = new MyDBContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return user.UserID;
            }
        }

        public UserDTO verifyLogin(string uname)
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Users.Where(c => c.Username == uname).FirstOrDefault();
                return obj;
            }
        }

        public List<QuizesDTO> AllResults( int uid)
        {
            List<QuizesDTO> li = new List<QuizesDTO>();
            using (var dbctx = new MyDBContext())
            {
                var obj = dbctx.Quizes.Where(q => q.UserID == uid & q.isTaken == true).ToList();
                li = obj;
            }

            return li;
        }

        public List<TestQuestionsDTO> GetTest(int tid)
        {
            using (var ctx = new MyDBContext())
            {
                var list = ctx.TestQuestions.Where(c => c.TestID == tid).ToList();
                return list;
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (var ctx = new MyDBContext())
            {
                return ctx.Users.ToList();
            }
        }

        //Teacher Controller
        public int SaveTest( TestDTO t_dto )
        {
            using( var ctx = new MyDBContext())
            {
                ctx.Test.Add(t_dto);
                ctx.SaveChanges();
                return t_dto.TestID;
            }
        }

        public int SaveQuestion(TestQuestionsDTO tq_dto)
        {
            using (var ctx = new MyDBContext())
            {
                ctx.TestQuestions.Add(tq_dto);
                ctx.SaveChanges();
                return tq_dto.TestID;
            }
        }

        public List<TestDTO> AllTest( int uid )
        {
            using ( var ctx = new MyDBContext() )
            {
                var obj = ctx.Quizes.Where(c => c.UserID == uid & c.isTaken ==  false).ToList();
                List<TestDTO> t_list = new List<TestDTO>();

                foreach( var q in obj )
                {
                    var obj1 = ctx.Test.Where(t => t.TestID == q.TestID).FirstOrDefault();
                    t_list.Add(obj1);
                }

                return t_list;
            }
        }

        /*public void MyResults( int tid )
        {
            using( var ctx = new MyDBContext())
            {
                var obj = ctx.TestQuestions.Where(q => q.TestID == tid).ToList();
            }
        }*/

        public List<TestDTO> StudentResults( string t_name )
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Test.Where(c => c.TeacherUname == t_name).ToList();
                return obj;
            }
        }

        public List<QuizesDTO> GetResult(int id)
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Quizes.Where(c => c.TestID == id).ToList();
                return obj;
            }
        }

        public void SaveStudentQuiz(TestDTO t_dto)
        {
            using (var ctx = new MyDBContext())
            {
                var usrs = ctx.Users.Where(c => c.Username.StartsWith(t_dto.Section)).ToList();

                QuizesDTO q_dto = new QuizesDTO();
                foreach (var q in usrs)
                {
                    q_dto.TestID = t_dto.TestID;
                    q_dto.UserID = q.UserID;
                    q_dto.UserName = q.Username;
                    q_dto.TotalMarks = t_dto.TotalMarks;
                    q_dto.MarksObtained = 0;
                    q_dto.isTaken = false;
                    q_dto.ConductDate = null;

                    ctx.Quizes.Add(q_dto);
                    ctx.SaveChanges();
                }
            }
        }

        public List<CoursesDTO> getAllCertificate(int id )
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Courses.Where(c => c.UserID == id & c.isTaken == false).ToList();
                return obj;
            }
        }

        public List<MsOfficeDTO> MSOfficeTest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.MsOffice.ToList();
                return obj;
            }
        }

        public List<DBAdto> DBATest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.DBA.ToList();
                return obj;
            }
        }

        public List<CCNAdto> CCNATest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.CCNA.ToList();
                return obj;
            }
        }

        public List<DotNetDTO> DotNetTest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.DotNet.ToList();
                return obj;
            }
        }

        public List<PhotoShopDTO> PhotoShopTest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.PhotoShop.ToList();
                return obj;
            }
        }

        public List<PHPdto> PhpTest()
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.PHP.ToList();
                return obj;
            }
        }

        public void SaveResult( CoursesDTO dto)
        {
            using (var ctx = new MyDBContext())
            {
                var obj = ctx.Courses.Where(i => i.UserID == dto.UserID & i.CourseName == dto.CourseName).FirstOrDefault();

                obj.grade = dto.grade;
                obj.isTaken = dto.isTaken;
                obj.ObtainedMarks = dto.ObtainedMarks;

                ctx.SaveChanges();
            }
        }
    }
}