//Kassandra Lopez & Zhiyuan Xue CIS 345 4:30-5:45 Project 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace Lopez_Xue_Project
{
    class Utilities
    {
        public static int ReadInteger(string displayString) //method that will catch overflow and format exception errors
        {
            int errorCatch = 0;
            int no = 0;

            bool userInput = false;

          do
            {
                //Try block start
                try
                {
                    Console.Write(displayString);
                    no = Convert.ToInt32(Console.ReadLine());

                    // input was okay, program didn't go into catch
                    // set promptAgain flag to false
                    userInput = false;
                }//end try
                catch (OverflowException) //Catch overflow exception
                {
                    // if number of errorCatch is already 3, give warning and exit application
                    if (errorCatch == 3)
                    {
                        Console.WriteLine("\nYou did not enter a valid value. The application will exit now.");
                        System.Environment.Exit(0);
                    }

                    // inform the user about issues and set the promptagain flag to true so that the do-while loop repeats
                    Console.WriteLine("\nThe number you entered was not valid! Please try again.\n");
                    userInput = true;

                    // increment errorCatch
                    errorCatch++;

                }
                catch (FormatException)//catch format exception
                {
                    // if number of errorCatch is already 3, give warning and then exit the program
                    if (errorCatch == 3)
                    {
                        Console.WriteLine("\nYou did not enter a valid value! The application will now exit.");
                        System.Environment.Exit(0);
                    }
                    // inform the user about issues and set the promptagain flag to true
                    Console.WriteLine("\nUser Input must be valid! Please try again.\n");
                    userInput = true;
                    errorCatch++;
                }
            } while (userInput == true);
            // return the number that was read
            return no;

        }
    }
}
