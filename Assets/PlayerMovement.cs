using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;   // Ταχύτητα κίνησης
    private Rigidbody rb;
    public GameObject slugPrefab; // Το prefab για το slug
    public float shootForce = 10f; // Δυναμη Βολης

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D ή ← →
        float moveZ = Input.GetAxis("Vertical");   // W/S ή ↑ ↓
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Ρίχνει slug με Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootSlug();
        }
    }
    void ShootSlug()
    {
        // Δημιουργία slug μπροστά από τον παίκτη
        GameObject slug = Instantiate(slugPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = slug.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);

        //Το slug θα αυτοκαταστρεφεται μετα απο 3 δευτερολεπτα
        Destroy(slug, 3f);
    }
}

