namespace MainForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonNoParaAsyn = new System.Windows.Forms.Button();
            this.ButtonParalellAsyn = new System.Windows.Forms.Button();
            this.textParallelAsym = new System.Windows.Forms.TextBox();
            this.textNoParalellAsyn = new System.Windows.Forms.TextBox();
            this.LoadDataAsyn = new System.Windows.Forms.Button();
            this.TextStatusProgress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputNumberValues = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonNoParaAsyn);
            this.groupBox2.Controls.Add(this.ButtonParalellAsyn);
            this.groupBox2.Controls.Add(this.textParallelAsym);
            this.groupBox2.Controls.Add(this.textNoParalellAsyn);
            this.groupBox2.Location = new System.Drawing.Point(12, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 168);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Linq Performance";
            // 
            // ButtonNoParaAsyn
            // 
            this.ButtonNoParaAsyn.Enabled = false;
            this.ButtonNoParaAsyn.Location = new System.Drawing.Point(12, 46);
            this.ButtonNoParaAsyn.Name = "ButtonNoParaAsyn";
            this.ButtonNoParaAsyn.Size = new System.Drawing.Size(174, 44);
            this.ButtonNoParaAsyn.TabIndex = 0;
            this.ButtonNoParaAsyn.Text = "Start No Parallel Linq";
            this.ButtonNoParaAsyn.UseVisualStyleBackColor = true;
            this.ButtonNoParaAsyn.Click += new System.EventHandler(this.ButtonNoParaAsyn_Click);
            // 
            // ButtonParalellAsyn
            // 
            this.ButtonParalellAsyn.Enabled = false;
            this.ButtonParalellAsyn.Location = new System.Drawing.Point(12, 108);
            this.ButtonParalellAsyn.Name = "ButtonParalellAsyn";
            this.ButtonParalellAsyn.Size = new System.Drawing.Size(174, 44);
            this.ButtonParalellAsyn.TabIndex = 1;
            this.ButtonParalellAsyn.Text = "Start Parallel Linq";
            this.ButtonParalellAsyn.UseVisualStyleBackColor = true;
            this.ButtonParalellAsyn.Click += new System.EventHandler(this.ButtonParalellAsyn_Click);
            // 
            // textParallelAsym
            // 
            this.textParallelAsym.Location = new System.Drawing.Point(201, 108);
            this.textParallelAsym.Multiline = true;
            this.textParallelAsym.Name = "textParallelAsym";
            this.textParallelAsym.ReadOnly = true;
            this.textParallelAsym.Size = new System.Drawing.Size(239, 44);
            this.textParallelAsym.TabIndex = 3;
            // 
            // textNoParalellAsyn
            // 
            this.textNoParalellAsyn.Location = new System.Drawing.Point(201, 46);
            this.textNoParalellAsyn.Multiline = true;
            this.textNoParalellAsyn.Name = "textNoParalellAsyn";
            this.textNoParalellAsyn.ReadOnly = true;
            this.textNoParalellAsyn.Size = new System.Drawing.Size(239, 44);
            this.textNoParalellAsyn.TabIndex = 2;
            // 
            // LoadDataAsyn
            // 
            this.LoadDataAsyn.Location = new System.Drawing.Point(273, 35);
            this.LoadDataAsyn.Name = "LoadDataAsyn";
            this.LoadDataAsyn.Size = new System.Drawing.Size(104, 31);
            this.LoadDataAsyn.TabIndex = 4;
            this.LoadDataAsyn.Text = "Load Data";
            this.LoadDataAsyn.UseVisualStyleBackColor = true;
            this.LoadDataAsyn.Click += new System.EventHandler(this.LoadDataAsync);
            // 
            // TextStatusProgress
            // 
            this.TextStatusProgress.Location = new System.Drawing.Point(137, 87);
            this.TextStatusProgress.Multiline = true;
            this.TextStatusProgress.Name = "TextStatusProgress";
            this.TextStatusProgress.ReadOnly = true;
            this.TextStatusProgress.Size = new System.Drawing.Size(303, 164);
            this.TextStatusProgress.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputNumberValues);
            this.groupBox1.Controls.Add(this.TextStatusProgress);
            this.groupBox1.Controls.Add(this.LoadDataAsyn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 257);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Item Panel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number Of Items:";
            // 
            // inputNumberValues
            // 
            this.inputNumberValues.Location = new System.Drawing.Point(137, 35);
            this.inputNumberValues.Multiline = true;
            this.inputNumberValues.Name = "inputNumberValues";
            this.inputNumberValues.Size = new System.Drawing.Size(130, 31);
            this.inputNumberValues.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 456);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Benchmark Linq";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LoadDataAsyn;
        private System.Windows.Forms.Button ButtonNoParaAsyn;
        private System.Windows.Forms.Button ButtonParalellAsyn;
        private System.Windows.Forms.TextBox textParallelAsym;
        private System.Windows.Forms.TextBox textNoParalellAsyn;
        private System.Windows.Forms.TextBox TextStatusProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputNumberValues;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

