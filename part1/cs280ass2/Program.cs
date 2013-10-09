using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace cs280ass2
{
    class Program
    {
        static List<string> creditList = new List<string>();
        static List<string> debitList = new List<string>();
        static List<string> errorList = new List<string>();

        static void Main(string[] args)
        {
            if (args != null && args[0].Equals("-l"))
            {
                Console.WriteLine("calidating number " + args[1] + " : " + validateluhn(args[1]));
                Console.WriteLine("Press any key to exit."); System.Console.ReadKey();
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(@"../../../../Transactions.txt");
            int counter = 1;
            foreach (string line in lines)
            {
                string[] splits = line.Split(new Char[] { ',' }); // , ' '
                try
                {
                    if (splits.Length != 4) throw new Exception("Truncated record");

                    foreach (string str in splits)
                    {
                        if (str.Trim().Equals(""))
                        {
                            throw new Exception("Truncated record");
                        }
                    }

                    int clientNumber;
                    if (!int.TryParse(splits[0], out clientNumber))
                    {
                        throw new Exception("Invalid Client Number");
                    }
                    if (!validateluhn("" + clientNumber))
                    {
                        throw new Exception("Client Number Invalid check digit");
                    }

                    if (!(splits[1].Trim().Equals("Cr") || splits[1].Trim().Equals("Dr")))
                    {
                        throw new Exception("Invalid type code");
                    }

                    DateTime tempDateTime;
                    string[] dateFormats = { "d/MM/yyyy", "dd/M/yyyy" };
                    if (!DateTime.TryParseExact(splits[2].Trim(), dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateTime))
                    {
                        throw new Exception("Invalid Transaction Date");
                    }
                    if (tempDateTime < new DateTime(2011, 1, 1) || tempDateTime > new DateTime(2012, 12, 31))
                    {
                        throw new Exception("Transaction Date Out of range");
                    }

                    double amount;
                    if (!double.TryParse(splits[3].Trim(), out amount))
                    {
                        throw new Exception("Transaction Amount Non-numeric");
                    }
                    if (amount <= 0 || amount >= 5000)
                    {
                        string str = "";
                        if (amount < 0) { str = "Negative"; }
                        if (amount == 0) { str = "Zero"; }
                        if (amount >= 5000) { str = "larger than 5000"; }
                        throw new Exception("Transaction Amount " + str);
                    }
                    if (splits[1].Trim().Equals("Cr"))
                    {
                        creditList.Add(line);
                    }
                    else
                    {
                        debitList.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    errorList.Add(line);
                    Console.WriteLine("Record " + counter + ": ERROR – " + ex.Message);//("exception: " + ex.Message + "\nLine: " + line);
                }
                finally
                {
                    counter++;
                }
                
            }
            System.IO.File.WriteAllLines(@"../../../../CreditFile.txt", creditList);
            System.IO.File.WriteAllLines(@"../../../../DebitFile.txt", debitList);
            System.IO.File.WriteAllLines(@"../../../../ErrorFile.txt", errorList);
            Console.WriteLine("totally records number: " + lines.Length + " creditList:" + creditList.Count + " debitList:" + debitList.Count + " errorList:" + errorList.Count);
            Console.WriteLine("Press any key to exit."); System.Console.ReadKey();
        }

        //Clean the card number- remove dashes and spaces
        // Hint use the Replace method for this
        //Convert card number into digits array
        public static bool validateluhn (String cardNumber)
        {
            int[] digits = new int[cardNumber.Length];
            for (int len = 0; len < cardNumber.Length; len++)
            {
                digits[len] = Int32.Parse(cardNumber.Substring(len, 1));
            }
            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int currentDigit = digits[i];
                if (alt)
                {
                    currentDigit *= 2;
                    if (currentDigit > 9)
                    {
                        currentDigit -= 9;
                    }
                }
                sum += currentDigit;
                alt = !alt;
            }
            //If Mod 10 equals 0, the number is good and this will return true
            return sum % 10 == 0;
        }
    }
}
