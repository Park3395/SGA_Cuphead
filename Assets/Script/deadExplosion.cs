using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject self;
    [SerializeField]
    private GameObject zap;
    [SerializeField]
    private float[] randScale;

    private float explodeTime;
    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
    private void playZap()
    {
        zap.GetComponent<Animator>().Play("Explosion_zap");
    }
    // Start is called before the first frame update
    void Start()
    {
        float xrand = Random.Range(0f, randScale[0]);
        float yrand = Random.Range(0f, randScale[1]);
        this.transform.position = new Vector3(target.transform.position.x + xrand, target.transform.position.y + yrand, 0);
    }
    // Update is called once per frame
    void Update()
    {
        explodeTime += Time.deltaTime;
        if (explodeTime > 1.0f)
        {
            Instantiate(self,target.transform);
            explodeTime = 0f;
        }
    }
}
