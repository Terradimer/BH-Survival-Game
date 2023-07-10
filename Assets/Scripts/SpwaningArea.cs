using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningArea : MonoBehaviour
{
    public float size;
    public Transform centerPoint;
    private Dictionary<GameObject, Vector2Int> summons;
    // Update is called once per frame
    
    //For testing
    public GameObject item;
    void Awake(){
        //For Testing!!
        //Game.onTickUpdate += OnTick;
        AddToSummonsQueue(item, new Vector2Int(1,1));
        
    }
    
    void Update(){
        transform.Rotate(Vector3.forward);
        transform.position = centerPoint.position;
    }
    public void AddToSummonsQueue(GameObject summon, Vector2Int rareity){
        Instantiate(item, transform.position, Quaternion.identity);
        if(summons.ContainsKey(summon)) summons[summon] = rareity;
        else summons.Add(summon, rareity);
    }
    public void OnTick(){
        print("thing");
        foreach(var summon in summons){
        int probabilityIndicator = Random.Range(0, summon.Value.x);
        if(probabilityIndicator == 0){
            Vector2 spawnPoint = transform.TransformDirection(Vector3.forward * size);
            Instantiate(summon.Key, spawnPoint, Quaternion.identity);
        }
        }
    }
}
