using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Admin
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Constructors
        public Admin(int id, string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KTPNum = ktpNum;
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
        public string KTPNum 
        { 
            get => ktpNum; 
            set => ktpNum = value; 
        }
        #endregion

        #region Methods
        #endregion
    }
}
