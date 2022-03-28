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
    class Customer
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private int balance;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Construtors
        public Customer(int id, string username, string email, string phone_number, string password, int balance, byte[] profile_photo, string ktpNum)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Balance = balance;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
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
        public int Balance 
        { 
            get => balance; 
            set => balance = value; 
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
        #endregion

        #region Methods
        #endregion
    }
}
