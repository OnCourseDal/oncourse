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
        private String idUnique = "NULL";
        public String IdUnique
        {
            get { return idUnique; }
            set { idUnique = value; }
        }

        private String courseName = "NULL";
        public String CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        private String day = "NULL";
        public String Day
        {
            get { return day; }
            set { day = value; }
        }

        private String nextAssign = "NULL";
        public String NextAssign
        {
            get { return nextAssign; }
            set { nextAssign = value; }
        }

        private String currGrade = "NULL";
        public String CurrGrade
        {
            get { return currGrade; }
            set { currGrade = value; }
        }
       // private String currGrade = "NULL";
        //private String currGrade = "NULL";
        //private String currGrade = "NULL";
        //private String currGrade = "NULL";

        /*
        Assignments*
        Projects*
        Presentations
        Attendance
        Quizzes
        Tests*
        Midterm
        Exam
        Other
         * */

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
        //This to String may need to be updated to reflect new properties, OR the save/load needs to change
        public override string ToString()
        {
            return IdUnique + "," + CourseName + ',' + Day + ',' + NextAssign + ',' + CurrGrade;
        }
    }
}
