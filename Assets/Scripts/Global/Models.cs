using System;
using System.Collections.Generic;
using UnityEngine;
public static class Models
{
    #region - Player -

    public enum PlayerStance
    {
        Stand,
        Crouch,
        Prone
    }

    [Serializable]
    public class PlayerSettingsModel
    {
        [Header("View Settings")]
        public float ViewXSensitivity;
        public float ViewYSensitivity;
        public float AimingSensitivityEffector;

        public bool ViewXInverted;
        public bool ViewYInverted;

        [Header("Movement Settings")]
        public bool SprintingHold;
        public float MovementSmoothing;

        [Header("Movement - Running")]
        public float RunningForwardSpeed;
        public float RunningStrafeSpeed;

        [Header("Movement - Walking")]
        public float WalkingForwardSpeed;
        public float WalkingBackwardSpeed;
        public float WalkingStrafeSpeed;

        [Header("Jumping")]
        public float JumpingHeight;
        public float JumpingFalloff;
        public float FallingSmoothing;

        [Header("Speed Effectors")]
        public float SpeedEffector = 1;
        public float CrouchSpeedEffector;
        public float ProneSpeedEffector;
        public float FallingSpeedEffector;
        public float AimingSpeedEffector;


        [Header("Is Grounded / Falling")]
        public float IsGroundedRadius;
        public float IsFallingSpeed;

    }

    [Serializable]
    public class CharacterStance
    {
        public float CameraHeight;
        public CapsuleCollider StanceCollider;
    }

    #endregion

    #region - Weapons -

    public enum WeaponFireType
    {
        SemiAuto,
        FullyAuto
    }
    [Serializable]
    public class WeaponSettingsModel
    {
        [Header("Weapon Sway")]
        public float SwayAmount;
        public bool SwayYInverted;
        public bool SwayXInverted;
        public float SwaySmoothing;
        public float SwayResetSmoothing;
        public float SwayClampX;
        public float SwayClampY;

        [Header("Weapon MovementSway")]
        public float MovementSwayX;
        public float MovementSwayY;
        public bool MovementSwayYInverted;
        public bool MovementSwayXInverted;
        public float MovementSwaySmoothing;

    }
    #endregion

    #region - Entity Attributes -
    [Serializable]
    public class AttributesModel
    {
        public float MaxHealth;
        [HideInInspector]
        public float CurrentHealth;
    }
    #endregion

    #region - Item Data -
    public enum ItemType
    {
        Healing,
        Equipment,
        Default,
        Weapon
    }

    public enum ItemAttributes{
        Agility,
        Intellect,
        Stamina,
        Strength
    }
    #endregion

    #region - Interface - 
    public enum InterfaceType{
        Inventory,
        Equipment
    }
    #endregion

    #region - Interactable Parameters -
    public class InteractableParameters{
        public Collider collider;
        public EntityInventory entityInventory;
    }
    #endregion
}