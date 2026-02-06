using UnityEngine;

public class PathingMesh : MonoBehaviour
{
    public NodeRow[] grid;

    [HideInInspector]
    public static PathingMesh instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (grid == null)
            Debug.LogError("No grid");
    }

    private void Start()
    {
        CheckValidMesh();
    }

    private void CheckValidMesh()
    {
        foreach (NodeRow row in grid)
        {
            for (int i = 1; i < row.columns.Length; i++)
            {
                if (row.columns[i - 1].GetX() >= row.columns[i].GetX())
                    Debug.LogError("ERROR: invalid Mesh | " + (i-1) + " element has higher x than " + i + " element on row " + row);
            }
        }
    }

    private PathingNode ClosestElementBinarySearch(int row, float x)
    {
        PathingNode[] columns = grid[row].columns;

        int left = 0;
        int right = columns.Length - 1;

        if (x < columns[0].GetX())
            return columns[0];
        if (x > columns[right].GetX())
            return columns[right];
        
        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (x < columns[middle].GetX())
                right = middle - 1;
            else if (x > columns[middle].GetX())
                left = middle + 1;
            else
            {
                return columns[middle];
            }

        }

        // left == right + 1
        return (columns[left].GetX() - x) < (x - columns[right].GetX()) ? columns[left] : columns[right];
    }

    public PathingNode GetNextNode(int currentRow, float x)
    {
        return ClosestElementBinarySearch(currentRow + 1, x);
    }
}
