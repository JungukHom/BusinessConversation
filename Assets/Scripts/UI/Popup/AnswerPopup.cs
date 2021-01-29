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
            SetListeners();
        }

        protected new void SetListeners()
        {
            //base.SetListeners();
            btn_close.onClick.AddListener(() => OnCloseButtonClicked());
            btn_backgroundPannel.onClick.AddListener(() => OnBackgroundButtonClicked());
        }

        protected new void OnCloseButtonClicked()
        {
            Close();
        }

        protected new void OnBackgroundButtonClicked()
        {
            if (unhandledAreaSwitcher)
            {
                Close();
            }
        }
        

        public void Show()
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }

        public void Close()
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -5000);
        }

        public void InitializeWith(AnswerDataOX data)
        {
            Show();

            isOX = true;
            DisableAllOutlines();

            if (data == null)
            {
                Debug.Log($"data is null");
            }
            else
            {
                Debug.Log($"data not null");
            }

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

            //Debug.Log($"playerAnswer : {data.playerAnswer}");
            //Debug.Log($"playerAnswer type : {data.playerAnswer.GetType()}");
            //Debug.Log($"playerAnswer : {int.Parse(data.playerAnswer)}");
            EnableOutline(int.Parse(data.playerAnswer));
        }
        public void InitializeWith(AnswerDataMC data)
        {
            Show();

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

            //Debug.Log($"playerAnswer : {int.Parse(data.playerAnswer)}");
            EnableOutline(int.Parse(data.playerAnswer));
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
