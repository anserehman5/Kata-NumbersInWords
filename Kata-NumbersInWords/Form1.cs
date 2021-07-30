using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;


namespace Kata_NumbersInWords
{

    public partial class Form1 : Form
    {
        public Form1()
        {

            Numbers.unitsMap[0] = "Zero";
            Numbers.unitsMap[1] = "One";
            Numbers.unitsMap[2] = "Two";
            Numbers.unitsMap[3] = "Three";
            Numbers.unitsMap[4] = "Four";
            Numbers.unitsMap[5] = "Five";
            Numbers.unitsMap[6] = "Six";
            Numbers.unitsMap[7] = "Seven";
            Numbers.unitsMap[8] = "Eight";
            Numbers.unitsMap[9] = "Nine";
            Numbers.unitsMap[10] = "Ten";
            Numbers.unitsMap[11] = "Eleven";
            Numbers.unitsMap[12] = "Twelve";
            Numbers.unitsMap[13] = "Thirteen";
            Numbers.unitsMap[14] = "Fourteen";
            Numbers.unitsMap[15] = "Fifteen";
            Numbers.unitsMap[16] = "Sixteen";
            Numbers.unitsMap[17] = "Seventeen";
            Numbers.unitsMap[18] = "Eighteen";
            Numbers.unitsMap[19] = "Nineteen";


            Numbers.tensMap[0] = "Zero";
            Numbers.tensMap[1] = "Ten";
            Numbers.tensMap[2] = "Twenty";
            Numbers.tensMap[3] = "Thirty";
            Numbers.tensMap[4] = "Forty";
            Numbers.tensMap[5] = "Fifty";
            Numbers.tensMap[6] = "Sixty";
            Numbers.tensMap[7] = "Seventy";
            Numbers.tensMap[8] = "Eighty";
            Numbers.tensMap[9] = "Ninety";


            Numbers.numberNames.Add("Zero", 0);
            Numbers.numberNames.Add("One", 1);
            Numbers.numberNames.Add("Two", 2);
            Numbers.numberNames.Add("Three", 3);
            Numbers.numberNames.Add("Four", 4);
            Numbers.numberNames.Add("Five", 5);
            Numbers.numberNames.Add("Six", 6);
            Numbers.numberNames.Add("Seven", 7);
            Numbers.numberNames.Add("Eight", 8);
            Numbers.numberNames.Add("Nine", 9);
            Numbers.numberNames.Add("Ten", 10);
            Numbers.numberNames.Add("Eleven", 11);
            Numbers.numberNames.Add("Twelve", 12);
            Numbers.numberNames.Add("Thirteen", 13);
            Numbers.numberNames.Add("Fourteen", 14);
            Numbers.numberNames.Add("Fifteen", 15);
            Numbers.numberNames.Add("Sixteen", 16);
            Numbers.numberNames.Add("Seventeen", 17);
            Numbers.numberNames.Add("Eighteen", 18);
            Numbers.numberNames.Add("Nineteen", 19);


            Numbers.numberNames.Add("Twenty", 20);
            Numbers.numberNames.Add("Thirty", 30);
            Numbers.numberNames.Add("Forty", 40);
            Numbers.numberNames.Add("Fifty", 50);
            Numbers.numberNames.Add("Sixty", 60);
            Numbers.numberNames.Add("Seventy", 70);
            Numbers.numberNames.Add("Eighty", 80);
            Numbers.numberNames.Add("Ninety", 90);


            Numbers.numberNames.Add("Hundred", 100);
            Numbers.numberNames.Add("Thousand", 1000);
            Numbers.numberNames.Add("Million", 1000000);


            InitializeComponent();


        }

        static class Numbers
        {
            //Hashtable to store numbers with corresponding names
            public static Hashtable numberNames = new Hashtable();

            //Array of strings to hold all possible units as words
            public static string[] unitsMap = new string[20];

            //Array of strings to hold all possible tens as words
            public static string[] tensMap = new string[10];
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero Pounds";

            //If number is negative recall function, but add "minus" to front of the result
            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            //Decalre string which will be returned as the result
            string words = "";

            //If number divided by 1 Million is larger than 1, appened recalled fucntion + "Million" to the final string
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            //If number divided by 1 Thousand is larger than 1, appened recalled fucntion + "Thousand" to the final string
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            //If number divided by 1 Hundred is larger than 1, appened recalled fucntion + "Hundred" to the final string
            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            //If number is larger than 1
            if (number > 0)
            {
                //If the result string is not empty, meaning the number has gone though at least one of the previous "if statements" - append "and" the result string
                if (words != "")
                    words += "and ";

                //If number is 19 or smaller, append the correspending unit as a word to the final string
                // e.g. unitsMap[0] = "Zero", unitsMap[6] = "Six".
                if (number < 20)
                    words += Numbers.unitsMap[number];
                else
                {
                    //If number is 20 or bigger, append the correspending tens as a word to the final string
                    // e.g. tensMap[20 / 10] = "Twenty", unitsMap[45 / 10] = "Forty".
                    words += Numbers.tensMap[number / 10];

                    //If number % 10 is bigger than 0 (meaning the number does not end in 0 e.g. 45)
                    //append "-" + the corresponding unit as a word to the final string e.g. 45 = "-five"
                    if ((number % 10) > 0)
                        words += "-" + Numbers.unitsMap[number % 10];
                }
                
            }

            return words;
        }

        public string DecimalToWords(decimal number)
        {
            //Works the same/with NumberToWords but checks if there is any numbers after the decimal
            //If there is it first calls NumberToWords for the decimal number (Pennies)
            //And then does the regular call for the whole number (Pounds)

            if (number == 0)
                return "Zero Pounds";

            if (number < 0)
                return "Minus " + DecimalToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            decimal fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumberToWords(intPortion);
            words += " Pounds";
            //If the amount of Pennies is bigger than 0, appened the number and Pennies to the final string
            if (decPortion > 0)
            {
                words += " and ";
                words += NumberToWords(decPortion);
                words += " Pennies";

            }
            return words;
        }

        public string WordsToNumber(string number)
        {

            // Creates a TextInfo based on the "en-US" culture.
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            //Converts text to title case so words can be detected later
            string textToBeConverted = myTI.ToTitleCase(textBox1.Text);


            //Split the text into two string - everything before Pounds and everything after (Pounds and Pennies)
            //If there is nothing after Pounds, remove the empty element
            string[] strArrayPoundsPennies = textToBeConverted.Split(new string[] { "Pounds" }, StringSplitOptions.RemoveEmptyEntries);

            string poundsVal = strArrayPoundsPennies[0];
            string penniesVal = "0";
            string[] strArrayPounds;
            string[] strArrayPennies;
            int value = 0;
            int tempValue = 0;

            //If there was 2 elements in the string array (If pennies were included in the amount)
            if (strArrayPoundsPennies.Length > 1)
            {
                //Remove extra words from the pennies string so you are just left with a string of the amount of pennies
                penniesVal = strArrayPoundsPennies[1];
                penniesVal = penniesVal.Replace(" Pennies", "");
                penniesVal = penniesVal.Replace(" And", "");

                //Create array of the words in the pennies array by spliiting spaces and '-'
                //e.g. Forty-Five = "Forty" and "Five"
                strArrayPennies = penniesVal.Split(' ', '-');


                //Loop through strings in array of penny values
                foreach (string s in strArrayPennies)
                {
                    //if string equal to any of these - take the string and find the corresponding value by using the hashtable and add it to value
                    if (Equals(s, "Hundred") || Equals(s, "Thousand") || Equals(s, "Million"))
                    {
                        value += tempValue * int.Parse(Numbers.numberNames[s].ToString());
                        tempValue = 0;
                    }
                    else
                    {
                        //If the value can be found in the hashtable, add the corresponding value to tempValue
                        if (Numbers.numberNames.ContainsKey(s))
                        {
                            tempValue += int.Parse(Numbers.numberNames[s].ToString());
                        }
                    }
                }

                //Add value and tempValue and convert it to a string for the final amount of pennies.
                penniesVal = (value + tempValue).ToString();
            }

            //Do the same as above, but for Pounds
            poundsVal = poundsVal.Replace(" Pounds", "");
            poundsVal = poundsVal.Replace(" And", "");


            strArrayPounds = poundsVal.Split(' ', '-');

            value = 0;
            tempValue = 0;


            foreach (string s in strArrayPounds)
            {
                if (Equals(s, "Hundred") || Equals(s, "Thousand") || Equals(s, "Million"))
                {
                    value += tempValue * int.Parse(Numbers.numberNames[s].ToString());
                    tempValue = 0;
                }
                else
                {
                    if (Numbers.numberNames.ContainsKey(s))
                    {
                        tempValue += int.Parse(Numbers.numberNames[s].ToString());
                    }
                }
            }

            poundsVal = (value + tempValue).ToString();

            //Append the Pounds and Pennies together with a decimal between them
            return poundsVal + "." + penniesVal;

        }

        private void numberToTextButton_Click(object sender, EventArgs e)
        {

            try {
                //Convert string amount to decimal and call function to convert
                decimal initialString;
                initialString = decimal.Parse(numberTextBox.Text);

                textTextBox.Text = DecimalToWords(initialString);
            }
            catch
            {
                //Error handling
                    MessageBox.Show("Please enter a valid amount. e.g. 568.23");
            }
  

        }


        private void wordsToNumberButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Call function to convert and set textBox2's text to be the result
                textBox2.Text = WordsToNumber(textBox1.Text);
            }
            catch
            {
                //Error handling
                MessageBox.Show("Please enter a valid amount. e.g. One Thousand and Twenty Pounds and Thirty-Five Pennies");
            }
            
        }

    }
}
