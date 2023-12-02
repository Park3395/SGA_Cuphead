using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearsound : MonoBehaviour
{
    public AudioClip[] gameClearSound;    // ���� Ŭ���� �� ����

    // Start is called before the first frame update
    void Start()
    {
        AudioSource sound = GetComponent<AudioSource>();
        if (sound != null)
        {
            int random = Random.Range(0, gameClearSound.Length);
            sound.PlayOneShot(gameClearSound[random]);
        }
    }
}
