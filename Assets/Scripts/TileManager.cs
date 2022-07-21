using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles;
    private GameObject playerTransform;
    public float spawnZ = 0.0f;
    public float tileLength;
    public int amountOfTileOnScreen = 3;
    private float safeZon = 15f;
    private int lastPrefabIndex = 0;
   
    PlayerController playerRef;
    public float minuend;
    GameObject go;
    public Floor[] floor;
    public UnlockFloors unlockFloors;
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        playerRef = playerTransform.GetComponent<PlayerController>();

        
    }

    public void StartSpawning()
    {
        for (int i = 0; i < amountOfTileOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);

            }
            else
            {
                SpawnTile();

            }
        }
    }

    // Update is called once per frame
    private void Update()
    {

       
        if (playerTransform.transform.position.z  > (spawnZ - amountOfTileOnScreen) - 12f)
        {
            SpawnTile();

            DeleteTile();
          
        }

    }

    private void SpawnTile(int prefabIndex = -1)
    {
       
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
      //  applyFloor();

        go.transform.SetParent(transform);

           
          go.transform.position = Vector3.forward * spawnZ;
       
      
        if(minuend < 2.3f)
        {
            go.transform.localScale -= new Vector3(minuend, 0, minuend);
        }
        else
        {
            go.transform.localScale = new Vector3(2f, 0.43769f, 2f);
        }

        minuend += 0.1f;

 
        spawnZ += tileLength;
     
        activeTiles.Add(go);
    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randIndex = lastPrefabIndex;
        while (randIndex == lastPrefabIndex)
        {
            randIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randIndex;
        return randIndex;
    }

    public void applyFloor()
    {
        for(int i= 0; i < floor.Length; i++)
        {
            if (floor[i].isSelected)
            {
                if (floor[i].isUnlock)
                {
                    Renderer renderer = go.GetComponent<Renderer>();
                    renderer.sharedMaterial = floor[i].material;
                }
           
            }
        }
    }

 




   
}
