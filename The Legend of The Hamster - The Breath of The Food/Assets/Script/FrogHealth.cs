using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogHealth : MonoBehaviour
{
    public float healthPoints = 200f;
    public bool isDead = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( healthPoints < 0 && isDead == false )
        {
            isDead = true;
            StartCoroutine(BlastAnim());
        }
    }
    IEnumerator BlastAnim()
    {
        //anim.SetTrigger("Blast");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level Kitchen");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullets"))
        {
            healthPoints = healthPoints - collision.GetComponent<MoveBullet>().BulletDamage;
        }
    }
}
