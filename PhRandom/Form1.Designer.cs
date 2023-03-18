
namespace PhRandom
{
    partial class Form1
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
            this.MapCombo = new System.Windows.Forms.ComboBox();
            this.DiffCombo = new System.Windows.Forms.ComboBox();
            this.ChallengeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RandomList = new System.Windows.Forms.ListBox();
            this.ChaChange = new System.Windows.Forms.Button();
            this.DiffChange = new System.Windows.Forms.Button();
            this.MapChange = new System.Windows.Forms.Button();
            this.RandomButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapCombo
            // 
            this.MapCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapCombo.Location = new System.Drawing.Point(132, 12);
            this.MapCombo.Name = "MapCombo";
            this.MapCombo.Size = new System.Drawing.Size(274, 32);
            this.MapCombo.Sorted = true;
            this.MapCombo.TabIndex = 0;
            // 
            // DiffCombo
            // 
            this.DiffCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiffCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiffCombo.Location = new System.Drawing.Point(132, 51);
            this.DiffCombo.Name = "DiffCombo";
            this.DiffCombo.Size = new System.Drawing.Size(274, 32);
            this.DiffCombo.Sorted = true;
            this.DiffCombo.TabIndex = 1;
            // 
            // ChallengeCombo
            // 
            this.ChallengeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChallengeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChallengeCombo.ItemHeight = 24;
            this.ChallengeCombo.Location = new System.Drawing.Point(132, 89);
            this.ChallengeCombo.Name = "ChallengeCombo";
            this.ChallengeCombo.Size = new System.Drawing.Size(274, 32);
            this.ChallengeCombo.Sorted = true;
            this.ChallengeCombo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Карта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сложность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Задание";
            // 
            // RandomList
            // 
            this.RandomList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandomList.FormattingEnabled = true;
            this.RandomList.ItemHeight = 20;
            this.RandomList.Location = new System.Drawing.Point(15, 127);
            this.RandomList.Name = "RandomList";
            this.RandomList.Size = new System.Drawing.Size(548, 124);
            this.RandomList.TabIndex = 8;
            // 
            // ChaChange
            // 
            this.ChaChange.Image = global::PhRandom.Properties.Resources.edit;
            this.ChaChange.Location = new System.Drawing.Point(411, 89);
            this.ChaChange.Name = "ChaChange";
            this.ChaChange.Size = new System.Drawing.Size(32, 32);
            this.ChaChange.TabIndex = 11;
            this.ChaChange.UseVisualStyleBackColor = true;
            this.ChaChange.Click += new System.EventHandler(this.ChaChange_Click);
            // 
            // DiffChange
            // 
            this.DiffChange.Image = global::PhRandom.Properties.Resources.edit;
            this.DiffChange.Location = new System.Drawing.Point(411, 51);
            this.DiffChange.Name = "DiffChange";
            this.DiffChange.Size = new System.Drawing.Size(32, 32);
            this.DiffChange.TabIndex = 10;
            this.DiffChange.UseVisualStyleBackColor = true;
            this.DiffChange.Click += new System.EventHandler(this.DiffChange_Click);
            // 
            // MapChange
            // 
            this.MapChange.Image = global::PhRandom.Properties.Resources.edit;
            this.MapChange.Location = new System.Drawing.Point(411, 12);
            this.MapChange.Name = "MapChange";
            this.MapChange.Size = new System.Drawing.Size(32, 32);
            this.MapChange.TabIndex = 9;
            this.MapChange.UseVisualStyleBackColor = true;
            this.MapChange.Click += new System.EventHandler(this.MapChange_Click);
            // 
            // RandomButton
            // 
            this.RandomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandomButton.Image = global::PhRandom.Properties.Resources.ghost;
            this.RandomButton.Location = new System.Drawing.Point(449, 12);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(114, 109);
            this.RandomButton.TabIndex = 6;
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 263);
            this.Controls.Add(this.ChaChange);
            this.Controls.Add(this.DiffChange);
            this.Controls.Add(this.MapChange);
            this.Controls.Add(this.RandomList);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChallengeCombo);
            this.Controls.Add(this.DiffCombo);
            this.Controls.Add(this.MapCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "ФазмоГен";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MapCombo;
        private System.Windows.Forms.ComboBox DiffCombo;
        private System.Windows.Forms.ComboBox ChallengeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.ListBox RandomList;
        private System.Windows.Forms.Button MapChange;
        private System.Windows.Forms.Button DiffChange;
        private System.Windows.Forms.Button ChaChange;
    }
}

