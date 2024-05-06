using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    public int size = 129; // Should be 2^n + 1
    public float roughness = 0.5f;
    public int islandCount = 10; // Number of islands

    private float[,] map;

    [SerializeField] private GameObject _tileObj;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        map = new float[size, size];

        // Initialize corners
        map[0, 0] = Random.value;
        map[0, size - 1] = Random.value;
        map[size - 1, 0] = Random.value;
        map[size - 1, size - 1] = Random.value;

        DiamondSquare(0, 0, size - 1, size - 1, roughness);

        // Identify islands based on a threshold
        for (int i = 0; i < islandCount; i++)
        {
            int x = Random.Range(0, size);
            int y = Random.Range(0, size);
            if (map[x, y] > 0.5f)
            {
                // Spawn island at (x, y)
                Instantiate(_tileObj, new Vector2(x, y), Quaternion.identity);
            }
        }
    }

    void DiamondSquare(int x1, int y1, int x2, int y2, float roughness)
    {
        // Diamond step
        int midX = (x1 + x2) / 2;
        int midY = (y1 + y2) / 2;
        float avg = (map[x1, y1] + map[x1, y2] + map[x2, y1] + map[x2, y2]) / 4;
        map[midX, midY] = avg + Random.Range(-roughness, roughness);

        // Square step
        map[x1, midY] = (map[x1, y1] + map[x1, y2] + map[midX, midY]) / 3 + Random.Range(-roughness, roughness);
        map[x2, midY] = (map[x2, y1] + map[x2, y2] + map[midX, midY]) / 3 + Random.Range(-roughness, roughness);
        map[midX, y1] = (map[x1, y1] + map[x2, y1] + map[midX, midY]) / 3 + Random.Range(-roughness, roughness);
        map[midX, y2] = (map[x1, y2] + map[x2, y2] + map[midX, midY]) / 3 + Random.Range(-roughness, roughness);

        // Recursion
        if (midX - x1 > 1)
        {
            DiamondSquare(x1, y1, midX, midY, roughness * 0.5f);
            DiamondSquare(x1, midY, midX, y2, roughness * 0.5f);
            DiamondSquare(midX, y1, x2, midY, roughness * 0.5f);
            DiamondSquare(midX, midY, x2, y2, roughness * 0.5f);
        }
    }
}