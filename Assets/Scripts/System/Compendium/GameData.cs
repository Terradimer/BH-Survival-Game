using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Compendium.GameData {
    public static class AreaMath {
        private static Vector2 RandomAlongCircleEdge(float rad, Vector2 origin) {
            return (Random.insideUnitCircle.normalized * rad) + origin;
        }
    }

    public static class Entities {
        public static HashSet<Player> Players = new HashSet<Player>();
        public static HashSet<Enemy> Enemies = new HashSet<Enemy>();
    }
    
}