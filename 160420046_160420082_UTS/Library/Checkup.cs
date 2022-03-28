using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Checkup
    {
        #region Fields
        private int id;
        private int price;
        private int totalPrice;
        private int finished;
        private DateTime startDate;
        private DateTime finishDate;
        private Customer customer;
        private Doctor doctor;
        List<Checkup_Medicine> checkup_medicines;
        #endregion

        #region Constructors
        public Checkup(int id, int price, int totalPrice, int finished, DateTime startDate, DateTime finishDate, Customer customer, Doctor doctor, List<Checkup_Medicine> checkup_medicines)
        {
            Id = id;
            Price = price;
            TotalPrice = totalPrice;
            Finished = finished;
            StartDate = startDate;
            FinishDate = finishDate;
            Customer = customer;
            Doctor = doctor;
            Checkup_medicines = checkup_medicines;
        }
        #endregion

        #region Properties
        public int Id 
        {
            get => id; 
            set => id = value; 
        }
        public int Price 
        {
            get => price; 
            set => price = value; 
        }
        public int TotalPrice 
        {
            get => totalPrice;
            set => totalPrice = value; 
        }
        public int Finished 
        {
            get => finished; 
            set => finished = value;
        }
        public DateTime StartDate 
        {
            get => startDate; 
            set => startDate = value; 
        }
        public DateTime FinishDate 
        {
            get => finishDate; 
            set => finishDate = value; 
        }
        internal Customer Customer 
        {
            get => customer; 
            set => customer = value; 
        }
        internal Doctor Doctor 
        {
            get => doctor; 
            set => doctor = value; 
        }
        internal List<Checkup_Medicine> Checkup_medicines 
        {
            get => checkup_medicines; 
            set => checkup_medicines = value; 
        }
        #endregion

        #region Methods
        #endregion
    }
}
