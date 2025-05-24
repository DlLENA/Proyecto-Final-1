namespace Proyecto_Final_1
{
    partial class Form1
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
            this.lblTema = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.btnInvestigar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.btnGenerarword = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnGenerarPPT = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Nirmala Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTema.Location = new System.Drawing.Point(33, 42);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(210, 23);
            this.lblTema.TabIndex = 0;
            this.lblTema.Text = "¿En que puedo ayudarte?";
            // 
            // txtTema
            // 
            this.txtTema.Location = new System.Drawing.Point(277, 33);
            this.txtTema.Multiline = true;
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(284, 43);
            this.txtTema.TabIndex = 1;
            // 
            // btnInvestigar
            // 
            this.btnInvestigar.Font = new System.Drawing.Font("Nirmala Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvestigar.Location = new System.Drawing.Point(644, 33);
            this.btnInvestigar.Name = "btnInvestigar";
            this.btnInvestigar.Size = new System.Drawing.Size(103, 64);
            this.btnInvestigar.TabIndex = 2;
            this.btnInvestigar.Text = "Consultar IA";
            this.btnInvestigar.UseVisualStyleBackColor = true;
            this.btnInvestigar.Click += new System.EventHandler(this.btnInvestigar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Este es el resultado de tu pregunta";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(45, 209);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(631, 269);
            this.txtResultado.TabIndex = 4;
            // 
            // btnGenerarword
            // 
            this.btnGenerarword.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerarword.Font = new System.Drawing.Font("Nirmala Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerarword.Location = new System.Drawing.Point(793, 299);
            this.btnGenerarword.Name = "btnGenerarword";
            this.btnGenerarword.Size = new System.Drawing.Size(150, 62);
            this.btnGenerarword.TabIndex = 5;
            this.btnGenerarword.Text = "Generar Word ";
            this.btnGenerarword.UseVisualStyleBackColor = false;
            this.btnGenerarword.Click += new System.EventHandler(this.btnGenerarword_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(956, 471);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 16);
            this.lblEstado.TabIndex = 6;
            // 
            // btnGenerarPPT
            // 
            this.btnGenerarPPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGenerarPPT.Font = new System.Drawing.Font("Nirmala Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPPT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerarPPT.Location = new System.Drawing.Point(793, 367);
            this.btnGenerarPPT.Name = "btnGenerarPPT";
            this.btnGenerarPPT.Size = new System.Drawing.Size(150, 65);
            this.btnGenerarPPT.TabIndex = 7;
            this.btnGenerarPPT.Text = "Generar Power Point";
            this.btnGenerarPPT.UseVisualStyleBackColor = false;
            this.btnGenerarPPT.Click += new System.EventHandler(this.btnGenerarPPT_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Nirmala Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(771, 33);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 64);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 508);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerarPPT);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnGenerarword);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvestigar);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.lblTema);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Button btnInvestigar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button btnGenerarword;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnGenerarPPT;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

