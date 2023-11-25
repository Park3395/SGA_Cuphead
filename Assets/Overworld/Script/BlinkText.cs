using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    Text flashingText;

    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(Blink_Text());
    }

    public IEnumerator Blink_Text()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "Press Any Button";
            yield return new WaitForSeconds(2.0f);
        }
    }
}
