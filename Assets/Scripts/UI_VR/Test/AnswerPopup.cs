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

    public class AnswerPopup : MonoBehaviour
    {
        public Button closeButton;

        private void Awake()
        {
            FindComponents();
            Initialize();
            AddListeners();
        }

        private void FindComponents()
        {
            
        }

        private void Initialize()
        {
            
        }

        private void AddListeners()
        {
            closeButton.onClick.AddListener(() => OnCloseButtonClicked());
        }

        private void OnCloseButtonClicked()
        {
            this.gameObject.SetActive(false);
        }
    }
}
