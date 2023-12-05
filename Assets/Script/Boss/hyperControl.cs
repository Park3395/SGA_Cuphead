using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperControl : BulletBase
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");

        Vector2 direction1 = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
        float angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, speed * Time.deltaTime);
        this.transform.rotation = rotation;

        togo = target.transform.position - this.transform.position;
        togo.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed* Time.deltaTime* togo.x, -speed* Time.deltaTime, 0));
    }
}
