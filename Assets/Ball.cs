using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpin = 1200f;

    private Rigidbody2D rb;
    private int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxSpin, maxSpin);
    }
}
