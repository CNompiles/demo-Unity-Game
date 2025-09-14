using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Slugs")]
    public GameObject[] slugs;
    public Transform firePoint; //�� ������ ��� �� ��������� �� slug
    public float shootForce = 20f;

    private int currentSlugIndex = 0; //���� slug ����� ������ 

    void Update()
    {
        //������ ��� slug 
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSlugIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSlugIndex = 1;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject slug = Instantiate(slugs[currentSlugIndex], firePoint.position, firePoint .rotation);
        Rigidbody rb = slug.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);

        // �� slug ����������������� ���� ��� 3 ������������
        Destroy(slug, 3f);
    }
}                                                                  
