using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject SpawnBulletPrefab;
    GameObject player;
    GameObject spawnbullet;
    Animator animator;
    public string peashooterspawnanime = "PeaShooterSpawn";
    //string nowAnime;
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = transform.Find("SpawnBullet");
        spawnbullet = tr.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
        //nowAnime = peashooterspawnanime;

    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(peashooterspawnanime);
        Vector3 pos = new Vector3(spawnbullet.transform.position.x,
                                                                    spawnbullet.transform.position.y,
                                                                    transform.position.z);
    }
}
