using Superhero.Models;
using Superhero.ViewModels;
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
using System.Windows.Shapes;

namespace Superhero
{
    /// <summary>
    /// Interaction logic for SuperHeroCreatorWindow.xaml
    /// </summary>
    public partial class SuperHeroCreatorWindow : Window
    {
        public SuperHeroCreatorWindow(SuperHeroMember shm)
        {
            InitializeComponent();
            cb.Items.Add(Types.bad);
            cb.Items.Add(Types.good);
            cb.Items.Add(Types.neutral);
            this.DataContext = new SuperHeroCreatorViewModel();
            (this.DataContext as SuperHeroCreatorViewModel).Setup(shm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack_editor.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (item is ComboBox c)
                {
                    c.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
                }

                this.DialogResult = true;
            }
        }
    }
}
