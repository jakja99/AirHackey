using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirHackey
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Home_Button_Click(object sender, EventArgs e) // 메인화면으로 돌아가기
        {
            this.Close(); //조작법 화면 끄기
        }
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            Image op = Properties.Resources.operation; //배경이미지 받아오기
            Point pt = new Point(0, 30);             //배경 이미지 위치
            e.Graphics.DrawImage(op, pt);         //배경 이미지 적용
        }
    }
}
