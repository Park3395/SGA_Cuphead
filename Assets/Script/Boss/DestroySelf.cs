using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void dead()
    {
        Destroy(this.gameObject);
    }
}
