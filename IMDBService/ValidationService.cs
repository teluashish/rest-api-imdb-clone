using System;
using System.Text.RegularExpressions;

namespace IMDBService
{
    public class ValidationService
    {

        public static bool IsValidName(string name)
        {
            //return Regex.IsMatch(name, "/^[a-z ,.'-]+$/i");
            return true;
        }
        public static bool IsValidDateOfBirth(string dateOfBirth, out DateTime DOB)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime dob))
            {
                int age = (int)(DateTime.Now.Year - dob.Year);
                if (age < 18 || age > 110)
                {
                    DOB = DateTime.Now;
                    return false;
                }

            }
            DOB = dob;
            return true;
        }
    }
}
