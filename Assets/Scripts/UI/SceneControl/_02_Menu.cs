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
        public Button btn_learning;
        public Button btn_experience;
        public Button btn_quiz;
        public Button btn_close_detailSelectPopup;

        private int selectedLessonIndex = -1;

        private void Awake()
        {
            Initialize();
            SetListeners();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();

            btn_select_completed.interactable = false;
        }

        private void SetListeners()
        {
            for (int index = 0; index < btn_lessons.Length; index++)
            {
                btn_lessons[index].onClick.AddListener(() => { OnLessonButtonClicked(index); });
            }

            btn_select_completed.onClick.AddListener(() => { OnSelectCompletedButtonClicked(); });

            btn_learning.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName._03_Study_Youtube); });
            btn_experience.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName.GetLessonStringWithIndex(PlayingData.selectedLessonIndex), true); });
            btn_quiz.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName._06_Quiz); });
            btn_close_detailSelectPopup.onClick.AddListener(() => { OnDetailSelectPopupCloseButtonClicked(); });
        }

        private void OnLessonButtonClicked(int index)
        {
            if (selectedLessonIndex == -1) // if lesson is not selected
            {
                pnl_explain.gameObject.SetActive(false);
                pnl_content.gameObject.SetActive(true);
            }

            ActiveSelectCompletedButton();
            selectedLessonIndex = index;

            ShowLearningTargetData();
        }

        private void OnSelectCompletedButtonClicked()
        {
            PlayingData.selectedLessonIndex = selectedLessonIndex;
            pnl_select_destination.gameObject.SetActive(true);
        }

        private void ActiveSelectCompletedButton()
        {
            btn_select_completed.interactable = true;
        }

        private void OnMoveSceneButtonClicked(string sceneName, bool async = false)
        {

            Screen.FadeOut(() =>
            {
                if (async)
                    SceneLoader.LoadSceneAsync(sceneName);
                else
                    SceneLoader.LoadScene(sceneName);
            });
        }

        private void OnDetailSelectPopupCloseButtonClicked()
        {
            SetDetailSelectPopupActive(false);
        }

        private void ShowLearningTargetData()
        {
            DeactivateLearningTargetLists();
        }

        private void DeactivateLearningTargetLists()
        {
            foreach (Text text in txt_learningTargets)
            {
                text.gameObject.SetActive(false);
            }
        }

        private void SetDetailSelectPopupActive(bool active)
        {
            pnl_select_destination.gameObject.SetActive(active);
        }
    }
}