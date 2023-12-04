using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowergruntController : MonoBehaviour
{
    public GameObject flowerGrunt;

    public float startDelay = 0.0f;
    public int spawnCount = 0;
    public float spawnDelay = 5.0f;
    float currTime = 0.0f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        Invoke("createFlowergrunt", startDelay);
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
            currTime += Time.deltaTime;

            if (spawnCount > 0 && currTime > startDelay)
            {
                currTime = 0.0f;
                startDelay = 0.0f;
                if (currTime > spawnDelay)
                {
                    createFlowergrunt();
                    currTime = 0.0f;
                    spawnDelay += 0.5f;
                }
            }
            else if (spawnCount <= 0)
            {
                Destroy(gameObject);
            }
        }            
    }

    public void createFlowergrunt()
    {
        Instantiate(flowerGrunt, pos, Quaternion.identity);
        spawnCount--;
    }
}
