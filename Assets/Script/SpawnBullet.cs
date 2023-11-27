using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    //단적으로 현재 이 스폰불렛은 필요가 없는 스크립트긴 하다. 어떻게 써야하나?
    public GameObject SpawnBulletPrefab;
    GameObject player;
    GameObject PeaShooterSpawn;
    Animator animator;
    public string peashooterspawnanime = "PeaShooterSpawn";
    //string nowAnime;
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = transform.Find("PeaShooterSpawn");
        PeaShooterSpawn = tr.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
        //nowAnime = peashooterspawnanime;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            animator.Play(peashooterspawnanime);
        }
        
        Vector3 pos = new Vector3(PeaShooterSpawn.transform.position.x,
                                                                    PeaShooterSpawn.transform.position.y,
                                                                    transform.position.z);

    }
}
