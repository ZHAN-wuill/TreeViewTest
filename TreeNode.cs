using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TreeViewTest
{
    public class TreeNode : ViewModelBase
    {
        protected ICommand _Tree_M_Click;
        private string title;
        private string pagename;
        public Frame frame;
        public Page page;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string PageName
        {
            get { return pagename; }
            set
            {
                pagename = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TreeNode> Nodes { get; set; } = new ObservableCollection<TreeNode>();
        public TreeNode(string title, string page, Page pg)
        {
            this.Title = title;
            this.PageName = page;
            this.page = pg;
        }
        public ICommand Tree_M_Click => _Tree_M_Click ??
            (_Tree_M_Click = new RelayCommand(parameter =>
            {
                if (frame != null)
                    if (page != null)
                        frame.Navigate(page);
            })
        );
    }
}
