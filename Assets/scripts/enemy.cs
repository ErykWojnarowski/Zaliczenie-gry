using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : mover
{
    public int xp = 1;

    public float triggerLenght = 1f;
    public float chaseLenght = 3f;
    private bool chasing; // idzie za toba 
    private bool colliding; //jezeli tak to stoj i bij
    private Transform playerTransform;
    private Vector3 startingPos;
   
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    public ContactFilter2D filter;

    protected override void Start()
    {
        base.Start();
        startingPos = transform.position;
        playerTransform = GameObject.Find("player").transform;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPos) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPos) < triggerLenght)
                chasing = true;
            
            if(chasing)
            {
                if (!colliding)
                    UpdateMotor((playerTransform.position - transform.position));
            }
            else 
            {
                UpdateMotor(startingPos - transform.position);
            }

        }
        else
        {
            UpdateMotor(startingPos - transform.position);
            chasing = false;
        }
        colliding = false;
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fight" && hits[i].name == "player")
            {
                colliding = true;
            }

            hits[i] = null;
        }
       
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += xp;
        GameManager.instance.ShowText("+ " + xp + "xp ", 25, Color.green, transform.position, Vector3.up * 40, 1.0f);
    }
}
