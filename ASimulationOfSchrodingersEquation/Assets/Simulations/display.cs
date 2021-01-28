using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : ProbFunc
{

    public GameObject dot;
    private GameObject master;
    //private int Lgrid = L * 10; 
    private GameObject[,] grid = new GameObject[30, 30];

    // Start is called before the first frame update
    void Start()
    {
        master = this.gameObject;
        Vector3 placeAt = Vector3.zero;
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                grid[i,j] = Instantiate(dot, new Vector3(j + 1, 0, i + 1), new Quaternion(0, 0, 0, 0));
                grid[i,j].transform.parent = master.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float masterHeight = master.transform.position.y;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                float x = grid[i, j].transform.localPosition.x;
                float y = grid[i, j].transform.localPosition.z;
                float height = waveFunctionProbability(x / 30, y / 30);
                grid[i,j].transform.localPosition = new Vector3(x, height * 1.8f, y);
                grid[i, j].GetComponent<ParticleSystem>().startColor = new Color(height / 2, height, height * 2, 0.5f);
            }
        }
    }
}
