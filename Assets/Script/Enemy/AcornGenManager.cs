using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornGenManager : MonoBehaviour
{
    public GameObject AcornPrefab;
    Vector3 pos;
    public float spawnDelay = 2.0f;
    float currTime = 0.0f;
    bool acornShoot = false;

    public float reactionDistance = 3.0f;   // 인식 거리


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        acornShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);   //몬스터와 플레이어 거리 계산
            if (dist <= reactionDistance)
            {
                currTime += Time.deltaTime;
                CreateAcorn();

                if (currTime > spawnDelay)
                {
                    acornShoot = true;
                    CreateAcorn();
                    currTime = 0.0f;
                }
            }
        } 
    }

    public void CreateAcorn()
    {
        if (acornShoot)
        {
            Instantiate(AcornPrefab, pos, Quaternion.identity);
            acornShoot = false;
        }
    }
}
