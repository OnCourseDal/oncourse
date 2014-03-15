using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4B_Lab1.Models
{
    public class Course
    {
        //TODO change these variable to proper types and names 
        public String idUnique = "NULL";
        public String courseName ="NULL";
        public String day = "NULL";
        public String nextAssign = "NULL";
        public String currGrade = "NULL";

        public Course()
        {
            idUnique = Guid.NewGuid().ToString();
        }
        public Course(String cName, String day, String nAssign, String cGrade)
        {
            idUnique = Guid.NewGuid().ToString();
            courseName = cName;
            this.day = day;
            nextAssign = nAssign;
            currGrade = cGrade;
        }
    }
}
