using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movingplatform : MonoBehaviour
{
    public Transform PointA, PointB;
    public float speed;
    Vector3  targetPoint;

    private void Start()
    {
        targetPoint = PointB.position;
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, PointA.position)< 0.05f)
        {
            targetPoint = PointB.position;
        }
        if(Vector2.Distance(transform.position, PointB.position) < 0.05f)
        {
            targetPoint = PointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
