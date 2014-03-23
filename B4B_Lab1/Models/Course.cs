using B4B_Lab1.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4B_Lab1.Models
{
    public class Course 
    {
        //TODO: change these variable to proper types and names 
        //PARAM: This must be updated to reflect any changes in new parameters
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

        //PARAM: This must be updated to reflect any changes in new parameters
        public void setParameters(String[] parameters)
        {
            foreach (String parameter in parameters)
            {
                var value = parameter.Split('=');
                if (value[0].Equals("IDUNIQUE"))
                {
                    idUnique = value[1];
                }
                else if (value[0].Equals("COURSENAME"))
                {
                    courseName = value[1];
                }
                else if (value[0].Equals("DAY"))
                {
                    day = value[1];
                }
                else if (value[0].Equals("NEXTASSIGNMENT"))
                {
                    nextAssign = value[1];
                }
                else if (value[0].Equals("CURRENTGRADE"))
                {
                    currGrade = value[1];
                }






            }
        }

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

        //PARAM: This must be updated to reflect any changes in new parameters
        //returns the parameters of this object in a way the view model can interpret them, order does not matter
        public ItemViewModel getVM()
        {
             return new ItemViewModel()
            {
                ID = IdUnique,
                CourseName = CourseName,
                Time = Day,
                Assignments = NextAssign,
                Grades = CurrGrade

                //insert new parameters here
            };
        }

        //This to String may need to be updated to reflect new properties, OR the save/load needs to change
        //Prints out the parameters a format for the CSV        (may want to do this work in another place since order does not matter.)
        public override string ToString()
        {
            //PARAM: This must be updated to reflect any changes in new parameters
            return "IDUNIQUE="+ IdUnique + ",COURSENAME=" + CourseName + ",DAY=" + Day + ",NEXTASSIGNMENT="
                    + NextAssign + ",CURRENTGRADE=" + CurrGrade;
        }
    }

}
