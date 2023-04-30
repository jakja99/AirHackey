using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirHackey
{
    class Players
    {
        public string Name { get; set; }    //플레이어 이름 가져오기 or 내보내기
        public double WinLate { get; set; } //플레이어 승률 가져오기 or 내보내기
        public long PlayCount { get; set; } //플레이어 플레이횟수 가져오기 or 내보내기
        public long Win { get; set; }       //플레이어 승리 횟수 가져오기 or 내보내기
        public string ID { get; set; }      //플레이어 아이디 가져오기 or 내보내기
    }
}
