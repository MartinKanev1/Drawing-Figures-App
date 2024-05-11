namespace tryoutsmth
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_rectangle = new Button();
            btn_color = new Button();
            btn_fil = new Button();
            btn_move = new Button();
            btn_del = new Button();
            btn_square = new Button();
            btn_Ellipse = new Button();
            btn_help = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_rectangle
            // 
            btn_rectangle.Image = (Image)resources.GetObject("btn_rectangle.Image");
            btn_rectangle.Location = new Point(129, 3);
            btn_rectangle.Name = "btn_rectangle";
            btn_rectangle.Size = new Size(87, 81);
            btn_rectangle.TabIndex = 0;
            btn_rectangle.Text = "Rectangle";
            btn_rectangle.UseVisualStyleBackColor = true;
            btn_rectangle.Click += btn_rectangle_Click;
            // 
            // btn_color
            // 
            btn_color.Image = (Image)resources.GetObject("btn_color.Image");
            btn_color.Location = new Point(419, 6);
            btn_color.Name = "btn_color";
            btn_color.Size = new Size(85, 78);
            btn_color.TabIndex = 1;
            btn_color.Text = "Color";
            btn_color.UseVisualStyleBackColor = true;
            btn_color.Click += btn_color_Click;
            // 
            // btn_fil
            // 
            btn_fil.Image = (Image)resources.GetObject("btn_fil.Image");
            btn_fil.Location = new Point(510, 6);
            btn_fil.Name = "btn_fil";
            btn_fil.Size = new Size(83, 78);
            btn_fil.TabIndex = 2;
            btn_fil.Text = "Fill";
            btn_fil.TextAlign = ContentAlignment.BottomCenter;
            btn_fil.UseVisualStyleBackColor = true;
            btn_fil.Click += btn_fil_Click;
            // 
            // btn_move
            // 
            btn_move.Image = (Image)resources.GetObject("btn_move.Image");
            btn_move.Location = new Point(599, 6);
            btn_move.Name = "btn_move";
            btn_move.Size = new Size(79, 78);
            btn_move.TabIndex = 3;
            btn_move.Text = "Move";
            btn_move.UseVisualStyleBackColor = true;
            btn_move.Click += btn_move_Click;
            // 
            // btn_del
            // 
            btn_del.Image = (Image)resources.GetObject("btn_del.Image");
            btn_del.Location = new Point(684, 6);
            btn_del.Name = "btn_del";
            btn_del.Size = new Size(78, 78);
            btn_del.TabIndex = 4;
            btn_del.Text = "Delete";
            btn_del.UseVisualStyleBackColor = true;
            btn_del.Click += btn_del_Click;
            // 
            // btn_square
            // 
            btn_square.Image = (Image)resources.GetObject("btn_square.Image");
            btn_square.Location = new Point(24, 3);
            btn_square.Name = "btn_square";
            btn_square.Size = new Size(99, 78);
            btn_square.TabIndex = 5;
            btn_square.Text = "Square";
            btn_square.UseVisualStyleBackColor = true;
            btn_square.Click += btn_square_Click;
            // 
            // btn_Ellipse
            // 
            btn_Ellipse.Image = (Image)resources.GetObject("btn_Ellipse.Image");
            btn_Ellipse.Location = new Point(231, 6);
            btn_Ellipse.Name = "btn_Ellipse";
            btn_Ellipse.Size = new Size(88, 75);
            btn_Ellipse.TabIndex = 6;
            btn_Ellipse.Text = "Ellipse";
            btn_Ellipse.UseVisualStyleBackColor = true;
            btn_Ellipse.Click += btn_Ellipse_Click;
            // 
            // btn_help
            // 
            btn_help.Image = (Image)resources.GetObject("btn_help.Image");
            btn_help.Location = new Point(768, 6);
            btn_help.Name = "btn_help";
            btn_help.Size = new Size(81, 78);
            btn_help.TabIndex = 7;
            btn_help.Text = "Help";
            btn_help.TextAlign = ContentAlignment.BottomCenter;
            btn_help.UseVisualStyleBackColor = true;
            btn_help.Click += btn_help_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(btn_square);
            panel1.Controls.Add(btn_help);
            panel1.Controls.Add(btn_rectangle);
            panel1.Controls.Add(btn_del);
            panel1.Controls.Add(btn_Ellipse);
            panel1.Controls.Add(btn_move);
            panel1.Controls.Add(btn_color);
            panel1.Controls.Add(btn_fil);
            panel1.Location = new Point(62, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(852, 92);
            panel1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 579);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseDoubleClick += Form1_MouseDoubleClick;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_rectangle;
        private Button btn_color;
        private Button btn_fil;
        private Button btn_move;
        private Button btn_del;
        private Button btn_square;
        private Button btn_Ellipse;
        private Button btn_help;
        private Panel panel1;
    }
}