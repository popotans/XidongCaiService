using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 新建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTaskForm atf = new AddTaskForm(this);
            atf.Show();

        }
    }
}
