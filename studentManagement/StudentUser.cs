using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement
{

    public class StudentUser
    {
        private string name;
        private string chinese;
        private string math;
        private string english;
        private string wuli;
        private string huaxue;
        private string avg;



        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Chinese
        {
            get
            {
                return chinese;
            }
            set
            {
                chinese = value;
            }
        }
        public string Math
        {
            get
            {
                return math;
            }
            set
            {
                math = value;
            }
        }
        public string English
        {
            get
            {
                return english;
            }
            set
            {
                english = value;
            }
        }
        public string Wuli
        {
            get
            {
                return wuli;
            }
            set
            {
                wuli = value;
            }
        }
        public string Huaxue
        {
            get
            {
                return huaxue;
            }
            set
            {
                huaxue = value;
            }
        }
        public string Avg
        {
            get
            {
                return avg;
            }
            set
            {
                avg = value;
            }
        }
    }
}
