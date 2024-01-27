using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShootProj : MonoBehaviour
{
    public Animator animAttack;
    public GameObject myProjectile;
    public float timebtwShots = 20f;
    public float timercount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timercount += Time.fixedDeltaTime;
        if (timercount > timebtwShots)
        {
            timercount = 0f;
            HornetShoot();
        }
    }
    void HornetShoot()
    {
        animAttack.SetTrigger("isAttacking");
        Instantiate(myProjectile, transform.position, Quaternion.identity);
    }
}
