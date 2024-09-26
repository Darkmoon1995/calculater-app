using System;
using System.Data; // For simple expression evaluation
using System.Windows;
using System.Windows.Controls;

namespace calculater_app
{
    public partial class MainWindow : Window
    {
        
        private bool isRadians = true; // Flag to switch between radians and degrees

        public MainWindow()
        {
            InitializeComponent();
        }

        // Handler for digit button clicks
        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Display.Text += button.Content.ToString();
            }
        }

        // Handler for addition
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "+";
        }

        // Handler for subtraction
        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "-";
        }

        // Handler for multiplication
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "×";
        }

        // Handler for division
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "÷";
        }

        // Handler for decimal point
        private void Decimal_click(object sender, RoutedEventArgs e)
        {
            Display.Text += ".";
        }

        // Handler for equals (this will require actual calculation logic)
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Replace custom symbols and evaluate
                var expression = Display.Text.Replace("×", "*").Replace("÷", "/").Replace("π", Math.PI.ToString()).Replace("e", Math.E.ToString());

                // Handle EXP notation for scientific calculations
                expression = expression.Replace("EXP", "E");

                var result = new DataTable().Compute(expression, null);

                Display.Text = result.ToString() ;
                
                StoreResult(result.ToString()); // Store the result for Ans button
                
            }
            catch (Exception)
            {
                Display.Text = "Error";
            }
        }

        // Handler for backspace
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
        }

        // Handler for clear all (AC)
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
        }

        // Handler for plus/minus toggle
        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Display.Text) && !Display.Text.StartsWith("-"))
            {
                Display.Text = "-" + Display.Text;
            }
            else if (Display.Text.StartsWith("-"))
            {
                Display.Text = Display.Text.Substring(1);
            }
        }

        // Handler for modulus operation
        private void Modulus_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "%"; // This can now act as a modulus operator
        }

        // Handler for percentage
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Display.Text = (double.Parse(Display.Text) / 100).ToString();
            }
            catch
            {
                Display.Text = "Error";
            }
        }

        // Handler for sine function
        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(Display.Text);
            if (!isRadians) value = value * Math.PI / 180; 
            Display.Text = Math.Sin(value).ToString();
        }

        // Handler for cosine function
        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(Display.Text);
            if (!isRadians) value = value * Math.PI / 180; 
            Display.Text = Math.Cos(value).ToString();
        }

        // Handler for tangent function
        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            double value = double.Parse(Display.Text);
            if (!isRadians) value = value * Math.PI / 180; 
            Display.Text = Math.Tan(value).ToString();
        }

        // Handler for arcsine function
        private void Asin_Click(object sender, RoutedEventArgs e)
        {
            double result = Math.Asin(double.Parse(Display.Text));
            if (!isRadians) result = result * 180 / Math.PI;
            Display.Text = result.ToString();
        }

        // Handler for arccosine function
        private void Acos_Click(object sender, RoutedEventArgs e)
        {
            double result = Math.Acos(double.Parse(Display.Text));
            if (!isRadians) result = result * 180 / Math.PI; 
            Display.Text = result.ToString();
        }

        // Handler for arctangent function
        private void Atan_Click(object sender, RoutedEventArgs e)
        {
            double result = Math.Atan(double.Parse(Display.Text));
            if (!isRadians) result = result * 180 / Math.PI; 
            Display.Text = result.ToString();
        }

        // Toggle between Radians and Degrees
        private void RadiansDegrees_Click(object sender, RoutedEventArgs e)
        {
            isRadians = !isRadians;
            ToggleButton.Content = isRadians ? "Rad" : "Deg";
        }

        // Handler for Pi constant
        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += Math.PI.ToString();
        }

        // Handler for Euler's number constant
        private void E_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += Math.E.ToString();
        }

        // Handler for power (x^y)
        private void Power_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "^";
        }

        // Handler for x^3
        private void Cube_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Pow(double.Parse(Display.Text), 3).ToString();
        }

        // Handler for x^2
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Pow(double.Parse(Display.Text), 2).ToString();
        }

        // Handler for e^x
        private void Exponential_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Exp(double.Parse(Display.Text)).ToString();
        }

        // Handler for 10^x
        private void PowerOf10_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Pow(10, double.Parse(Display.Text)).ToString();
        }

        // Handler for nth root (y√x)
        private void YRootX_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "√";
        }

        // Handler for cube root
        private void CubeRoot_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Pow(double.Parse(Display.Text), 1.0 / 3).ToString();
        }

        // Handler for square root
        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Sqrt(double.Parse(Display.Text)).ToString();
        }

        // Handler for natural log (ln)
        private void Ln_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Log(double.Parse(Display.Text)).ToString();
        }

        // Handler for logarithm (base 10)
        private void Log_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Math.Log10(double.Parse(Display.Text)).ToString();
        }

        // Handler for inverse (1/x)
        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = (1 / double.Parse(Display.Text)).ToString();
        }

        // Handler for factorial (n!)
        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(Display.Text);
            Display.Text = Factorial(n).ToString();
        }

        // Recursive factorial function
        private int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        // Handler for random number generation (RND)
        private void Rnd_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            Display.Text = rand.NextDouble().ToString();
        }

        // Memory Operations (add, recall, subtract)
        private double memory = 0;

        private void MemoryAdd_Click(object sender, RoutedEventArgs e)
        {
            memory += double.Parse(Display.Text);
        }

        private void MemoryRecall_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = memory.ToString();
        }

        private void MemorySubtract_Click(object sender, RoutedEventArgs e)
        {
            memory -= double.Parse(Display.Text);
        }

        // Handler for Ans button (just recalls last result for simplicity)
        private string lastResult = "0";

        private void Ans_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += lastResult;
        }

        // Store the result when equals is clicked
        private void StoreResult(string result)
        {
            lastResult = result;
        }

        // Handler for EXP (Exponential) button
        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "EXP";
        }

        // Handler for right parenthesis button
        private void RightParenthesis_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += ")";
        }

        // Handler for left parenthesis button
        private void LeftParenthesis_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "(";
        }

        

        // New handler for scientific notation (E notation)
        private void ExpNotation_Click(object sender, RoutedEventArgs e)
        {
            Display.Text += "E";
        }

        // New handler for switching between radians and degrees
        private void ToggleRadiansDegrees_Click(object sender, RoutedEventArgs e)
        {
            isRadians = !isRadians;
            ToggleButton.Content = isRadians ? "Rad" : "Deg";
        }
    }
}
