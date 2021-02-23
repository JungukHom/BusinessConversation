namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class VRUIRootBehaviour : MonoBehaviour
    {
        private Canvas rootCanvas;
        private Transform rootCanvasTransform;
        private Transform lookTarget;

        private void Awake()
        {
            FindComponents();
            Initialize();
        }

        private void FindComponents()
        {
            rootCanvas = GetComponent<Canvas>();
            rootCanvasTransform = rootCanvas.GetComponent<Transform>();
            lookTarget = Camera.main.GetComponent<Transform>();
        }

        private void Initialize()
        {
            
        }

        protected void Update()
        {
            rootCanvasTransform.LookAt(lookTarget);
        }
    }
}
