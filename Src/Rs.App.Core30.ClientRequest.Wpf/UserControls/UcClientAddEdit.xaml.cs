using Rs.App.Core30.ClientRequest.Management.Domain;
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
    /// Interaction logic for UcClientAddEdit.xaml
    /// </summary>
    public partial class UcClientAddEdit : UserControl
    {
        public Action<Client> AddEdit;

        public UcClientAddEdit()
        {
            InitializeComponent();
        }

        public UcClientAddEdit(ClientViewModel client) : this()
        {
            DataContext = client;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ClientViewModel;
            var client = vm.Client;

            if (vm.IsValidate())
            {
                AddEdit?.Invoke(client);
            }
        }
    }
}
