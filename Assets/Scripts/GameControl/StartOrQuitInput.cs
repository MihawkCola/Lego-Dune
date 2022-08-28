//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Scripts/GameControl/StartOrQuitInput.inputactions
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

public partial class @StartOrQuitInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @StartOrQuitInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StartOrQuitInput"",
    ""maps"": [
        {
            ""name"": ""StartOrQuit"",
            ""id"": ""df5a8109-e7f9-48b8-96b4-9ff7c47ffecc"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""478e145f-811e-4d50-8c81-b7c3d7fcebc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""3d76d442-57eb-4682-964b-3ffe8a617927"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""709a7608-27c1-4c2e-acca-6766784db146"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1a15b06-1daa-4eee-a35f-0e150c104978"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1dfa6d1-01d0-42ab-ad47-6b0ef33e2fc8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a34090c-046d-4744-95d5-905a749451b9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7edcb844-8bbc-4128-9179-960412835c28"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b63d0164-704d-4d73-8cf5-720168964a08"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7391d430-f39d-4954-9044-14d22656dcd1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // StartOrQuit
        m_StartOrQuit = asset.FindActionMap("StartOrQuit", throwIfNotFound: true);
        m_StartOrQuit_Down = m_StartOrQuit.FindAction("Down", throwIfNotFound: true);
        m_StartOrQuit_Up = m_StartOrQuit.FindAction("Up", throwIfNotFound: true);
        m_StartOrQuit_Select = m_StartOrQuit.FindAction("Select", throwIfNotFound: true);
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

    // StartOrQuit
    private readonly InputActionMap m_StartOrQuit;
    private IStartOrQuitActions m_StartOrQuitActionsCallbackInterface;
    private readonly InputAction m_StartOrQuit_Down;
    private readonly InputAction m_StartOrQuit_Up;
    private readonly InputAction m_StartOrQuit_Select;
    public struct StartOrQuitActions
    {
        private @StartOrQuitInput m_Wrapper;
        public StartOrQuitActions(@StartOrQuitInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_StartOrQuit_Down;
        public InputAction @Up => m_Wrapper.m_StartOrQuit_Up;
        public InputAction @Select => m_Wrapper.m_StartOrQuit_Select;
        public InputActionMap Get() { return m_Wrapper.m_StartOrQuit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StartOrQuitActions set) { return set.Get(); }
        public void SetCallbacks(IStartOrQuitActions instance)
        {
            if (m_Wrapper.m_StartOrQuitActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnUp;
                @Select.started -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_StartOrQuitActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_StartOrQuitActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public StartOrQuitActions @StartOrQuit => new StartOrQuitActions(this);
    public interface IStartOrQuitActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
