//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Scripts/Cutscene/SkipScene.inputactions
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

public partial class @SkipScene : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SkipScene()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SkipScene"",
    ""maps"": [
        {
            ""name"": ""skip"",
            ""id"": ""4066e611-0355-437e-ae33-d99667a6fc1a"",
            ""actions"": [
                {
                    ""name"": ""skip"",
                    ""type"": ""Button"",
                    ""id"": ""71475909-5248-4bd9-816c-335bf13f2059"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcf5c248-bc01-441f-9f21-6e24962de2bd"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // skip
        m_skip = asset.FindActionMap("skip", throwIfNotFound: true);
        m_skip_skip = m_skip.FindAction("skip", throwIfNotFound: true);
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

    // skip
    private readonly InputActionMap m_skip;
    private ISkipActions m_SkipActionsCallbackInterface;
    private readonly InputAction m_skip_skip;
    public struct SkipActions
    {
        private @SkipScene m_Wrapper;
        public SkipActions(@SkipScene wrapper) { m_Wrapper = wrapper; }
        public InputAction @skip => m_Wrapper.m_skip_skip;
        public InputActionMap Get() { return m_Wrapper.m_skip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SkipActions set) { return set.Get(); }
        public void SetCallbacks(ISkipActions instance)
        {
            if (m_Wrapper.m_SkipActionsCallbackInterface != null)
            {
                @skip.started -= m_Wrapper.m_SkipActionsCallbackInterface.OnSkip;
                @skip.performed -= m_Wrapper.m_SkipActionsCallbackInterface.OnSkip;
                @skip.canceled -= m_Wrapper.m_SkipActionsCallbackInterface.OnSkip;
            }
            m_Wrapper.m_SkipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @skip.started += instance.OnSkip;
                @skip.performed += instance.OnSkip;
                @skip.canceled += instance.OnSkip;
            }
        }
    }
    public SkipActions @skip => new SkipActions(this);
    public interface ISkipActions
    {
        void OnSkip(InputAction.CallbackContext context);
    }
}
