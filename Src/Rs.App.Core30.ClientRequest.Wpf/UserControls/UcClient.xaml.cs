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
        private Guid _currentClientId;

        public Action<Guid> ShowRequests;
        public Action<Guid> AddRequest;

        public UcClient()
        {
            InitializeComponent();
        }

        public UcClient(ClientViewModel client, EditType editType) : this()
        {
            _editType = editType;
            _client = client;
            DataContext = _client;
            _currentClientId = client.Client.ClientId;
        }

        private void ButtonShowRequests_Click(object sender, RoutedEventArgs e)
        {
            if (_currentClientId == Guid.Empty)
            {
                //TODO: do something
                return;
            }
            ShowRequests?.Invoke(_currentClientId);
        }

        private void ButtonAddRequest_Click(object sender, RoutedEventArgs e)
        {
            if (_currentClientId == Guid.Empty)
            {
                //TODO: do something
                return;
            }
            AddRequest?.Invoke(_currentClientId);
        }
    }
}
