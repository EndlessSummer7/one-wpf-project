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

namespace CocomoProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isDigit = true;
        public MainWindow()
        {

            InitializeComponent();

        }

        private void GetInfoBtn_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCodeSize.Text))
            {
                MessageBox.Show("Вы не ввели кол-во строк кода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int type = comboBoxProjectType.SelectedIndex; // определяем тип проекта
            int codeSize = int.Parse(txtCodeSize.Text); // строк кода

            EffortSize.Text = string.Format("{0} {1}", Calculation.GetEfforts(codeSize, type).ToString("F2"), "люд/міс.");

            Time.Text = string.Format("{0} {1}", Calculation.GetTimeToDevelop(codeSize, type).ToString("F2"), "міс.");

            DevNumber.Text = string.Format("{0} {1}", Calculation.GetPersonsToDevelop(codeSize, type).ToString(), "люд.");
        }

        private void txtCodeSize_KeyDown_1(object sender, KeyEventArgs e)
        {
            isDigit = ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key != Key.Back));
            e.Handled = isDigit;
        }


        //int result = comboBoxProjectType.SelectedIndex;

        //EffortSize.Text = result.ToString();
    }
}

