using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rs.App.Core30.ClientRequest.Wpf.ViewModel;

namespace Rs.App.Core30.ClientRequest.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for UcRequests.xaml
    /// </summary>
    public partial class UcRequests : UserControl
    {
        protected RequestsViewModel vm;
        public UcRequests()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        internal void SetDataContext(RequestsViewModel vm)
        {
            DataContext = vm;
            this.vm = vm;
        }
    }
}
