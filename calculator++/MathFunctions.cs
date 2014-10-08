using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace calculatorplusplus
{
    public static class MathFunctions
    {

        static String validCharacters = "0123456789+-()/*%.";

        /// <summary>
        /// Calculates the totals currently and updates text box
        /// </summary>
        public static String calculateTotal(String value)
        {
            try
            {
                return (Math.Round((decimal)new DataTable().Compute("0" + value, null), 4, MidpointRounding.AwayFromZero)).ToString();
            }  
            catch (Exception)
            {
                return value;
            }
        }

        /// <summary>
        /// Method to compare the contents of the TextBox with a string of allowed characters.
        /// IF not remove invalid ones.
        /// </summary>
        /// <param name="displayBox"></param>
        public static void checkValidChars(TextBox displayBox)
        {
            for (int i = 0; i < displayBox.Text.Length; i++)
            {
                if (!validCharacters.Contains(displayBox.Text.ElementAt(i)))
                {
                    displayBox.Text = displayBox.Text.Remove(i, 1);
                    displayBox.Select(i, 0);
                    break;
                }
            }
        }

        public static bool checkLength(TextBox displayBox)
        {
            if (Math.Abs((decimal)new DataTable().Compute("0"+displayBox.Text, null)) > 9999999)
            {
                displayBox.Text = "0";
                MessageBox.Show("Only numbers between -9999999 and 9999999 are valid.", "Huge Number Error");
                return false;
            }
            return true;
        }
    }
}
