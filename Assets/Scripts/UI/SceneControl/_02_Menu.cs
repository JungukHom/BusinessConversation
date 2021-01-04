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

    public class _02_Menu : MonoBehaviour
    {
        [Header("우측 판넬 설명/내용")]
        public Transform pnl_explain;
        public Transform pnl_content;

        [Header("레슨 선택 버튼")]
        public Button[] btn_lessons;

        [Header("pnl_content - 레슨 텍스트")]
        public Text txt_lesson;

        [Header("pnl_content - 내용 텍스트")]
        public Text[] txt_learningTargets;

        [Header("선택 완료 버튼")]
        public Button btn_select_completed;

        [Header("학습내용 세부선택 팝업")]
        public Transform pnl_select_destination;

        private int selectedLessonIndex = -1;

        private void Awake()
        {
            Initialize();
            SetListeners();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
        }

        private void SetListeners()
        {
            for (int index = 0; index < btn_lessons.Length; index++)
            {
                btn_lessons[index].onClick.AddListener(() => { OnLessonButtonClicked(index); });
            }

            btn_select_completed.onClick.AddListener(() => { OnSelectCompletedButtonClicked(); });
        }

        private void OnLessonButtonClicked(int index)
        {
            ActiveSelectCompletedButton();
            selectedLessonIndex = index;
        }

        private void OnSelectCompletedButtonClicked()
        {
            PlayingData.selectedLessonIndex = selectedLessonIndex;
            pnl_select_destination.gameObject.SetActive(true);

            // string nextSceneName = SceneName.GetLessonStringWithIndex(PlayingData.selectedLessonIndex);
        }

        private void ActiveSelectCompletedButton()
        {
            btn_select_completed.interactable = true;
        }

    }
}