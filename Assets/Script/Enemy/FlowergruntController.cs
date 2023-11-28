using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowergruntController : MonoBehaviour
{
    public GameObject flowerGrunt;

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
        currTime += Time.deltaTime;

        if (currTime > spawnDelay)
        {
            createFlowergrunt();
            currTime = 0.0f;
            spawnDelay += 0.5f;
        }
    }

    public void createFlowergrunt()
    {
        Instantiate(flowerGrunt, pos, Quaternion.identity);
    }
}
