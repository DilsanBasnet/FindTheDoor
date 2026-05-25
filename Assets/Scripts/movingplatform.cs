using System.Drawing;
using UnityEditor.Callbacks;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform PointA, PointB;
    public float speed;
    private Vector3  targetPoint;

    private void Start()
    {
        targetPoint = PointB.position;
    }
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        if(transform.position == targetPoint)
        {
            targetPoint = (targetPoint == PointA.position) ? PointB.position : PointA.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           collision.gameObject.transform.parent = null; 
        }
    }

}
