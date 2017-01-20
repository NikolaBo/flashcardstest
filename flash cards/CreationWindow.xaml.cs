/*
 * Created by SharpDevelop.
 * User: s-NBOJANIC
 * Date: 10/17/2016
 * Time: 21:37
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
	/// Interaction logic for CreationWindow.xaml
	/// </summary>
	public partial class CreationWindow : Window
	{
		Stack<string> terms = new Stack<string>(100);
		Stack<string> definitions = new Stack<string>(100);
		
		string path = "C:\\Users\\s-nbojanic\\Documents\\test.cardset";
		
		//CreationWindow current = this;
		
		public CreationWindow()
		{
			InitializeComponent();
		}
		void addButton_Click(object sender, RoutedEventArgs e)
		{
			terms.Push(termBox.Text);
			definitions.Push(definitionBox.Text);
			definitionBox.Text = "";
			termBox.Text = "";
			//throw new NotImplementedException();
		}
		void saveButton_Click(object sender, RoutedEventArgs e)
		{
			path = pathBox.Text;
			string termsToSave;
			string definitionsToSave;
			termsToSave = terms.Pop();
			definitionsToSave = definitions.Pop();
			foreach(string current in terms){
				termsToSave = termsToSave + "," + current;
			}
			foreach(string current in definitions){	
				definitionsToSave = definitionsToSave + "," + current;
			}
			// Compose a string that consists of three lines.
			//string lines = "First line.\r\nSecond line.\r\nThird line.";
			// Write the string to a file.
			System.IO.StreamWriter file = new System.IO.StreamWriter(path);	
			File.SetAttributes(path,FileAttributes.Normal);

			file.WriteLine(termsToSave);
			file.WriteLine(definitionsToSave);

			file.Close();
			
			Window1 currentWindow = new Window1();
    		App.Current.MainWindow = currentWindow;
   			this.Close();
    		currentWindow.Show();

			//WriteToBinaryFile(path,textToSave,false);
		}
		//public static void WriteToBinaryFile<String>(string filePath, string objectToWrite, bool append = false)
		//{
    	//	using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
    	//	{
        //		var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //		binaryFormatter.Serialize(stream, objectToWrite);
    	//	}
		//}

	}
}