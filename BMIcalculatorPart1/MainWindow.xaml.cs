using System;
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


    public class Info
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
        double heightCm;
        double weightKg;
        double BMI;

        //private List<Info> LoadCollectionData()
        //{
        //    List<Info> info = new List<Info>();
        //    info.Add(new Info()
        //    {
        //        First_Name = firstName,
        //        Last_Name = lastName,
        //        Phone_Number = phoneNumber,
        //        User_Height = height,
        //        User_Weight = weight
        //    });
        //    return info;
        //}

        //private List<Info> LoadCollectionDat()
        //{
        //    List<Info> info = new List<Info>();
        //    info.Add(new Info()
        //    {
        //        First_Name =firstName,
        //        Last_Name=lastName,
        //        Phone_Number=phoneNumber,
        //        User_Height=height,
        //        User_Weight=weight
        //    });
        //    return info;
        //}

        public class Customer
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string phoneNumber { get; set; }
            public int heightCm { get; set; }
            public int weightKg { get; set; }
            public int BMI { get; set; }

        }
       


        public MainWindow()
        {
            InitializeComponent();
        }
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (heightInput.Text == "" || weightInput.Text == "")
            {
                MessageBox.Show("This is a message box that appears if there was an error, please input information into each box.");
            }
            else
            {
                firstName = firstNameInput.Text;
                lastName = lastNameInput.Text;
                phoneNumber = phoneInput.Text;
                height = Double.Parse(heightInput.Text);
                weight = Double.Parse(weightInput.Text);
                fileText();
                //dataGrid.ItemsSource = LoadCollectionData();
                weightKg = weight / 2.205;
                heightCm = height * 2.54;
                BMI=weightKg/heightCm/heightCm*10000;
                userBMI.Text = $"{BMI}";
                string userMessage;
                if (BMI < 18.5)
                {
                    userMessage = "According to CDC.gov BMI Calculator you are underweight.";
                } else if (BMI <24.9 && BMI>18.5)
                {
                    userMessage = "According to CDC.gov BMI Calculator you have a normal body weight.";
                } else if (BMI <29.9 && BMI > 24.9)
                {
                    userMessage = "According to CDC.gov BMI Calculator you are overweight.";
                } else if (BMI >= 30)
                {
                    userMessage = "According to CDC.gov BMI Calculator you are obese.";
                } else
                {
                    userMessage = "Something broke...";
                }
                userMessageXAML.Text = $"{userMessage}";
            }
        }
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            firstNameInput.Text = "";
            lastNameInput.Text = "";
            phoneInput.Text = "";
            heightInput.Text = "";
            weightInput.Text = "";
            userBMI.Text = "";
            userMessageXAML.Text = "";
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

        private void importBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}