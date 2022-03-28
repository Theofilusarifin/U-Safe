using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Checkup_Medicine
    {
        #region Fields
        private Checkup checkup;
        private Medicine medicine;
        #endregion

        #region Constructors
        public Checkup_Medicine(Checkup checkup, Medicine medicine)
        {
            Checkup = checkup;
            Medicine = medicine;
        }
        #endregion

        #region Properties
        public Checkup Checkup 
        { 
            get => checkup; 
            set => checkup = value; 
        }
        public Medicine Medicine 
        { 
            get => medicine;
            set => medicine = value; 
        }
        #endregion

        #region Methods
        #endregion
    }
}
