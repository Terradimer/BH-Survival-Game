using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeveloperConsole.Commands {
    public abstract class ConsoleCommand : ScriptableObject {
        [SerializeField] private string commandWord = string.Empty;
        public string CommandWord => commandWord;
        public abstract bool Process(string[] args);
    }
}