using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ViewModel;

namespace AdventOfCode2020
{
    /// <summary>
    /// Interaction logic for Day01Control.xaml
    /// </summary>
    public partial class Day01Control : UserControl
    {
        public Day01Control()
        {
            InitializeComponent();
        }

        public void TestingAnimation()
        {
            Day01VM myVM = this.DataContext as Day01VM;
            var myRec01 = this.FindName("RecA01") as Rectangle;
            var myRec02 = this.FindName("RecA02") as Rectangle;

            foreach (var attempt in myVM.AttemptsA)
            {
                myRec01.Width = attempt.Item1 / 10;
                myRec02.Width = attempt.Item2 / 10;
                Thread.Sleep(10);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestingAnimation();
        }
    }
}
