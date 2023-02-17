using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TreeViewTest
{
    public class MainVM : ViewModelBase
    {
        protected ICommand _ProgramLoaded;
        private Frame sourceframe;
        public ObservableCollection<TreeNode> TreeNodes { get; set; } = new ObservableCollection<TreeNode>();
        public PageVM pagevm;
        public MainVM()
        {
            TreeNode tn = new TreeNode("主要1", null, null);
            TreeNode tn1 = new TreeNode("主要2", null, null);
            tn.Nodes.Add(new TreeNode("頁面1", "page1", new Page1()));
            tn.Nodes.Add(new TreeNode("頁面2", "page2", new Page2()));
            tn1.Nodes.Add(new TreeNode("頁面3", "page3", new Page3()));
            TreeNodes.Add(tn);
            TreeNodes.Add(tn1);
        }
        public ICommand ProgramLoadedCommand => _ProgramLoaded ??
            (_ProgramLoaded = new RelayCommand(parameter =>
            {
                if (parameter != null)
                    sourceframe = ((Window)parameter).FindName("frameel") as Frame;
                SetFrame(TreeNodes, sourceframe);

            })
        );
        public void SetFrame(ObservableCollection<TreeNode> Nodes, Frame frame)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].frame = frame;
                if (Nodes[i].page != null)
                    ((PageVM)Nodes[i].page.DataContext).sourceframe = sourceframe;
                if (Nodes[i].Nodes.Count > 0)
                    SetFrame(Nodes[i].Nodes, frame);
            }
        }
    }
}
