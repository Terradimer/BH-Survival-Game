using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

namespace DeveloperConsole.Commands {
    public class Console {
        private readonly Dictionary<string, ConsoleCommand> commands;
        public Console(Dictionary<string, ConsoleCommand> commands) {
            this.commands = commands;
        }

        public void ProcessCommand(string commandInput) {
            string[] splitInput = commandInput.Split(' ');
            commands[splitInput[0]].Process(splitInput.Skip(1).ToArray());
        }
    }

    public class ConsoleBehavior : MonoBehaviour {
        [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

        [Header("UI")]
        [SerializeField] private GameObject uiCanvas = null;
        [SerializeField] private TMP_InputField inputField = null;

        private static ConsoleBehavior instance;

        private Console devConsole;
        private Console DeveloperConsole => 
            (devConsole != null) ? devConsole : new Console(commands.ToDictionary(x => x.CommandWord, x => x));
                

        private void Awake() {
            if(instance != null && instance != this) {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Toggle(CallbackContext context) {
            if(!context.action.triggered) return;

            if(uiCanvas.activeSelf) { 
                GameClock.TogglePause(false);
                uiCanvas.SetActive(false);
                return;
            }
            
            uiCanvas.SetActive(true);
            inputField.ActivateInputField();
        }
    }
}