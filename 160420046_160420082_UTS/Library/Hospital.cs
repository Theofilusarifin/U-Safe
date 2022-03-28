using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Hospital
    {
        #region Fields
        private int id;
        private string name;
        private string address;
        List<Hospital> listHospital;
        #endregion

        #region Constructors
        public Hospital(int id, string name, string address, List<Hospital> listHospital)
        {
            Id = id;
            Name = name;
            Address = address;
            ListHospital = listHospital;
        }
        #endregion

        #region Properties
        public int Id 
        {
            get => id; 
            set => id = value; 
        }
        public string Name 
        {
            get => name; 
            set => name = value; 
        }
        public string Address 
        {
            get => address; 
            set => address = value; 
        }
        internal List<Hospital> ListHospital 
        {
            get => listHospital; 
            set => listHospital = value; 
        }
        #endregion

        #region Methods
        #endregion
    }
}
