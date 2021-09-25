using EntityFrameworkDbContext.DbContexts;
using EntityFrameworkDbContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDbContext
{
    public class Program
    {
        static void Main(string[] args)
        {
            TrainingContext context = new TrainingContext();

            Student student = new Student();
            student.Name = "Roy";
            student.DateOfBirth = new DateTime(1990, 1, 3);
            student.Address = "Mohammadpur";

            Course course = new Course();
            course.Title = "Critical Thinking";
            course.Fees = 4000;
            course.DurationInHours = 24;

            course.CourseEnrollment = new List<Enrollment>();


            Insertion(ref student, ref course, ref context);



            student.Name = "Samin";
            student.DateOfBirth = new DateTime(2020, 10, 3);
            student.Address = "Dhanmondi";

            course.Title = "Computer Science";
            course.Fees = 10000;
            course.DurationInHours = 48;
            //course.CourseEnrollment.Add(new Enrollment { Student = student });
            context.Students.Update(student);
            context.Courses.Update(course);
            context.SaveChanges();

        }

        public static void Insertion(ref Student student, ref Course course, ref TrainingContext context)
        {
            context.Students.Add(student);
            context.Courses.Add(course);
            course.CourseEnrollment.Add(new Enrollment { Student = student });
            context.SaveChanges();
        }

       
    }
}
