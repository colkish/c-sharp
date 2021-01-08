using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Explorer
{
    public partial class Explorer : Form
    {
        public Explorer()
        {
            InitializeComponent();
        }

        private void Explorer_Load(object sender, EventArgs e)
        {
            var docs = new TreeNode("My Documents");
            docs.Tag = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "hublsoft limited");
            treeView1.Nodes.Add(docs);
            GetFolders(docs);
        }

        private void GetFolders(TreeNode node)
        {
            var dir = new DirectoryInfo(node.Tag.ToString());

            foreach (var childDir in dir.GetDirectories())
            {
                var childNode = new TreeNode(childDir.Name);
                childNode.Tag = childDir.FullName;
                node.Nodes.Add(childNode);
                GetFolders(childNode);

            }
        }
    }
}
