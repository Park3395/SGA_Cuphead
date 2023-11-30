using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowergruntController : MonoBehaviour
{
    public GameObject flowerGrunt;

    public int spawnCount = 0;
    public float spawnDelay = 5.0f;
    float currTime = 0.0f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        createFlowergrunt();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount > 0)
        {
            currTime += Time.deltaTime;

            if (currTime > spawnDelay)
            {
                createFlowergrunt();
                currTime = 0.0f;
                spawnDelay += 0.5f;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void createFlowergrunt()
    {
        Instantiate(flowerGrunt, pos, Quaternion.identity);
        spawnCount--;
    }
}
