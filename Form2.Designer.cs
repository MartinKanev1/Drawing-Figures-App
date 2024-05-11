namespace tryoutsmth
{
    partial class Form2
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
            btn_okay = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // btn_okay
            // 
            btn_okay.Location = new Point(323, 355);
            btn_okay.Name = "btn_okay";
            btn_okay.Size = new Size(113, 66);
            btn_okay.TabIndex = 0;
            btn_okay.Text = "Okay";
            btn_okay.UseVisualStyleBackColor = true;
            btn_okay.Click += btn_okay_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 99);
            label1.Name = "label1";
            label1.Size = new Size(201, 20);
            label1.TabIndex = 1;
            label1.Text = "Move - you can move figures";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 141);
            label2.Name = "label2";
            label2.Size = new Size(549, 20);
            label2.TabIndex = 2;
            label2.Text = "Delete - you can delete 1 by 1 figures/or you can delete all of the selected figures";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 184);
            label3.Name = "label3";
            label3.Size = new Size(278, 20);
            label3.TabIndex = 3;
            label3.Text = "Color- you can  choose an outlined color";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 228);
            label4.Name = "label4";
            label4.Size = new Size(233, 20);
            label4.TabIndex = 4;
            label4.Text = "Fill- you can  choose a color to fill";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 270);
            label5.Name = "label5";
            label5.Size = new Size(331, 20);
            label5.TabIndex = 5;
            label5.Text = "Double click on a figure to open the resize menu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 308);
            label6.Name = "label6";
            label6.Size = new Size(284, 20);
            label6.TabIndex = 6;
            label6.Text = "Shift + left Click = Shows the figure's area";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_okay);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_okay;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}