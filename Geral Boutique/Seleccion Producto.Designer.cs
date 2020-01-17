namespace Geral_Boutique
{
    partial class Seleccion_Producto
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
            this.btnaceptar = new System.Windows.Forms.Button();
            this.dgvbuscarprod = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscarprod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnaceptar
            // 
            this.btnaceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaceptar.Location = new System.Drawing.Point(433, 44);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(75, 30);
            this.btnaceptar.TabIndex = 8;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            // 
            // dgvbuscarprod
            // 
            this.dgvbuscarprod.AllowUserToAddRows = false;
            this.dgvbuscarprod.AllowUserToDeleteRows = false;
            this.dgvbuscarprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbuscarprod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvbuscarprod.Location = new System.Drawing.Point(12, 80);
            this.dgvbuscarprod.Name = "dgvbuscarprod";
            this.dgvbuscarprod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbuscarprod.Size = new System.Drawing.Size(496, 150);
            this.dgvbuscarprod.TabIndex = 7;
            // 
            // Seleccion_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 237);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.dgvbuscarprod);
            this.MaximumSize = new System.Drawing.Size(533, 276);
            this.MinimumSize = new System.Drawing.Size(533, 276);
            this.Name = "Seleccion_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion_Producto";
            this.Load += new System.EventHandler(this.Seleccion_Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbuscarprod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnaceptar;
        public System.Windows.Forms.DataGridView dgvbuscarprod;
    }
}