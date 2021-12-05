using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collactable : collidable
{
    //logic
    protected bool collected;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
            OnCollect();
    }
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
