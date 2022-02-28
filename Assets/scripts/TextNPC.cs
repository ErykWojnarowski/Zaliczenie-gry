using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNPC : collidable
{
    public string message;
    private float cooldown = 1.0f;
    private float lastShout = -1.0f;

    protected override void OnCollide(Collider2D coll)
    {
        
        if(Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message, 30, Color.white, transform.position + new Vector3(0,0.32f,0), Vector3.zero, cooldown);
        }
        
        
    }
}
