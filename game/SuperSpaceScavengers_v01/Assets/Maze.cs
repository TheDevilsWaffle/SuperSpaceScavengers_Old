using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

    public int sizeX;
    public int sizeZ;
    public float generationStepDelay = 0.01f;

    public MazeCell cellPrefab;

    private MazeCell[,] cells;

	// Use this for initialization
	void Start()
    {
	
	}
	
	public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[sizeX, sizeZ];
        
        for(int x = 0; x < sizeX; ++x)
        {
            for(int z = 0; z < sizeZ; ++z)
            {
                yield return delay;
                CreateCell(x, z);
            }
        }
    }

    public void CreateCell(int x_, int z_)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x_, z_] = newCell;
        newCell.name = "Maze Cell " + x_ + ", " + z_;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x_ - sizeX * 0.5f + 0.5f,
                                                      0f,
                                                      z_ - sizeZ * 0.5f + 0.5f);
    }
}
