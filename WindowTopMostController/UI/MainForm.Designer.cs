namespace WindowTopMostController
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listWindows = new System.Windows.Forms.ListBox();
            this.chkTopMous = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listWindows
            // 
            this.listWindows.FormattingEnabled = true;
            this.listWindows.Location = new System.Drawing.Point(12, 36);
            this.listWindows.Name = "listWindows";
            this.listWindows.Size = new System.Drawing.Size(322, 433);
            this.listWindows.TabIndex = 0;
            this.listWindows.SelectedIndexChanged += new System.EventHandler(this.listWindows_SelectedIndexChanged);
            // 
            // chkTopMous
            // 
            this.chkTopMous.AutoSize = true;
            this.chkTopMous.Location = new System.Drawing.Point(12, 481);
            this.chkTopMous.Name = "chkTopMous";
            this.chkTopMous.Size = new System.Drawing.Size(96, 17);
            this.chkTopMous.TabIndex = 1;
            this.chkTopMous.Text = "Always on Top";
            this.chkTopMous.UseVisualStyleBackColor = true;
            this.chkTopMous.CheckedChanged += new System.EventHandler(this.chkTopMous_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(241, 475);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Update";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "You can pin multiple windows at once.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkTopMous);
            this.Controls.Add(this.listWindows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "WindowStick";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listWindows;
        private System.Windows.Forms.CheckBox chkTopMous;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
    }
}

