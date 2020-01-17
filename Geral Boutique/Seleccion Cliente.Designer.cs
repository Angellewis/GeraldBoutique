namespace Geral_Boutique
{
    partial class Seleccion_Cliente
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
            this.dgvbuscacli = new System.Windows.Forms.DataGridView();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.txtbusqyeda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscacli)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbuscacli
            // 
            this.dgvbuscacli.AllowUserToAddRows = false;
            this.dgvbuscacli.AllowUserToDeleteRows = false;
            this.dgvbuscacli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbuscacli.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvbuscacli.Location = new System.Drawing.Point(12, 75);
            this.dgvbuscacli.Name = "dgvbuscacli";
            this.dgvbuscacli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbuscacli.Size = new System.Drawing.Size(496, 150);
            this.dgvbuscacli.TabIndex = 0;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaceptar.Location = new System.Drawing.Point(433, 39);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(75, 30);
            this.btnaceptar.TabIndex = 1;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // txtbusqyeda
            // 
            this.txtbusqyeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqyeda.Location = new System.Drawing.Point(12, 45);
            this.txtbusqyeda.Name = "txtbusqyeda";
            this.txtbusqyeda.Size = new System.Drawing.Size(205, 24);
            this.txtbusqyeda.TabIndex = 2;
            this.txtbusqyeda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbusqyeda_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busqueda Por Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, -1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Busqueda por cedula";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(221, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 24);
            this.textBox2.TabIndex = 5;
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbusqyeda_KeyUp);
            // 
            // Seleccion_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 235);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbusqyeda);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.dgvbuscacli);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(536, 274);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(536, 274);
            this.Name = "Seleccion_Cliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion Cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Seleccion_Cliente_FormClosed);
            this.Load += new System.EventHandler(this.Seleccion_Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscacli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbuscacli;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.TextBox txtbusqyeda;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}