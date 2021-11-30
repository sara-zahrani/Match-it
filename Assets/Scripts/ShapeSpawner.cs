using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public List<GameObject> mShapes = new List<GameObject>();
    //public bool mSpawnRandomShapes;
    //public bool mSpawnShapes;
    public bool mResetShape = false;

    private List<Transform> mShapesLocations = new List<Transform>();
    private int mRandomSpawnCounter = 4;
    private int mSpawnCounter = 1;


    private void Awake()
    {
        foreach(Transform child in transform)
        {
            mShapesLocations.Add(child);
        }
    }


    private void Update()
    {
        if (mRandomSpawnCounter > 0)
        {
            for (int i = 1; i < mShapesLocations.Count; i++)
            {
                StartCoroutine("SpawnEnemiesRandomly");
            }

            mRandomSpawnCounter--;
        }
    }


    IEnumerator SpawnEnemiesRandomly()
    {
        yield return new WaitForSeconds(2);

        int randomIdex = UnityEngine.Random.Range(0, mShapes.Count);

        for (int i = 0; i < mShapesLocations.Count; i++)
        {
            Spawn(randomIdex, i);
        }
    }

    void Spawn(int enemyIndex, int locationIndex)
    {
        Instantiate(mShapes[enemyIndex],
            mShapesLocations[locationIndex].position,
            mShapesLocations[locationIndex].rotation);
    }

}
