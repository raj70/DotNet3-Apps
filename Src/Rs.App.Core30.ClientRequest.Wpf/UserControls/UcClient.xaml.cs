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
    /// Interaction logic for UcClient.xaml
    /// </summary>
    public partial class UcClient : UserControl
    {
        private EditType _editType;
        private ClientViewModel _client;

        public Action<Guid> Delete;

        public UcClient()
        {
            InitializeComponent();
        }

        public UcClient(ClientViewModel client, EditType editType) : this()
        {
            _editType = editType;
            _client = client;
            DataContext = _client;

            if(_editType == EditType.Delete)
            {
                ButtonOk.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonOk.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ViewModel.ClientViewModel;
            var clientId = vm.Client.ClientId;

            Delete?.Invoke(clientId);
        }
    }
}
