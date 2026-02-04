using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Rigidbody2D leftFlipper;

    [SerializeField]
    private Rigidbody2D rightFlipper;

    private HingeJoint2D leftHinge, rightHinge;

    int score, highScore;

    private void Awake()
    {
        leftHinge = leftFlipper.GetComponent<HingeJoint2D>();
        rightHinge = rightFlipper.GetComponent<HingeJoint2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {

        HandleFlipper(leftHinge, KeyCode.A, true);
        HandleFlipper(rightHinge, KeyCode.D, false);
    }

    void HandleFlipper(HingeJoint2D hinge, KeyCode key, bool isLeft)
    {
        var motor = hinge.motor;
        var rb = hinge.GetComponent<Rigidbody2D>();

        float angle = hinge.jointAngle;
        float max = hinge.limits.max;
        float min = hinge.limits.min;

        if (Input.GetKey(key))
        {
            if (angle < 60 - 0.2f)
            {
                motor.motorSpeed = isLeft ? -1500f : +1500f;
                motor.maxMotorTorque = 50000f;
            }
            else
            {
                //rb.angularVelocity += isLeft ? -1500f : +1500f;
                rb.angularVelocity = 0f;
                motor.motorSpeed = 0f;
            }
        }
        else
        {
            motor.motorSpeed = isLeft ? +800f : -800f;
            motor.maxMotorTorque = 20000f;
        }

        hinge.motor = motor;
    }
}
