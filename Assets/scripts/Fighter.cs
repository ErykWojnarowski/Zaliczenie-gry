using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float recoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    //dmg for all

    protected virtual void ReceiveDamage(damage dmg) 
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damagePoint;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.knockback;

            GameManager.instance.ShowText(dmg.damagePoint.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }

    }
    protected virtual void Death()
    {

    }
}
