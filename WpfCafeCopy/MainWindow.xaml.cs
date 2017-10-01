using LibCafe;
using System;

using System.Threading;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media.Imaging;


namespace WpfCafeCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddPintImage()
        {
            // zoek een pintfiguurtje, plaats dat in de map images
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("images/pint.png", UriKind.Relative));
            img.Width = 40;

            spPints.Children.Add(img);
        }
        int numberOfPints = 5;
        int teller;

        private void btnPintPlease_Click(object sender, RoutedEventArgs e)
        {

            PintDish pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.PintCompleted += PintDish_PintCompleted;
            pintDish.DishCompleted += PintDish_DishCompleted;



            for (teller = 0; teller < numberOfPints; teller++)
            {
                try
                {
                    pintDish.AddPint();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void PintDish_PintCompleted(object sender, PintCompletedArgs e)
        {

            AddPintImage();
            lblCountPints.Content = (teller + 1) + " / " + numberOfPints;
            TimeBrewPint();
        }

        private void PintDish_DishCompleted(object sender, DishCompletedArgs e)
        {

            lblMessage.Content = ($"Dish completed in {e.CreationTimeNeeded.TotalMilliseconds} ms, prepare for consumption!");
        }


        private void PintDish_PintStarted(object sender, EventArgs e)
        {
            btnPintPlease.IsEnabled = false;
            lblMessage.Content = ("Pints brewing!..");


        }
        private void TimeBrewPint()
        {
            Thread.Sleep(1475);

        }
    }
}

