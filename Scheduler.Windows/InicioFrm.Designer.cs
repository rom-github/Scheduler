
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
            this.SuspendLayout();
            // 
            // BtStartProcess
            // 
            this.BtStartProcess.Location = new System.Drawing.Point(107, 49);
            this.BtStartProcess.Name = "BtStartProcess";
            this.BtStartProcess.Size = new System.Drawing.Size(81, 54);
            this.BtStartProcess.TabIndex = 0;
            this.BtStartProcess.Text = "Start";
            this.BtStartProcess.UseVisualStyleBackColor = true;
            this.BtStartProcess.Click += new System.EventHandler(this.BtStartProcess_Click);
            // 
            // InicioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 152);
            this.Controls.Add(this.BtStartProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InicioFrm";
            this.Text = "Schedule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtStartProcess;
    }
}

