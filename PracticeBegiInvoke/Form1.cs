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
        

        // Task1Controller.Task1(uiContext, listBox1);
        private void button1_Click(object sender, EventArgs e)
        {
            ///1

            //try
            //{
            //    Task1Controller.BeginTask1(uiContext, listBox1);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //MessageBox.Show("Form is free");
            ///2
            try
            {
                BeginTask2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("button1_Click" + ex.Message);
            }
        }



        public static void BeginTask2()
        {
            Action func = Test2;
            try
            {
                func.BeginInvoke(null,null);
                func.EndInvoke(null);/// if comment unhandled exception
            }
            catch (Exception ex)
            {
                MessageBox.Show("BeginTask2()" + ex.Message);
            }
        }
        public static void Test2()=> throw new ArgumentNullException("some exception");
        
    }
}
