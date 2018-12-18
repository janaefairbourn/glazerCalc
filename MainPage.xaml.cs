using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace glazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        // list of variables we will need to work with
        private double width;
        private double height;
        private double woodLength;
        private double glassArea;
        private string tint;
        private double quantityOfItems;

        private void cb_tintColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_tintColor == null) return;

            cb_tintColor.Items.Add("No Tint");
            cb_tintColor.Items.Add("Black");
            cb_tintColor.Items.Add("Brown");
            cb_tintColor.Items.Add("Blue");


            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            cb_tintColor.PlaceholderText = item.Content.ToString();
        }

        // All of the events that will happen when user calculates the window
        private void bt_calculate_Click(object sender, RoutedEventArgs e)
        { 
            // take elements from text boxes, convert ToString()
            width = double.Parse(tb_enterWidth.Text.ToString());
            height = double.Parse(tb_enterHeight.Text.ToString());
            tint = ((ComboBoxItem)cb_tintColor.SelectedItem).Content.ToString();
            //quantityOfItems = int.Parse(sl_quantity.IsTextScaleFactorEnabled.ToString());
            quantityOfItems = double.Parse(sl_quantity.Value.ToString());
            
            // calculate wood length and area of glass needed
            woodLength = quantityOfItems * (2 * (width + height) * 3.25);
            glassArea = quantityOfItems * (2 * (width * height));


            // display date and results to user in text blocks
            DateTime todaysDate = DateTime.Now;
            tb_DateOfQuote.Text = todaysDate.ToString("dd MMM yyyy");
            tb_usersWidth.Text = width.ToString();
            tb_usersHeight.Text = height.ToString();
            tb_usersTint.Text = tint;
            tb_usersQuantity.Text = quantityOfItems.ToString();
            tb_usersWoodLength.Text = woodLength.ToString() + " feet";
            tb_usersGlassArea.Text = glassArea.ToString() + " square meters";
        }

        // if users don't enter a number or enter an invalid number, throw an error message
        private void tb_enterWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(tb_enterWidth.Text.ToString(), out double i))
            {
                errorMessage.Text = "You must enter a number";
            }
            else
            {
                width = double.Parse(tb_enterWidth.Text.ToString());
                if (width > 0.5 && width < 5)
                {
                    errorMessage.Text = String.Empty;
                }
                else
                {
                    errorMessage.Text = "You must enter a number between 0.5 and 5";
                }
            }
        }

        // if users don't enter a number or enter an invalid number, throw an error message
        private void tb_enterHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(tb_enterHeight.Text.ToString(), out double i))
            {
                errorMessage.Text = "You must enter a number";
            }
            else
            {
                height = double.Parse(tb_enterHeight.Text.ToString());
                if (height > 0.75 && height < 3)
                {
                    errorMessage.Text = String.Empty;
                }
                else
                {
                    errorMessage.Text = "You must enter a number between 0.75 and 3";
                }
            }
        }

    }
}
