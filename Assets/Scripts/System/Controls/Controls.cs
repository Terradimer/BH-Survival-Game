//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/System/Controls/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""playerActionMap"",
            ""id"": ""4e96af02-ef15-4353-b777-d6711eec4140"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a1ec05a5-a7cf-4be5-8ef6-eb92089af798"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""183a882e-64a7-4def-91b1-f6d14ac4adf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""59fe877f-dbba-47da-b329-1ccbf3010785"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""cf04b022-77f6-41de-a4f9-17a8f4738d79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""b1ea89bc-da51-41fd-bdf5-4205bd63ffc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""1c72f4ea-3f8b-4804-9c80-8ed98148b9f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d4802a51-c6c4-429d-aba3-0e6b253958a1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""931a3fc0-2ae0-4d0d-b222-cb2417e293fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2d3e516f-1ea8-4c40-bcad-be64d807cb04"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0c11c5f9-b351-4f7b-8c33-b4def749a438"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6f1e6115-21e2-4d2b-8380-c40725f92693"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d3c22e13-5bb5-4a6c-a7ee-18b34f303197"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c7d7d29-eb8a-4213-b26a-ebe954018fed"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac373400-9dcf-41d7-ba62-3f4eb1bd3971"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1d1e9a8-3f21-4994-8f83-a4d35551562c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c15d9310-ec77-4cfe-820c-b2a5edb4fe52"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerActionMap
        m_playerActionMap = asset.FindActionMap("playerActionMap", throwIfNotFound: true);
        m_playerActionMap_WASD = m_playerActionMap.FindAction("WASD", throwIfNotFound: true);
        m_playerActionMap_Primary = m_playerActionMap.FindAction("Primary", throwIfNotFound: true);
        m_playerActionMap_Ability1 = m_playerActionMap.FindAction("Ability1", throwIfNotFound: true);
        m_playerActionMap_Ability2 = m_playerActionMap.FindAction("Ability2", throwIfNotFound: true);
        m_playerActionMap_Ability3 = m_playerActionMap.FindAction("Ability3", throwIfNotFound: true);
        m_playerActionMap_Ability4 = m_playerActionMap.FindAction("Ability4", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // playerActionMap
    private readonly InputActionMap m_playerActionMap;
    private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
    private readonly InputAction m_playerActionMap_WASD;
    private readonly InputAction m_playerActionMap_Primary;
    private readonly InputAction m_playerActionMap_Ability1;
    private readonly InputAction m_playerActionMap_Ability2;
    private readonly InputAction m_playerActionMap_Ability3;
    private readonly InputAction m_playerActionMap_Ability4;
    public struct PlayerActionMapActions
    {
        private @Controls m_Wrapper;
        public PlayerActionMapActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_playerActionMap_WASD;
        public InputAction @Primary => m_Wrapper.m_playerActionMap_Primary;
        public InputAction @Ability1 => m_Wrapper.m_playerActionMap_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_playerActionMap_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_playerActionMap_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_playerActionMap_Ability4;
        public InputActionMap Get() { return m_Wrapper.m_playerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
            @WASD.started += instance.OnWASD;
            @WASD.performed += instance.OnWASD;
            @WASD.canceled += instance.OnWASD;
            @Primary.started += instance.OnPrimary;
            @Primary.performed += instance.OnPrimary;
            @Primary.canceled += instance.OnPrimary;
            @Ability1.started += instance.OnAbility1;
            @Ability1.performed += instance.OnAbility1;
            @Ability1.canceled += instance.OnAbility1;
            @Ability2.started += instance.OnAbility2;
            @Ability2.performed += instance.OnAbility2;
            @Ability2.canceled += instance.OnAbility2;
            @Ability3.started += instance.OnAbility3;
            @Ability3.performed += instance.OnAbility3;
            @Ability3.canceled += instance.OnAbility3;
            @Ability4.started += instance.OnAbility4;
            @Ability4.performed += instance.OnAbility4;
            @Ability4.canceled += instance.OnAbility4;
        }

        private void UnregisterCallbacks(IPlayerActionMapActions instance)
        {
            @WASD.started -= instance.OnWASD;
            @WASD.performed -= instance.OnWASD;
            @WASD.canceled -= instance.OnWASD;
            @Primary.started -= instance.OnPrimary;
            @Primary.performed -= instance.OnPrimary;
            @Primary.canceled -= instance.OnPrimary;
            @Ability1.started -= instance.OnAbility1;
            @Ability1.performed -= instance.OnAbility1;
            @Ability1.canceled -= instance.OnAbility1;
            @Ability2.started -= instance.OnAbility2;
            @Ability2.performed -= instance.OnAbility2;
            @Ability2.canceled -= instance.OnAbility2;
            @Ability3.started -= instance.OnAbility3;
            @Ability3.performed -= instance.OnAbility3;
            @Ability3.canceled -= instance.OnAbility3;
            @Ability4.started -= instance.OnAbility4;
            @Ability4.performed -= instance.OnAbility4;
            @Ability4.canceled -= instance.OnAbility4;
        }

        public void RemoveCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionMapActions @playerActionMap => new PlayerActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
    }
}
