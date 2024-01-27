using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndShoot : MonoBehaviour
{
    public GameObject bulletProjectile;
    public GameObject BulletSpawner;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is the same as the object's z-coordinate

        // Calculate the direction from the object to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object to face the mouse pointer
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    public void FireBullet()
    {
           GameObject instantiatedObject = Instantiate(bulletProjectile, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
           Debug.Log("Fired");
    }
    
}
