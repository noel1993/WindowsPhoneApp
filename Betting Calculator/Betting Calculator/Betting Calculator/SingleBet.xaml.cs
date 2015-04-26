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
    public partial class SingleBet : PhoneApplicationPage
    {
        public double eachWayValue;
        public double amount;
        public int fifth = 5, quarter = 4;
        public string bet1Value, ewValue, winValue1, newOdds1, newbet1;

        public SingleBet()
        {
            InitializeComponent();
        }


        private void txtBox3_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //txtBox3.IsEnabled = false;
        }

        private void Win_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {
                bet1Value = ((Decimal.Parse(txtBox1.Text) / Decimal.Parse(txtBox2.Text))).ToString();


                winValue1 = Convert.ToString(Convert.ToDouble(txtBokStake.Text) * (Convert.ToDouble(bet1Value) + 1));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);
            }

            try
            {

                if (Quarter_Odds.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2.Text) * 4);
                }
                else if (Fifth_Odds.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1.Text) / (Convert.ToDouble(newOdds1)));

                ewValue = Convert.ToString(Convert.ToDouble(txtBokStake.Text) * (Convert.ToDouble(newbet1) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (EW_Check.IsChecked == true)
            {
                txtBox3.Text = Convert.ToString(Convert.ToDouble(winValue1) + Convert.ToDouble(ewValue));
            }
            else if (EW_Check.IsChecked == false)
            {
                txtBox3.Text = Convert.ToString(Convert.ToDouble(winValue1));
            }

        }

        private void Place_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            try
            {

                if (Quarter_Odds.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2.Text) * 4);
                }
                else if (Fifth_Odds.IsChecked == true)
                {
                    newOdds1 = Convert.ToString(Convert.ToDouble(txtBox2.Text) * 5);
                }

                newbet1 = Convert.ToString(Convert.ToDouble(txtBox1.Text) / (Convert.ToDouble(newOdds1)));

                ewValue = Convert.ToString(Convert.ToDouble(txtBokStake.Text) * (Convert.ToDouble(newbet1) + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Please Enter all needed fields!", MessageBoxButton.OK);

            }

            if (EW_Check.IsChecked == false)
            {
                txtBox3.Text = "0";
            }
            else if (EW_Check.IsChecked == true)
            {
                txtBox3.Text = Convert.ToString(Convert.ToDouble(ewValue));
            }
        }

        private void Lose_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            // Sets returns to 0 if its a lose
            txtBox3.Text = "0";
        }

        private void N_R_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox3.Text == "Infinity")
            {
                MessageBox.Show("Please be sure all EW parts are selected");
            }

            // Orignal stake is returned if bet is a non runner
            if (EW_Check.IsChecked == false)
            {
                txtBox3.Text = (Decimal.Parse(txtBokStake.Text)).ToString();
            }
            else if (EW_Check.IsChecked == true)
            {
                txtBox3.Text = (Decimal.Parse(txtBokStake.Text)).ToString();
                string betValue = txtBox3.Text;
                txtBox3.Text = Convert.ToString(Convert.ToDouble(betValue) + (Convert.ToDouble(betValue)));
            }

        }

        private void Fifth_Odds_Checked(object sender, RoutedEventArgs e)
        {
            eachWayValue = 0.2;
        }

        private void Quarter_Odds_Checked(object sender, RoutedEventArgs e)
        {
            eachWayValue = 0.25;
        }





    }
        
}