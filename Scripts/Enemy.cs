using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Sounds
{
    public Transform castPos;
    public float basecastDist;
    const string LEFT = "left";
    const string RIGHT = "right";
    string facingDirection;
    private Rigidbody2D rb;
    public float speed;
    Vector3 baseScale;

    private void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        float vX = speed;
        if (facingDirection == LEFT)
        {
            vX = -speed;
        }

        rb.velocity = new Vector2(vX, rb.velocity.y);
        if (IsHittingWall() || IsNearEdge())
        {
            if (facingDirection == LEFT)
            {
                ChangeFactingDirection(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                ChangeFactingDirection(LEFT);
            }
        }
    }

    bool IsHittingWall()
    {
       
        bool val = false;
        float castDist = basecastDist;
        if (facingDirection == LEFT)
        {
            castDist = -basecastDist;
        }
        else
        {
            castDist = basecastDist;
        }
        Vector3 TargetPos = castPos.position;
        TargetPos.x += castDist;
        Debug.DrawLine(castPos.position, TargetPos, Color.blue);
        if (Physics2D.Linecast(castPos.position, TargetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }
        return val;
    }

    void ChangeFactingDirection(string newDirection)
    {
        PlaySound(sounds[0]);
        Vector3 newScale = baseScale;
        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if (newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }
        transform.localScale = newScale;
        facingDirection = newDirection;
    }

    bool IsNearEdge()
    {
       
        bool val = true;
        float castDist = basecastDist;
        Vector3 targetPosition = castPos.position;
        targetPosition.y -= castDist;
        Debug.DrawLine(castPos.position, targetPosition, Color.red);
        if (Physics2D.Linecast(castPos.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }
        return val;
    }
}
