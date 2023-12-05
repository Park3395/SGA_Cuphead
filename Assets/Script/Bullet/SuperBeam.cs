using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBeam : MonoBehaviour
{
    public GameObject superbeamPrefeb; //�峭�� ��(�⺻ ��)
    bool isSuperBeam = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.C))
        {
            SuperBeamAttack();
        }
        */
        //SuperBeamAttack();
    }

    public void SuperBeamAttack()
    {
        if(isSuperBeam == false)
        {
            isSuperBeam = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;

            //�Ѿ��� ĳ���� �������� ȸ��
            Quaternion r = Quaternion.Euler(0, 0, angleZ);

            GameObject superbeam = Instantiate(superbeamPrefeb, transform.position, r);

            Invoke("SuperBeamStop", 2.5f);
            Destroy(superbeam, 2.5f);

        }
    }

    public void SuperBeamStop()
    {
        isSuperBeam = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("������ ���ۺ� ����");
            
            
        }

    }
}
