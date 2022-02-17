using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : collactable
{
    public Sprite Chest_empty;
    public int goldAmount = 0;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = Chest_empty;
            GameManager.instance.gold += goldAmount;
            GameManager.instance.ShowText("+ " + goldAmount + " gold!",25,Color.yellow,transform.position, Vector3.down * 30, 1.5f);
        }
        
    }
}
