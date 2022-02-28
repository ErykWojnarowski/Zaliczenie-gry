using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : collidable
{
    public int healingAmount = 5;

    public float healCooldown = 5.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name != "player")
            return;
        if (Time.time - lastHeal > healCooldown)
        {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmount);
        }
    }
}
