﻿namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.EventSystems;

    // Valve
    using Valve.VR;

    // Project
    // Alias

    public class VRInputModule : BaseInputModule
    {
        public new Camera camera;
        public SteamVR_Input_Sources targetSource;
        public SteamVR_Action_Boolean clickAction;

        private GameObject currentObject = null;
        private PointerEventData data = null;

        protected override void Awake()
        {
            base.Awake();

            Initialize();
        }

        private void Initialize()
        {
            data = new PointerEventData(eventSystem);
        }

        public override void Process()
        {
            camera = Camera.main;
            data.Reset();
            data.position = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);

            eventSystem.RaycastAll(data, m_RaycastResultCache);
            data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
            currentObject = data.pointerCurrentRaycast.gameObject;

            m_RaycastResultCache.Clear();

            HandlePointerExitAndEnter(data, currentObject);

            if (clickAction.GetStateDown(targetSource))
            {
                ProcessPress(data);
            }

            if (clickAction.GetStateUp(targetSource))
            {
                ProcessRelease(data);
            }
        }

        public PointerEventData GetData()
        {
            return data;
        }

        private void ProcessPress(PointerEventData data)
        {
            data.pointerPressRaycast = data.pointerCurrentRaycast;
            GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);

            if (newPointerPress == null)
            {
                newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);
            }

            data.pressPosition = data.position;
            data.pointerPress = newPointerPress;
            data.rawPointerPress = currentObject;
        }

        private void ProcessRelease(PointerEventData data)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
            GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

            if (data.pointerPress == pointerUpHandler)
            {
                ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
            }

            eventSystem.SetSelectedGameObject(null);

            data.pressPosition = Vector2.zero;
            data.pointerPress = null;
            data.rawPointerPress = null;
        }
    }
}
