using EfEddb.Models;

using System;
using System.Linq;

namespace EfEddb {
    class Program {
        static void Main(string[] args) {

            var context = new EdDbContext();

            var studentsWithMajors = from s in context.Students
                                     join m in context.Majors
                                     on s.MajorId equals m.Id
                                     where s.StateCode == "KY"
                                     orderby s.Lastname
                                     select new { 
                                         s.Firstname, s.Lastname, Major = m.Description 
                                     };
            foreach(var s in studentsWithMajors) {
                Console.WriteLine($"{s.Firstname} {s.Lastname} || {s.Major}");
            }

            #region KY students by lastname
            //var studentsInKy = context.Students
            //                            .Where(s => s.StateCode == "KY")
            //                            .OrderBy(s => s.Lastname)
            //                            .ToList();
            //foreach(var s in studentsInKy) {
            //    Console.WriteLine($"{s.Firstname} {s.Lastname}");
            //}
            #endregion

        }
    }
}
