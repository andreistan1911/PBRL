using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    float moveForce = 6f;
    float maxSpeed = 4f;

    PathingNode targetNode;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Start()
    {
        //targetNode = getNextNode(transform.position)
    }

    private void Update()
    {
        Vector2 direction = targetNode.transform.position - transform.position;
        Vector2 forceVector = direction.normalized * moveForce;

        rb.AddForce(forceVector, ForceMode2D.Force);

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

        if (direction.magnitude < 0.2f)
        {
            //targetNode = getNextNode(transform.position)
        }
    }

    public void PushUp(float force)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Force);
    }
}
