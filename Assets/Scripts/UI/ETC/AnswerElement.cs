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

        public AnswerPopup pnl_answerPoup;

        private AnswerData answerData;

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
            pnl_answerPoup.Show();
            pnl_ansewrPopup.InitializeWith(answerData);
        }
    }
}
