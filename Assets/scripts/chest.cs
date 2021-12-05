using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : collactable
{
    public Sprite chest_empty;
    public int goldAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = chest_empty;
            Debug.Log("Grant " + goldAmount + " gold!");
        }
        
    }
}
