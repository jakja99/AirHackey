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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();             
            dataGridView1.DataSource = null; //데이터 그리드 새로고침
            dataGridView1.DataSource = PlayRecord.Player;   //데이터 그리드 XML로 저장
        }

        private void Home_Button_Click(object sender, EventArgs e) // 메인화면으로 돌아가기
        {
            
            this.Close(); //대전기록 끄기
        }
    }
}
