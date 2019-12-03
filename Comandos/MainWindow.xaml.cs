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
using System.Windows.Threading;

namespace Comandos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string cadenaCopy;
        private DispatcherTimer timer;
        List<string> lista;
        public MainWindow()
        {
            lista = new List<string>();
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1000)
            };
            timer.Tick += IntervalElapsed;
            timer.Start();
            timer.IsEnabled = true;
        }

        private void IntervalElapsed(object sender, EventArgs e)
        {
            HoraTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Commands_Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void Commands_Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Commands_New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lista.Add("Item añadido a las " + HoraTextBlock.Text);
            ItemsListBox.Items.Add(lista.Last());
        }

        private void Commands_New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count < 10)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void Commands_Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            cadenaCopy = ItemsListBox.SelectedItem.ToString();
        }

        private void Commands_Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ItemsListBox != null)
                e.CanExecute = ItemsListBox.SelectedItem != null;
            else
                e.CanExecute = true;
        }

        private void Commands_Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBoxItem itm = new ListBoxItem
            {
                Content = cadenaCopy
            };

            cadenaCopy = null;

            ItemsListBox.Items.Add(itm);
        }

        private void Commands_Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = cadenaCopy != null && ItemsListBox != null && ItemsListBox.Items.Count < 10;
        }

        private void Commands_Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ItemsListBox.Items.Clear();
            lista.Clear();
        }

        private void Commands_Clear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}
