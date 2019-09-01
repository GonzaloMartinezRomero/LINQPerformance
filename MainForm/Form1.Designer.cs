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
            this.ButtonNoParallelLinq = new System.Windows.Forms.Button();
            this.ButtonParalellLinq = new System.Windows.Forms.Button();
            this.textParallelAsym = new System.Windows.Forms.TextBox();
            this.textNoParalellAsyn = new System.Windows.Forms.TextBox();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.TextStatusProgress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputNumberValues = new System.Windows.Forms.NumericUpDown();
            this.numberOfThreadInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RestartButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadInput)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonNoParallelLinq);
            this.groupBox2.Controls.Add(this.ButtonParalellLinq);
            this.groupBox2.Controls.Add(this.textParallelAsym);
            this.groupBox2.Controls.Add(this.textNoParalellAsyn);
            this.groupBox2.Location = new System.Drawing.Point(12, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 133);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Linq Performance";
            // 
            // ButtonNoParallelLinq
            // 
            this.ButtonNoParallelLinq.Enabled = false;
            this.ButtonNoParallelLinq.Location = new System.Drawing.Point(12, 21);
            this.ButtonNoParallelLinq.Name = "ButtonNoParallelLinq";
            this.ButtonNoParallelLinq.Size = new System.Drawing.Size(174, 44);
            this.ButtonNoParallelLinq.TabIndex = 0;
            this.ButtonNoParallelLinq.Text = "Start No Parallel Linq";
            this.ButtonNoParallelLinq.UseVisualStyleBackColor = true;
            this.ButtonNoParallelLinq.Click += new System.EventHandler(this.ButtonNoParaAsyn_Click);
            // 
            // ButtonParalellLinq
            // 
            this.ButtonParalellLinq.Enabled = false;
            this.ButtonParalellLinq.Location = new System.Drawing.Point(12, 83);
            this.ButtonParalellLinq.Name = "ButtonParalellLinq";
            this.ButtonParalellLinq.Size = new System.Drawing.Size(174, 44);
            this.ButtonParalellLinq.TabIndex = 1;
            this.ButtonParalellLinq.Text = "Start Parallel Linq";
            this.ButtonParalellLinq.UseVisualStyleBackColor = true;
            this.ButtonParalellLinq.Click += new System.EventHandler(this.ButtonParalellAsyn_Click);
            // 
            // textParallelAsym
            // 
            this.textParallelAsym.Location = new System.Drawing.Point(201, 83);
            this.textParallelAsym.Multiline = true;
            this.textParallelAsym.Name = "textParallelAsym";
            this.textParallelAsym.ReadOnly = true;
            this.textParallelAsym.Size = new System.Drawing.Size(239, 44);
            this.textParallelAsym.TabIndex = 3;
            // 
            // textNoParalellAsyn
            // 
            this.textNoParalellAsyn.Location = new System.Drawing.Point(201, 21);
            this.textNoParalellAsyn.Multiline = true;
            this.textNoParalellAsyn.Name = "textNoParalellAsyn";
            this.textNoParalellAsyn.ReadOnly = true;
            this.textNoParalellAsyn.Size = new System.Drawing.Size(239, 44);
            this.textNoParalellAsyn.TabIndex = 2;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(301, 30);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(104, 59);
            this.LoadDataButton.TabIndex = 4;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataAsync);
            // 
            // TextStatusProgress
            // 
            this.TextStatusProgress.Location = new System.Drawing.Point(137, 107);
            this.TextStatusProgress.Multiline = true;
            this.TextStatusProgress.Name = "TextStatusProgress";
            this.TextStatusProgress.ReadOnly = true;
            this.TextStatusProgress.Size = new System.Drawing.Size(303, 169);
            this.TextStatusProgress.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputNumberValues);
            this.groupBox1.Controls.Add(this.numberOfThreadInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextStatusProgress);
            this.groupBox1.Controls.Add(this.LoadDataButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 294);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Item Panel";
            // 
            // inputNumberValues
            // 
            this.inputNumberValues.Location = new System.Drawing.Point(137, 30);
            this.inputNumberValues.Maximum = new decimal(new int[] {
            50000000,
            0,
            0,
            0});
            this.inputNumberValues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNumberValues.Name = "inputNumberValues";
            this.inputNumberValues.Size = new System.Drawing.Size(120, 22);
            this.inputNumberValues.TabIndex = 16;
            this.inputNumberValues.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // numberOfThreadInput
            // 
            this.numberOfThreadInput.Location = new System.Drawing.Point(137, 67);
            this.numberOfThreadInput.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfThreadInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfThreadInput.Name = "numberOfThreadInput";
            this.numberOfThreadInput.Size = new System.Drawing.Size(120, 22);
            this.numberOfThreadInput.TabIndex = 15;
            this.numberOfThreadInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number Threads:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number Of Items:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(175, 451);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(104, 31);
            this.RestartButton.TabIndex = 10;
            this.RestartButton.Text = "Restart Test";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 494);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Benchmark Linq";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Button ButtonNoParallelLinq;
        private System.Windows.Forms.Button ButtonParalellLinq;
        private System.Windows.Forms.TextBox textParallelAsym;
        private System.Windows.Forms.TextBox textNoParalellAsyn;
        private System.Windows.Forms.TextBox TextStatusProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.NumericUpDown numberOfThreadInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inputNumberValues;
    }
}

