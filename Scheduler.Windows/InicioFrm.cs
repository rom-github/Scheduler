using System;
using System.Windows.Forms;
using System.Linq;

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
                    Convert.ToInt32(this.NudEvery.Value), this.DtpStartDate.Value, this.DtpEndDate.Value);
            }

            if (this.processor != null)
            {
                this.processor = new Processor(TheConfiguration);
            }

            try
            {
                this.processor = new Processor(TheConfiguration);
                SchedulerResult TheResult = this.processor.GetNextExecution();
                this.TbResultado.Text = TheResult == null ? string.Empty : TheResult.DateTime.ToShortDateString() + " - " + TheResult.Description;
            }
            catch (ApplicationException exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + exc.StackTrace);
            }
        }

        private void InicioFrm_Load(object sender, EventArgs e)
        {
            this.LoadComboEnum(this.CbType, typeof(PeriodicityTypes));
            this.LoadComboEnum(this.CbOccurs, typeof(PeriodicityModes));

            this.DtpCurrentDate.Value = DateTime.Now;
            this.DtpStartDate.Value = DateTime.Now;
        }

        private void LoadComboEnum(ComboBox TheComboBox, Type TheEnumType)
        {
            TheComboBox.Items.Clear();
            foreach (var EachItem in Enum.GetValues(TheEnumType))
            {
                TheComboBox.Items.Add(EachItem.ToString());
            }
            TheComboBox.SelectedIndex = 0;
        }
    }
}
