using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSpawner : MonoBehaviour
{
    public GameObject tester_prefab;
    public int num_spawn;

    void Start() {
        for(int i = num_spawn; i > 0; i --) {
            Instantiate(tester_prefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
