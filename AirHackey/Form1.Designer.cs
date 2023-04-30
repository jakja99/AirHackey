
namespace AirHackey
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
            this.Start_Button = new System.Windows.Forms.Button();
            this.Record_Button = new System.Windows.Forms.Button();
            this.Operation_Button = new System.Windows.Forms.Button();
            this.Player_1 = new System.Windows.Forms.GroupBox();
            this.p1_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Player1_login = new System.Windows.Forms.Button();
            this.New_Player1 = new System.Windows.Forms.Button();
            this.Player1ID = new System.Windows.Forms.TextBox();
            this.Player1name = new System.Windows.Forms.TextBox();
            this.Player2_ID = new System.Windows.Forms.Label();
            this.player1_name = new System.Windows.Forms.Label();
            this.Player_2 = new System.Windows.Forms.GroupBox();
            this.p2_login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Player2_login = new System.Windows.Forms.Button();
            this.New_Player2 = new System.Windows.Forms.Button();
            this.Player2ID = new System.Windows.Forms.TextBox();
            this.Plater2_ID = new System.Windows.Forms.Label();
            this.Player2name = new System.Windows.Forms.TextBox();
            this.Player2_name = new System.Windows.Forms.Label();
            this.Player_1.SuspendLayout();
            this.Player_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(444, 478);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(129, 46);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "시작하기";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Record_Button
            // 
            this.Record_Button.Location = new System.Drawing.Point(444, 530);
            this.Record_Button.Name = "Record_Button";
            this.Record_Button.Size = new System.Drawing.Size(129, 46);
            this.Record_Button.TabIndex = 1;
            this.Record_Button.Text = "랭킹";
            this.Record_Button.UseVisualStyleBackColor = true;
            this.Record_Button.Click += new System.EventHandler(this.Record_Button_Click);
            // 
            // Operation_Button
            // 
            this.Operation_Button.Location = new System.Drawing.Point(444, 582);
            this.Operation_Button.Name = "Operation_Button";
            this.Operation_Button.Size = new System.Drawing.Size(129, 46);
            this.Operation_Button.TabIndex = 2;
            this.Operation_Button.Text = "조작법";
            this.Operation_Button.UseVisualStyleBackColor = true;
            this.Operation_Button.Click += new System.EventHandler(this.Operation_Button_Click);
            // 
            // Player_1
            // 
            this.Player_1.Controls.Add(this.p1_login);
            this.Player_1.Controls.Add(this.label1);
            this.Player_1.Controls.Add(this.Player1_login);
            this.Player_1.Controls.Add(this.New_Player1);
            this.Player_1.Controls.Add(this.Player1ID);
            this.Player_1.Controls.Add(this.Player1name);
            this.Player_1.Controls.Add(this.Player2_ID);
            this.Player_1.Controls.Add(this.player1_name);
            this.Player_1.Location = new System.Drawing.Point(829, 236);
            this.Player_1.Name = "Player_1";
            this.Player_1.Size = new System.Drawing.Size(243, 216);
            this.Player_1.TabIndex = 3;
            this.Player_1.TabStop = false;
            this.Player_1.Text = "플레이어 1";
            // 
            // p1_login
            // 
            this.p1_login.Location = new System.Drawing.Point(44, 177);
            this.p1_login.Name = "p1_login";
            this.p1_login.Size = new System.Drawing.Size(100, 23);
            this.p1_login.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // Player1_login
            // 
            this.Player1_login.Location = new System.Drawing.Point(6, 137);
            this.Player1_login.Name = "Player1_login";
            this.Player1_login.Size = new System.Drawing.Size(75, 23);
            this.Player1_login.TabIndex = 5;
            this.Player1_login.Text = "로그인";
            this.Player1_login.UseVisualStyleBackColor = true;
            this.Player1_login.Click += new System.EventHandler(this.Player1_login_Click);
            // 
            // New_Player1
            // 
            this.New_Player1.Location = new System.Drawing.Point(6, 22);
            this.New_Player1.Name = "New_Player1";
            this.New_Player1.Size = new System.Drawing.Size(75, 23);
            this.New_Player1.TabIndex = 4;
            this.New_Player1.Text = "신규등록";
            this.New_Player1.UseVisualStyleBackColor = true;
            this.New_Player1.Click += new System.EventHandler(this.New_Player1_Click);
            // 
            // Player1ID
            // 
            this.Player1ID.Location = new System.Drawing.Point(44, 88);
            this.Player1ID.Name = "Player1ID";
            this.Player1ID.Size = new System.Drawing.Size(100, 23);
            this.Player1ID.TabIndex = 3;
            // 
            // Player1name
            // 
            this.Player1name.Location = new System.Drawing.Point(44, 59);
            this.Player1name.Name = "Player1name";
            this.Player1name.Size = new System.Drawing.Size(100, 23);
            this.Player1name.TabIndex = 2;
            // 
            // Player2_ID
            // 
            this.Player2_ID.AutoSize = true;
            this.Player2_ID.Location = new System.Drawing.Point(6, 88);
            this.Player2_ID.Name = "Player2_ID";
            this.Player2_ID.Size = new System.Drawing.Size(19, 15);
            this.Player2_ID.TabIndex = 1;
            this.Player2_ID.Text = "ID";
            // 
            // player1_name
            // 
            this.player1_name.AutoSize = true;
            this.player1_name.Location = new System.Drawing.Point(6, 59);
            this.player1_name.Name = "player1_name";
            this.player1_name.Size = new System.Drawing.Size(31, 15);
            this.player1_name.TabIndex = 0;
            this.player1_name.Text = "이름";
            // 
            // Player_2
            // 
            this.Player_2.Controls.Add(this.p2_login);
            this.Player_2.Controls.Add(this.label2);
            this.Player_2.Controls.Add(this.Player2_login);
            this.Player_2.Controls.Add(this.New_Player2);
            this.Player_2.Controls.Add(this.Player2ID);
            this.Player_2.Controls.Add(this.Plater2_ID);
            this.Player_2.Controls.Add(this.Player2name);
            this.Player_2.Controls.Add(this.Player2_name);
            this.Player_2.Location = new System.Drawing.Point(829, 468);
            this.Player_2.Name = "Player_2";
            this.Player_2.Size = new System.Drawing.Size(243, 216);
            this.Player_2.TabIndex = 4;
            this.Player_2.TabStop = false;
            this.Player_2.Text = "플레이어 2";
            // 
            // p2_login
            // 
            this.p2_login.Location = new System.Drawing.Point(44, 174);
            this.p2_login.Name = "p2_login";
            this.p2_login.Size = new System.Drawing.Size(100, 23);
            this.p2_login.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // Player2_login
            // 
            this.Player2_login.Location = new System.Drawing.Point(6, 137);
            this.Player2_login.Name = "Player2_login";
            this.Player2_login.Size = new System.Drawing.Size(75, 23);
            this.Player2_login.TabIndex = 7;
            this.Player2_login.Text = "로그인";
            this.Player2_login.UseVisualStyleBackColor = true;
            this.Player2_login.Click += new System.EventHandler(this.Player2_login_Click);
            // 
            // New_Player2
            // 
            this.New_Player2.Location = new System.Drawing.Point(6, 22);
            this.New_Player2.Name = "New_Player2";
            this.New_Player2.Size = new System.Drawing.Size(75, 23);
            this.New_Player2.TabIndex = 6;
            this.New_Player2.Text = "신규등록";
            this.New_Player2.UseVisualStyleBackColor = true;
            this.New_Player2.Click += new System.EventHandler(this.New_Player2_Click);
            // 
            // Player2ID
            // 
            this.Player2ID.Location = new System.Drawing.Point(44, 95);
            this.Player2ID.Name = "Player2ID";
            this.Player2ID.Size = new System.Drawing.Size(100, 23);
            this.Player2ID.TabIndex = 5;
            // 
            // Plater2_ID
            // 
            this.Plater2_ID.AutoSize = true;
            this.Plater2_ID.Location = new System.Drawing.Point(6, 95);
            this.Plater2_ID.Name = "Plater2_ID";
            this.Plater2_ID.Size = new System.Drawing.Size(19, 15);
            this.Plater2_ID.TabIndex = 3;
            this.Plater2_ID.Text = "ID";
            // 
            // Player2name
            // 
            this.Player2name.Location = new System.Drawing.Point(44, 59);
            this.Player2name.Name = "Player2name";
            this.Player2name.Size = new System.Drawing.Size(100, 23);
            this.Player2name.TabIndex = 4;
            // 
            // Player2_name
            // 
            this.Player2_name.AutoSize = true;
            this.Player2_name.Location = new System.Drawing.Point(6, 59);
            this.Player2_name.Name = "Player2_name";
            this.Player2_name.Size = new System.Drawing.Size(31, 15);
            this.Player2_name.TabIndex = 2;
            this.Player2_name.Text = "이름";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 761);
            this.Controls.Add(this.Player_2);
            this.Controls.Add(this.Player_1);
            this.Controls.Add(this.Operation_Button);
            this.Controls.Add(this.Record_Button);
            this.Controls.Add(this.Start_Button);
            this.Name = "Form1";
            this.Text = "메인화면";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Player_1.ResumeLayout(false);
            this.Player_1.PerformLayout();
            this.Player_2.ResumeLayout(false);
            this.Player_2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Record_Button;
        private System.Windows.Forms.Button Operation_Button;
        private System.Windows.Forms.GroupBox Player_1;
        private System.Windows.Forms.Button Player1_login;
        private System.Windows.Forms.Button New_Player1;
        private System.Windows.Forms.TextBox Player1ID;
        private System.Windows.Forms.TextBox Player1name;
        private System.Windows.Forms.Label Player2_ID;
        private System.Windows.Forms.Label player1_name;
        private System.Windows.Forms.GroupBox Player_2;
        private System.Windows.Forms.Button Player2_login;
        private System.Windows.Forms.Button New_Player2;
        private System.Windows.Forms.TextBox Player2ID;
        private System.Windows.Forms.Label Plater2_ID;
        private System.Windows.Forms.TextBox Player2name;
        private System.Windows.Forms.Label Player2_name;
        private System.Windows.Forms.TextBox p1_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox p2_login;
        private System.Windows.Forms.Label label2;
    }
}

