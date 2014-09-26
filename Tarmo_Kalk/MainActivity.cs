using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Tarmo_Kalk
{
	[Activity (Label = "Tarmo Kalkulaator", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string opr;
		double operand1, operand2, operand3, result;

		//declare button and other variables
		Button btn_1;
		Button btn_2;
		Button btn_3;
		Button btn_4;
		Button btn_5;
		Button btn_6;
		Button btn_7;
		Button btn_8;
		Button btn_9;
		Button btn_0;

		Button btn_sin;
		Button btn_cos;
		Button btn_tan;

		Button btn_plusMin;
		Button btn_decimal;
		Button btn_backS;
		Button btn_sqr;
		Button btn_xToPowY;
		Button btn_sqrt;
		Button btn_clear;
		Button btn_equals;
		Button btn_plus;
		Button btn_minus;
		Button btn_multiply;
		Button btn_divide;

		Button btn_pi;
		Button btn_hex;
		Button btn_dec;
		Button btn_bin;



		EditText textBox1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

		}

		protected override void OnPostCreate(Bundle bundle)
		{
			//after app load define new class for buttons
			base.OnPostCreate (bundle);

			//define future uses for button calculations
			bool plus = false;
			bool minus = false;
			bool multiply = false;
			bool divide = false;
			bool equal = false;

			//define editbox and buttons from layout, find by id
			textBox1 = FindViewById<EditText> (Resource.Id.editText1);

			btn_1 = FindViewById<Button> (Resource.Id.button_1);
			btn_2 = FindViewById<Button> (Resource.Id.button_2);
			btn_3 = FindViewById<Button> (Resource.Id.button_3);
			btn_4 = FindViewById<Button> (Resource.Id.button_4);
			btn_5 = FindViewById<Button> (Resource.Id.button_5);
			btn_6 = FindViewById<Button> (Resource.Id.button_6);
			btn_7 = FindViewById<Button> (Resource.Id.button_7);
			btn_8 = FindViewById<Button> (Resource.Id.button_8);
			btn_9 = FindViewById<Button> (Resource.Id.button_9);
			btn_0 = FindViewById<Button> (Resource.Id.button_0);

			btn_sin = FindViewById<Button> (Resource.Id.button_sin);
			btn_cos = FindViewById<Button> (Resource.Id.button_cos);
			btn_tan = FindViewById<Button> (Resource.Id.button_tan);

			btn_plusMin = FindViewById<Button> (Resource.Id.button_posNeg);
			btn_decimal = FindViewById<Button> (Resource.Id.button_decimal);
			btn_backS = FindViewById<Button> (Resource.Id.button_backspace);
			btn_sqr = FindViewById<Button> (Resource.Id.button_sqared);
			btn_xToPowY = FindViewById<Button> (Resource.Id.button_xToPowY);
			btn_sqrt = FindViewById<Button> (Resource.Id.button_sqrt);
			btn_clear = FindViewById<Button> (Resource.Id.button_clear);
			btn_equals = FindViewById<Button> (Resource.Id.button_equals);
			btn_plus = FindViewById<Button> (Resource.Id.button_plus);
			btn_minus = FindViewById<Button> (Resource.Id.button__min);
			btn_multiply = FindViewById<Button> (Resource.Id.button_multiply);
			btn_hex = FindViewById<Button> (Resource.Id.button_div);

			btn_hex = FindViewById<Button> (Resource.Id.radioButton1_hex);
			btn_dec = FindViewById<Button> (Resource.Id.radioButton2_dec);
			btn_bin = FindViewById<Button> (Resource.Id.radioButton3_bin);
			btn_pi = FindViewById<Button> (Resource.Id.button_pi);

			btn_1.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "1";};
			btn_2.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "2";};
			btn_3.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "3";};
			btn_4.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "4";};
			btn_5.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "5";};
			btn_6.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "6";};
			btn_7.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "7";};
			btn_8.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "8";};
			btn_9.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "9";};
			btn_0.Click += delegate { if (equal) { textBox1.Text = ""; equal = false; } textBox1.Text += "0";};


			//decimal code
			btn_decimal.Click += delegate 
			{
				if (textBox1.Text.Contains("."))
				{
					textBox1.Text = textBox1.Text;
				}
				else
				{
					textBox1.Text = textBox1.Text + "0.";
				}
			};

			//plus button code
			btn_plus.Click += delegate 
			{
				if (textBox1.Text.Contains("-")) //check if "-" sign is present of not
				{
					textBox1.Text = textBox1.Text.Remove(0,1);
				}
				else
				{
					textBox1.Text = "-" + textBox1.Text;
				}
				operand1 = Convert.ToDouble(textBox1.Text);
				opr = "+";
				textBox1.Text = "";
			};

			btn_multiply.Click += delegate 
			{
				operand1 = Convert.ToDouble(textBox1.Text);
				opr = "*";
				textBox1.Text = "";
			};

			btn_divide.Click += delegate 
			{
				operand1 = Convert.ToDouble(textBox1.Text);
				opr = "/";
				textBox1.Text = "";
			};

			btn_equals.Click += delegate {
				operand2 = Convert.ToDouble(textBox1.Text);
				switch(opr)
				{
				case "+":
					result = operand1 + operand2;
					textBox1.Text = Convert.ToString(result);
					break;
				case "-":
					result = operand1 - operand2;
					textBox1.Text = Convert.ToString(result);
					break;
				case "*":
					result = operand1 * operand2;
					textBox1.Text = Convert.ToString(result);
					break;
				case "/":
					if (operand2 == 0)
					{
						textBox1.Text = "0.0";
						break;
					}
					else 
					{
						result = operand1 / operand2;
						textBox1.Text = Convert.ToString(result);
						break;
					}
				case "x^2":
					operand1 = Convert.ToDouble(textBox1.Text);
					result = operand1 * operand1;
					textBox1.Text = Convert.ToString(result);
					break;
				case "x^y":
					result = System.Math.Pow(Convert.ToDouble(operand1),Convert.ToDouble(operand2));
					textBox1.Text = Convert.ToString(result);
					break;
				case "√":
					textBox1.Text = Convert.ToString(System.Math.Sqrt(Convert.ToDouble(textBox1.Text)));
					break;

				}
			};

			btn_sin.Click += delegate {

				if (textBox1.Text == "")
				{
					textBox1.Text = "0";
				}
				else
				{
					textBox1.Text = Convert.ToString(System.Math.Sin((Convert.ToDouble(System.Math.PI) / 100) * (Convert.ToDouble(textBox1.Text))));
				}
			};

			/**			btn_minus.Click += delegate 
			{
				if (textBox1.Text == "") 
				{ 
					return; 
				} else 	{ 
					minus = true; 
					textBox1.Tag = textBox1.Text; 
					textBox1.Text = "";
				}
			};

			btn_multiply.Click += delegate 
			{
				if (textBox1.Text == "") 
				{ 
					return; 
				} else 	{ 
					multiply = true; 
					textBox1.Tag = textBox1.Text; 
					textBox1.Text = "";
				}
			};

			btn_divide.Click += delegate 
			{
				if (textBox1.Text == "") 
				{ 
					return; 
				} else 	{ 
					divide = true; 
					textBox1.Tag = textBox1.Text; 
					textBox1.Text = "";
				}
			};

			btn_equals.Click += delegate {

				if (plus)
					try
					{
						double a = double.Parse(textBox1.Text);
						double b = double.Parse(textBox1.Text);
						double c = a + b;
						textBox1.Text = c.ToString();
					}
					catch (Exception ex)
					{
						//textBox1.Text = "Error";
					}


				else if (minus)
				{
					double dec = Convert.ToDouble(textBox1.Tag) - Convert.ToDouble(textBox1.Text);
					textBox1.Text = dec.ToString();
				}

				else if (multiply)
				{
					double dec = Convert.ToDouble(textBox1.Tag) * Convert.ToDouble(textBox1.Text);
					textBox1.Text = dec.ToString();
				}

				else if (divide)
				{
					if (textBox1.Text == "0") //check if second number is 0
					{
						textBox1.Text = "Infinity";
					}
					else
					{
						double dec = Convert.ToDouble(textBox1.Tag) / Convert.ToDouble(textBox1.Text);
						textBox1.Text = dec.ToString();
					}
				}
			};
			**/
			btn_clear.Click += delegate 
			{
				plus = minus = plus = divide = equal = false; //clear display
				textBox1.Text = "0"; //clear memory

			};



		}


	}
}


