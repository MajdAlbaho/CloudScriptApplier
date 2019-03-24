using CloudScriptApplier.Db.ServerDb;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

namespace CloudScriptApplier.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            kernal.Load(Assembly.GetExecutingAssembly());
            var dbManager = kernal.Get<IServerDbManager>();

            var registeredDbs =
                dbManager.GetRegisteredDBS();

            DBView.ItemsSource = registeredDbs;
        }

        StandardKernel kernal = new StandardKernel();

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            var dbManager2 = kernal.Get<IServerDbManager>();

            DBView.ItemsSource = dbManager2.GetRegisteredDBS(SearchDB.Text);

        }
    }
}
