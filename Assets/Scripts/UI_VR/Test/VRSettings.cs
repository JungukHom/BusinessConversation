namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class VRSettings : MonoBehaviour
    {
        private void Awake()
        {
            FindComponents();
            Initialize();
        }

        private void FindComponents()
        {
            
        }

        private void Initialize()
        {
            //UnityEngine.Screen.SetResolution(1920, 1080, true);
        }
    }
}
