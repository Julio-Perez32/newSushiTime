namespace Sushi_Time_PTC_2024.Vista.Calendario
{
    partial class UserControlDias
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlDias));
            this.lblDays = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // lblDays
            // 
            this.lblDays.AllowParentOverrides = false;
            this.lblDays.AutoEllipsis = false;
            this.lblDays.CursorType = null;
            this.lblDays.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.ForeColor = System.Drawing.Color.White;
            this.lblDays.Location = new System.Drawing.Point(10, 11);
            this.lblDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblDays.Name = "lblDays";
            this.lblDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDays.Size = new System.Drawing.Size(24, 30);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "00";
            this.lblDays.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblDays.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // UserControlDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.Controls.Add(this.lblDays);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControlDias";
            this.Size = new System.Drawing.Size(86, 76);
            this.Load += new System.EventHandler(this.UserControlDias_Load);
            this.Click += new System.EventHandler(this.UserControlDias_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel lblDays;
    }
}
