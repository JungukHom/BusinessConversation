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

    public class AnswerPopup : Popup
    {
        public Text txt_number;
        public Text txt_question;
        public Text txt_explain;
        public Text txt_commentary;

        public Transform pnl_ox;

        public Transform pnl_mc;
        public Text txt_choice_01;
        public Text txt_choice_02;
        public Text txt_choice_03;
        public Text txt_choice_04;

        public Image[] img_ox_array;
        public Image[] img_mc_array;

        protected new void Awake()
        {
            base.Awake();
            Initialize();
        }

        protected new void Initialize()
        {
            base.Initialize();
        }

        protected new void SetListeners()
        {
            base.SetListeners();
        }

        public void Show()
        {

        }

        public void Close()
        {

        }

        public void InitializeWith(AnswerDataOX data)
        {
            txt_number.text = data.correctAnswer;
        }
        public void InitializeWith(AnswerDataMC data)
        {

        }
    }
}
