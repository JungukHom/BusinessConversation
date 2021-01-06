namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI; 

    // Project
    // Alias

    public class LessonDisplayer : MonoBehaviour
    {
        public Text txt_lesson;
        public Text txt_korean;
        public Text txt_chinese;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            ShowData(PlayingData.selectedLessonIndex);
        }

        private void ShowData(int lesson)
        {
            // TODO : CSV 형태로 변경하기
            // 현재 개발 상 편의 문제로 CSV작업을 거치치 않고 진행. 추후 CSV파일 읽는 방식로 변경할 예정

            string korean = "";
            string chinese = "";

            switch (lesson)
            {
                case 0:
                    korean = "방은 이미 예약했는데요";
                    chinese = "我已经预订房间了";
                    break;

                case 1:
                    korean = "예약하셨나요";
                    chinese = "请问您有预定吗";
                    break;

                case 2:
                    korean = "어제 예약했는데 왜 예약되어 있지 않나요?";
                    chinese = "我昨天晚上预订的,怎么会没有记录?";
                    break;

                case 3:
                    korean = "몇 시에 모닝콜 해 드릴까요?";
                    chinese = "需要几点叫醒您?";
                    break;

                case 4:
                    korean = "여기서 환전할 수 있나요?";
                    chinese = "请问这儿可以换钱吗?";
                    break;

                case 5:
                    korean = "체크아웃 체크아웃 하려고 합니다";
                    chinese = "我要退房";
                    break;

                case 6:
                    korean = "잘못된 요금청구 죄송하지만. 계산이 잘못된 거 같은데요?";
                    chinese = "对不起,是不是算错了?";
                    break;

                case 7:
                    korean = "메뉴판 좀 주세요";
                    chinese = "请给我看一下菜单";
                    break;
            }

            txt_lesson.text = "0" + (lesson + 1);
            txt_korean.text = korean;
            txt_chinese.text = chinese;
        }
    }
}
