using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace AirHackey
{
    class PlayRecord
    {
        public static List<Players> Player = new List<Players>(); //플레이어 정보를 리스트로 제작

        static PlayRecord()
        {
            Player_Load();  //플레이어 정보 불러오기
        }
        public static void Player_Load() //기록된 플레이어 정보 불러오기
        {
            try
            {
                string player_record = File.ReadAllText(@"./Player.xml");   //플레이어 정보 모두 불러오기
                XElement player_element = XElement.Parse(player_record);    //불러온 정보를 XML 요소로 변환
                Player = (from item in player_element.Descendants("player") //XML에서 불러온 플레이어 정보 클래스에 저장
                    select new Players()
                    {
                        Name = item.Element("name").Value,                      //이름 클래스에 저장
                        WinLate = double.Parse(item.Element("winlate").Value),  //승률 클래스에 저장                 
                        PlayCount = long.Parse(item.Element("count").Value),     //게임 횟수 클래스에 저장
                        Win = long.Parse(item.Element("win").Value),             //승리 횟수 클래스에 저장
                        ID = item.Element("id").Value                           //아이디 클래스에 저장

                    }).ToList<Players>();
            }
            catch (FileNotFoundException exception) // 처음 실행 시 파일이 존재하지 않기 때문에 빈 파일 생성
            {
                Player_Save();  
            }
        }
        public static void Player_Save() //플레이어 정보 기록하기
        {
            string player_list = "";                                        //플레이어 정보 초기화
            var ranking = from item in Player
                          orderby item.WinLate descending                   //플레이어 정보 승률 기준으로 내림차순 정렬(랭킹을 나타내기 위함)
                          select item;
            player_list += "<players>\n";                                   //플레이어 정보 입력 시작부분
            foreach(var item in ranking)                                    //플레이어 정보를 랭킹순으로 XML파일에 저장
            {
                player_list += "<player>\n";                                //플레이어 구분
                player_list += "<name>" + item.Name + "</name>\n";          //플레이어 이름 XML파일에 저장
                player_list += "<winlate>" + item.WinLate + "</winlate>\n"; //승률 XML파일에 저장
                player_list += "<count>" + item.PlayCount + "</count>\n";   //게임횟수 XML파일에 저장
                player_list += "<win>" + item.Win + "</win>\n";             //이긴 횟수 XML파일에 저장
                player_list += "<id>" + item.ID + "</id>\n";                //아이디 XML파일에 저장
                player_list += "</player>\n";                               //플레이어 구분
            }  
            player_list += "</players>";                                    //플레이어 정보 입력 끝부분
            File.WriteAllText(@"./Player.xml", player_list);                //파일 저장
            Player_Load();                                                  //데이터 그리드 뷰 랭킹을 실시간으로 갱신하기 위해 사용
        }

    }
}
