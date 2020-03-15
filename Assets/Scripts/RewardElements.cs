using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardElements : MonoBehaviour
{
    public float delay = 3f;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    //Create new Vector
    void Spawn()
    {
        Instantiate(cube, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
    }
}
