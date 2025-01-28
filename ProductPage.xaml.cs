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

namespace Ганиев41
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            var currentProduct = Ганиев41Entities.GetContext().Product.ToList();
            ProductListView.ItemsSource = currentProduct;
            ComboType.SelectedIndex = 0;
            UpdateSerices();
        }

        private void UpdateSerices()
        {
            var currentProducts = Ганиев41Entities.GetContext().Product.ToList();

            TBAllRecords.Text = currentProducts.Count.ToString();

            if (ComboType.SelectedIndex == 0)
            {
                currentProducts = currentProducts.Where(p => (Convert.ToInt32(p.ProductDiscountAmount) >= 0 && Convert.ToInt32(p.ProductDiscountAmount) <= 100)).ToList();

            }
            if (ComboType.SelectedIndex == 1)
            {
                currentProducts = currentProducts.Where(p => (Convert.ToInt32(p.ProductDiscountAmount) >= 0 && Convert.ToInt32(p.ProductDiscountAmount) < 10)).ToList();

            }
            if (ComboType.SelectedIndex == 2)
            {
                currentProducts = currentProducts.Where(p => (Convert.ToInt32(p.ProductDiscountAmount) >= 10 && Convert.ToInt32(p.ProductDiscountAmount) < 15)).ToList();

            }
            if (ComboType.SelectedIndex == 3)
            {
                currentProducts = currentProducts.Where(p => (Convert.ToInt32(p.ProductDiscountAmount) >= 15 && Convert.ToInt32(p.ProductDiscountAmount) <= 100)).ToList();
            }

            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(TBoxSear4.Text.ToLower())).ToList();

            ProductListView.ItemsSource = currentProducts.ToList();

            if (RButtonDown.IsChecked.Value)
                ProductListView.ItemsSource = currentProducts.OrderByDescending(p => p.ProductCost).ToList();

            if(RButtonUp.IsChecked.Value)
                ProductListView.ItemsSource = currentProducts.OrderBy(p=>p.ProductCost).ToList();
            TBcount.Text = currentProducts.Count.ToString();

        }
        int CountRecords;
        int CountPage;
        int CurrentPage;

        List<Product> CurrentPageList = new List <Product>();
        List<Product> TableList;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void TBoxSear4_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSerices();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSerices();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSerices();
        }

        private void RButtonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSerices();
        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSerices();
        }
    }
}
