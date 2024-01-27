using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public float angle = 90f;
    public float BulletDamage = 5f;
    void Start()
    {
        
    }
    private void Update()
    {
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        Vector2 velocity = direction * speed;
        // Move the object in its X direction when it is created
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Assuming the object has a Rigidbody2D component
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            // If the object doesn't have a Rigidbody2D, you can use Transform for simple movement
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<BeeController>().BeeHealth -= BulletDamage;
        }
    }
}
