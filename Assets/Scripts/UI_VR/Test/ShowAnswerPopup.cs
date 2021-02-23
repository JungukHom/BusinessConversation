namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    // Project
    // Alias

    public class ShowAnswerPopup : MonoBehaviour
    {
        public Button button;
        public Transform popup;

        private void Awake()
        {
            FindComponents();
            Initialize();
            AddListeners();
        }

        private void FindComponents()
        {
            button = GetComponentInChildren<Button>();
        }

        private void Initialize()
        {
            
        }

        private void AddListeners()
        {
            button.onClick.AddListener(() => OnButtonClicked());
        }

        private void OnButtonClicked()
        {
            popup.gameObject.SetActive(true);
        }
    }
}
