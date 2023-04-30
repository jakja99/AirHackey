using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

namespace AirHackey
{
    public partial class Form1 : Form
    {
        public string p1_ID;        //플레이어 아이디 확인
        public string p2_ID;        //플레이어 아이디 확인
        bool player1_login = false; //플레이어 로그인 확인
        bool player2_login = false; //플레이어 로그인 확인
        [DllImport("winmm.dll")]    //배경음을 끄기 위해 사용
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);//배경음을 끄기 위해 사용
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)   //메인화면 이미지 적용
        {
            Image main = Properties.Resources.main; //배경이미지 받아오기

            Point pt = new Point(0, 0);             //배경 이미지 위치
            e.Graphics.DrawImage(main, pt);         //배경 이미지 적용
        }
        private void New_Player1_Click(object sender, EventArgs e) // 플레이어 신규 등록
        {
            if(Player1name.Text.Trim()=="" || Player1ID.Text.Trim()=="")    // 공백 상태 검사
            {
                MessageBox.Show("이름이나 ID가 입력되지 않았습니다.");
            }
            else
            {
                if (PlayRecord.Player.Exists((x) => x.ID == Player1ID.Text.Trim())) //아이디 중복시 다시 입력, 이름은 동명이인 가능성 있음, 공백은 제거
                {
                    MessageBox.Show("동일한 ID가 있습니다.");
                    Player1name.Text = "";                                  //텍스트 박스 비우기
                    Player1ID.Text = "";                                    //텍스트 박스 비우기
                }
                else
                {
                    Players player = new Players()                          //신규 플레이어 정보 등록
                    {
                        Name = Player1name.Text.Trim(),                     //이름 등록, 공백 제거
                        ID = Player1ID.Text.Trim(),                         //아이디 등록, 공백 제거
                        PlayCount = 0,                                      //플레이 횟수 등록
                        Win = 0,                                            //이긴 횟수
                        WinLate = 0                                         //승률 계산
                    };
                    Player1name.Text = "";                                  //텍스트 박스 비우기
                    Player1ID.Text = "";                                    //텍스트 박스 비우기
                    PlayRecord.Player.Add(player);                          //플레이어 목록에 추가
                    PlayRecord.Player_Save();                               //플레이어 목록 저장
                }     
            } 
        }

        private void Player1_login_Click(object sender, EventArgs e) //플레이어 정보 불러오기
        {
            if (p1_login.Text.Trim() == "")    // 공백 상태 검사
            {
                MessageBox.Show("이름이나 ID가 입력되지 않았습니다.");
            }
            else
            {
                try
                {
                    if (PlayRecord.Player.Exists((x) => x.ID == p1_login.Text.Trim())) //아이디가 있는지 확인, 공백 제거
                    {
                        using (StreamWriter sw = new StreamWriter("../../../player1_ID.txt"))//플레이어1의 아이디 저장 위치
                        {
                            player1_login = true;           //플레이어 로그인 확인
                            sw.Write(p1_login.Text.Trim()); //플레이어 1 아이디 저장(게임 화면에서 활용), 공백 제거
                        }
                    }
                    else 
                        throw new Exception(); //아이디가 없으면 예외처리
                }
                catch (Exception)
                {
                    MessageBox.Show("등록된 플레이어가 없습니다."); //플레이어 정보가 없을 시 예외 처리
                    p1_login.Text = "";                             //텍스트 박스 비우기
                }

            }
        }

        private void New_Player2_Click(object sender, EventArgs e) //신규 플레이어 등록
        {
            if (Player2name.Text.Trim() == "" || Player2ID.Text.Trim() == "")    // 공백 상태 검사
            {
                MessageBox.Show("이름이나 ID가 입력되지 않았습니다.");
            }
            else
            {

                if (PlayRecord.Player.Exists((x) => x.ID == Player2ID.Text.Trim())) //아이디 중복시 다시 입력, 이름은 동명이인 가능성 있음, 공백 제거
                {
                    MessageBox.Show("동일한 ID가 있습니다.");
                    Player2name.Text = "";                          //텍스트 박스 비우기
                    Player2ID.Text = "";                            //텍스트 박스 비우기
                }
                else
                {
                    Players player = new Players()  //신규 플레이어 정보 등록
                    {
                        Name = Player2name.Text.Trim(),     //이름 등록, 공백 제거
                        ID = Player2ID.Text.Trim(),         //아이디 등록, 공백 제거
                        PlayCount = 0,                      //플레이 횟수 등록
                        Win = 0,                            //이긴 횟수 등록 
                        WinLate = 0                         //승률 등록
                    };
                    Player2name.Text = "";                  //텍스트 박스 비우기
                    Player2ID.Text = "";                    //텍스트 박스 비우기
                    PlayRecord.Player.Add(player);          //플레이어 목록에 추가
                    PlayRecord.Player_Save();               //플레이어 목록 저장
                }
            }
        }

        private void Player2_login_Click(object sender, EventArgs e)    //플레이어 정보 불러오기
        {
            if ( p2_login.Text.Trim() == "")    // 공백 상태 검사
            {
                MessageBox.Show("이름이나 ID가 입력되지 않았습니다.");
            }
            else
            {
                try
                {
                    if (PlayRecord.Player.Exists((x) => x.ID == p2_login.Text.Trim())) //아이디가 같은지 확인, 공백 제거
                    {
                        using (StreamWriter sw = new StreamWriter("../../../player2_ID.txt"))//플레이어2의 아이디 저장 위치
                        {
                            player2_login = true;               //플레이어 로그인 확인
                            sw.Write(p2_login.Text.Trim());     //플레이어 아이디 저장(게임 화면에서 사용)
                        }
                    }
                    else
                        throw new Exception();          //아이디가 없으면 예외처리
                }
                catch (Exception)
                {
                    MessageBox.Show("등록된 플레이어가 없습니다."); //플레이어 정보가 없을 시 예외 처리
                    p2_login.Text = "";                             //텍스트 박스 비우기
                }

            }
        }
        private void Start_Button_Click(object sender, EventArgs e) //게임시작버튼
        {
            try
            {
                if (player2_login && player1_login) //플레이어 모두 로그인 했을 시
                {
                    if(p1_login.Text.Trim() != p2_login.Text.Trim()) //동일한 플레이어가 로그인 하지 않았을 시
                    {
                        new Form2().ShowDialog();
                        mciSendString("stop MediaFile", null, 0, IntPtr.Zero); //게임을 홈버튼이 아닌 창닫기로 닫았을 때 배경음 끄기
                        p1_login.Text = "";             //텍스트 박스 비우기
                        p2_login.Text = "";             //텍스트 박스 비우기
                    }
                    else
                        throw new Exception();          //로그인 정보가 동일할 시 예외처리
                }
                else
                    throw new Exception();              //플레이어가 로그인 하지 않았을 시 예외처리
            }
            catch (Exception)
            {
                MessageBox.Show("로그인을 하지 않았거나 동일한 사용자가 로그인 되었습니다"); //예외처리
            } 
        }

        private void Record_Button_Click(object sender, EventArgs e)    //랭킹 확인 버튼
        {
            new Form3().ShowDialog();
        }

        private void Operation_Button_Click(object sender, EventArgs e) // 조작법 버튼
        {
            new Form4().ShowDialog();
        }      
    }
}
