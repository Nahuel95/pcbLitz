namespace LitzGrafica
{
    partial class CambiarEscala
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.desdeX = new System.Windows.Forms.TextBox();
            this.hastaX = new System.Windows.Forms.TextBox();
            this.desdeY = new System.Windows.Forms.TextBox();
            this.hastaY = new System.Windows.Forms.TextBox();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.chkCurvas = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // desdeX
            // 
            this.desdeX.Location = new System.Drawing.Point(78, 30);
            this.desdeX.Name = "desdeX";
            this.desdeX.Size = new System.Drawing.Size(52, 20);
            this.desdeX.TabIndex = 0;
            // 
            // hastaX
            // 
            this.hastaX.Location = new System.Drawing.Point(192, 30);
            this.hastaX.Name = "hastaX";
            this.hastaX.Size = new System.Drawing.Size(52, 20);
            this.hastaX.TabIndex = 1;
            // 
            // desdeY
            // 
            this.desdeY.Location = new System.Drawing.Point(78, 77);
            this.desdeY.Name = "desdeY";
            this.desdeY.Size = new System.Drawing.Size(52, 20);
            this.desdeY.TabIndex = 2;
            // 
            // hastaY
            // 
            this.hastaY.Location = new System.Drawing.Point(192, 77);
            this.hastaY.Name = "hastaY";
            this.hastaY.Size = new System.Drawing.Size(52, 20);
            this.hastaY.TabIndex = 3;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(50, 182);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(80, 28);
            this.cmdAceptar.TabIndex = 4;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(144, 182);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(80, 28);
            this.cmdCancelar.TabIndex = 5;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // chkCurvas
            // 
            this.chkCurvas.FormattingEnabled = true;
            this.chkCurvas.Location = new System.Drawing.Point(101, 117);
            this.chkCurvas.Name = "chkCurvas";
            this.chkCurvas.Size = new System.Drawing.Size(72, 49);
            this.chkCurvas.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Desde Y";
            // 
            // CambiarEscala
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCurvas);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.hastaY);
            this.Controls.Add(this.desdeY);
            this.Controls.Add(this.hastaX);
            this.Controls.Add(this.desdeX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CambiarEscala";
            this.Text = "CambiarEscala";
            this.Load += new System.EventHandler(this.CambiarEscala_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox desdeX;
        private System.Windows.Forms.TextBox hastaX;
        private System.Windows.Forms.TextBox desdeY;
        private System.Windows.Forms.TextBox hastaY;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.CheckedListBox chkCurvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}