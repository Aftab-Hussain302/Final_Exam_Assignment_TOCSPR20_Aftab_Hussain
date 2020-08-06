using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollectible : MonoBehaviour
{
    public GameObject cubeCollecttible;

    Vector3 position;

    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        int cube = 0;
        while (cube <10)
        {
            position = new Vector3(Random.Range(-10, 10f), 0.5f, Random.Range(-4, 10));

            Instantiate(cubeCollecttible, position, Quaternion.identity);
            cube++;
        }
    }
}
