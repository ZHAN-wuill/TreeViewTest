using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TreeViewTest
{
    public class PageVM : ViewModelBase
    {
        protected ICommand _Mouse_Click;
        internal Frame sourceframe;
        public ICommand M_Click => _Mouse_Click ??
            (_Mouse_Click = new RelayCommand(parameter =>
            {
                if (sourceframe != null)
                    sourceframe.Navigate(new Uri(@"./Page1.xaml", UriKind.Relative));
            })
        );
    }
}
