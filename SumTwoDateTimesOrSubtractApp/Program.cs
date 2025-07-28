using System.Globalization;
namespace SumTwoDateTimesOrSubtractApp
{
            /*
            This program reads two datetimes from the user 
            and if the first is the greatest we will subtract the first from the second
            and if the second is the greatest we will apply sum of them
            and if are equal we will print each of them
             */
    internal class Program
    {
        static void Main(string[] args)
        {

            // Declaring variables
            char cUserChoice = ' ';
            DateTime dtDate1 = new DateTime();
            DateTime dtDate2 = new DateTime();
            while (true)
            {
                // Welcome message
                WelcomeApp("two dates comparison");
                // To change the culture of the app to en-US on all devices
                ChangeToEnUS();
                // To read the first date from the user and validate it
                do
                {
                    if (!ReadDateTime("first date", out dtDate1))
                        continue;
                    break;
                } while (true);
                // To read the second date from the user and validate it
                do
                {
                    if (!ReadDateTime("second date", out dtDate2))
                        continue;
                    break;
                } while (true);
                // To check if first date > second date or the second date > first date or they are equal
                if (dtDate1 > dtDate2)
                    Print($"The subtraction is: {SubtractTwoDateTimes(dtDate1, dtDate2)}");
                else if (dtDate1 < dtDate2)
                    Print($"The summation is: {SumTwoDateTimes(dtDate1, dtDate2).ToString("dd/MM/yyyy")}");
                else
                    PrintTwoDates(dtDate1, dtDate2);


                // To read user choice to continue in the app again and validate the user input
                if (!IsChar("y to continue in the application else enter n", out cUserChoice))
                    return;
                // Convert the character to lower 
                cUserChoice = Char.ToLower(cUserChoice);
                // To check the user input in the right format (y,n)
                if (!IsInRightFormat(cUserChoice))
                    return;
                // To check if the user want to continue or not
                if (!WantToContinue(cUserChoice))
                    return;
            }

        }

        #region Methods 

        // This region contains the main methods used in the application
        #region main-methods

        // 1) this method to welcome user in the beginning of the application
        static void WelcomeApp(String welcomeMessage)
        {
            Console.Clear();
            Console.WriteLine("*********************************************************************************");
            Console.WriteLine($"  Welcome to {welcomeMessage} Application!");
            Console.WriteLine("  This app is designed to make your life easier.");
            Console.WriteLine("  Let's get started!");
            Console.WriteLine("  Developed by: Mohammed Salem");
            Console.WriteLine("*********************************************************************************");
        }

        // 2) this method to print message in a beatiful form
        static void Print(String message)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        // 3) this method to read and validate character from the user
        static bool IsChar(string field, out char cInput)
        {
            Console.Write($"Please, enter {field}: ");
            if (!char.TryParse(Console.ReadLine(), out cInput))
            {
                Print("Please, enter a valid character");
                return false;
            }
            return true;
        }

        // 4) this method to check that the user entered (y,n) only
        static bool IsInRightFormat(char input)
        {
            if (input == 'y' || input == 'n')
                return true;
            Print("Please, enter (y) to continue in the application again else enter (n)");
            return false;
        }

        // 5) this method to check the user choice if he wants to continue in the app or not
        static bool WantToContinue(char input)
        {
            if (input == 'y')
                return true;
            Print("The program ended : see you soon again");
            return false;
        }

        // 6) this method to change the culture of the app to en-US on all devices
        static void ChangeToEnUS()
        {
            CultureInfo enUS = new CultureInfo("en-US");
        }

        // 7) to read a datetime from user in custom format then validate it
        static bool ReadDateTime(string field, out DateTime dtOutput)
        {
            Console.Write($"Please, enter {field} in that format dd/MM/yyyy: ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy"
                ,CultureInfo.InvariantCulture,DateTimeStyles.None
                ,out dtOutput))
            {
                Print("Please enter a valid date in the format dd/MM/yyyy");
                return false;
            }
            return true;
        }

        // 8) Sum two datetimes
        static DateTime SumTwoDateTimes(DateTime date1, DateTime date2)
        {
            TimeSpan tsDate2 = new TimeSpan(date2.Ticks);
            return date1.Add(tsDate2);
        }
        // 9) Subtract two datetimes
        static TimeSpan SubtractTwoDateTimes(DateTime date1, DateTime date2)
        {
            return date1 - date2;
        }
        // 10) print DateTime
        static void PrintTwoDates(DateTime date1,DateTime date2)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine($"The date1: {date1.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"The date2: {date2.ToString("dd/MM/yyyy")}");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }



        #endregion


        #endregion

    }
}