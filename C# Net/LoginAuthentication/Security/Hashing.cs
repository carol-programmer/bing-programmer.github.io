using System;
using System.Collections.Generic;
using System.Text;
using Scrypt;

namespace Security
{
    public class Hashing
    {
       //***********************BCript Method *****************************//
        public static string HashPassword(string password)
        {
            var hashPW = BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
            return hashPW;
        }

        public static bool ValidatePassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private static string GetRandomSalt()
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12, BCrypt.Net.SaltRevision.Revision2Y);
            return salt;
        }




        /******************Scrypt Method***********************************
        public static string HashPassword(string password)
        {

            ScryptEncoder encoder = new ScryptEncoder();
            string hashedPassword = encoder.Encode(password);
            return hashedPassword;
        }

        public static bool ValidatePassword(string password, string hashedPassword)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            bool areEquals = encoder.Compare(password, hashedPassword);
            return areEquals;

        }
        ****************************************************************/

    }
}
