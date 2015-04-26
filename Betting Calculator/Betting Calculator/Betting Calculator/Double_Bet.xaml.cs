using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Betting_Calculator
{
    public partial class Double_Bet : PhoneApplicationPage
    {
        public double eachWayValue1 = 0.25;
        public double eachWayValue2 = 0.20;
        public string bet1Value, bet2Value, winValue1, placeVlaue1, placeValue2, placeValue, ewValue1;
        public string newOdds1, newOdds2, newbet1, newbet2;

        public Double_Bet()
        {
            InitializeComponent();
        }



        private void WinDouble1_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {
                bet1Value = ((Decimal.Parse(txtBox1Double1.Text) / Decimal.Parse(txtBox2Double1.Text))).ToString();
                bet2Value = ((Decimal.Parse(txtBox1Double1_Copy.Text) / Decimal.Parse(txtBox2Double1_Copy.Text))).ToString();

                winValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(bet1Value) + 1)
                * (Convert.ToDouble(bet2Value) + 1));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);
            }

            try
            {

                if (Quarter_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Quarter_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1Double1.Text) / (Convert.ToDouble(newOdds1)));
                newbet2 = Convert.ToString(Convert.ToDouble(txtBox1Double1_Copy.Text) / (Convert.ToDouble(newOdds2)));

                ewValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(newbet1) + 1)
                * (Convert.ToDouble(newbet2) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (WinDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == false)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(winValue1));
            }
            else if (WinDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(winValue1) + Convert.ToDouble(ewValue1));
            }
            else if (PlaceDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else
            {
                txtBox3Double1.Text = "0";
            }

        }

        private void PlaceDouble1_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {

                if (Quarter_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Quarter_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1Double1.Text) / (Convert.ToDouble(newOdds1)));
                newbet2 = Convert.ToString(Convert.ToDouble(txtBox1Double1_Copy.Text) / (Convert.ToDouble(newOdds2)));

                ewValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(newbet1) + 1)
                * (Convert.ToDouble(newbet2) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (WinDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == false)
            {
                txtBox3Double1.Text = "0";
            }
            else if (WinDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else if (PlaceDouble2.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else
            {
                txtBox3Double1.Text = "0";
            }
        }

        private void Double1_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            // Sets returns to 0 if its a lose
            txtBox3Double1.Text = "0";
        }

        private void NRDouble1_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            MessageBox.Show("Bet is not valid, please use single bet to calculate winnings");
        }

        private void Quarter_OddsDouble1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Fifth_OddsDouble1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void WinDouble2_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {
                bet1Value = ((Decimal.Parse(txtBox1Double1.Text) / Decimal.Parse(txtBox2Double1.Text))).ToString();
                bet2Value = ((Decimal.Parse(txtBox1Double1_Copy.Text) / Decimal.Parse(txtBox2Double1_Copy.Text))).ToString();

                winValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(bet1Value) + 1)
                * (Convert.ToDouble(bet2Value) + 1));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);
            }

            try
            {

                if (Quarter_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Quarter_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1Double1.Text) / (Convert.ToDouble(newOdds1)));
                newbet2 = Convert.ToString(Convert.ToDouble(txtBox1Double1_Copy.Text) / (Convert.ToDouble(newOdds2)));

                ewValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(newbet1) + 1)
                * (Convert.ToDouble(newbet2) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (WinDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == false)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(winValue1));
            }
            else if (WinDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(winValue1) + Convert.ToDouble(ewValue1));
            }
            else if (PlaceDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else
            {
                txtBox3Double1.Text = "0";
            }
        }

        private void PlaceDouble2_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {

                if (Quarter_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Quarter_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 4);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Quarter_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 4);
                }
                else if (Fifth_OddsDouble1.IsChecked == true && Fifth_OddsDouble1_Copy.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2Double1.Text) * 5);
                    newOdds2 = Convert.ToString(Convert.ToDouble(txtBox2Double1_Copy.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1Double1.Text) / (Convert.ToDouble(newOdds1)));
                newbet2 = Convert.ToString(Convert.ToDouble(txtBox1Double1_Copy.Text) / (Convert.ToDouble(newOdds2)));

                ewValue1 = Convert.ToString(Convert.ToDouble(txtBokStakeDouble1.Text) * (Convert.ToDouble(newbet1) + 1)
                * (Convert.ToDouble(newbet2) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (WinDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == false)
            {
                txtBox3Double1.Text = "0";
            }
            else if (WinDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else if (PlaceDouble1.IsChecked == true && EW_CheckDouble1.IsChecked == true)
            {
                txtBox3Double1.Text = Convert.ToString(Convert.ToDouble(ewValue1));
            }
            else
            {
                txtBox3Double1.Text = "0";
            }
        }

        private void LoseDouble2_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            txtBox3Double1.Text = "0";
        }

        private void NRDouble2_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3Double1.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            MessageBox.Show("Bet is not valid, please use single bet to calculate winnings");
        }

        private void Quarter_OddsDouble1_Copy_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Fifth_OddsDouble1_Copy_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void txtBox3Double1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}