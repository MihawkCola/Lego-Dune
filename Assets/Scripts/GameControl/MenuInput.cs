//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Scripts/GameControl/MenuInput.inputactions
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

public partial class @MenuInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuInput"",
    ""maps"": [
        {
            ""name"": ""Pause"",
            ""id"": ""ea1977e5-67bc-4909-a9a8-029bd16d9445"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""a5c01596-fd85-4603-9e2e-4ce895286ad0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""c51dca54-42d2-4d8f-adee-75fedd6e5493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""d5420180-9f6d-4ce5-85ae-da6b02597f8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f0bab41-afe4-4418-aa26-634966b2a79d"",
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
                    ""id"": ""c39ce7d5-6d9f-48ab-b4c1-a40f4e7c9dc6"",
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
                    ""id"": ""b972a2e1-6a14-4087-8462-35580b033594"",
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
                    ""id"": ""9b33db88-d3fd-454e-a9ad-db48704c4c7d"",
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
                    ""id"": ""165cd66d-3f16-4e39-9acc-b07c832bdecd"",
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
                    ""id"": ""ed706f3c-5e05-4a93-be63-e9e0e541cdf0"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Volume"",
            ""id"": ""b442d5a3-d378-4a4e-b07b-367c10dc0cce"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""d51f1087-35e1-4254-9839-60b187921daf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""4a863672-da75-4bb5-b1cd-16abc1c0dfab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""779e6144-bf09-4c33-bd03-b07b85145129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Plus"",
                    ""type"": ""Button"",
                    ""id"": ""ee4932e0-877d-41d6-9a52-a2db827c8b2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Minus"",
                    ""type"": ""Button"",
                    ""id"": ""7aaac96d-7f1a-4708-94a1-1496bcb2b93a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f12f9172-87cc-49b2-8a74-d0842789ca2e"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55f4755d-52f9-412b-b124-ca66e3516778"",
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
                    ""id"": ""e51f4260-054d-4c93-959e-0a9a7d2d4e3f"",
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
                    ""id"": ""1f750638-080e-406b-8366-2bd59cc4d000"",
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
                    ""id"": ""ab88c847-899e-4341-a376-0067e9d7eca6"",
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
                    ""id"": ""3f95549c-c58a-4221-a478-236ce014eea8"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5550894-b0aa-451e-b8d0-b4c2e25a4ad3"",
                    ""path"": ""<Keyboard>/#(+)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cc1eb87-de38-43f0-bd18-8d3a8d9ffc1c"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Minus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ed73f21-16e2-4013-a396-4a1cc2c0c0c2"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Minus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcd78948-47dd-4390-8d03-4ca61f5b65d2"",
                    ""path"": ""<Keyboard>/#(-)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Minus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Resolution"",
            ""id"": ""1d1a8c79-71c3-4f00-ac81-8aa03531be0d"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""445d54f9-0a77-4fad-a113-91f0b3f6abb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""97c6478b-388f-430e-9026-26ee3eeff5b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""4a31249d-84f8-4b52-9698-77718ab5dc15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""93d957ac-bcfc-473c-a27f-f46415ffbb58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2ccb924-7bea-4406-b215-a48b50de513a"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""282f05f3-817a-453b-a071-2d427fae46a1"",
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
                    ""id"": ""aa57975e-a3b7-4fa6-8773-bef87d450038"",
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
                    ""id"": ""1ccd4ee2-d0c4-4108-ae02-716a77802b3a"",
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
                    ""id"": ""a35e3438-6664-40a4-abbb-19fb808eacfb"",
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
                    ""id"": ""970f48a1-1f6c-479b-bf06-e5c9a97d7dc3"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Modes"",
            ""id"": ""8d0f3124-47e7-4f97-91f1-c71d064bebb1"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""3f0d68b3-5289-49b7-94eb-4db73e131666"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""38376636-f95d-42d7-9dcf-1116516cf4af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""5209a210-7023-43f9-b27c-63fc918de9f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""946adeba-9a24-4023-9796-734f1c4ad052"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c4d6185-8b89-4e1f-8ba0-51ec7237f014"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acc8eaf9-9f36-4722-8bd4-b46c56b5dcea"",
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
                    ""id"": ""8fcc7a1f-3a18-4845-9c57-89760c36ba84"",
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
                    ""id"": ""f1120ded-337d-4849-8965-078d6a63abe3"",
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
                    ""id"": ""90d2e854-6202-40f4-804d-027661d0be73"",
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
                    ""id"": ""02ef9f95-c773-4739-a43e-a7082862af05"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""192d41aa-1e79-4a5a-93c6-9269099697ef"",
                    ""path"": ""<Gamepad>/select"",
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
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Up = m_Pause.FindAction("Up", throwIfNotFound: true);
        m_Pause_Down = m_Pause.FindAction("Down", throwIfNotFound: true);
        m_Pause_Select = m_Pause.FindAction("Select", throwIfNotFound: true);
        // Volume
        m_Volume = asset.FindActionMap("Volume", throwIfNotFound: true);
        m_Volume_Back = m_Volume.FindAction("Back", throwIfNotFound: true);
        m_Volume_Up = m_Volume.FindAction("Up", throwIfNotFound: true);
        m_Volume_Down = m_Volume.FindAction("Down", throwIfNotFound: true);
        m_Volume_Plus = m_Volume.FindAction("Plus", throwIfNotFound: true);
        m_Volume_Minus = m_Volume.FindAction("Minus", throwIfNotFound: true);
        // Resolution
        m_Resolution = asset.FindActionMap("Resolution", throwIfNotFound: true);
        m_Resolution_Back = m_Resolution.FindAction("Back", throwIfNotFound: true);
        m_Resolution_Up = m_Resolution.FindAction("Up", throwIfNotFound: true);
        m_Resolution_Down = m_Resolution.FindAction("Down", throwIfNotFound: true);
        m_Resolution_Select = m_Resolution.FindAction("Select", throwIfNotFound: true);
        // Modes
        m_Modes = asset.FindActionMap("Modes", throwIfNotFound: true);
        m_Modes_Back = m_Modes.FindAction("Back", throwIfNotFound: true);
        m_Modes_Select = m_Modes.FindAction("Select", throwIfNotFound: true);
        m_Modes_Up = m_Modes.FindAction("Up", throwIfNotFound: true);
        m_Modes_Down = m_Modes.FindAction("Down", throwIfNotFound: true);
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

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Up;
    private readonly InputAction m_Pause_Down;
    private readonly InputAction m_Pause_Select;
    public struct PauseActions
    {
        private @MenuInput m_Wrapper;
        public PauseActions(@MenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Pause_Up;
        public InputAction @Down => m_Wrapper.m_Pause_Down;
        public InputAction @Select => m_Wrapper.m_Pause_Select;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);

    // Volume
    private readonly InputActionMap m_Volume;
    private IVolumeActions m_VolumeActionsCallbackInterface;
    private readonly InputAction m_Volume_Back;
    private readonly InputAction m_Volume_Up;
    private readonly InputAction m_Volume_Down;
    private readonly InputAction m_Volume_Plus;
    private readonly InputAction m_Volume_Minus;
    public struct VolumeActions
    {
        private @MenuInput m_Wrapper;
        public VolumeActions(@MenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Volume_Back;
        public InputAction @Up => m_Wrapper.m_Volume_Up;
        public InputAction @Down => m_Wrapper.m_Volume_Down;
        public InputAction @Plus => m_Wrapper.m_Volume_Plus;
        public InputAction @Minus => m_Wrapper.m_Volume_Minus;
        public InputActionMap Get() { return m_Wrapper.m_Volume; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VolumeActions set) { return set.Get(); }
        public void SetCallbacks(IVolumeActions instance)
        {
            if (m_Wrapper.m_VolumeActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_VolumeActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_VolumeActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_VolumeActionsCallbackInterface.OnBack;
                @Up.started -= m_Wrapper.m_VolumeActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_VolumeActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_VolumeActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_VolumeActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_VolumeActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_VolumeActionsCallbackInterface.OnDown;
                @Plus.started -= m_Wrapper.m_VolumeActionsCallbackInterface.OnPlus;
                @Plus.performed -= m_Wrapper.m_VolumeActionsCallbackInterface.OnPlus;
                @Plus.canceled -= m_Wrapper.m_VolumeActionsCallbackInterface.OnPlus;
                @Minus.started -= m_Wrapper.m_VolumeActionsCallbackInterface.OnMinus;
                @Minus.performed -= m_Wrapper.m_VolumeActionsCallbackInterface.OnMinus;
                @Minus.canceled -= m_Wrapper.m_VolumeActionsCallbackInterface.OnMinus;
            }
            m_Wrapper.m_VolumeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Plus.started += instance.OnPlus;
                @Plus.performed += instance.OnPlus;
                @Plus.canceled += instance.OnPlus;
                @Minus.started += instance.OnMinus;
                @Minus.performed += instance.OnMinus;
                @Minus.canceled += instance.OnMinus;
            }
        }
    }
    public VolumeActions @Volume => new VolumeActions(this);

    // Resolution
    private readonly InputActionMap m_Resolution;
    private IResolutionActions m_ResolutionActionsCallbackInterface;
    private readonly InputAction m_Resolution_Back;
    private readonly InputAction m_Resolution_Up;
    private readonly InputAction m_Resolution_Down;
    private readonly InputAction m_Resolution_Select;
    public struct ResolutionActions
    {
        private @MenuInput m_Wrapper;
        public ResolutionActions(@MenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Resolution_Back;
        public InputAction @Up => m_Wrapper.m_Resolution_Up;
        public InputAction @Down => m_Wrapper.m_Resolution_Down;
        public InputAction @Select => m_Wrapper.m_Resolution_Select;
        public InputActionMap Get() { return m_Wrapper.m_Resolution; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ResolutionActions set) { return set.Get(); }
        public void SetCallbacks(IResolutionActions instance)
        {
            if (m_Wrapper.m_ResolutionActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnBack;
                @Up.started -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_ResolutionActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_ResolutionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public ResolutionActions @Resolution => new ResolutionActions(this);

    // Modes
    private readonly InputActionMap m_Modes;
    private IModesActions m_ModesActionsCallbackInterface;
    private readonly InputAction m_Modes_Back;
    private readonly InputAction m_Modes_Select;
    private readonly InputAction m_Modes_Up;
    private readonly InputAction m_Modes_Down;
    public struct ModesActions
    {
        private @MenuInput m_Wrapper;
        public ModesActions(@MenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Modes_Back;
        public InputAction @Select => m_Wrapper.m_Modes_Select;
        public InputAction @Up => m_Wrapper.m_Modes_Up;
        public InputAction @Down => m_Wrapper.m_Modes_Down;
        public InputActionMap Get() { return m_Wrapper.m_Modes; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ModesActions set) { return set.Get(); }
        public void SetCallbacks(IModesActions instance)
        {
            if (m_Wrapper.m_ModesActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_ModesActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_ModesActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_ModesActionsCallbackInterface.OnBack;
                @Select.started -= m_Wrapper.m_ModesActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_ModesActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_ModesActionsCallbackInterface.OnSelect;
                @Up.started -= m_Wrapper.m_ModesActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_ModesActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_ModesActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_ModesActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_ModesActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_ModesActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_ModesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public ModesActions @Modes => new ModesActions(this);
    public interface IPauseActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IVolumeActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnPlus(InputAction.CallbackContext context);
        void OnMinus(InputAction.CallbackContext context);
    }
    public interface IResolutionActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IModesActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
