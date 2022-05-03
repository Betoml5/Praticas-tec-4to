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

namespace HerosApp.Views
{
    /// <summary>
    /// Lógica de interacción para HeroDetailsView.xaml
    /// </summary>
    public partial class HeroDetailsView : UserControl
    {
        public HeroDetailsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            

            //var vm = DataContext.herovm;
            //if(MessageBox.Show("¿Está seguro de eliminar el heroe","Confirme",
            //    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            //    herovm.DeleteHeroCommand.Execute(null);
            //}
        }
    }
}
