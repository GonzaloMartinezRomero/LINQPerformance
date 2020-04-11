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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonNoParallelLinq = new System.Windows.Forms.Button();
            this.ButtonParalellLinq = new System.Windows.Forms.Button();
            this.textParallelAsym = new System.Windows.Forms.TextBox();
            this.textNoParalellAsyn = new System.Windows.Forms.TextBox();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.TextStatusProgress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inputNumberValues = new System.Windows.Forms.NumericUpDown();
            this.comboTaskCreationOpt = new System.Windows.Forms.ComboBox();
            this.numberOfThreadInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.numericDegreeOfParalelism = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboParallelModes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDegreeOfParalelism)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonNoParallelLinq
            // 
            this.ButtonNoParallelLinq.Enabled = false;
            this.ButtonNoParallelLinq.Location = new System.Drawing.Point(9, 22);
            this.ButtonNoParallelLinq.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonNoParallelLinq.Name = "ButtonNoParallelLinq";
            this.ButtonNoParallelLinq.Size = new System.Drawing.Size(98, 36);
            this.ButtonNoParallelLinq.TabIndex = 0;
            this.ButtonNoParallelLinq.Text = "Start No Parallel Linq";
            this.ButtonNoParallelLinq.UseVisualStyleBackColor = true;
            this.ButtonNoParallelLinq.Click += new System.EventHandler(this.ButtonNoParaAsyn_Click);
            // 
            // ButtonParalellLinq
            // 
            this.ButtonParalellLinq.Enabled = false;
            this.ButtonParalellLinq.Location = new System.Drawing.Point(9, 89);
            this.ButtonParalellLinq.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonParalellLinq.Name = "ButtonParalellLinq";
            this.ButtonParalellLinq.Size = new System.Drawing.Size(98, 36);
            this.ButtonParalellLinq.TabIndex = 1;
            this.ButtonParalellLinq.Text = "Start Parallel Linq";
            this.ButtonParalellLinq.UseVisualStyleBackColor = true;
            this.ButtonParalellLinq.Click += new System.EventHandler(this.ButtonParalellAsyn_Click);
            // 
            // textParallelAsym
            // 
            this.textParallelAsym.Location = new System.Drawing.Point(121, 89);
            this.textParallelAsym.Margin = new System.Windows.Forms.Padding(2);
            this.textParallelAsym.Multiline = true;
            this.textParallelAsym.Name = "textParallelAsym";
            this.textParallelAsym.ReadOnly = true;
            this.textParallelAsym.Size = new System.Drawing.Size(284, 36);
            this.textParallelAsym.TabIndex = 3;
            // 
            // textNoParalellAsyn
            // 
            this.textNoParalellAsyn.Location = new System.Drawing.Point(121, 22);
            this.textNoParalellAsyn.Margin = new System.Windows.Forms.Padding(2);
            this.textNoParalellAsyn.Multiline = true;
            this.textNoParalellAsyn.Name = "textNoParalellAsyn";
            this.textNoParalellAsyn.ReadOnly = true;
            this.textNoParalellAsyn.Size = new System.Drawing.Size(284, 36);
            this.textNoParalellAsyn.TabIndex = 2;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(393, 280);
            this.LoadDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(90, 32);
            this.LoadDataButton.TabIndex = 4;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataAsync);
            // 
            // TextStatusProgress
            // 
            this.TextStatusProgress.Location = new System.Drawing.Point(103, 128);
            this.TextStatusProgress.Margin = new System.Windows.Forms.Padding(2);
            this.TextStatusProgress.Multiline = true;
            this.TextStatusProgress.Name = "TextStatusProgress";
            this.TextStatusProgress.ReadOnly = true;
            this.TextStatusProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextStatusProgress.Size = new System.Drawing.Size(380, 138);
            this.TextStatusProgress.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.inputNumberValues);
            this.groupBox1.Controls.Add(this.comboTaskCreationOpt);
            this.groupBox1.Controls.Add(this.numberOfThreadInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LoadDataButton);
            this.groupBox1.Controls.Add(this.TextStatusProgress);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(500, 325);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Data Configuration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Task Creation Opt";
            // 
            // inputNumberValues
            // 
            this.inputNumberValues.Location = new System.Drawing.Point(103, 24);
            this.inputNumberValues.Margin = new System.Windows.Forms.Padding(2);
            this.inputNumberValues.Maximum = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.inputNumberValues.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNumberValues.Name = "inputNumberValues";
            this.inputNumberValues.Size = new System.Drawing.Size(90, 20);
            this.inputNumberValues.TabIndex = 16;
            this.inputNumberValues.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // comboTaskCreationOpt
            // 
            this.comboTaskCreationOpt.FormattingEnabled = true;
            this.comboTaskCreationOpt.Location = new System.Drawing.Point(103, 92);
            this.comboTaskCreationOpt.Name = "comboTaskCreationOpt";
            this.comboTaskCreationOpt.Size = new System.Drawing.Size(218, 21);
            this.comboTaskCreationOpt.TabIndex = 21;
            // 
            // numberOfThreadInput
            // 
            this.numberOfThreadInput.Location = new System.Drawing.Point(103, 57);
            this.numberOfThreadInput.Margin = new System.Windows.Forms.Padding(2);
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
            this.numberOfThreadInput.Size = new System.Drawing.Size(90, 20);
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
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number Threads:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Number Of Items:";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(840, 290);
            this.RestartButton.Margin = new System.Windows.Forms.Padding(2);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(90, 32);
            this.RestartButton.TabIndex = 10;
            this.RestartButton.Text = "Restart Test";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // numericDegreeOfParalelism
            // 
            this.numericDegreeOfParalelism.Location = new System.Drawing.Point(121, 19);
            this.numericDegreeOfParalelism.Margin = new System.Windows.Forms.Padding(2);
            this.numericDegreeOfParalelism.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericDegreeOfParalelism.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDegreeOfParalelism.Name = "numericDegreeOfParalelism";
            this.numericDegreeOfParalelism.Size = new System.Drawing.Size(126, 20);
            this.numericDegreeOfParalelism.TabIndex = 18;
            this.numericDegreeOfParalelism.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Degree Paralelism";
            // 
            // comboParallelModes
            // 
            this.comboParallelModes.FormattingEnabled = true;
            this.comboParallelModes.Location = new System.Drawing.Point(121, 52);
            this.comboParallelModes.Name = "comboParallelModes";
            this.comboParallelModes.Size = new System.Drawing.Size(126, 21);
            this.comboParallelModes.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Pararell Exec Mode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textParallelAsym);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ButtonParalellLinq);
            this.groupBox3.Controls.Add(this.numericDegreeOfParalelism);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboParallelModes);
            this.groupBox3.Location = new System.Drawing.Point(514, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 136);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parallel LINQ Test";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonNoParallelLinq);
            this.groupBox2.Controls.Add(this.textNoParalellAsyn);
            this.groupBox2.Location = new System.Drawing.Point(514, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 74);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LINQ No Parallel Test";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(728, 290);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 32);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 345);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "LINQ Performance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDegreeOfParalelism)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Button ButtonNoParallelLinq;
        private System.Windows.Forms.Button ButtonParalellLinq;
        private System.Windows.Forms.TextBox textParallelAsym;
        private System.Windows.Forms.TextBox textNoParalellAsyn;
        private System.Windows.Forms.TextBox TextStatusProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.NumericUpDown numberOfThreadInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inputNumberValues;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboParallelModes;
        private System.Windows.Forms.NumericUpDown numericDegreeOfParalelism;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboTaskCreationOpt;
        private System.Windows.Forms.Button buttonClose;
    }
}

