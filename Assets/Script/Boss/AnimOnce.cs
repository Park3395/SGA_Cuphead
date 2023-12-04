using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOnce : MonoBehaviour
{
    void activeOnce()
    {
        this.GetComponent<Animator>().SetBool("once", true);
    }
}
