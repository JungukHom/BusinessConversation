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
            
        }

        private void RegisterAnswerData()
        {
            // TODO : i < 10 하드코딩되어있는부분 수정
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {

                }
                else if (i >= 3 && i < 10)
                {

                }
                else
                {
                    // do nothing
                }
            }
        }
    }
}
