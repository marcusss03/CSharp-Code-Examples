using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Code_Examples.Basics
{
    class PasswordCreator
    {
        // Authors: Marcus Sanghvi - 26944375

        // Password Creator:
        // This code example has been made in order to be used in software applications that require users to sign up for an account etc.

        // The user is asked to make a password and then this is stored into the 'password1' variable.
        // The user is asked a second time to validate their password and the result is stored into the 'password2' variable.
        // The user then has 3 attempts before the application closes (in order to stop bot activity or spam - perhaps make a cooldown between failed attempts at validation?)
        // The passwords are then checked that they are not empty or null and then are checked for complexity requirments (e.g length, special chars, etc)
        // The program will loop until a successfull attempt or if the user reaches a max attempt of 3.
        // Added feedback for the user in the form of console write lines, guiding the user and telling them if there were any errors or problems.

        public static void run()
        {
            int attempts = 3;

            while (attempts > 0)
            {
                Console.WriteLine("Ensure that the password is 6 characters long, contains an uppercase, 1 numerical value and a special character. \n");

                Console.WriteLine("Please create your password below: \n");
                string password1 = Console.ReadLine();

                if(!complexityIsValid(password1))
                {
                    Console.WriteLine("Your password doesn't meet the complexity requirements, please try again! \n");
                    attempts--;
                    if (attempts == 0)
                    {
                        Console.WriteLine("Maxmimum attempts reached. Closing application. \n");
                        break;
                    }
                    continue;
                }

                Console.WriteLine("Please input your password again to be validated: \n");
                string password2 = Console.ReadLine();

                if (!string.IsNullOrEmpty(password1) && !string.IsNullOrEmpty(password2))
                {
                    Console.WriteLine("Both inputs are not null, proceeding. \n");

                    if (password1 == password2)
                    {
                        Console.WriteLine("Passwords match! Password has now been set, please continue to login! \n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match, please try again. \n");
                    }
                }
                else
                {
                    Console.WriteLine("One or more password inputs do not contain a valid entry, please try again. \n");
                }

                attempts--;
                if (attempts == 0)
                {
                    Console.WriteLine("Maximum attempts reached. Exiting.\n");
                }
            }
        }

        private static bool complexityIsValid(string password)
        {
            // Checks the password meets the minimum length, and is not null or empty
            if(string.IsNullOrEmpty(password) || password.Length < 6)
                return false;

            // Checks the password contains at least one uppercase value
            if(!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            if(!Regex.IsMatch(password, @"[\W_]"))
                return false;

            return true;
        }


    }
}
