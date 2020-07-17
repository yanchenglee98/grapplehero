using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{

    private Vector3 target;

    private float timer;

    private int sec;

    public LayerMask layermask;

    //public float maxHeight;

    //public float minHeight;

    public Transform groundDetection;
    public Transform upDetection;
    public Transform leftDetection;
    public Transform rightDetection;

    void Start()
    {
        target = ResetTarget();
        sec = ResetSec();
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2.1f, layermask);
        RaycastHit2D leftInfo = Physics2D.Raycast(leftDetection.position, Vector2.left, 2.1f, layermask);
        RaycastHit2D rightInfo = Physics2D.Raycast(rightDetection.position, Vector2.right, 2.1f, layermask);
        RaycastHit2D upInfo = Physics2D.Raycast(upDetection.position, Vector2.up, 2.1f, layermask);

        timer += Time.deltaTime;
        if (timer > sec)
        {
            target = ResetTarget();
            sec = ResetSec();
        }
        
        if (groundInfo.collider)// || transform.position.y <= minHeight)
        {
            transform.Translate(Vector2.up * 1 * Time.deltaTime);
        }

        if (leftInfo.collider)
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);
        }

        if (rightInfo.collider)
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        }
        if (upInfo.collider)// || transform.position.y >= maxHeight)
        {
            transform.Translate(Vector2.down * 1 * Time.deltaTime);
        }



        transform.Translate(target * 2 * Time.deltaTime);
    }

    Vector3 ResetTarget()
    {
        return new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
    }

    int ResetSec()
    {
        timer = 0;
        return Random.Range(1, 1);
    }
}