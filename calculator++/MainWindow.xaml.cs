﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculatorplusplus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///    Method to handle the enter key being pressed.
        ///    Calculates the total and then moves the curser to the right hand side of box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterKeyPress(object sender, KeyEventArgs e)
        {
            String value;
            if (e.Key == Key.Enter && MathFunctions.checkLength(calcDisplayBox.Text, out value))
            {
                calcDisplayBox.Text = MathFunctions.calculateTotal(value);
            }
            else if (MathFunctions.checkLength(calcDisplayBox.Text, out value))
            {
                calcDisplayBox.Text = value;
            }
            calcDisplayBox.Select(calcDisplayBox.Text.Length, 0);
        }

        /// <summary>
        /// Add a number (taken from the content field) to the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberButtonClick(object sender, RoutedEventArgs e)
        {
            calcDisplayBox.Text += ((Button)sender).Content;
        }

        /// <summary>
        /// Add a standard operator to the text box.
        /// Before adding operator calculate the total so it is sequential
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operatorButtonClick(object sender, RoutedEventArgs e)
        {
            calcDisplayBox.Text = MathFunctions.calculateTotal(calcDisplayBox.Text);
            String value;
            if(MathFunctions.checkLength(calcDisplayBox.Text, out value))
            {
                calcDisplayBox.Select(calcDisplayBox.Text.Length, 0);
                calcDisplayBox.Text += ((Button)sender).Content;
            }
            else
            {
                calcDisplayBox.Text = value;
            }
        }

        /// <summary>
        /// If equals is pressed call to calculateTotal method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equalsButtonClick(object sender, RoutedEventArgs e)
        {
            calcDisplayBox.Text = MathFunctions.calculateTotal(calcDisplayBox.Text);
            calcDisplayBox.Select(calcDisplayBox.Text.Length, 0);
        }

        /// <summary>
        /// Used to clear the display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearClick(object sender, RoutedEventArgs e)
        {
            calcDisplayBox.Text = "";
        }

        /// <summary>
        /// Used to ensure no invalid characters are entered into the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayBoxUpdated(object sender, TextChangedEventArgs e)
        {
            calcDisplayBox.Text = MathFunctions.checkValidChars(calcDisplayBox.Text);
            calcDisplayBox.Select(calcDisplayBox.Text.Length, 0);
        }
    }
}
