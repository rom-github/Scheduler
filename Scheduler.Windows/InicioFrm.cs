using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Windows
{
    public partial class InicioFrm : Form
    {
        public InicioFrm()
        {
            this.InitializeComponent();
        }

        private void BtStartProcess_Click(object sender, EventArgs e)
        {
            SchedulerConfiguration TheConfiguration = new SchedulerConfiguration();

            try
            {
                Processor TheProcessor = new Processor(TheConfiguration);
            }
            catch (ApplicationException exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + exc.StackTrace);
            }
        }
    }
}
