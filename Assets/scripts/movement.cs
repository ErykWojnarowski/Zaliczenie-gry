using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : Fighter
{
    private BoxCollider2D boxCollider;
    
    private Vector3 moveDelta;
   
    private RaycastHit2D hit;
    //public float MoveSpeed = 5f;
     
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
   
    private void Update()                   
    {                                            
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        
        moveDelta = new Vector3(x, y, 0);
        
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale= new Vector3(-1, 1, 1);
        }
        
        //if (Input.GetAxisRaw("Horizontal") > 0.01f)
        //    transform.rotation =new Quaternion(0,0,0,0);
        //else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        //    transform.rotation = new Quaternion(0, 180, 0,0);
    
        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * MoveSpeed, 0);
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("player","blocking"));
        if(hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime , 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("player", "blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime , 0, 0);
        }



    }

}
