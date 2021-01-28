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

    public class AnswerElement : MonoBehaviour
    {
        public Button btn_wrapperButton;
        public Text txt_answer;

        public AnswerPopup pnl_answerPopup;

        public Sprite sprite_o;
        public Sprite sprite_x;

        private AnswerDataOX answerDataOX;
        private AnswerDataMC answerDataMC;

        private int currentIndex = -1;

        //private void Start()
        //{
        //    Initialize();
        //}

        //private void Initialize()
        //{
        //    SetListeners();
        //}

        public void InitializeWith(AnswerDataOX data)
        {
            this.answerDataOX = data;

            if (answerDataOX == null)
            {
                Debug.Log("null answerDataOX");
            }

            SetAnswerText(data.playerAnswer);
            SetListeners();
        }

        public void InitializeWith(AnswerDataMC data)
        {
            this.answerDataMC = data;

            if (answerDataMC == null)
            {
                Debug.Log("null answerDataMC");
            }

            SetAnswerText(data.playerAnswer);
            SetListeners();
        }

        private void SetListeners()
        {
            btn_wrapperButton.onClick.AddListener(() => { OnWrapperButtonClicked(); });
        }

        public void SetAnswerText(string playerAnswer)
        {
            txt_answer.text = playerAnswer;
        }

        private void OnWrapperButtonClicked()
        {
            bool isOX = currentIndex < 3;

            if (answerDataOX == null)
            {
                Debug.Log("null answerDataOX");
            }

            if (answerDataMC == null)
            {
                Debug.Log("null answerDataMC");
            }
            
            if (GetAnswerPopup() == null)
            {
                Debug.Log("null GetAnswerPopup");
            }

            if (isOX)
                GetAnswerPopup().InitializeWith(answerDataOX);
            else
                GetAnswerPopup().InitializeWith(answerDataMC);
        }

        private AnswerPopup GetAnswerPopup()
        {
            return this.pnl_answerPopup;
        }
    }
}
