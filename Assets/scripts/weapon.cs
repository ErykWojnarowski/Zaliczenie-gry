using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : collidable
{
    public int damagePkt = 1;
    public float knockback = 1.0f;
    //upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    private float cooldown = 1f;
    private float lastattack;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastattack > cooldown)
            {
                lastattack = Time.time;
                Attack();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fight")
        {
            if (coll.name == "player")
                return;

            damage dmg = new damage
            {
                damagePoint = damagePkt,
                origin = transform.position,
                knockback = knockback
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
        
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}
