using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mover : Fighter
{
    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;

    protected RaycastHit2D hit;

    protected float xSpeed = 1f;
    protected float ySpeed = 0.75f;
    //public float MoveSpeed = 5f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed,0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //knockback
        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, recoverySpeed);
        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * MoveSpeed, 0);
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("player", "blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("player", "blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}