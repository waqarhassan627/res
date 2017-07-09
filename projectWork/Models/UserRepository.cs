using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectWork.Models
{
    public class UserRepository
    {
        public int SaveUser(UserDTO dto)
        {
            MyDBService ser = new MyDBService();
            int id = ser.SaveUser(dto);
            return id;
        }

        public void SaveCourse(CoursesDTO c_dto)
        {
            MyDBService ser = new MyDBService();
            ser.SaveCourse(c_dto);
        }

        public List<UserDTO> GetAllUsers()
        {
            MyDBService ser = new MyDBService();
            return ser.GetAllUsers();
        }

        public int SaveTest( TestDTO t_dto)
        {
            MyDBService ser = new MyDBService();
            return ser.SaveTest(t_dto);
        }

        public int SaveQuestion(TestQuestionsDTO tq_dto)
        {
            MyDBService ser = new MyDBService();
            return ser.SaveQuestion(tq_dto);
        }

        public void SaveQuery(QueriesDTO q_dto)
        {
            MyDBService ser = new MyDBService();
            ser.SaveQuery(q_dto);
        }

        public UserDTO verifyLogin( string uname)
        {
            MyDBService ser = new MyDBService();
            return ser.verifyLogin(uname);
        }

        public List<TestDTO> AllTest( int uid )
        {
            MyDBService ser = new MyDBService();
            return ser.AllTest(uid);
        }

        public List<TestQuestionsDTO> GetTest(int tid)
        {
            MyDBService ser = new MyDBService();
            return ser.GetTest(tid);
        }

        public List<TestDTO> StudentResult( string uname )
        {
            MyDBService ser = new MyDBService();
            return ser.StudentResults(uname);
        }

        public List<QuizesDTO> GetResult(int id)
        {
            MyDBService ser = new MyDBService();
            return ser.GetResult(id);
        }

        public void SaveStudentsQuiz(TestDTO t_dto)
        {
            MyDBService ser = new MyDBService();
            ser.SaveStudentQuiz(t_dto);
        }

        public List<QuizesDTO> AllResults( int uid )
        {
            MyDBService ser = new MyDBService();
            return ser.AllResults(uid);
        }

        public int EditUser(UserDTO dto)
        {
            MyDBService ser = new MyDBService();
            int id = ser.EditUser(dto);
            return id;
        }

        public int ToogleStatus(UserDTO dto)
        {
            MyDBService ser = new MyDBService();
            int id = ser.ToogleStatus(dto);
            return id;
        }

        public UserDTO GetUserById(int id)
        {
            MyDBService s = new MyDBService();
            UserDTO dt = s.GetUserById(id);
            return dt;
        }

        public List<UserDTO> GetUniversityStudents()
        {
            MyDBService ser = new MyDBService();
            List<UserDTO> result = ser.GetUniversityStudents();
            return result;
        }

        public List<QueriesDTO> GetAllQueries()
        {
            MyDBService ser = new MyDBService();
            return ser.GetQueries();
        }

        public int GetQueriesCount()
        {
            MyDBService ser = new MyDBService();
            return ser.GetQueriesCount();
        }

        public List<QueriesDTO> GetUnattendedQueries()
        {
            MyDBService ser = new MyDBService();
            return ser.GetUnattendedQueries();
        }

        public List<UserDTO> GetOutsiderStudents()
        {
            MyDBService ser = new MyDBService();
            List<UserDTO> result = ser.GetOutsiderStudents();
            return result;
        }

        public List<UserDTO> GetTeachers()
        {
            MyDBService ser = new MyDBService();
            List<UserDTO> result = ser.GetTeachers();
            return result;
        }

        public List<UserDTO> GetDisabled()
        {
            MyDBService ser = new MyDBService();
            List<UserDTO> result = ser.GetDisabled();
            return result;
        }

        public List<CoursesDTO> getAllCertificate( int id )
        {
            MyDBService ser = new MyDBService();
            return ser.getAllCertificate( id );
        }
 
        public List<MsOfficeDTO> MSOfficeTest()
        {
            MyDBService ser = new MyDBService();
            return ser.MSOfficeTest();
        }

        public List<DBAdto> DBATest()
        {
            MyDBService ser = new MyDBService();
            return ser.DBATest();
        }

        public List<CCNAdto> CCNATest()
        {
            MyDBService ser = new MyDBService();
            return ser.CCNATest();
        }

        public List<DotNetDTO> DotNetTest()
        {
            MyDBService ser = new MyDBService();
            return ser.DotNetTest();
        }

        public List<PhotoShopDTO> PhotoShopTest()
        {
            MyDBService ser = new MyDBService();
            return ser.PhotoShopTest();
        }

        public List<PHPdto> PhpTest()
        {
            MyDBService ser = new MyDBService();
            return ser.PhpTest();
        }

        public List<CoursesDTO> GetCourseResult( int id )
        {
            MyDBService ser = new MyDBService();
            return ser.getCourseResult(id);
        }

        public void SaveResult(CoursesDTO dto)
        {
            MyDBService ser = new MyDBService();
            ser.SaveResult(dto);
        }
    }
}