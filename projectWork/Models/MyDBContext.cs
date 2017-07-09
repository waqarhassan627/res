using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace projectWork.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<UserDTO> Users
        {
            get;
            set;
        }

        public DbSet<TestDTO> Test
        {
            get;
            set;
        }


        public DbSet<QuizesDTO> Quizes
        {
            get;
            set;
        }

        public DbSet<TestQuestionsDTO> TestQuestions
        {
            get;
            set;
        }

        public DbSet<CoursesDTO> Courses
        {
            get;
            set;
        }

        public DbSet<QueriesDTO> Queries
        {
            get;
            set;
        }

        public DbSet<MsOfficeDTO> MsOffice
        {
            get;
            set;
        }

        public DbSet<DBAdto> DBA
        {
            get;
            set;
        }

        public DbSet<DotNetDTO> DotNet
        {
            get;
            set;
        }

        public DbSet<CCNAdto> CCNA
        {
            get;
            set;
        }

        public DbSet<PhotoShopDTO> PhotoShop
        {
            get;
            set;
        }

        public DbSet<PHPdto> PHP
        {
            get;
            set;
        }

        public MyDBContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}