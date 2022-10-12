using System.Collections.Generic;
using UnityEngine;

public class MoveForTime : MonoBehaviour
{
    public List<MeansOfCube> Mcubes = new List<MeansOfCube>();
    void Update()
    {
        for (var i = 0; i < Mcubes.Count; i++)
        {
            MeansOfCube mcube = Mcubes[i];
            Vector3 vecX = new Vector3(mcube.distx, 0, 0);
            mcube.transform.position = Vector3.MoveTowards(mcube.transform.position, vecX, mcube.speed * Time.deltaTime);
            if(mcube.transform.position == vecX)
            {
                mcube.gameObject.SetActive(false);
                Mcubes.Remove(mcube);
                break;
            }
        }
    }
}