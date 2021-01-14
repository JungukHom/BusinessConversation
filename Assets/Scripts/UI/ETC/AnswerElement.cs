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

        private AnswerDataOX answerDataOX;
        private AnswerDataMC answerDataMC;

        private int currentIndex = -1;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetListeners();
        }

        public void InitializeWith(AnswerDataOX data)
        {

        }

        public void InitializeWith(AnswerDataMC data)
        {

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
            pnl_answerPopup.Show();
            pnl_answerPopup.InitializeWith(currentIndex < 3 ? answerDataOX : answerDataMC);
        }
    }
}
