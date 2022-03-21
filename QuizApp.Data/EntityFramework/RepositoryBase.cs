
using Microsoft.EntityFrameworkCore;
using QuizApp.Entity.Models;

namespace QuizApp.Data.EntityFramework
{
    public class RepositoryBase
    {
        protected DbContext context;
        private static object _lockSync = new object();

        public RepositoryBase()
        {
            context = new QuizAppContext();
            //CreateContext();
        }

        //private static void CreateContext()
        //{
        //    if (context == null)
        //    {
        //        lock (_lockSync)
        //        {
        //            if (context == null)
        //            {
        //                context = new DatabaseContext();
        //            }
        //        }
        //    }
        //}
    }
}