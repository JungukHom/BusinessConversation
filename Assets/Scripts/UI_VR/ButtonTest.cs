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

    public class ButtonTest : MonoBehaviour
    {
        public Button button;

        private void Awake()
        {
            FindComponents();
            Initialize();
        }

        private void FindComponents()
        {
            button = GetComponent<Button>();
        }

        private void Initialize()
        {
            button.onClick.AddListener(() => OnButtonClicked());
            print("Initialized");
        }

        private void OnButtonClicked()
        {
            Debug.Log("123123123123123");
        }
    }
}
