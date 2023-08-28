using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum abilityOrder{Primary, Ability1, Ability2, Ability3, Ability4, Ability5, Ability6, Ability7, Ability8, Ability9}
public class AbilityControler : MonoBehaviour
{
    private Controls primary;
    private Controls Ability1;
    private Controls Ability2;
    private Controls Ability3;
    private Controls Ability4;
    private Controls Ability5;
    public List<AbilityClass> abilities = new List<AbilityClass>();
    
    void Awake() { 
        primary = new Controls();
        Ability1 = new Controls();
        Ability2 = new Controls();
        Ability3 = new Controls();
        Ability4 = new Controls();
        Ability5 = new Controls();
         }
    void OnEnable() { 
        EnableButtons();
         }
    void OnDisable() { 
        DisableButtons();
         }
    private void PrimaryFunction(InputAction.CallbackContext context){
        print("whoa pew pew and stuff");
        if(abilities.Count > (int)abilityOrder.Primary && abilities[(int)abilityOrder.Primary] != null){
            abilities[(int)abilityOrder.Primary].Cast(this);
        }
    }
    private void Ability1Function(InputAction.CallbackContext context){
        if(abilities.Count > (int)abilityOrder.Ability1 && abilities[(int)abilityOrder.Ability1] != null){
            abilities[(int)abilityOrder.Ability1].Cast(this);
        }
    }
    private void Ability2Function(InputAction.CallbackContext context){
        if(abilities.Count > (int)abilityOrder.Ability2 && abilities[(int)abilityOrder.Ability2] != null){
            abilities[(int)abilityOrder.Ability2].Cast(this);
        }
    }
    private void Ability3Function(InputAction.CallbackContext context){
        if(abilities.Count > (int)abilityOrder.Ability3 && abilities[(int)abilityOrder.Ability3] != null){
            abilities[(int)abilityOrder.Ability3].Cast(this);
        }
    }
    private void Ability4Function(InputAction.CallbackContext context){
        if(abilities.Count > (int)abilityOrder.Ability4 && abilities[(int)abilityOrder.Ability4] != null){
            abilities[(int)abilityOrder.Ability4].Cast(this);
        }
    }
    private void Ability5Function(InputAction.CallbackContext context){
        if(abilities.Count > (int)abilityOrder.Ability5 && abilities[(int)abilityOrder.Ability5] != null){
            abilities[(int)abilityOrder.Ability5].Cast(this);
        }
    }
    void EnableButtons(){
        primary.playerActionMap.Primary.Enable();
        primary.playerActionMap.Primary.performed += PrimaryFunction;
        Ability1.playerActionMap.Ability1.Enable();
        Ability1.playerActionMap.Ability1.performed += Ability1Function; 
        Ability2.playerActionMap.Ability2.Enable();
        Ability2.playerActionMap.Ability2.performed += Ability2Function;
        Ability3.playerActionMap.Ability3.Enable();
        Ability3.playerActionMap.Ability3.performed += Ability3Function;
        Ability4.playerActionMap.Ability4.Enable();
        Ability4.playerActionMap.Ability4.performed += Ability4Function;
        Ability5.playerActionMap.Ability5.Enable();
        Ability5.playerActionMap.Ability5.performed += Ability5Function;
    }
    void DisableButtons(){
        primary.playerActionMap.Primary.Disable();
        Ability1.playerActionMap.Ability1.Disable();
        Ability2.playerActionMap.Ability2.Disable();
        Ability3.playerActionMap.Ability3.Disable();
        Ability4.playerActionMap.Ability4.Disable();
    }

}
