using LibCafe;
using System;

using System.Threading;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media.Imaging;


namespace WpfCafe
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
        int numberOfPints = 5;
        int teller;
        PintDish pintDish;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pintDish = new PintDish(numberOfPints);

            try
            {
                pintDish.AddPint();

            }
            catch (Exception ex)
            {
                btnPintPlease.IsEnabled = false;
                MessageBox.Show(ex.Message);
                pintDish.timer.Stop();
                

            }
            
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.DishCompleted += PintDish_DishCompleted;
        }

        private void PintDish_PintStarted(object sender, PintStartedArgs e)
        {
            Dispatcher.Invoke(delegate
            {
               
                AddPintImage();
                btnPintPlease.IsEnabled = false;
                lblMessage.Content = ($"Pint {(teller +1)} is brewed at {e.TijdstipVanBrewedPint}.");
                lblCountPints.Content = (teller + 1) + " / " + numberOfPints;
                teller++;

                if (teller >= numberOfPints)
                {
                    lblMessage.Visibility = Visibility.Hidden;
                    lblDish.Visibility = Visibility.Visible;
                    pintDish.Stop();
                }
            }
            );
        }

        private void AddPintImage()
        {
            // zoek een pintfiguurtje, plaats dat in de map images
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("images/pint.png", UriKind.Relative));
            img.Width = 40;

            spPints.Children.Add(img);
        }
       

        private void btnPintPlease_Click(object sender, RoutedEventArgs e)
        {

            pintDish.Start();

          
        }

        
        private void PintDish_DishCompleted(object sender, DishCompletedArgs e)
        {
        
            Dispatcher.Invoke(delegate
            {

                lblDish.Content = ($"Dish completed in {e.CreationTimeNeeded.TotalMilliseconds} ms, prepare for consumption!");
            }
            );

        }

    }
}

