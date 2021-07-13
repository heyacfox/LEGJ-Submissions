using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigFunctionality : MonoBehaviour
{
    //You'll need to create a transform that will determine where the dig will occur
    //otherwise, you will dig right under your feet.
    public Transform performDigAtThisLocation;
    public Terrain terrainToUpdate;
    public bool oneDigPerClick = false;
    public float digsPerSecond = 0.1f;
    //Note: if you have not raised the terrain at all from the default, the terrain cannot be lowered.
    public float lowerTerrainAmountPerDig = 0.01f;

    float[,] savedTerrainHeights;
    bool dontSaveTerrainChanges = true;

    // Start is called before the first frame update
    void Start()
    {
        int terrainResolution = terrainToUpdate.terrainData.heightmapResolution;
        savedTerrainHeights = terrainToUpdate.terrainData.GetHeights(0, 0, terrainResolution, terrainResolution);
        if (performDigAtThisLocation == null)
        {
            performDigAtThisLocation = this.transform;
        }
    }

    private void OnDisable()
    {
        resetTerrainToOriginal();
    }

    private void resetTerrainToOriginal()
    {
        if (dontSaveTerrainChanges)
        {
            terrainToUpdate.terrainData.SetHeights(0, 0, savedTerrainHeights);
            terrainToUpdate.terrainData.SyncHeightmap();
        }
    }

    private void performDig()
    {
        int terrainResolution = terrainToUpdate.terrainData.heightmapResolution;

        //Find the relevant grid position for the terrain where you want to dig
        Vector3 actualTerrainPosition = performDigAtThisLocation.position + terrainToUpdate.transform.position;
        Vector3 mapPosition = new Vector3(actualTerrainPosition.x / terrainToUpdate.terrainData.size.x,
            0,
            actualTerrainPosition.z / terrainToUpdate.terrainData.size.z);

        float zCoord = mapPosition.x * terrainToUpdate.terrainData.heightmapResolution;
        float xCoord = mapPosition.z * terrainToUpdate.terrainData.heightmapResolution;

        int posX = (int)xCoord;
        int posZ = (int)zCoord;

        //Update specific terrain point
        float[,] newHeights = terrainToUpdate.terrainData.GetHeights(0, 0, terrainResolution, terrainResolution);
        newHeights[posX, posZ] = newHeights[posX, posZ] - lowerTerrainAmountPerDig;
        terrainToUpdate.terrainData.SetHeights(0, 0, newHeights);
        terrainToUpdate.terrainData.SyncHeightmap();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (oneDigPerClick)
            {
                performDig();
            } else
            {
                InvokeRepeating("performDig", 0, digsPerSecond);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!oneDigPerClick)
            {
                CancelInvoke("performDig");
            }
        }
    }
}
