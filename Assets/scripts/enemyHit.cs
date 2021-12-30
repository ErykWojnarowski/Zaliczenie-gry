using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : collidable
{
    public int damage= 1;
    public float knockback=2;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fight" && coll.name == "player")
        {
            damage dmg = new damage
            {
                damagePoint = damage,
                origin = transform.position,
                knockback = knockback
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
