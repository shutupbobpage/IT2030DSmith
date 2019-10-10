using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EnrollmentApplication.Models
{
    public class StudentData : DropCreateDatabaseAlways<EnrollmentDB>
    {
        protected override void Seed(EnrollmentDB context)
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentFirstName = "Jack", StudentLastName = "Burton"},
                //new Student { StudentId = 2, StudentFirstName = "Ellen", StudentLastName = "Ripley"},
                //new Student { StudentId = 3, StudentFirstName = "Dennis", StudentLastName = "Quaid"},
                //new Student { StudentId = 4, StudentFirstName = "Biff", StudentLastName = "Tannen"},
                //new Student { StudentId = 5, StudentFirstName = "Sarah", StudentLastName = "Connor"},
            };

            var courses = new List<Course>
            {
                new Course { CourseId = 1, CourseTitle = "Calculus I", CourseDescription = "Math", CourseCredits = 4},
                //new Course { CourseId = 2, CourseTitle = "Calculus II", CourseDescription = "Math", CourseCredits = 4},
                //new Course { CourseId = 3, CourseTitle = "English Composition", CourseDescription = "English", CourseCredits = 3},
                //new Course { CourseId = 4, CourseTitle = "Physics I", CourseDescription = "Physics", CourseCredits = 3},
                //new Course { CourseId = 5, CourseTitle = "Biology I", CourseDescription = "Biology", CourseCredits = 3}
            };
            
            //base.Seed(context);
        }
    }
}