//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Inputs/DefaultInput.inputactions
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

public partial class @DefaultInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInput"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""b44a0ce9-e370-4122-9617-8bc96021d8fc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b54a0547-739d-4fa1-aeb8-f2d10e7959a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""View"",
                    ""type"": ""PassThrough"",
                    ""id"": ""42197f6d-f2c9-44af-aeb6-b0a8f174da47"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b5f463d9-4287-4dc1-a52a-45e18a33bc11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""400cd389-fe72-432c-8897-bd281513029c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Prone"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d645f17b-38e4-4d71-8521-a6d3b8b63870"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""b9de3829-9306-4aa3-8c81-40d9f60546e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintReleased"",
                    ""type"": ""Button"",
                    ""id"": ""0f7cd960-01ec-40c9-917d-ca465cc94341"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeanLeftPressed"",
                    ""type"": ""Button"",
                    ""id"": ""23733861-dfab-409d-a2bb-023985083065"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeanRightPressed"",
                    ""type"": ""Button"",
                    ""id"": ""8cf8935a-c526-49a6-9330-9a9d13ad3587"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeanLeftReleased"",
                    ""type"": ""Button"",
                    ""id"": ""656cd3ca-6de4-406b-b7b9-9966f989a988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeanRightReleased"",
                    ""type"": ""Button"",
                    ""id"": ""f6ec2fad-ae3c-4704-8d6d-6c34ede6cb44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LoseHealth"",
                    ""type"": ""Button"",
                    ""id"": ""57ea10b0-f1cd-4f19-bc85-82be141dcb76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GainHealth"",
                    ""type"": ""Button"",
                    ""id"": ""0623755d-492b-4f3b-8e9d-23772c87859f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2eda02e2-8357-4008-bc3d-58bdce7258c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0e10078-2fec-4755-8727-33f125af7e6e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8277817e-d611-4d3b-b2f0-b893dba16fef"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0c921d27-13b1-4fd0-83b8-01199be0588a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b238f2b-96d5-4536-9800-1d7e2845226e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""663630bd-8e2e-464c-bea5-a5ed08ae260a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2cf4ab94-ac5e-42c3-a742-e281732cb000"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b49a0362-eded-4db1-aa90-9d487eef4c51"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a143fb4-d88f-4d65-92e9-ec7229b7a945"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37a43f4a-1c15-4287-9471-b540a90c2ba0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Prone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ceca1c0c-a509-4c92-8f86-26053e73aa9b"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Prone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f62f2bb3-c798-471f-b696-fb8f774f0c81"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e49f3bf8-5d7b-42b9-85b1-1e127ec4122e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a042e4b-f3e8-454e-9ae7-395a703077a7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanLeftPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcdf8236-8192-4a07-a08d-65bbfb43eff1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanRightPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9df849b1-49b3-4218-bee9-582020e5536b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanLeftReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48c1b02c-6cff-4bd3-9e11-1f7be3454b29"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeanRightReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1d6dd48-93b0-4094-a762-e46675697e7f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoseHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb51d223-ad35-4e1a-907d-0c3d234d7411"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GainHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ce95c17-93ef-4828-864f-e3f046b53a50"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Weapon"",
            ""id"": ""70530384-d607-4dce-87d6-84a85677025d"",
            ""actions"": [
                {
                    ""name"": ""Fire2Pressed"",
                    ""type"": ""Button"",
                    ""id"": ""9468e7b5-f25f-4c9b-9dac-5e687a2ae7d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire2Released"",
                    ""type"": ""Button"",
                    ""id"": ""8e74305f-340a-4e20-9117-3dbdc7aabb64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire1Pressed"",
                    ""type"": ""Button"",
                    ""id"": ""c4a9cbcf-f1dd-473b-9bed-504200eaa7df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire1Released"",
                    ""type"": ""Button"",
                    ""id"": ""942faa58-abca-456c-b27c-2dedf18aa80c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""af302b76-bd7f-4f82-b08b-cd9446dcb3e4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire2Pressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""000a0009-2160-41c4-a916-f09ebf3d830d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire2Released"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dfce591-021c-4413-83db-a7995afbd31f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire1Pressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2199f9d2-9c1e-4584-b48e-6e618c11f5b0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire1Released"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_View = m_Character.FindAction("View", throwIfNotFound: true);
        m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
        m_Character_Crouch = m_Character.FindAction("Crouch", throwIfNotFound: true);
        m_Character_Prone = m_Character.FindAction("Prone", throwIfNotFound: true);
        m_Character_Sprint = m_Character.FindAction("Sprint", throwIfNotFound: true);
        m_Character_SprintReleased = m_Character.FindAction("SprintReleased", throwIfNotFound: true);
        m_Character_LeanLeftPressed = m_Character.FindAction("LeanLeftPressed", throwIfNotFound: true);
        m_Character_LeanRightPressed = m_Character.FindAction("LeanRightPressed", throwIfNotFound: true);
        m_Character_LeanLeftReleased = m_Character.FindAction("LeanLeftReleased", throwIfNotFound: true);
        m_Character_LeanRightReleased = m_Character.FindAction("LeanRightReleased", throwIfNotFound: true);
        m_Character_LoseHealth = m_Character.FindAction("LoseHealth", throwIfNotFound: true);
        m_Character_GainHealth = m_Character.FindAction("GainHealth", throwIfNotFound: true);
        m_Character_Interact = m_Character.FindAction("Interact", throwIfNotFound: true);
        // Weapon
        m_Weapon = asset.FindActionMap("Weapon", throwIfNotFound: true);
        m_Weapon_Fire2Pressed = m_Weapon.FindAction("Fire2Pressed", throwIfNotFound: true);
        m_Weapon_Fire2Released = m_Weapon.FindAction("Fire2Released", throwIfNotFound: true);
        m_Weapon_Fire1Pressed = m_Weapon.FindAction("Fire1Pressed", throwIfNotFound: true);
        m_Weapon_Fire1Released = m_Weapon.FindAction("Fire1Released", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_View;
    private readonly InputAction m_Character_Jump;
    private readonly InputAction m_Character_Crouch;
    private readonly InputAction m_Character_Prone;
    private readonly InputAction m_Character_Sprint;
    private readonly InputAction m_Character_SprintReleased;
    private readonly InputAction m_Character_LeanLeftPressed;
    private readonly InputAction m_Character_LeanRightPressed;
    private readonly InputAction m_Character_LeanLeftReleased;
    private readonly InputAction m_Character_LeanRightReleased;
    private readonly InputAction m_Character_LoseHealth;
    private readonly InputAction m_Character_GainHealth;
    private readonly InputAction m_Character_Interact;
    public struct CharacterActions
    {
        private @DefaultInput m_Wrapper;
        public CharacterActions(@DefaultInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @View => m_Wrapper.m_Character_View;
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputAction @Crouch => m_Wrapper.m_Character_Crouch;
        public InputAction @Prone => m_Wrapper.m_Character_Prone;
        public InputAction @Sprint => m_Wrapper.m_Character_Sprint;
        public InputAction @SprintReleased => m_Wrapper.m_Character_SprintReleased;
        public InputAction @LeanLeftPressed => m_Wrapper.m_Character_LeanLeftPressed;
        public InputAction @LeanRightPressed => m_Wrapper.m_Character_LeanRightPressed;
        public InputAction @LeanLeftReleased => m_Wrapper.m_Character_LeanLeftReleased;
        public InputAction @LeanRightReleased => m_Wrapper.m_Character_LeanRightReleased;
        public InputAction @LoseHealth => m_Wrapper.m_Character_LoseHealth;
        public InputAction @GainHealth => m_Wrapper.m_Character_GainHealth;
        public InputAction @Interact => m_Wrapper.m_Character_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @View.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnView;
                @Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouch;
                @Prone.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnProne;
                @Prone.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnProne;
                @Prone.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnProne;
                @Sprint.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
                @SprintReleased.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintReleased;
                @SprintReleased.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintReleased;
                @SprintReleased.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintReleased;
                @LeanLeftPressed.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftPressed;
                @LeanLeftPressed.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftPressed;
                @LeanLeftPressed.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftPressed;
                @LeanRightPressed.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightPressed;
                @LeanRightPressed.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightPressed;
                @LeanRightPressed.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightPressed;
                @LeanLeftReleased.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftReleased;
                @LeanLeftReleased.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftReleased;
                @LeanLeftReleased.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanLeftReleased;
                @LeanRightReleased.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightReleased;
                @LeanRightReleased.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightReleased;
                @LeanRightReleased.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLeanRightReleased;
                @LoseHealth.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLoseHealth;
                @LoseHealth.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLoseHealth;
                @LoseHealth.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLoseHealth;
                @GainHealth.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnGainHealth;
                @GainHealth.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnGainHealth;
                @GainHealth.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnGainHealth;
                @Interact.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Prone.started += instance.OnProne;
                @Prone.performed += instance.OnProne;
                @Prone.canceled += instance.OnProne;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @SprintReleased.started += instance.OnSprintReleased;
                @SprintReleased.performed += instance.OnSprintReleased;
                @SprintReleased.canceled += instance.OnSprintReleased;
                @LeanLeftPressed.started += instance.OnLeanLeftPressed;
                @LeanLeftPressed.performed += instance.OnLeanLeftPressed;
                @LeanLeftPressed.canceled += instance.OnLeanLeftPressed;
                @LeanRightPressed.started += instance.OnLeanRightPressed;
                @LeanRightPressed.performed += instance.OnLeanRightPressed;
                @LeanRightPressed.canceled += instance.OnLeanRightPressed;
                @LeanLeftReleased.started += instance.OnLeanLeftReleased;
                @LeanLeftReleased.performed += instance.OnLeanLeftReleased;
                @LeanLeftReleased.canceled += instance.OnLeanLeftReleased;
                @LeanRightReleased.started += instance.OnLeanRightReleased;
                @LeanRightReleased.performed += instance.OnLeanRightReleased;
                @LeanRightReleased.canceled += instance.OnLeanRightReleased;
                @LoseHealth.started += instance.OnLoseHealth;
                @LoseHealth.performed += instance.OnLoseHealth;
                @LoseHealth.canceled += instance.OnLoseHealth;
                @GainHealth.started += instance.OnGainHealth;
                @GainHealth.performed += instance.OnGainHealth;
                @GainHealth.canceled += instance.OnGainHealth;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // Weapon
    private readonly InputActionMap m_Weapon;
    private IWeaponActions m_WeaponActionsCallbackInterface;
    private readonly InputAction m_Weapon_Fire2Pressed;
    private readonly InputAction m_Weapon_Fire2Released;
    private readonly InputAction m_Weapon_Fire1Pressed;
    private readonly InputAction m_Weapon_Fire1Released;
    public struct WeaponActions
    {
        private @DefaultInput m_Wrapper;
        public WeaponActions(@DefaultInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire2Pressed => m_Wrapper.m_Weapon_Fire2Pressed;
        public InputAction @Fire2Released => m_Wrapper.m_Weapon_Fire2Released;
        public InputAction @Fire1Pressed => m_Wrapper.m_Weapon_Fire1Pressed;
        public InputAction @Fire1Released => m_Wrapper.m_Weapon_Fire1Released;
        public InputActionMap Get() { return m_Wrapper.m_Weapon; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponActions instance)
        {
            if (m_Wrapper.m_WeaponActionsCallbackInterface != null)
            {
                @Fire2Pressed.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Pressed;
                @Fire2Pressed.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Pressed;
                @Fire2Pressed.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Pressed;
                @Fire2Released.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Released;
                @Fire2Released.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Released;
                @Fire2Released.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire2Released;
                @Fire1Pressed.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Pressed;
                @Fire1Pressed.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Pressed;
                @Fire1Pressed.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Pressed;
                @Fire1Released.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Released;
                @Fire1Released.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Released;
                @Fire1Released.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnFire1Released;
            }
            m_Wrapper.m_WeaponActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire2Pressed.started += instance.OnFire2Pressed;
                @Fire2Pressed.performed += instance.OnFire2Pressed;
                @Fire2Pressed.canceled += instance.OnFire2Pressed;
                @Fire2Released.started += instance.OnFire2Released;
                @Fire2Released.performed += instance.OnFire2Released;
                @Fire2Released.canceled += instance.OnFire2Released;
                @Fire1Pressed.started += instance.OnFire1Pressed;
                @Fire1Pressed.performed += instance.OnFire1Pressed;
                @Fire1Pressed.canceled += instance.OnFire1Pressed;
                @Fire1Released.started += instance.OnFire1Released;
                @Fire1Released.performed += instance.OnFire1Released;
                @Fire1Released.canceled += instance.OnFire1Released;
            }
        }
    }
    public WeaponActions @Weapon => new WeaponActions(this);
    public interface ICharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnProne(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSprintReleased(InputAction.CallbackContext context);
        void OnLeanLeftPressed(InputAction.CallbackContext context);
        void OnLeanRightPressed(InputAction.CallbackContext context);
        void OnLeanLeftReleased(InputAction.CallbackContext context);
        void OnLeanRightReleased(InputAction.CallbackContext context);
        void OnLoseHealth(InputAction.CallbackContext context);
        void OnGainHealth(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IWeaponActions
    {
        void OnFire2Pressed(InputAction.CallbackContext context);
        void OnFire2Released(InputAction.CallbackContext context);
        void OnFire1Pressed(InputAction.CallbackContext context);
        void OnFire1Released(InputAction.CallbackContext context);
    }
}
