using System;
using System.Collections.Generic;
using System.Data;
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

namespace ChronosEditor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var connString = "Host=localhost;Username=postgres;Password=heslo0123;Database=postgres;";
            var db = new ChronosLibrary("Npgsql", connString);
            var table = new DataTable();
            try {
                var id = db.InsertDoc("user", "Frodo");
                db.AddSetAttribute(id, "jedna", "1", false, "user", "Frodo");
                db.AddSetAttribute(id, "dva", "2", false, "user", "Frodo");
                db.AddSetAttribute(id, "dva", "2", false, "user", "Frodo");
                db.AddSetAttribute(id, "ctyri", "4", false, "user", "Frodo");
                db.ExecuteTransaction();
                db.ClearTransaction();
                table = db.ScanDocs(id, DateTime.Now);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
