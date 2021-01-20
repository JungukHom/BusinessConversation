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

        private bool isOX = true;

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
            this.gameObject.SetActive(true);
        }

        public void Close()
        {
            this.gameObject.SetActive(false);
        }

        public void InitializeWith(AnswerDataOX data)
        {
            isOX = true;
            DisableAllOutlines();

            string number = "0" + (data.number + 1);
            if (data.number == 9)
            {
                number = "10";
            }

            txt_number.text = number;
            txt_question.text = data.question;
            txt_explain.text = data.explain;
            txt_commentary.text = data.commentary;

            pnl_ox.gameObject.SetActive(true);
            pnl_mc.gameObject.SetActive(false);

            Debug.Log($"playerAnswer : {int.Parse(data.playerAnswer)}");
            //EnableOutline(int.Parse(data.playerAnswer));
        }
        public void InitializeWith(AnswerDataMC data)
        {
            isOX = false;
            DisableAllOutlines();

            string number = "0" + (data.number + 1);
            if (data.number == 9)
            {
                number = "10";
            }

            txt_number.text = number;
            txt_question.text = data.question;
            txt_explain.text = data.explain;
            txt_commentary.text = data.commentary;

            txt_choice_01.text = data.choice_01;
            txt_choice_02.text = data.choice_02;
            txt_choice_03.text = data.choice_03;
            txt_choice_04.text = data.choice_04;

            pnl_ox.gameObject.SetActive(true);
            pnl_mc.gameObject.SetActive(false);

            Debug.Log($"playerAnswer : {int.Parse(data.playerAnswer)}");
            //EnableOutline(int.Parse(data.playerAnswer));
        }

        private void EnableOutline(int index)
        {
            Image target = isOX ? img_ox_array[index] : img_mc_array[index];
            Color color = target.color;
            color.a = 1;
            target.color = color;
        }

        private void DisableAllOutlines()
        {
            foreach(Image element in img_ox_array)
            {
                Color color = element.color;
                color.a = 0;
                element.color = color;
            }

            foreach (Image element in img_mc_array)
            {
                Color color = element.color;
                color.a = 0;
                element.color = color;
            }
        }
    }
}
