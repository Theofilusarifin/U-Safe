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
    class Medicine
    {
        #region Fields
        private int id;
        private string name;
        private int price;
        private int stock;
        List<Checkup_Medicine> checkup_medicine;
        #endregion

        #region Constructors
        public Medicine(int id, string name, int price, int stock, List<Checkup_Medicine> checkup_medicine)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Checkup_medicine = checkup_medicine;
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
        public int Price
        {
            get => price;
            set => price = value;
        }
        public int Stock
        {
            get => stock;
            set => stock = value;
        }
        internal List<Checkup_Medicine> Checkup_medicine
        {
            get => checkup_medicine;
            set => checkup_medicine = value;
        }
        #endregion

        #region Methods
        #endregion
    }
}
