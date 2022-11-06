using System;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WidgetBoard.Widgets
{
	public sealed partial class CalcWidget : UserControl
	{
		private double operand1 = 0.0, operand2 = 0.0;
		private bool dot_status = false, op_status = false;
		private char optype = '\u0000';
		public CalcWidget()
		{
			this.InitializeComponent();
			Result.Text = "0";
		}

		private void Percent_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			Result.Text = (Convert.ToDouble(Result.Text) / 100).ToString();
			op_status = true;
		}

		private void CE_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			Result.Text = "0";
			dot_status = false;
		}

		private void C_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			Result.Text = "0";
			OngoingOperation.Text = "";
			dot_status = false;
			operand1 = 0.0;
			operand2 = 0.0;
		}

		private void Backspace_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text != "0")
				Result.Text = (Result.Text.Substring(0, Result.Text.Length - 1));
			if (Result.Text.Length == 0)
				Result.Text = "0";
		}

		private void OneByX_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			operand1 = 1.0;
			operand2 = Convert.ToDouble(Result.Text);
			Result.Text = (operand1 / operand2).ToString();
			OngoingOperation.Text = "1 / " + operand2;
			operand1 = 0;
			operand2 = 0;
			op_status = true;
		}

		private void X2_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			operand1 = Convert.ToDouble(Result.Text);
			Result.Text = (operand1 * operand1).ToString();
			OngoingOperation.Text = operand1 + "²";
			operand1 = 0;
			operand2 = 0;
			op_status = true;
		}

		private void RootX_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			operand1 = Convert.ToDouble(Result.Text);
			Result.Text = (Math.Sqrt(operand1)).ToString();
			OngoingOperation.Text = "√(" + operand1 + ")";
			operand1 = 0;
			operand2 = 0;
			op_status = true;
		}

		private void Div_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text != "")
			{
				optype = 'd';
				Operation(optype);
			}
		}

		private void Seven_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "7";
			}
			else
				Result.Text += "7";
		}

		private void Eight_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "8";
			}
			else
				Result.Text += "8";
		}

		private void Nine_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "9";
			}
			else
				Result.Text += "9";
		}

		private void Prod_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text != "")
			{
				optype = 'm';
				Operation(optype);
			}
		}

		private void Four_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text += "4";
			}
			else
				Result.Text += "4";
		}

		private void Five_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "5";
			}
			else
				Result.Text += "5";
		}

		private void Six_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "6";
			}
			else
				Result.Text += "6";
		}

		private void Sub_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text != "")
			{
				optype = 's';
				Operation(optype);
			}
		}

		private void Three_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "3";
			}
			else
				Result.Text += "3";
		}

		private void Two_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "2";
			}
			else
				Result.Text += "2";
		}

		private void One_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false; Result.Text = "1";
			}
			else
				Result.Text += "1";
		}

		private void Zero_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (Result.Text == "0" || op_status)
			{
				op_status = false;
				Result.Text = "0";
			}
			else
				Result.Text += "0";
		}

		private void Dot_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (!dot_status)
			{
				Result.Text += ".";
				dot_status = false;
			}
		}

		private void Equal_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			if (OngoingOperation.Text != "" && Result.Text!="")
			{
				switch (optype)
				{
					case 'd':
						operand2 = Convert.ToDouble(Result.Text);
						Result.Text = (operand1 / operand2).ToString();
						OngoingOperation.Text = "";
						break;
					case 'm':
						operand2 = Convert.ToDouble(Result.Text);
						Result.Text = (operand1 * operand2).ToString();
						OngoingOperation.Text = "";
						break;
					case 's':
						operand2 = Convert.ToDouble(Result.Text);
						Result.Text = (operand1 - operand2).ToString();
						OngoingOperation.Text = "";
						break;
					case 'a':
						operand2 = Convert.ToDouble(Result.Text);
						Result.Text = (operand1 + operand2).ToString();
						OngoingOperation.Text = "";
						break;
				}
			}
		}

		private void Operation(char x)
		{
			switch (x)
			{
				case 'd':
					operand1 = Convert.ToDouble(Result.Text);
					OngoingOperation.Text = Result.Text + " / ";
					Result.Text = "0";
					break;
				case 'm':
					operand1 = Convert.ToDouble(Result.Text);
					OngoingOperation.Text = Result.Text + " * ";
					Result.Text = "0";
					break;
				case 's':
					operand1 = Convert.ToDouble(Result.Text);
					OngoingOperation.Text = Result.Text + " - ";
					Result.Text = "0";
					break;
				case 'a':
					operand1 = Convert.ToDouble(Result.Text);
					OngoingOperation.Text = Result.Text + " + ";
					Result.Text = "0";
					break;
			}
		}
	}
}
