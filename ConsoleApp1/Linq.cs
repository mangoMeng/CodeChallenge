using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public int STID { get; set; }
        public string STName { get; set; }
    }

    public class CourseStudent
    {
        public string CourseName { get; set; }
        public int STID { get; set; }
    }



    public class Linq
    {

        static bool IsOdd(int i)
        {
            return i % 2 == 0;
        }
        static void Main()
        {
            Student[] studentlist = new Student[] {
            new Student{STID=1,STName="Carson"},
            new Student{STID=2,STName="Klassen"},
            new Student{STID=3,STName="Fleming"}
            };

            CourseStudent[] studentsInCourses = new CourseStudent[]{
            new CourseStudent{CourseName="Art",STID=1},
            new CourseStudent{CourseName="Art",STID=2},
            new CourseStudent{CourseName="History",STID=1},
            new CourseStudent{CourseName="History",STID=3},
            new CourseStudent{CourseName="Physics",STID=3}
            };

            //Join
            var query = from s in studentlist
                        join c in studentsInCourses on s.STID equals c.STID
                        where c.CourseName == "History"
                        select s.STName;

            //from
            query = from s in studentlist
                    from c in studentsInCourses
                    where s.STID == c.STID && c.CourseName == "History"
                    select s.STName;


            //let
            var groupA = new[] { 3, 4, 5, 6 };
            var groupB = new[] { 6, 7, 8, 9 };
            var someInts = from a in groupA
                           from b in groupB
                           let sum = a + b         //在新的变量中保存结果
                           where sum == 12
                           select new { a, b, sum };

            //where 
            var someInts2 = from a in groupA
                            from b in groupB
                            let sum = a + b
                            where sum >= 11 && a == 4         // ←条件1
                            select new { a, b, sum };

            //order by  
            var stus = new[]
            {
                new{LName="Jones",FName="Mary",Age=19,Major="History"},
                new{LName="Smith",FName="Bob",Age=20,Major="CompSci"},
                new{LName="Fleming",FName="Carol",Age=21,Major="History"},
            };

            var result = stus.Take(stus.Count());
            var result2 = from s in stus
                          select s;

            var query2 = from s in stus
                         orderby s.Age descending
                         select s;

            //group by 
            var result3 = from s in stus
                          group s by s.Major;
            //foreach (var s in result3)
            //{
            //    Console.WriteLine(s.Key + "({0})", s.Count());
            //    foreach (var t in s)
            //    {
            //        Console.WriteLine("     " + t.FName);
            //    }
            //}

            //into 
            var someInts3 = from a in groupA
                            join b in groupB on a equals b
                            into groupAandB
                            from c in groupAandB
                            select c;

            //Sum和Count
            var numList = new int[] { 2, 3, 4, 6 };
            int sumQ = numList.Sum();
            int countQ = numList.Count();
            //Console.WriteLine("SUM={0}&&COUNT={1}", sumQ, countQ);

            //Union,Intersect,Distinct
            var objListA = new string[] { "AAA", "BBB", "CCC", "CCC" };
            var objListB = new string[] { "AAA", "DDD", "CCC" };

            var queryResult1 = objListA.Union(objListB);
            var queryResult2 = objListA.Intersect(objListB);
            var queryResult3 = objListA.Distinct();
            var queryResult4 = numList.First();
            var queryResult5 = numList.Last();

            var queryResykt6 = numList.Count(IsOdd);
            Console.WriteLine(queryResykt6);


            Console.ReadKey();

        }
    }
}
