
namespace Scheduler.Windows
{
    partial class InicioFrm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtStartProcess = new System.Windows.Forms.Button();
            this.TbResultado = new System.Windows.Forms.TextBox();
            this.DtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.NudEvery = new System.Windows.Forms.NumericUpDown();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CbOccurs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.NudEvery)).BeginInit();
            this.SuspendLayout();
            // 
            // BtStartProcess
            // 
            this.BtStartProcess.Location = new System.Drawing.Point(190, 12);
            this.BtStartProcess.Name = "BtStartProcess";
            this.BtStartProcess.Size = new System.Drawing.Size(181, 54);
            this.BtStartProcess.TabIndex = 7;
            this.BtStartProcess.Text = "Calculate next date";
            this.BtStartProcess.UseVisualStyleBackColor = true;
            this.BtStartProcess.Click += new System.EventHandler(this.BtStartProcess_Click);
            // 
            // TbResultado
            // 
            this.TbResultado.Location = new System.Drawing.Point(11, 279);
            this.TbResultado.Multiline = true;
            this.TbResultado.Name = "TbResultado";
            this.TbResultado.ReadOnly = true;
            this.TbResultado.Size = new System.Drawing.Size(360, 79);
            this.TbResultado.TabIndex = 1;
            this.TbResultado.TabStop = false;
            // 
            // DtpCurrentDate
            // 
            this.DtpCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpCurrentDate.Location = new System.Drawing.Point(79, 12);
            this.DtpCurrentDate.Name = "DtpCurrentDate";
            this.DtpCurrentDate.Size = new System.Drawing.Size(95, 20);
            this.DtpCurrentDate.TabIndex = 0;
            // 
            // NudEvery
            // 
            this.NudEvery.Location = new System.Drawing.Point(276, 157);
            this.NudEvery.Name = "NudEvery";
            this.NudEvery.Size = new System.Drawing.Size(64, 20);
            this.NudEvery.TabIndex = 4;
            this.NudEvery.ThousandsSeparator = true;
            // 
            // CbType
            // 
            this.CbType.FormattingEnabled = true;
            this.CbType.Items.AddRange(new object[] {
            "Once",
            "Recurring"});
            this.CbType.Location = new System.Drawing.Point(79, 78);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(98, 21);
            this.CbType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "DateTime";
            // 
            // DtpDateTime
            // 
            this.DtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTime.Location = new System.Drawing.Point(79, 115);
            this.DtpDateTime.Name = "DtpDateTime";
            this.DtpDateTime.Size = new System.Drawing.Size(184, 20);
            this.DtpDateTime.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Occurs";
            // 
            // CbOccurs
            // 
            this.CbOccurs.FormattingEnabled = true;
            this.CbOccurs.Items.AddRange(new object[] {
            "Secondly",
            "Minutely",
            "Hourly",
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.CbOccurs.Location = new System.Drawing.Point(79, 156);
            this.CbOccurs.Name = "CbOccurs";
            this.CbOccurs.Size = new System.Drawing.Size(98, 21);
            this.CbOccurs.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Every";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Start date";
            // 
            // DtpStartDate
            // 
            this.DtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpStartDate.Location = new System.Drawing.Point(79, 237);
            this.DtpStartDate.Name = "DtpStartDate";
            this.DtpStartDate.Size = new System.Drawing.Size(95, 20);
            this.DtpStartDate.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "End date";
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpEndDate.Location = new System.Drawing.Point(276, 237);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(95, 20);
            this.DtpEndDate.TabIndex = 6;
            // 
            // InicioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 369);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpEndDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtpStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CbOccurs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpDateTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.NudEvery);
            this.Controls.Add(this.DtpCurrentDate);
            this.Controls.Add(this.TbResultado);
            this.Controls.Add(this.BtStartProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InicioFrm";
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.InicioFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudEvery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtStartProcess;
        private System.Windows.Forms.TextBox TbResultado;
        private System.Windows.Forms.DateTimePicker DtpCurrentDate;
        private System.Windows.Forms.NumericUpDown NudEvery;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbOccurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtpEndDate;
    }
}

