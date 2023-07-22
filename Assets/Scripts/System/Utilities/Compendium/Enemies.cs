using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Compendium.GameData;

namespace Compendium.Enemies {
    public enum EnemyTags {
        chaser, shooter, ect
    }

    public static class Enemies {
        public static Queue<Enemy> EnemyCache = new Queue<Enemy>();
        private static Dictionary<EnemyTags, Enemy> Get = new Dictionary<EnemyTags, Enemy>() {

        };

        public static void Spawn(EnemyTags key, Vector2 pos) {
            if (EnemyCache.Count > 0) {
                Enemy reSpawned = EnemyCache.Dequeue().SetTo(Get[key]);
                reSpawned.enabled = true;
                reSpawned.transform.position = pos;
                return;
            }

            Enemy x = MonoBehaviour.Instantiate(Prefabs.EnemyPrefab, pos, Quaternion.identity)
                .GetComponent<Enemy>()
                .SetTo(Get[key]);
        }
    }
}