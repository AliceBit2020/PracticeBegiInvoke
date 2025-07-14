using PracticeBeginInvoke.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PracticeBegiInvoke
{
    public partial class Form1 : Form
    {
        public SynchronizationContext uiContext;
        public Form1()
        {
            InitializeComponent();
            // Получим контекст синхронизации для текущего потока 
            uiContext = SynchronizationContext.Current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        Task1Controller.BeginTask1(uiContext,listBox1);
          
        }
    }
}
