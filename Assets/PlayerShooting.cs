using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Slugs")]
    public GameObject[] slugs;
    public Transform firePoint; //το σημειο που θα εμφανιζει το slug
    public float shootForce = 20f;
    public float slugLifetime = 3f;

    private int currentSlugIndex = 0; //Ποιο slug ειναι ενεργο 
    private int CurrentSlugIndex { get { return currentSlugIndex; } }


    void Update()
    {
        //Αλλαγη του slug 
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSlugIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSlugIndex = 1;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            currentSlugIndex++;
            if (currentSlugIndex >= slugs.Length) currentSlugIndex = 0;
        }
        else if (scroll < 0f)
        {
            currentSlugIndex--;
            if (currentSlugIndex < 0) currentSlugIndex = slugs.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    { 
        if (slugs == null || slugs.Length == 0) return;
        if (firePoint == null) return;

        GameObject slug = Instantiate(slugs[currentSlugIndex], firePoint.position, firePoint .rotation);

        Collider slugCol = slug.GetComponent<Collider>();
        Collider playerCol = GetComponent<Collider>();
        if (slugCol != null && playerCol != null) 
            Physics.IgnoreCollision(slugCol, playerCol);

        Rigidbody rb = slug.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}                                                                  
