using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : collidable
{
    public int[] damagePkt = {1 , 2,3,4,5,6,7,8 };
    public float[] knockback = {1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f };
    //upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    private Animator anim;
    private float cooldown = 0.5f;
    private float lastattack;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
                damagePoint = damagePkt[weaponLevel],
                origin = transform.position,
                knockback = knockback[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
        
    }

    private void Attack()
    {
        anim.SetTrigger("hit");
    }
    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
    public void SetWeapon(int level)   
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
