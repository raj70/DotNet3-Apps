using Rs.App.Core30.ClientRequest.Wpf.ViewModel;
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

namespace Rs.App.Core30.ClientRequest.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for UcRequestAddEdit.xaml
    /// </summary>
    public partial class UcRequestAddEdit : UserControl
    {
        protected RequestViewModel _requestViewModel;
        public UcRequestAddEdit()
        {
            InitializeComponent();
           
        }

        public void SetDataContext(RequestViewModel vm)
        {
            _requestViewModel = vm;
            DataContext = vm;
        }
        

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            _requestViewModel.Add();
        }
    }
}
