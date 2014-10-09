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

        static String validCharacters = "0123456789+-()/*.";

        /// <summary>
        /// Calculates the totals currently and updates text box
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The value to go into the display box></returns>
        public static String calculateTotal(String value)
        {
            try
            {
                double result = Convert.ToDouble(new System.Data.DataTable().Compute(value, null));
                return (Math.Round(result, 4, MidpointRounding.AwayFromZero)).ToString();
            }  
            catch (Exception)
            {
                return value;
            }
        }

        /// <summary>
        /// Method to compare the contents of the TextBox with a string of allowed characters.
        /// IF not remove invalid ones.
        /// Only returns at the end incase a statement with multiple invalid chars is pasted in
        /// </summary>
        /// <param name="displayBox"></param>
        public static String checkValidChars(String displayBox)
        {
            for (int i = 0; i < displayBox.Length; i++)
            {
                if (!validCharacters.Contains(displayBox.ElementAt(i)))
                {
                    displayBox = displayBox.Remove(i, 1);
                }
            }
            return displayBox;
        }

        /// <summary>
        /// Method to actually check length of value
        /// </summary>
        /// <param name="displayBox"></param>
        /// <returnsTrue if length is ok, false if invalid></returns>
        public static bool checkLength(String displayBox, out String value)
        {
            value = displayBox;
            if (Math.Abs(Convert.ToDouble(calculateTotal(displayBox))) > 9999999)
            {
                value = "0";
                MessageBox.Show("Only numbers between -9999999 and 9999999 are valid.", "Huge Number Error");
                return false;
            }
            return true;
        }
    }
}
