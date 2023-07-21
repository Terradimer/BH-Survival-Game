using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningArea : MonoBehaviour
{
    public float size;
    public List<Transform> players = new List<Transform>();
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
    public void AddToSummonsPool(string summon, int rareity, bool summonNow){
        if(rollPool.ContainsKey(summon)){
           rollPool[summon] = rareity;
        }
        else{
            rollPool.Add(summon, rareity);
        }

        if(summonNow){Create(summon,players[0].position);}
         
    }
    public void Create(string summon, Vector2 point)
    {
        Vector2 spawnPoint = RandomAlongCircleEdge(size, point);
        //Debug.Log("point: "+ spawnPoint);
        GameObject created;
        if (enemyCache.Count != 0)
        {
            created = enemyCache.Dequeue();
            created.transform.position = spawnPoint;
        }
        else
        {
            created = Instantiate(spwaningCircle, spawnPoint, Quaternion.identity);
        }

        created.SetActive(true);
        created.AddComponent<BaseEnemy>().Overload(summon).sArea = this;
    }
    public void deManafest(GameObject adding) {
        enemyCache.Enqueue(adding);
        foreach (var comp in adding.GetComponents<Component>())
        {
            if (!(comp is Transform))
            {
                Destroy(comp);
            }
        }
        adding.SetActive(false);
    }
    public void OnTick(){
        //Got confused on doing multiplayer point tracking, that is why players are a list
        print("thing");
        DiceRoll(players[0].position, size);
    }
    private void DiceRoll(Vector2 point, float rad){

        foreach(var summon in rollPool){
        int probabilityIndicator = Random.Range(0, 101);
        //Debug.Log("probabilityIndicator: " + probabilityIndicator);
        if(probabilityIndicator <= summon.Value){
            Create(summon.Key, point);
        }
        }
    }
    private Vector2 RandomAlongCircleEdge(float rad, Vector2 origin) {
        Vector2 fruit = (Random.insideUnitCircle.normalized * rad) + origin;
        Debug.Log("fruit: " + fruit);
        return fruit;
    }
}
