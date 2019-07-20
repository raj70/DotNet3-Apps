using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.JsonRepositories;
using Rs.App.Core30.ClientRequest.Management.Repositories;
using Rs.App.Core30.ClientRequest.Wpf.UserControls;
using Rs.App.Core30.ClientRequest.Wpf.ViewModel;
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

namespace Rs.App.Core30.ClientRequest.Wpf
{

    public enum EditType { None, Add, Delete, Edit }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository<Client> _clientRepo;
        private IJsonDataFile<Client> _clientDataFile;
        private Client _selectedClient;
        private EditType _editType = EditType.Add;

        public MainWindow()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            _clientDataFile = new JsonDataClient(_clientRepo.GetAll() as Clients);
            _clientDataFile.Initialise();

            //yaak // not used MVVM for now
            this.ClientListBox.ItemsSource = _clientRepo.GetAll();
            DisableEnable();
        }

        private void ClientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _selectedClient = e.AddedItems[0] as Client;

                _editType = EditType.None;
                ShowClientInfor(_selectedClient);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var newClient = new Client();
            _editType = EditType.Add;
            ShowEditClientInfor(newClient);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedClient == null)
            {
                return;
            }
            _editType = EditType.Edit;
            ShowEditClientInfor(_selectedClient);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedClient == null)
            {
                return;
            }
            _editType = EditType.Delete;
            ShowClientInfor(_selectedClient);
           
        }

        private void ShowClientInfor(Client newClient)
        {
            var clientViewModel = new ClientViewModel(newClient);
            var uc = new UcClient(clientViewModel, _editType);
            uc.Delete = Delete;
            var mainStack = MainStackPanel;
            mainStack.Children.Clear();

            mainStack.Children.Add(uc);
            DisableEnable();
        }

        private void ShowEditClientInfor(Client newClient)
        {
            var clientViewModel = new ClientViewModel(newClient);
            var uc = new UcClientAddEdit(clientViewModel);
            uc.AddEdit = AddEdit;
            var mainStack = MainStackPanel;
            mainStack.Children.Clear();

            mainStack.Children.Add(uc);
            DisableEnable();
        }

        private void AddEdit(Client client)
        {
            if (_editType == EditType.Add)
            {
                _clientRepo.Add(client);
            }
            if (_editType == EditType.Edit)
            {
                _clientRepo.Update(client.ClientId, client);
            }
            Refresh();
        }

        private void Delete(Guid id)
        {
            _clientRepo.Delete(id);
            _selectedClient = null;
            Refresh();
        }


        private void DisableEnable()
        {
            if (_selectedClient == null)
            {
                ButtonDelete.Visibility = Visibility.Hidden;
                ButtonEdit.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonDelete.Visibility = Visibility.Visible;
                ButtonEdit.Visibility = Visibility.Visible;
            }
        }

        private void Refresh()
        {
            this.ClientListBox.Items.Refresh();
            DisableEnable();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _clientDataFile.Save();
        }
    }

}
