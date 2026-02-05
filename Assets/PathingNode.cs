using UnityEngine;

public class PathingNode : MonoBehaviour
{
    private float x;

    private void Awake()
    {
        x = transform.position.x;
    }

    public float GetX()
    {
        return x;
    }
}
