using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxSpin = 1200f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxSpin, maxSpin);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Dead":
                Time.timeScale = 0;
                break;

            case "Bouncer":
                break;

            case "Point":
                break;

            case "Flipper":
                break;

            default:
                break;
        }
    }
}
