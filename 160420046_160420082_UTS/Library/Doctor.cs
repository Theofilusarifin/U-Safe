using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Doctor
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private byte[] profile_photo;
        private string ktpNum;
        private int balance;
        private string availability;
        private string bank_account;
        private Hospital hospital;
        #endregion

        #region Constructors
        public Doctor(int id, string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum, int balance, string availability, string bank_account, Hospital hospital)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
            Balance = balance;
            Availability = availability;
            Bank_account = bank_account;
            Hospital = hospital;
        }
        #endregion

        #region Properties
        public int Id 
        {
            get => id; 
            set => id = value; 
        }
        public string Username 
        {
            get => username; 
            set => username = value; 
        }
        public string Email 
        {
            get => email; 
            set => email = value; 
        }
        public string Phone_number 
        {
            get => phone_number; 
            set => phone_number = value; 
        }
        public string Password 
        {
            get => password;
            set => password = value; 
        }
        public byte[] Profile_photo 
        {
            get => profile_photo; 
            set => profile_photo = value; 
        }
        public string KtpNum 
        {
            get => ktpNum; 
            set => ktpNum = value; 
        }
        public int Balance 
        {
            get => balance; 
            set => balance = value; 
        }
        public string Availability 
        {
            get => availability; 
            set => availability = value; 
        }
        public string Bank_account 
        {
            get => bank_account; 
            set => bank_account = value; 
        }
        internal Hospital Hospital 
        {
            get => hospital; 
            set => hospital = value; 
        }
        #endregion

        #region Methods
        #endregion
    }
}
