using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;
    public GameObject[] tile_grass;
    public GameObject tile_wall;
    public GameObject slime;
 
    public int width = 100;
    public int height = 100;

    public int mobCount = 10;
 
    List<List<GameObject>> grid = new List<List<GameObject>>();
 
    float wall_size = 12.0f;
 
    int x_offset;  
    int y_offset; 
 
    void Start()
    {
        x_offset = (int)Random.Range(-100.0f, 100.0f);
        y_offset = (int)Random.Range(-100.0f, 100.0f);
        CreateTilesetAndGroups();
        generate();
        SpawnMobs();
    }
 
    void CreateTilesetAndGroups()
    {
        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, tile_grass[0]);
        tileset.Add(1, tile_wall);

        tile_groups = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, GameObject> prefab_pair in tileset)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector2(0, 0);
            tile_groups.Add(prefab_pair.Key, tile_group);
        }
    }
 
    void generate()
    {
        for(int x = 0; x < width; x++)
        {
            grid.Add(new List<GameObject>());
 
            for(int y = 0; y < height; y++)
            {
                int tile_id = GetId(x, y);
                CreateTile(tile_id, x, y);
            }
        }
    }
 
    int GetId(int x, int y)
    {
        float perlin = Mathf.PerlinNoise((x - x_offset) / wall_size, (y - y_offset) / wall_size);
        float clamp_perlin = Mathf.Clamp01(perlin);
        float scaled_perlin = clamp_perlin * tileset.Count;
        float clamp_scaled_perlin = Mathf.Clamp(scaled_perlin, 0.01f, 1.5f);

        if (clamp_scaled_perlin == 2)
        {
            clamp_scaled_perlin -= 1;
        }
        
        return Mathf.FloorToInt(clamp_scaled_perlin);
    }
 
    void CreateTile(int tile_id, int x, int y)
    {
        GameObject tile_prefab = tileset[tile_id];
        if (tile_id == 0)
        {
            tile_prefab = tile_grass[Random.Range(0, tile_grass.Length)];
        }
        GameObject tile_group = tile_groups[tile_id];
        GameObject tile = Instantiate(tile_prefab, tile_group.transform);
 
        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector2(x, y);
 
        grid[x].Add(tile);
    }

    void SpawnMobs(){
        while (mobCount > 0)
        {
            Transform tile_group = tile_groups[0].transform;
            int rollForTile = Mathf.FloorToInt(Random.Range(0, tile_group.childCount - 1));
            Vector2 tileToSpawnAt = tile_group.GetChild(rollForTile).transform.position;
            GameObject spawnedSlime = Instantiate(slime, tileToSpawnAt, new Quaternion(0, 0, 0, 0));
            spawnedSlime.SetActive(true);
            mobCount--;
        } 
    }
}