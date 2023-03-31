using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDbContext.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        public int DurationInHours { get; set; }
        public List<Enrollment> CourseEnrollment { get; set; }
    }
}
