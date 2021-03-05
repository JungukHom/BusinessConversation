namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    // Project
    // Alias

    public class ESCPopup : Popup
    {
        public Button btn_resume;
        public Button btn_restart;
        public Button btn_settings;
        public Button btn_stop;
        public Button btn_quit;

        public GameObject pnl_content_esc;
        public GameObject pnl_content_settings;

        public Action enableCallback = null;
        public Action disableCallback = null;

        private bool isDisplaying = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool RegisterEvent(bool visibility, Action callback)
        {
            ESCPopup popup = GameObject.Find("ESCPopup")?.GetComponent<ESCPopup>();
            if (popup)
            {
                if (visibility)
                    popup.enableCallback += callback;
                else
                    popup.disableCallback += callback;

                return true;
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private new void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetESCPopopVisibillity(isDisplaying = !isDisplaying);
            }
        }

        private new void Initialize()
        {
            SetListeners();
            //SetESCPopopVisibillity(false);
        }

        private new void SetListeners()
        {
            btn_resume.onClick.AddListener(() => { OnResumeButtonClicked(); });
            btn_restart.onClick.AddListener(() => { OnRestartButtonClicked(); });
            btn_settings.onClick.AddListener(() => { OnSettingsButtonClicked(); });
            btn_stop.onClick.AddListener(() => { OnStopButtonClicked(); });
            btn_quit.onClick.AddListener(() => { OnQuitButtonClicked(); });
        }

        private void OnResumeButtonClicked()
        {
            SetESCPopopVisibillity(false);
        }

        private void OnRestartButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                //SceneLoader.LoadSceneAsync(SceneName.GetLessonStringWithIndex(PlayingData.selectedLessonIndex));
                if (currentSceneName.Contains("05"))
                {
                    SceneLoader.LoadSceneAsync(currentSceneName);
                }
                else
                {
                    SceneLoader.LoadScene(currentSceneName);
                }
                
            });
        }

        private void OnSettingsButtonClicked()
        {
            // TODO : Implement Settings Dialog
        }

        private void OnStopButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                if (PlayingData.isHotel)
                    SceneLoader.LoadScene(SceneName._02_Menu_Hotel);
                else
                    SceneLoader.LoadScene(SceneName._02_Menu_Airport);
            });
        }

        private void OnQuitButtonClicked()
        {
            MessagePopup.Show("정말 종료하시겠습니까?",
                () =>
                {
                    Screen.FadeOut(() =>
                    {
                        Application.Quit();
                    });
                }, null);
        }

        private void SetESCPopopVisibillity(bool visibility)
        {
            try
            {
                // disable camera and player move
                FindObjectOfType<CameraMove>().enabled = !visibility;
                //FindObjectOfType<PCPlayerController>().enabled = !visibility;
            }
            catch { }

            // set cursor state
            bool isGameScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("05");
            if (isGameScene)
            {
                Cursor.visible = visibility;
                Cursor.lockState = (visibility ? CursorLockMode.None : CursorLockMode.Locked);
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }            

            // set pannel visibility
            pnl_content_esc.SetActive(visibility);
        }
    }
}