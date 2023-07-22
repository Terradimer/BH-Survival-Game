using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Compendium.GameData {
    public class Prefabs : MonoBehaviour {
        public static GameObject EnemyPrefab {get; private set;}
        public static GameObject PlayerPrefab {get; private set;} 

        [SerializeField]
        private GameObject _enemyPF_;

        [SerializeField]
        private GameObject _playerPF_;
    }
}