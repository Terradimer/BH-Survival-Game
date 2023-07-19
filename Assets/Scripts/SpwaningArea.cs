using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningArea : MonoBehaviour
{
    public float size;
    public Transform centerPoint;
    //Vector 2 int= rarity, time to summon
    public Queue<GameObject> enemyCache = new Queue<GameObject>();
    public Dictionary<string, int> rollPool = new Dictionary<string, int>();
    public GameObject spwaningCircle;


    // Update is called once per frame
    
    
    void Start(){
        //For Testing!!
        Game.onTickUpdate += OnTick;
        AddToSummonsPool( "Test" , 33 , true);
        
    }
    void Update(){
        transform.Rotate(Vector3.forward);
        transform.position = centerPoint.position;
    }
    public void AddToSummonsPool(string summon, int rareity, bool summonNow){
        if(rollPool.ContainsKey(summon)){
           rollPool[summon] = rareity;
        }
        else{
            rollPool.Add(summon, rareity);
        }

        if(summonNow){Create(summon);}
         
    }

    public void Create(string summon){
            Vector2 spawnPoint = transform.TransformDirection(Vector2.left * size);
            //Debug.Log("point: "+ spawnPoint);
            if(enemyCache.Count != 0){
                GameObject created = enemyCache.Dequeue();
                created.transform.position = spawnPoint;
                created.AddComponent<Actor>().Overload(summon);
                created.SetActive(true);
            }
            else{
                GameObject created = Instantiate(spwaningCircle, spawnPoint, Quaternion.identity);
                created.AddComponent<Actor>().Overload(summon);
            }
    }

    public void deManafest(GameObject adding) {
        enemyCache.Enqueue(adding);
        adding.SetActive(false);
    }

    public void OnTick(){
        print("thing");
        foreach(var summon in rollPool){
        int probabilityIndicator = Random.Range(0, 101);
        //Debug.Log("probabilityIndicator: " + probabilityIndicator);
        if(probabilityIndicator <= summon.Value){
            Create(summon.Key);
        }
        }
    }
}
