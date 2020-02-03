using S_1.Classes;
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

namespace S_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        private List<Item> _items;
        private List<string> _locations;
        private List<string> _types;

        public DataPage()
        {
            InitializeComponent();

            _items = AppVariables.Db.Item.ToList();
            _locations = AppVariables.Db.Location.Select(x => x.Name).ToList();
            _types = AppVariables.Db.Type.Select(x => x.Name).ToList();

            _locations.Insert(0, "All");
            _types.Insert(0, "All");

            LocationCmb.ItemsSource = _locations;
            TypeCmb.ItemsSource = _types;

            LocationCmb.SelectedIndex = 0;
            TypeCmb.SelectedIndex = 0;

            DataGrid.ItemsSource = _items;
        }

        private void TypeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LocationCmb.SelectedIndex == 0 && TypeCmb.SelectedIndex == 0)
            {
                DataGrid.ItemsSource = _items;
            }
            else if (LocationCmb.SelectedIndex == 0 && TypeCmb.SelectedIndex != 0)
                DataGrid.ItemsSource = _items.Where(x => x.TypeId == TypeCmb.SelectedIndex);
            else if (LocationCmb.SelectedIndex != 0 && TypeCmb.SelectedIndex == 0)
                DataGrid.ItemsSource = _items.Where(x => x.LocationId == LocationCmb.SelectedIndex);
            else
                DataGrid.ItemsSource = _items.Where(x => x.LocationId == LocationCmb.SelectedIndex && x.TypeId == TypeCmb.SelectedIndex) ;
        }
    }
}
