using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateWalls : MonoBehaviour
{

    public Tilemap grid;
    public Tile[] walls;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = -64; x <= 64; x++)
        {
            for(int y = -24; y <= 24; y++)
            {   
                
                if(y == -24 || y == 23)//lower half of walls
                {
                    if(x < -3 || x > 3)//dont place walls on path
                    grid.SetTile(new Vector3Int(x,y,0), walls[Random.Range(8,10)]);
                }
                if(y == -23 || y == 24)//upper upper half of walls
                {
                    if(x < -3 || x > 3)//dont place walls on path
                    grid.SetTile(new Vector3Int(x,y,0), walls[Random.Range(10,12)]);
                }
                if(x == -64)//left walls
                {
                    grid.SetTile(new Vector3Int(x,y,0), walls[Random.Range(0,4)]);
                }
                else if(x == 64)//right walls
                {
                    grid.SetTile(new Vector3Int(x,y,0), walls[Random.Range(4,8)]);
                }
                


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
