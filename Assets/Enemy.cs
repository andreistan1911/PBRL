using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    private float moveForce = 6f;

    int currentMeshRow;
    PathingNode targetNode;

    public EnemyStats stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Start()
    {
        targetNode = PathingMesh.instance.GetNextNode(-1, transform.position.x);
        currentMeshRow = 0;

        stats.speed = 0.8f;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeHealthDamage();
            TakeShieldDamage();
        }
    }

    private void TakeShieldDamage()
    {
        if (stats.shield > 0)
            stats.shield--;

        // TODO: visual update la casca
    }

    private void TakeHealthDamage()
    {
        if (stats.shield == 0)
        {
            if (stats.health > 0)
                stats.health--;

            if (stats.health <= 0)
                Destroy(gameObject);
        }

        // TODO: visual upgrade la gras
    }

    private void Move()
    {
        Vector2 direction = targetNode.transform.position - transform.position;
        Vector2 forceVector = direction.normalized * moveForce;

        rb.AddForce(forceVector, ForceMode2D.Force);

        if (rb.linearVelocity.magnitude > stats.speed)
            rb.linearVelocity = rb.linearVelocity.normalized * stats.speed;

        // Debug.Log(direction.magnitude);
        if (direction.magnitude < 0.2f)
        {
            targetNode = PathingMesh.instance.GetNextNode(currentMeshRow, transform.position.x);
            currentMeshRow++;
        }
    }

    public void PushUp(float force)
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Force);
    }
}
