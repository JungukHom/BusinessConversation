namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    // Project
    // Alias

    public class MessagePopup : Popup
    {
        public Text txt_content;
        public Button btn_ok;
        public Button btn_cancel;

        private static readonly string PrefabPath = "Prefabs/Popups/MessagePopup";

        private string contentText;
        private Action okCallback;
        private Action cancelCallback;

        public static MessagePopup GetOrCreateInstance(string contentText, Action okCallback = null, Action cancelCallback = null)
        {
            GameObject prefab = Resources.Load(PrefabPath) as GameObject;
            MessagePopup component = prefab.GetComponent<MessagePopup>();
            component.SetData(contentText, okCallback, cancelCallback);

            return component;
        }

        protected new void Awake()
        {
            base.Awake();
            Initialize();
        }

        protected new void Initialize()
        {
            base.Initialize();

            SetSortingLayerToHighest();
            txt_content.text = contentText;
        }

        protected new void SetListeners()
        {
            base.SetListeners();

            btn_ok.onClick.AddListener(() => OnOkButtonClicked());
            btn_cancel.onClick.AddListener(() => OnCancelButtonClicked());
        }

        private void SetData(string contentText, Action okCallback, Action cancelCallback)
        {
            this.contentText = contentText;
            this.okCallback = okCallback;
            this.cancelCallback = cancelCallback;
        }

        private void OnOkButtonClicked()
        {
            okCallback?.Invoke();
            Destroy(this.gameObject);
        }

        private void OnCancelButtonClicked()
        {
            cancelCallback?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
