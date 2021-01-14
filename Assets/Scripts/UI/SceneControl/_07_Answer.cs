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

    public class _07_Answer : MonoBehaviour
    {
        public Button exitButton;

        public AnswerElement[] answerElements;

        private List<CSVQuizOXDataHolder> holderOX = null;
        private List<CSVQuizMCDataHolder> holderMC = null;

        private void Awake()
        {
            FindComponents();
            Initialize();
        }

        private void FindComponents()
        {
            
        }

        private void Initialize()
        {
            LoadAnswerData();
            RegisterAnswerData();
        }

        private void LoadAnswerData()
        {
            holderOX = CSVQuizOXDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
            holderMC = CSVQuizMCDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
        }

        private void RegisterAnswerData()
        {
            // TODO : i < 10 하드코딩되어있는부분 수정
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    answerElements[i].InitializeWith(new AnswerDataOX()
                    {
                        question = holderOX[i].question,
                        explain = holderOX[i].explain,
                        answerIndex = holderOX[i].answer,
                        commentary = holderOX[i].commentary
                    });
                }
                else if (i >= 3 && i < 10)
                {
                    answerElements[i].InitializeWith(new AnswerDataMC()
                    {
                        question = holderMC[i].question,
                        explain = holderMC[i].explain,
                        choice_01 = holderMC[i].choice_01,
                        choice_02 = holderMC[i].choice_02,
                        choice_03 = holderMC[i].choice_03,
                        choice_04 = holderMC[i].choice_04,
                        answerIndex = holderMC[i].answer,
                        commentary = holderMC[i].commentary
                    });
                }
                else
                {
                    // do nothing
                }
            }
        }
    }
}
