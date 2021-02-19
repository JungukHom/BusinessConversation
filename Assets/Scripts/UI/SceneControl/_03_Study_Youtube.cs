namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class _03_Study_Youtube : MonoBehaviour
    {
        public Button btn_next;

        public YoutubeSettings youtubeSettings;
        public YoutubePlayer youtubePlayer;
        public RawImage videoRenderer;

        private void Awake()
        {
            Initialize();

            // Add escpopup event
            ESCPopup.RegisterEvent(true, () =>
            {
                youtubePlayer.Pause();
            });
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            SetListeners();
        }

        private void SetListeners()
        {
            btn_next.onClick.AddListener(() => { OnNextButtonClicked(); });
        }

        private void OnNextButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                SceneLoader.LoadScene(SceneName._04_Study_Read);
            });
        }

        public void SkipTime(float time)
        {
            youtubeSettings.videoPlayer.time += time;
            youtubeSettings.audioPlayer.time += time;
        }

        public void VideoStop()
        {
            youtubeSettings.Seek(0);
            videoRenderer.color = Color.black;
        }

        public void PlayVideoColorSet()
        {
            videoRenderer.color = Color.white;
        }
    }
}