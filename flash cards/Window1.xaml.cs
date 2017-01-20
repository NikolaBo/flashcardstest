/*
 * Created by SharpDevelop.
 * User: s-NBOJANIC
 * Date: 10/17/2016
 * Time: 9:24 PM
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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		void NewSet(object sender, RoutedEventArgs e)
		{
			//throw new NotImplementedException();
			CreationWindow creation = new CreationWindow();
    		App.Current.MainWindow = creation;
   			this.Close();
    		creation.Show();
		}
		
		void ImportSet(object sender, RoutedEventArgs e)
		{
			openSet current = new openSet();
    		App.Current.MainWindow = current;
   			this.Close();
    		current.Show();
			//throw new NotImplementedException();
		}
	}
}