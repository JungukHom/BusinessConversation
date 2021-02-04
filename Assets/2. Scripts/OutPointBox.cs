using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutPointBox : MonoBehaviour
{
    int sceneIndex = 0;

    public void TriggerEnter()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
