/*
 * Created by SharpDevelop.
 * User: s-NBOJANIC
 * Date: 10/20/2016
 * Time: 10:14
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
using System.IO;

namespace flash_cards
{
	/// <summary>
	/// Interaction logic for openSet.xaml
	/// </summary>
	public partial class openSet : Window
	{
		string fileTerms;
		string fileDefinitions;
		Stack<string> termsStack = new Stack<string>();
		Stack<string> definitionsStack = new Stack<string>();
		//string[] terms;
		//string[] definitions;
		int num = 0;
		
		public openSet()
		{
			InitializeComponent();
		}
		void openButton_Click(object sender, RoutedEventArgs e)
		{
			string pathInput = pathBox.Text;
			System.IO.StreamReader file = new System.IO.StreamReader(pathInput);
			File.SetAttributes(pathInput,FileAttributes.Normal);

			fileTerms = file.ReadLine();
			fileDefinitions = file.ReadLine();

			file.Close();
			
			char[] termsArr = fileTerms.ToCharArray();
			char[] definitionsArr = fileDefinitions.ToCharArray();
			string currentWord = "";
			
			foreach (char val in termsArr){
				if (val == ','){
					termsStack.Push(currentWord);
					currentWord = "";
					num++;
				}
				else{
					currentWord = currentWord + val.ToString();
				}
			}
			termsStack.Push(currentWord);
			currentWord = "";
			num++;
			foreach (char val in definitionsArr){
				if (val == ','){
					definitionsStack.Push(currentWord);
					currentWord = "";
				}
				else{
					currentWord = currentWord + val.ToString();
				}
			}
			definitionsStack.Push(currentWord);
			currentWord = "";
			
			//pathBox.Text = termsStack.Pop();
			
			string[] terms = new string[num];
			string[] definitions = new string[num];
		
			termsStack.CopyTo(terms,0);
			definitionsStack.CopyTo(definitions,0);
			
			Window2 current = new Window2();
			current.setArrays(terms,definitions);
    		App.Current.MainWindow = current;
    		
    		//current.setArrays(terms,definitions);
    		
   			this.Close();
   			current.Show();
			//C:\\Users\\s-nbojanic\Documents\\ab.cardset
		}
	}
}