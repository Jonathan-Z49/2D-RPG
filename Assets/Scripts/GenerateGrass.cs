using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateGrass : MonoBehaviour
{

    public Tilemap grid;
    public Tile[] grass;
    public Tile[] dirt;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = -70; x <= 70; x++)
        {
            for(int y = -30; y <= 30; y++)
            {
                grid.SetTile(new Vector3Int(x,y,0), grass[Random.Range(0,grass.Length)]);
            }
        }

        for(int x = -2; x <= 2; x++)//setting entrance dirt path
        {
            for(int y = -30; y <= -15; y++)
            {
                if(x == -2) //set left edge of path
                {  
                    grid.SetTile(new Vector3Int(x,y,0), dirt[Random.Range(0,2)]);
                    if(y == -15)    //top left corner
                    {
                        grid.SetTile(new Vector3Int(x,y,0), dirt[4]);
                    }
                }
                else if(x == 2) //set right edge of path
                {
                    grid.SetTile(new Vector3Int(x,y,0), dirt[Random.Range(2,4)]);
                    if(y == -15)    //top right corner
                    {
                        grid.SetTile(new Vector3Int(x,y,0), dirt[5]);
                    }
                }
                else    //set rest of path normal dirt blocks
                {
                    grid.SetTile(new Vector3Int(x,y,0), dirt[Random.Range(6,8)]);
                    if(y == -15)
                    {
                        grid.SetTile(new Vector3Int(x,y,0), dirt[Random.Range(8,10)]);//set top of path
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
