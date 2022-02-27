using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : mover 
{
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //DontDestroyOnLoad(gameObject);
    }
    protected override void ReceiveDamage(damage dmg)
    {
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        UpdateMotor(new Vector3(x, y, 0));
    }
    public void OnLevelUp()
    {
        maxHitpoints += 5;
        hitpoints = maxHitpoints;
    }
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }
    public void Heal(int healingAmount)
    {
        hitpoints += healingAmount;
        if (hitpoints == maxHitpoints)
            return;
        if (hitpoints > maxHitpoints)
            hitpoints = maxHitpoints;
        
        GameManager.instance.ShowText("+" + healingAmount.ToString() + " hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitPointChange();
    }
    
}
