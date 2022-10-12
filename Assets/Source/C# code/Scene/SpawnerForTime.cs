using System.Collections;
using UnityEngine;

public class SpawnerForTime : MonoBehaviour
{
    private PoolCubes poolCubes;
    private Inputs inputs;
    float timeSpawn, timR = 1.5f;
    MoveForTime moveForTime;
    private void Awake()
    {
        poolCubes = FindObjectOfType<PoolCubes>();
        inputs = FindObjectOfType<Inputs>();
        moveForTime = FindObjectOfType<MoveForTime>();
    }
    public void ChangeTimeSpawn()
    {
        
        timR = float.Parse(inputs.inpFTimeS.text);
        if (timR < .1f)
        {
            inputs.inpFTimeS.text = ".1";
            timR = .1f;
        }
    }
    private void Update()
    {
        if (timeSpawn <= 0)
        {
            timeSpawn = timR;
            SpawnCubes();
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
    void SpawnCubes()
    {
        bool have = false;
        for (var i = 0; i < poolCubes.cubes.Count; i++)
        {
            MeansOfCube mCube = poolCubes.cubes[i];
            if (!mCube.gameObject.activeSelf)
            {
                have = true;
                AddCubeAndMeans(mCube);
                break;
            }
        }

        if (!have)
        {
            MeansOfCube mCube = Instantiate(poolCubes.CubeForSpawn, poolCubes.transform).GetComponent<MeansOfCube>();
            poolCubes.cubes.Add(mCube);
            AddCubeAndMeans(mCube);
        }

    }
    void AddCubeAndMeans(MeansOfCube mCube)
    {
        mCube.transform.position = Vector3.zero;
        mCube.gameObject.SetActive(true);
        mCube.distx = float.Parse(inputs.inpFDist.text);
        float speed = float.Parse(inputs.inpFSpeed.text);
        if (speed < .5f)
        {
            inputs.inpFSpeed.text = ".5";
            speed = .5f;
        }
        mCube.speed = speed;
            moveForTime.Mcubes.Add(mCube);
    }

}
