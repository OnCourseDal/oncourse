using B4B_Lab1.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4B_Lab1.Models
{
    public class Grades
    {
        //TODO: change these variable to proper types and names 
        //PARAM: This must be updated to reflect any changes in new parameters
        private String idUnique = "NULL";
        public String IdUnique
        {
            get { return idUnique; }
            set { idUnique = value; }
        }

        IDictionary components = new Dictionary<string, string[]>();
        public IDictionary Components
        {
            get { return components; }
            set { components = value; }
        }

        public void setGrades(IDictionary input)
        {
            components = input;
        }

        public Grades()
        {
            idUnique = Guid.NewGuid().ToString();
        }
        public Grades(IDictionary mComp)
        {
            idUnique = Guid.NewGuid().ToString();
            components = mComp;
        }
        //PARAM: This must be updated to reflect any changes in new parameters
        //returns the parameters of this object in a way the view model can interpret them, order does not matter
        public ItemViewModel getVM()
        {
            return new ItemViewModel()
            {
                ID = IdUnique,
                Components = components,
            };
        }

        //This to String may need to be updated to reflect new properties, OR the save/load needs to change
        //Prints out the parameters a format for the CSV        (may want to do this work in another place since order does not matter.)
        public override string ToString()
        {
            //PARAM: This must be updated to reflect any changes in new parameters
            return "IDUNIQUE = " + IdUnique + ", COMPONENTS = " + Components;
        }
    }
}
