using System;
using System.Windows.Forms;

namespace Scheduler.Windows
{
    public partial class InicioFrm : Form
    {
        Processor processor;
        public InicioFrm()
        {
            this.InitializeComponent();
        }

        private void BtStartProcess_Click(object sender, EventArgs e)
        {
            SchedulerConfiguration TheConfiguration = new SchedulerConfiguration();

            if (CbType.Text == "Once")
            {
                TheConfiguration.SetOnce(this.DtpCurrentDate.Value, this.DtpDateTime.Value);
            }

            if (CbType.Text == "Recurring")
            {
                TheConfiguration.SetRecurring(this.DtpCurrentDate.Value, (PeriodicityModes)Enum.Parse(typeof(PeriodicityModes), this.CbOccurs.Text),
                    Convert.ToInt32(this.NudEvery.Value), this.DtpDateTime.Value, this.DtpEndDate.Value);
            }

            if (this.processor != null)
            {
                this.processor = new Processor(TheConfiguration);
            }

            //try
            //{
            this.processor = new Processor(TheConfiguration);
                this.TbResultado.Text = this.processor.GetNextExecution();






            //}
            //catch (ApplicationException exc)
            //{
            //    MessageBox.Show(exc.Message + Environment.NewLine + exc.StackTrace);
            //}
        }

        private void InicioFrm_Load(object sender, EventArgs e)
        {
            //foreach (string CadaItem in (string)Enum.GetValues(typeof(PeriodicityTypes)))
            //{
            //    this.CbType.Items.Add(CadaItem);
            //}

            //foreach (string CadaItem in Enum.GetValues(typeof(PeriodicityModes)))
            //{
            //    this.CbOccurs.Items.Add(CadaItem);
            //}

            this.DtpCurrentDate.Value = DateTime.Now;
            this.DtpStartDate.Value = DateTime.Now;
        }
    }
}
