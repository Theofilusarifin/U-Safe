using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Library
{
    public class Checkup_Medicine
    {
        #region Fields
        private Checkup checkup;
        private Medicine medicine;
        private int amount;
        private int price;
        #endregion

        #region Constructors
        public Checkup_Medicine(Checkup checkup, Medicine medicine, int amount, int price)
        {
            Checkup = checkup;
            Medicine = medicine;
            Amount = amount;
            Price = price;
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
        public int Amount
        {
            get => amount;
            set => amount = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }
        #endregion

        #region Methods
        #endregion
    }
}
