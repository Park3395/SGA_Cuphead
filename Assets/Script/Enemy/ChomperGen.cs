using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperGen : MonoBehaviour
{
    public GameObject chomper;

    public float reactionDistance = 0.0f;

    public float spawnDelay = 2.0f;
    float currTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        currTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState != "playing")
        {
            Destroy(gameObject);
        }

        if (RngManager.GameIsPaused)
        {
            float nowTime = currTime;
            currTime = nowTime;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float dist = Vector2.Distance(transform.position, player.transform.position);   //몬스터와 플레이어 거리 계산
                if (dist < reactionDistance)
                {
                    currTime += Time.deltaTime;

                    if (currTime > spawnDelay)
                    {
                        createChomper();
                        currTime = 0.0f;
                    }
                }
            }
        }
    }

    public void createChomper()
    {
        Instantiate(chomper, transform.position, Quaternion.identity);
    }
}
