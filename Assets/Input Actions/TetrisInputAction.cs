//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input Actions/TetrisInputAction.inputactions
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

public partial class @TetrisInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TetrisInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TetrisInputAction"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""caf2fc7f-a6a7-409f-86ac-e417dc31f93e"",
            ""actions"": [
                {
                    ""name"": ""Shift"",
                    ""type"": ""Value"",
                    ""id"": ""b3e7f0fe-8699-4719-b54a-46f346d25f56"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""5807a8c5-a27a-48c7-a55a-46595d15f94d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fall"",
                    ""type"": ""Value"",
                    ""id"": ""62ed680a-ab1e-43c1-907a-02425b147085"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Plummet"",
                    ""type"": ""Button"",
                    ""id"": ""bbc40626-eaba-4974-ae22-0bdb79c2fe35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""9df8cee4-d710-44f1-b4e2-1dc7d4824f13"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""07378c33-adf6-4ae7-b7a1-17803c554ae8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""491fb60b-7d69-499e-97a0-bdd4ca9f10dd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de3a0b5e-deda-4d39-a5d3-2380e3911edb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5037ae95-a1d6-4b4e-beae-a8486acb8070"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a856667-75c2-463b-a4d2-18260daa87b0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plummet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Shift = m_Game.FindAction("Shift", throwIfNotFound: true);
        m_Game_Rotate = m_Game.FindAction("Rotate", throwIfNotFound: true);
        m_Game_Fall = m_Game.FindAction("Fall", throwIfNotFound: true);
        m_Game_Plummet = m_Game.FindAction("Plummet", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();
    private readonly InputAction m_Game_Shift;
    private readonly InputAction m_Game_Rotate;
    private readonly InputAction m_Game_Fall;
    private readonly InputAction m_Game_Plummet;
    public struct GameActions
    {
        private @TetrisInputAction m_Wrapper;
        public GameActions(@TetrisInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shift => m_Wrapper.m_Game_Shift;
        public InputAction @Rotate => m_Wrapper.m_Game_Rotate;
        public InputAction @Fall => m_Wrapper.m_Game_Fall;
        public InputAction @Plummet => m_Wrapper.m_Game_Plummet;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void AddCallbacks(IGameActions instance)
        {
            if (instance == null || m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
            @Shift.started += instance.OnShift;
            @Shift.performed += instance.OnShift;
            @Shift.canceled += instance.OnShift;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Fall.started += instance.OnFall;
            @Fall.performed += instance.OnFall;
            @Fall.canceled += instance.OnFall;
            @Plummet.started += instance.OnPlummet;
            @Plummet.performed += instance.OnPlummet;
            @Plummet.canceled += instance.OnPlummet;
        }

        private void UnregisterCallbacks(IGameActions instance)
        {
            @Shift.started -= instance.OnShift;
            @Shift.performed -= instance.OnShift;
            @Shift.canceled -= instance.OnShift;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Fall.started -= instance.OnFall;
            @Fall.performed -= instance.OnFall;
            @Fall.canceled -= instance.OnFall;
            @Plummet.started -= instance.OnPlummet;
            @Plummet.performed -= instance.OnPlummet;
            @Plummet.canceled -= instance.OnPlummet;
        }

        public void RemoveCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameActions instance)
        {
            foreach (var item in m_Wrapper.m_GameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnShift(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFall(InputAction.CallbackContext context);
        void OnPlummet(InputAction.CallbackContext context);
    }
}