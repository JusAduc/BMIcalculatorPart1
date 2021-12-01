﻿using System;
using System.Collections.Generic;
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
using System.IO;

namespace BMIcalculatorPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public class Author
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public double User_Height { get; set; }
        public double User_Weight { get; set; }
    }

    public partial class MainWindow : Window
    {
        string firstName;
        string lastName;
        string phoneNumber;
        double height;
        double weight;


        public MainWindow()
        {
            InitializeComponent();
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //I dont need firstName, lastName and phone inputs for this right?
            //if (firstNameInput.Text == "" || lastNameInput.Text == "" || phoneInput.Text == "")
            if (heightInput.Text == ""|| weightInput.Text=="")
            {
                MessageBox.Show("This is a message box that appears if there was an error, please input information into each box.");
            }
            //Find out why this is giving an error. It will not work if it is added into the first if statement 
            else {
                firstName = firstNameInput.Text;
                lastName = lastNameInput.Text;
                phoneNumber = phoneInput.Text;
                height = Double.Parse(heightInput.Text);
                weight = Double.Parse(weightInput.Text);
                fileText();
                MessageBox.Show($"{firstName} {lastName} {phoneNumber} {height} {weight}");
            }
        }
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            firstNameInput.Text = "";
            lastNameInput.Text = "";
            phoneInput.Text = "";
            heightInput.Text = "";
            weightInput.Text = "";
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void fileText()
        {
            string userInfo = $"Your name is {firstName} {lastName}. Your phone number is {phoneNumber}. Your height is {height} and weight is {weight}.";
            File.WriteAllText("userInformation.txt", userInfo);
        }
    }
}
