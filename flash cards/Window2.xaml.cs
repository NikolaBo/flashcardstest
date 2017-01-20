/*
 * Created by SharpDevelop.
 * User: s-NBOJANIC
 * Date: 10/22/2016
 * Time: 18:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace flash_cards
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
		public string[] termsArray;
		public string[] definitionsArray;
		
		int rand = 0;
		
		bool term = true;
		
		Random randObj = new Random();
		
		public Window2()
		{
			InitializeComponent();
			//string j;
			//rand = randObj.Next(termsArray.Length);
			//display.Text = termsArray[0];
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			/*foreach (string a in termsArray){
				rand++;
			}
			display.Text = rand.ToString();*/
			if (termsArray == null){
				display.Text = "null";
			}
			else if (term){
				rand = randObj.Next(0,termsArray.Length);
				display.Text = termsArray[rand];
				term = false;
			}
			else{
				display.Text = definitionsArray[rand];
				term = true;
			}
			//throw new NotImplementedException();
		}
		public void setArrays(string[] termArr,string[] defArr){
			termsArray = new string[termArr.Length];
			definitionsArray = new string[defArr.Length];
			termsArray = termArr;
			definitionsArray = defArr;
		}
		void Menu_Click(object sender, RoutedEventArgs e)
		{
			Window1 currentWindow = new Window1();
    		App.Current.MainWindow = currentWindow;
   			this.Close();
    		currentWindow.Show();

		}
	}
}