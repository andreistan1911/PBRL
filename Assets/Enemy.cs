using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveForce = 6f;
    public float maxSpeed = 4f;

    int currentMeshRow;
    PathingNode targetNode;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Start()
    {
        targetNode = PathingMesh.Instance.GetNextNode(-1, transform.position.x);
        currentMeshRow = 0;
    }

    private void Update()
    {
        Vector2 direction = targetNode.transform.position - transform.position;
        Vector2 forceVector = direction.normalized * moveForce;

        rb.AddForce(forceVector, ForceMode2D.Force);

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

       // Debug.Log(direction.magnitude);
        if (direction.magnitude < 0.2f)
        {
            targetNode = PathingMesh.Instance.GetNextNode(currentMeshRow, transform.position.x);
            currentMeshRow++;
        }
    }

    public void PushUp(float force)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Force);
    }
}
