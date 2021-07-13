using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour
{
    public Terrain terrainReference;
    Transform lookDirection;
    public Camera myCamera;
    public float range = 100f;
    public float digSpeed = .1f;
    public Transform digPoint;
    public AudioClip digSound;

    public void Awake()
    {
        int xRes = terrainReference.terrainData.heightmapResolution;
        float[,] allHeights = terrainReference.terrainData.GetHeights(0, 0, xRes, xRes);
        float[,] newHeights = terrainReference.terrainData.GetHeights(0, 0, xRes, xRes);

        // https://stackoverflow.com/questions/8184306/iterate-through-2-dimensional-array-c-sharp
        for (int k = 0; k < allHeights.GetLength(0); k++)
        {

            for (int z = 0; z < allHeights.GetLength(1); z++)
            {
                newHeights[k, z] = 1f;
                
            }
        }
        terrainReference.terrainData.SetHeights(0, 0, newHeights);
        terrainReference.terrainData.SyncHeightmap();
    }

    public void diggingNow()
    {
        Debug.Log("Click");
        GetComponent<AudioSource>().PlayOneShot(digSound);
        RaycastHit hit;

        //if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        //{

            //Debug.Log(hit.transform.name);


            Terrain hitTerrain = terrainReference;
            //check if potato hit
            //Terrain hitTerrain = hit.transform.GetComponent<Terrain>();

            if (hitTerrain != null)
            {
                //Vector3 hitPoint = hit.point;
                //float currentHeight = hitTerrain.SampleHeight(hitPoint);
                //https://answers.unity.com/questions/29211/please-explain-terrainsetheights.html thanks dude
                int xRes = hitTerrain.terrainData.heightmapResolution;
                //Debug.Log("xRes" + xRes);
                //Debug.Log("Height here is:" + currentHeight);

                //https://gamedevbeginner.com/terrain-footsteps-in-unity-how-to-detect-different-textures/
                Vector3 actualTerrainPosition = digPoint.position + hitTerrain.transform.position;
                //Vector3 actualTerrainPosition = digPoint.position - hitTerrain.transform.position;
                Vector3 mapPosition = new Vector3(actualTerrainPosition.x / hitTerrain.terrainData.size.x,
                    0,
                    actualTerrainPosition.z / hitTerrain.terrainData.size.z);

                float zCoord = mapPosition.x * hitTerrain.terrainData.heightmapResolution;
                float xCoord = mapPosition.z * hitTerrain.terrainData.heightmapResolution;

                int posX = (int)xCoord;
                int posZ = (int)zCoord;

                //Debug.Log("X coord:" + posX + "|ZCoord:" + posZ);



                //also this? https://www.reddit.com/r/Unity3D/comments/2vf70k/referencing_terrain_points_via_world_position/

                float[,] allHeights = hitTerrain.terrainData.GetHeights(0, 0, xRes, xRes);
                float[,] newHeights = hitTerrain.terrainData.GetHeights(0, 0, xRes, xRes);

                // https://stackoverflow.com/questions/8184306/iterate-through-2-dimensional-array-c-sharp
                for (int k = 0; k < allHeights.GetLength(0); k++)
                {

                    for (int z = 0; z < allHeights.GetLength(1); z++)
                    {
                        //newHeights[k, z] = newHeights[k, z] - 0.1f;
                        if (k == posX && z == posZ)
                        {
                            Debug.Log("Oh hit it's the point at start:" + newHeights[k, z]);
                            newHeights[k, z] = newHeights[k, z] - 0.01f;
                            Debug.Log("And here it is now:" + newHeights[k, z]);
                        }
                    }
                }
                hitTerrain.terrainData.SetHeights(0, 0, newHeights);
                hitTerrain.terrainData.SyncHeightmap();


                //foreach (float floatArray in allHeights)
                //{
                //    newHeights[floatArray[0], floatArray[1]] = 
                //}




                float myHeight = hitTerrain.terrainData.GetHeight(posX, posZ);
                //hitTerrain.terrainData.SetHeights[0, 0,]
                float heightAtPoint = allHeights[posX, posZ];
                //Debug.Log("HeightAtPoint:" + heightAtPoint);
                //Debug.Log("MyHeightAtPoint:" + myHeight);

                //Debug.Log("X size:" + xValue);
                //Debug.Log("Z size:" + zValue);
                //Debug.Log("All Samples:" + lotsOfThings.ToString());
            //}
        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("diggingNow", 0, digSpeed);
        }
        if (Input.GetMouseButtonUp(0))
         {
                CancelInvoke("diggingNow");
        }
           
    }
}
