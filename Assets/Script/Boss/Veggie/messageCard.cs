using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageCard : MonoBehaviour
{
    [SerializeField]
    private GameObject scenemanager;

    private void hide()
    {
        this.gameObject.SetActive(false);
    }

    private void activeOver()
    {
        scenemanager.GetComponent<VeggieSceneManager>().activeOverUI();
    }
}
