using UnityEngine;

public class PinballCameraFollow : MonoBehaviour
{
    public Transform ball;
    public Rigidbody2D ballRb;

    [Header("Follow")]
    public float followSmooth = 0.15f;

    [Header("Arena Limits")]
    public float arenaMinY;
    public float arenaMaxY;

    Camera cam;
    float yVelocity;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
    }

    void LateUpdate()
    {
        FollowBall();
    }

    void FollowBall()
    {
        float targetY = ball.position.y;

        // clamp ca sa nu iesi din arena
        float camHalfHeight = cam.orthographicSize;
        targetY = Mathf.Clamp(
            targetY,
            arenaMinY + camHalfHeight,
            arenaMaxY - camHalfHeight
        );

        float smoothY = Mathf.SmoothDamp(
            transform.position.y,
            targetY,
            ref yVelocity,
            followSmooth
        );

        transform.position = new Vector3(
            transform.position.x,
            smoothY,
            transform.position.z
        );
    }
}
