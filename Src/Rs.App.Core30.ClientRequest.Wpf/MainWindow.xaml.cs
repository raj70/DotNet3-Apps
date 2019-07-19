using Rs.App.Core30.ClientRequest.Management.Domain;
using Rs.App.Core30.ClientRequest.Management.JsonRepositories;
using Rs.App.Core30.ClientRequest.Management.Repositories;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository<Client> _clientRepo;
        private IJsonDataFile<Client> _clientDataFile;

        public MainWindow()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository();
            _clientDataFile = new JsonDataClient(_clientRepo.GetAll() as Clients);
            _clientDataFile.Initialise();

            //yaak // not used MVVM for now
            this.ClientListBox.ItemsSource = _clientRepo.GetAll();
        }


    }
}
