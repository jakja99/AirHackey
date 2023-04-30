using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;

namespace AirHackey
{
    public partial class Form2 : Form
    {   
        public Form2()
        {
            InitializeComponent();
        }
        const int player_speed = 12; // 플레이어 이동 속도
        const int Max_Score = 1; //최대 점수(승리 점수)
        const int pwidth = 120; //플레이어 너비
        const int pheight = 120; //플레이어 높이
        const int hackey_height = 40; // 하키 높이
        const int hackey_width = 40; //하키 너비
        bool start = false; //게임 진행 여부
        struct player // 게임 속 플레이어에 관한 정보
        {
            public int x, y;//플레이어 위치
            public int score; // 플레이어 개인 점수
            public bool hit; // 중복 충돌 확인 -> 좌표에 해당할 때 여러번 충돌되는 것을 방지
        }
        Players Player1 = new Players(); //플레이어 1 정보 불러오기 위해 사용
        Players Player2 = new Players(); //플레이어 2 정보 불러오기 위해 사용
        string p1; //저장된 플레이어 1의 아이디 가져올 변수
        string p2; //저장된 플레이어 2의 아이디 가져올 변수

        player player1 = new player();  //게임 속 플레이어1 정보
        player player2 = new player();  //게임 속 플레이어2 정보

        Random random = new Random(); // 시작할 때 하키의 이동 방향 결정
        struct Hackey
        {
            public int x, y; //하키 공 위치
            public int xspeed; //하키 공 속도
            public int yspeed; //하키 공 속도
            public bool exist; // 하키 공이 존재하는지 확인
            
        }
        Hackey hackey = new Hackey(); //하키 정보
        Bitmap Area = new Bitmap(1150, 700); //게임 영역을 위한 비트맵 객체
        Bitmap background, fplayer, splayer,hackeyball;  //배경, 플레이어1,2, 하키공을 위한 비트맵 객체       
        [DllImport("User32.dll")] // 키 이벤트를 처리하기 위해 dll을 부름
        private static extern short GetKeyState(int keycode); // 키보드에 입력한 키 값을 받아오는 메서드
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback); //배경음 재생을 위해 사용      
        private void Form2_Load(object sender, EventArgs e) // 이미지를 띄우는 역할
        {
            this.Size = new Size(1150, 700); // 윈폼 크기 설정하기
            background = Properties.Resources.Background; //배경 이미지 적용하기
            fplayer = Properties.Resources.Player1; // 플레이어1 이미지 적용하기
            splayer = Properties.Resources.Player2; // 플레이어2 이미지 적용하기
            hackeyball = Properties.Resources.hackeyball; //하키 공 이미지 적용하기    
            GameStart(); //게임 시작 함수
        }
        private void GameStart() //게임 시작 함수 
        {
            using (StreamReader sr = new StreamReader("../../../player1_ID.txt")) //플레이어1정보 불러오기
            {
                p1 = sr.ReadToEnd();                                   //플레이어 1의 아이디 저장
                Player1 = PlayRecord.Player.Single((x) => x.ID == p1); //아이디를 바탕으로 플레이어 1 정보 불러오기
                PlayRecord.Player.Remove(Player1);                     //플레이어1의 정보 목록에 삭제 
            }
            using (StreamReader sr = new StreamReader("../../../player2_ID.txt")) //플레이어2정보 불러오기
            {
                p2 = sr.ReadToEnd();                                    //플레이어 2의 아이디 저장
                Player2 = PlayRecord.Player.Single((x) => x.ID == p2);  //아이디를 바탕으로 플레이어 2 정보 불러오기
                PlayRecord.Player.Remove(Player2);                      //플레이어2의 정보 목록에 삭제 
            }
            start = true; //게임 시작 확인
            player1.x = 950; //플레이어 1의 x위치
            player1.y = 365; //플레이어 1의 y위치
            player2.x = 0; //플레이어 2의 x위치
            player2.y = 365; //플레이어 2의 y위치
            player1.score = 0; //플레이어 1의 점수
            player2.score = 0; //플레이어 2의 점수
            player1.hit = false; //플레이어1과 하키의 충돌 체크(중복 충돌 방지)
            player2.hit = false; //플레이어2와 하키의 충돌 체크(중복 충돌 방지)
            hackey.x = Size.Width / 2 - 60; //하키 말의 x위치
            hackey.y = Size.Height / 2 - 50; //하키 말의 y위치
            hackey.xspeed = 0; //하키의 좌우 이동 속도
            hackey.yspeed = 0; //하키의 상하 이동 속도
            hackey.exist = true; //하키 존재 여부
            Player1.PlayCount++; //플레이어1 게임 수 증가
            Player2.PlayCount++; //플레이어2 게임 수 증가

            
            //배경음악 재생
            mciSendString("open \"" + "../../../Resources/bgm.mp3" + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);    //리소스폴더에 있는 bgm 재생
            mciSendString("play MediaFile REPEAT", null, 0, IntPtr.Zero);                                                           //반복재생
            timer1.Start(); //타이머 시작
        }
        
        private void Form2_Paint(object sender, PaintEventArgs e) //그래픽 객체를 이용해 화면에 비트맵 객체 출력
        {
            if (Area != null)
            {
                e.Graphics.DrawImage(Area, 0, 0); //DrawImage()메소드는 이미지를 출력
                // 전체적인 너비의 이미지 영역 그림
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e) //화면을 지우는 메서드
        {
            //기존에는 화면을 지우는 메서드로 이로 인해 이미지를 다시 불러올 때 깜빡임 현상이 생김
            //해당 메서드를 오버라이딩 하여 부모 클래스에 있던 메서드가 실행되지 않고 이곳에서 정의한 메서드 실행
            //메서드에는 다른 기능을 넣지 않으므로 화면을 지우지 않아 깜빡임 현상을 제거
        }
        private void timer1_Tick(object sender, EventArgs e) // 반복해서 이미지를 갱신
        {
            Graphics g = Graphics.FromImage(Area); //그래픽 객체 얻기
            Rectangle player1_hit, player2_hit, hackey_hit,check1,check2; //충돌을 판정하기 위한 사각형
            g.DrawImage(background, 0, 50); // 배경 그리기
            g.DrawImage(fplayer, player1.x, player1.y - pheight); //플레이어 1 그리기
            g.DrawImage(splayer, player2.x, player2.y - pheight); // 플레이어 2 그리기
            g.DrawImage(hackeyball, hackey.x, hackey.y); //하키 말 그리기

            if (player1.score != Max_Score && player2.score != Max_Score) //플레이어가 목표 점수에 도달하면 종료
            {
                if (hackey.xspeed == 0)     //처음 하키의 속도 or 하키가 다시 생성될 때 속도이면
                {
                    hackey.xspeed = random.Next(40) - 20; //시작할 때 하키의 이동방향 및 속도 결정
                }
                if (hackey.yspeed == 0)     //처음 하키의 속도 or 하키가 다시 생성될 때 속도이면
                {
                    hackey.yspeed = random.Next(40) - 20; //시작할 때 하키의 이동방향 및 속도 결정
                }
                
                if(hackey.x<0 || hackey.x > ClientSize.Width-70)        //하키공이 맵 범위를 벗어나면 반대로 튕기기
                {
                    hackey.xspeed = -hackey.xspeed;                     //변수의 부호를 바꾸어 반대로 향하도록 설정
                }
                if (hackey.y < 85|| hackey.y > ClientSize.Height-120)   //하키공이 맵 범위를 벗어나면 반대로 튕기기
                {
                    hackey.yspeed = -hackey.yspeed;                     //변수의 부호를 바꾸어 반대로 향하도록 설정
                }
                hackey.x = hackey.x + hackey.xspeed;                    //하키의 좌우 이동
                hackey.y = hackey.y + hackey.yspeed;                    //하키의 상하 이동
                
                //플레이어 1의 이동
                if (GetKeyState((int)Keys.Left) < 0) // 눌렸을 때 음수가 됨
                {
                    player1.x = player1.x - player_speed;   //왼쪽으로 이동
                    player1.x = Math.Max(ClientSize.Width / 2 - (pwidth / 2 + 40), player1.x); //가장 왼쪽까지 가면 더이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.Right) < 0)
                {
                    player1.x = player1.x + player_speed;   //오른쪽으로 이동
                    player1.x = Math.Min(ClientSize.Width - (pwidth + 40), player1.x); //가장 오른쪽까지 가면 더이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.Up) < 0)
                {
                    player1.y = player1.y - player_speed;   //위쪽으로 이동
                    player1.y = Math.Max(pheight + 40, player1.y); //가장 위로 가면 더 이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.Down) < 0)
                {
                    player1.y = player1.y + player_speed;   //아래쪽으로 이동
                    player1.y = Math.Min(ClientSize.Height - 75, player1.y); // 가장 밑으로 가면 더 이상 움직이면 안됨
                }

                //플레이어 2의 이동
                if (GetKeyState((int)Keys.A) < 0) // 눌렸을 때 음수가 됨
                {
                    player2.x = player2.x - player_speed;   //왼쪽으로 이동
                    player2.x = Math.Max(107 - pwidth, player2.x);//가장 왼쪽까지 가면 더이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.D) < 0)
                {
                    player2.x = player2.x + player_speed;   //오른쪽으로 이동
                    player2.x = Math.Min(ClientSize.Width / 2 - pwidth, player2.x); //가장 오른쪽까지 가면 더이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.W) < 0)
                {
                    player2.y = player2.y - player_speed;   //위쪽으로 이동
                    player2.y = Math.Max(pheight + 40, player2.y);//가장 위로 가면 더이상 움직이면 안됨
                }
                if (GetKeyState((int)Keys.S) < 0)
                {
                    player2.y = player2.y + player_speed;   //아래쪽으로 이동
                    player2.y = Math.Min(ClientSize.Height - 75, player2.y);//가장 아래로 가면 더이상 움직이면 안됨
                }
                player1_hit = new Rectangle(player1.x - pwidth/4 , player1.y-pheight, pwidth, pheight); //플레이어1 충돌 범위
                player2_hit = new Rectangle(player2.x , player2.y-(pheight-10), pwidth, pheight); //플레이어 2 충돌 범위
                hackey_hit = new Rectangle(hackey.x - hackey_height / 2, hackey.y, hackey_width, hackey_height); //하키 공 충돌 범위
                check1 = Rectangle.Intersect(player1_hit, hackey_hit); //플레이어1과 하키 충돌 판정
                check2 = Rectangle.Intersect(player2_hit, hackey_hit);//플레이어2와 하키 충돌 판정
                if (check1.IsEmpty == false&&player1.hit==false) //플레이어1과 하키가 충돌하면 하키 튕기기
                {
                    player1.hit = true; //충돌 확인
                    if (hackey.x<player1.x+60) //하키 공이 플레이어보다 왼쪽에 있으면 왼쪽으로 튕기기
                    {
                        hackey.xspeed = random.Next(5) + 20;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.xspeed =  - Math.Abs(hackey.xspeed); //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                    else if(hackey.x>player1.x+60)//하키 공이 플레이어보다 오른쪽에 있으면 오른쪽으로 튕기기
                    {
                        hackey.xspeed = random.Next(5) + 20;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.xspeed = Math.Abs(hackey.xspeed);    //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                    if(hackey.y<player1.y-40)//하키 공이 플레이어보다 위쪽에 있으면 위쪽으로 튕기기
                    {
                        hackey.yspeed = random.Next(5) + 10;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.yspeed = -Math.Abs(hackey.yspeed);   //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                    else if(hackey.y > player1.y - 40)//하키 공이 플레이어보다 아래쪽에 있으면 아래쪽으로 튕기기
                    {
                        hackey.yspeed = random.Next(5) + 10;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.yspeed = Math.Abs(hackey.yspeed);    //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                }
                else if(check1.IsEmpty == true) // 중복 충돌 방지(계속 부딫히면 충돌범위 내부에서 방향이 계속 바뀜)
                {
                    player1.hit = false;
                }
                if (check2.IsEmpty == false&&player2.hit == false)//플레이어2와 하키가 충돌하면 하키 튕기기
                {
                    player2.hit = true;//충돌 확인
                    if (hackey.x < player2.x + 50)//하키 공이 플레이어보다 왼쪽에 있으면 왼쪽으로 튕기기
                    {
                        hackey.xspeed = random.Next(5) + 20;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.xspeed = -Math.Abs(hackey.xspeed);   //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                    else if (hackey.x > player2.x + 50)//하키 공이 플레이어보다 오른쪽에 있으면 오른쪽으로 튕기기
                    {
                        hackey.xspeed = random.Next(5) + 20;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.xspeed = Math.Abs(hackey.xspeed);    //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)

                    }
                    if (hackey.y < player2.y - 50)//하키 공이 플레이어보다 위쪽에 있으면 위쪽으로 튕기기
                    {
                        hackey.yspeed = random.Next(5) + 10;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.yspeed = -Math.Abs(hackey.yspeed);   //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                    else if (hackey.y > player2.y - 50)//하키 공이 플레이어보다 아래쪽에 있으면 아래쪽으로 튕기기
                    {
                        hackey.yspeed = random.Next(5) + 10;        //플레이어와 부딫치면 속도랜덤 변경
                        hackey.yspeed = Math.Abs(hackey.yspeed);    //절대값을 이용하여 튕기는 방향 고정(절대값을 사용하지 않을 때 플레이어 뒤에서 부딫히면 튕기지 않고 계속 나아감)
                    }
                }
                else if (check2.IsEmpty == true) // 중복 충돌 방지(계속 부딫히면 충돌범위 내부에서 방향이 계속 바뀜)
                {
                    player2.hit = false;
                }
                if(hackey.y > 220 && hackey.y < 400)
                {
                    if (hackey.x < 10) //하키공이 골대 안에 들어가면 점수 획득
                    {
                        player1.score++;            //플레이어 1 점수증가
                        hackey.exist = false;       //하키 제거
                    }
                    else if (hackey.x > 1050) //하키공이 골대 안에 들어가면 점수 획득
                    {
                        player2.score++;            //플레이어 2 점수증가
                        hackey.exist = false;       //하키 제거
                    }
                }
                if(hackey.exist ==false) // 하키가 골대안에 들어가면 위치 중앙에 재배치
                {
                    hackey.x = Size.Width / 2 - 60;     //하키 말의 x위치
                    hackey.y = Size.Height / 2 - 50;    //하키 말의 y위치
                    hackey.xspeed = 0;                  //이동 멈춤
                    hackey.yspeed = 0;                  //이동 멈춤
                    hackey.exist = true;                //하키 생성
                }
                Font _font = new System.Drawing.Font(new FontFamily("휴먼둥근헤드라인"), 30, FontStyle.Bold); //글자 폰트, 사이즈, 형식 선택
                g.DrawString(Player2.Name, _font, Brushes.White, new PointF(200, 70));          //플레이어 2 이름 표시
                g.DrawString(Player1.Name, _font, Brushes.White, new PointF(800, 70));          //플레이어 1 이름 표시
                g.DrawString( player2.score.ToString() + "   :   " + player1.score.ToString(), _font, Brushes.White, new PointF(430, 70)); //플레이어들의 점수 표시         
            }
            else
            {
                if (player1.score == Max_Score) //플레이어 승리 횟수 증가
                {
                    Player1.Win++;
                }
                else if (player2.score == Max_Score) //플레이어 승리 횟수 증가
                {
                    Player2.Win++;
                }
                GameStop(); //게임 종료
                timer1.Stop(); //타이머 스탑하기                
            }
            Invalidate(); // 화면 업데이트
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (start == false) //게임이 끝나면 재시작 가능
            {
                switch (e.KeyCode)
                {
                    case Keys.Space: //스페이스바 감지
                        GameStart(); //다시 시작
                        break;
                }
            }
        }

        private void GameStop() //게임 종료하는 함수
        {            
            start = false;                  //게임 끝 확인
            Graphics g = Graphics.FromImage(Area); //그래픽 객체 얻기
            g.DrawImage(background, 0, 50); // 배경 그리기
            Font _font = new System.Drawing.Font(new FontFamily("휴먼둥근헤드라인"), 30, FontStyle.Bold); //글자 폰트, 사이즈, 형식 선택
            g.DrawString(Player2.Name, _font, Brushes.White, new PointF(200, 70));  //플레이어 2이름 표시
            g.DrawString(Player1.Name, _font, Brushes.White, new PointF(800, 70));  //플레이어 1이름 표시
            g.DrawString(player2.score.ToString() + "   :   " + player1.score.ToString(), _font, Brushes.White, new PointF(430, 70)); //플레이어들의 점수 표시
            Player1.WinLate = (double)Player1.Win / (double)Player1.PlayCount * 100; //플레이어 1의 승률 계산
            Player2.WinLate = (double)Player2.Win / (double)Player2.PlayCount * 100; //플에이어 2의 승률 계산 
            g.DrawString("스페이스바를 누르면 다시 시작합니다.", _font, Brushes.White, new PointF(200, 200));   //다시 시작하는 방법 알림
            PlayRecord.Player.Add(Player1); //갱신된 플레이어 정보 추가
            PlayRecord.Player.Add(Player2); //갱신된 플레이어 정보 추가
            PlayRecord.Player_Save();       //플레이어 정보 저장
        }
        
        private void Home_Button_Click(object sender, EventArgs e)//메인메뉴로 돌아가기
        {
            if (start == false) //게임 중에는 돌아가지 못함
            {
                this.Close(); //게임화면 끄기
            }
        }
        private void Record_Button_Click(object sender, EventArgs e)//랭킹 확인하기
        {
            if (start == false) //게임 중에는 불러오지 못함
            {
                mciSendString("stop MediaFile", null, 0, IntPtr.Zero); //배경음 끄기
                new Form3().ShowDialog();   // 대전기록 불러오기
                this.Close();               // 대전 기록을 본 후 메인화면으로 이동해야 함
            }
        }
    }
}
