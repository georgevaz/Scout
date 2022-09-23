using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Models;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput defaultInput;
    private EntityStats entityHealth;
    private EntityInventory entityInventory;
    [HideInInspector]
    public Vector2 inputMovement;
    [HideInInspector]
    public Vector2 inputView;

    private Vector3 newCameraRotation;
    private Vector3 newCharacterRotation;

    [Header("References")]
    public Transform cameraHolder;
    public Transform _camera;
    private Camera actualCamera;
    public Transform feetTransform;
    public GameObject pauseScreen;
    public GameObject itemPickUpScreen;
    public Animator inventoryScreenFlash;

    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    public float viewClampYMin = -70;
    public float viewClampYMax = 80;
    public LayerMask playerMask;
    public LayerMask groundMask;
    public LayerMask raycastMask;

    [Header("Gravity")]
    public float gravityAmount;
    public float gravityMin;
    private float playerGravity;

    public Vector3 jumpingForce;
    private Vector3 jumpingForceVelocity;

    [Header("Stance")]
    public PlayerStance playerStance;
    public float playerStanceSmoothing;
    public CharacterStance playerStandStance;
    public CharacterStance playerCrouchStance;
    public CharacterStance playerProneStance;
    private float stanceCheckErrorMargin = 0.05f;
    private float cameraHeight;
    private float cameraHeightVelocity;

    private Vector3 stanceCapsuleCenterVelocity;
    private float stanceCapsuleHeightVelocity;
    [HideInInspector]
    public bool isSprinting;

    private Vector3 newMovementSpeed;
    private Vector3 newMovementSpeedVelocity;

    [Header("Weapon")]
    public WeaponController currentWeapon;
    // [HideInInspector]
    public float weaponAnimationSpeed;

    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isFalling;

    [Header("Leaning")]
    public Transform leanPivot;
    private float currentLean;
    private float targetLean;
    public float leanAngle;
    public float leanSmoothing;
    public bool leanWhileProne;
    private float leanVelocity;
    private bool isLeaningLeft;
    private bool isLeaningRight;

    [Header("Aiming In")]
    public bool isAimingIn;

    [Header("Raycasting")]
    [SerializeField]
    private float raycastDistance = 3f;
    [Header("Interactables")]
    InteractableParameters interactableParameters;
    [Header("Pausing")]
    public static bool gameIsPaused = false;
    private bool inPickupScreen = false;

    #region - Awake
    private void Awake()
    {
        actualCamera = GetComponentInChildren<Camera>();

        Cursor.visible = false;
        defaultInput = new DefaultInput();


        entityHealth = GetComponent<EntityStats>();
        entityInventory = GetComponent<EntityInventory>();

        interactableParameters = new InteractableParameters();
        interactableParameters.entityInventory = entityInventory;

        defaultInput.Character.Movement.performed += e => inputMovement = e.ReadValue<Vector2>();
        defaultInput.Character.View.performed += e => inputView = e.ReadValue<Vector2>();
        defaultInput.Character.Jump.performed += e => Jump();
        defaultInput.Character.Interact.performed += e => PlayerInteract();
        defaultInput.Character.Inventory.performed += e => ToggleInventory();

        defaultInput.Character.Crouch.performed += e => Crouch();
        defaultInput.Character.Prone.performed += e => Prone();

        defaultInput.Character.Sprint.performed += e => ToggleSprint();
        defaultInput.Character.SprintReleased.performed += e => StopSprint();


        defaultInput.Character.LeanLeftPressed.performed += e => isLeaningLeft = true;
        defaultInput.Character.LeanLeftReleased.performed += e => isLeaningLeft = false;

        defaultInput.Character.LeanRightPressed.performed += e => isLeaningRight = true;
        defaultInput.Character.LeanRightReleased.performed += e => isLeaningRight = false;

        defaultInput.Weapon.Fire2Pressed.performed += e => AimingInPressed();
        defaultInput.Weapon.Fire2Released.performed += e => AimingInReleased();

        defaultInput.Weapon.Fire1Pressed.performed += e => ShootingPressed();
        defaultInput.Weapon.Fire1Released.performed += e => ShootingReleased();

        defaultInput.Character.GainHealth.performed += e => entityHealth.GainHealth();
        defaultInput.Character.LoseHealth.performed += e => entityHealth.LoseHealth();


        defaultInput.Enable();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newCharacterRotation = transform.localRotation.eulerAngles;

        characterController = GetComponent<CharacterController>();

        cameraHeight = cameraHolder.localPosition.y;



        if (currentWeapon)
        {
            currentWeapon.Initialize(this);
        }
    }
    #endregion


    #region - Update -
    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked && !gameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (!gameIsPaused)
        {
            SetIsGrounded();
            SetIsFalling();

            CalculateMovement();
            CalculateView();
            CalculateJump();
            CalculateStance();
            CalculateLeaning();
            CalculateAimingIn();

        }
    }

    #endregion
    #region - Shooting -
    private void ShootingPressed()
    {
        if (currentWeapon)
        {
            currentWeapon.isShooting = true;
        }
    }
    private void ShootingReleased()
    {
        if (currentWeapon)
        {
            currentWeapon.isShooting = false;
        }

    }
    #endregion

    #region - Aiming In -
    private void AimingInPressed()
    {
        if (isSprinting) // If pressed while sprinting, stop sprinting to aim in.
        {
            isSprinting = false;
        }
        isAimingIn = true;

    }
    private void AimingInReleased()
    {
        isAimingIn = false;
    }

    private void CalculateAimingIn()
    {
        if (!currentWeapon)
        {
            return;
        }
        currentWeapon.isAimingIn = isAimingIn;

    }
    #endregion
    #region - IsFalling / IsGrounded -
    private void SetIsGrounded()
    {

        isGrounded = Physics.CheckSphere(feetTransform.position, playerSettings.IsGroundedRadius, groundMask);
    }

    private void SetIsFalling()
    {

        isFalling = (!isGrounded && characterController.velocity.magnitude >= playerSettings.IsFallingSpeed);

    }
    #endregion
    #region - View / Movement -
    private void CalculateView()
    {
        newCharacterRotation.y += (isAimingIn ? playerSettings.ViewXSensitivity * playerSettings.AimingSensitivityEffector : playerSettings.ViewXSensitivity) * (playerSettings.ViewXInverted ? -inputView.x : inputView.x) * Time.deltaTime; // bool is check for inverted state
        transform.localRotation = Quaternion.Euler(newCharacterRotation);

        newCameraRotation.x += (isAimingIn ? playerSettings.ViewYSensitivity * playerSettings.AimingSensitivityEffector : playerSettings.ViewYSensitivity) * (playerSettings.ViewYInverted ? inputView.y : -inputView.y) * Time.deltaTime; // bool is check for inverted state
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYMin, viewClampYMax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);

    }

    private void CalculateMovement()
    {
        if (inputMovement.y <= 0.2f)
        {
            isSprinting = false;
        }

        var verticalSpeed = playerSettings.WalkingForwardSpeed;
        var horizontalSpeed = playerSettings.WalkingStrafeSpeed;

        // Walking backwards
        if (inputMovement.y < 0)
        {
            verticalSpeed = playerSettings.WalkingBackwardSpeed;
        }

        if (isSprinting)
        {
            verticalSpeed = playerSettings.RunningForwardSpeed;
            horizontalSpeed = playerSettings.RunningStrafeSpeed;
        }

        // Effectors

        if (!isGrounded)
        {
            playerSettings.SpeedEffector = playerSettings.FallingSpeedEffector;
        }
        else if (playerStance == PlayerStance.Crouch)
        {
            playerSettings.SpeedEffector = playerSettings.CrouchSpeedEffector;
        }
        else if (playerStance == PlayerStance.Prone)
        {
            playerSettings.SpeedEffector = playerSettings.ProneSpeedEffector;
        }
        else
        {
            playerSettings.SpeedEffector = 1;
        }

        // Alter the speed effector of the corresponding stance player is in with the aiming effector.
        if (isAimingIn)
        {
            playerSettings.SpeedEffector *= playerSettings.AimingSpeedEffector;
        }


        weaponAnimationSpeed = (!isAimingIn ? characterController.velocity.magnitude / (playerSettings.WalkingForwardSpeed * playerSettings.SpeedEffector) : 0); // Bool check to see if we are not aiming in in order to alter the weapon animation.

        if (weaponAnimationSpeed > 1)
        {
            weaponAnimationSpeed = 1;
        }

        verticalSpeed *= playerSettings.SpeedEffector;
        horizontalSpeed *= playerSettings.SpeedEffector;

        newMovementSpeed = Vector3.SmoothDamp(newMovementSpeed, new Vector3(horizontalSpeed * inputMovement.x * Time.deltaTime, 0, verticalSpeed * inputMovement.y * Time.deltaTime), ref newMovementSpeedVelocity, isGrounded ? playerSettings.MovementSmoothing : playerSettings.FallingSmoothing);
        var MovementSpeed = transform.TransformDirection(newMovementSpeed);


        if (playerGravity > gravityMin)
        {
            playerGravity -= gravityAmount * Time.deltaTime;
        }

        if (playerGravity < -0.1f && isGrounded)
        {
            playerGravity = -0.1f;
        }

        MovementSpeed.y += playerGravity;

        MovementSpeed += jumpingForce * Time.deltaTime;

        characterController.Move(MovementSpeed);


    }
    #endregion
    #region - Leaning -


    private void CalculateLeaning()
    {
        if (isLeaningLeft)
        {
            targetLean = leanAngle;
        }
        else if (isLeaningRight)
        {
            targetLean = -leanAngle;
        }
        else
        {
            targetLean = 0;
        }

        if (!leanWhileProne && playerStance == PlayerStance.Prone) // A check to see if this toggle is off and if the player is in prone position.
        {
            targetLean = 0;
        }

        currentLean = Mathf.SmoothDamp(currentLean, targetLean, ref leanVelocity, leanSmoothing);
        leanPivot.localRotation = Quaternion.Euler(new Vector3(0, 0, currentLean));
    }

    #endregion
    #region - Jump -
    private void CalculateJump()
    {
        jumpingForce = Vector3.SmoothDamp(jumpingForce, Vector3.zero, ref jumpingForceVelocity, playerSettings.JumpingFalloff);
    }
    private void Jump()
    {

        if (!isGrounded || playerStance == PlayerStance.Prone)
        {
            return;
        }

        if (playerStance == PlayerStance.Crouch)
        {
            if (StanceCheck(playerStandStance.StanceCollider.height))
            {
                return;
            }
            playerStance = PlayerStance.Stand;
            return;
        }

        jumpingForce = Vector3.up * playerSettings.JumpingHeight;
        playerGravity = 0;

        currentWeapon.TriggerJump();
    }
    #endregion

    #region - Stance - 
    private void CalculateStance()
    {
        var currentStance = playerStandStance;

        if (playerStance == PlayerStance.Crouch)
        {
            currentStance = playerCrouchStance;
        }
        else if (playerStance == PlayerStance.Prone)
        {
            currentStance = playerProneStance;
        }

        cameraHeight = Mathf.SmoothDamp(cameraHolder.localPosition.y, currentStance.CameraHeight, ref cameraHeightVelocity, playerStanceSmoothing);
        cameraHolder.localPosition = new Vector3(cameraHolder.localPosition.x, cameraHeight, cameraHolder.localPosition.z);

        characterController.height = Mathf.SmoothDamp(characterController.height, currentStance.StanceCollider.height, ref stanceCapsuleHeightVelocity, playerStanceSmoothing);
        characterController.center = Vector3.SmoothDamp(characterController.center, currentStance.StanceCollider.center, ref stanceCapsuleCenterVelocity, playerStanceSmoothing);
    }

    private void Crouch()
    {
        if (playerStance == PlayerStance.Crouch)
        {
            if (StanceCheck(playerStandStance.StanceCollider.height))
            {
                return;
            }

            playerStance = PlayerStance.Stand;
            return;
        }
        if (StanceCheck(playerCrouchStance.StanceCollider.height))
        {
            return;
        }

        playerStance = PlayerStance.Crouch;
    }
    private void Prone()
    {
        // This brings player from prone to standing skipping crouch. Reconsidering if this is worthwhile to keep.
        if (playerStance == PlayerStance.Prone)
        {
            if (StanceCheck(playerStandStance.StanceCollider.height))
            {
                return;
            }
            playerStance = PlayerStance.Stand;
            return;
        }

        playerStance = PlayerStance.Prone;

    }

    private bool StanceCheck(float stanceCheckHeight)
    {
        var start = new Vector3(feetTransform.position.x, feetTransform.position.y + characterController.radius + stanceCheckErrorMargin, feetTransform.position.z);
        var end = new Vector3(feetTransform.position.x, feetTransform.position.y - characterController.radius - stanceCheckErrorMargin + stanceCheckHeight, feetTransform.position.z);


        return Physics.CheckCapsule(start, end, characterController.radius, playerMask);
    }
    #endregion

    #region - Sprinting -
    private void ToggleSprint()
    {
        if (inputMovement.y <= 0.2f || isAimingIn) // Don't sprint if aiming in, moving backwards, or not moving.
        {
            isSprinting = false;
            return;
        }
        isSprinting = !isSprinting;
    }
    private void StopSprint()
    {
        if (playerSettings.SprintingHold)
        {
            isSprinting = false;

        }
    }
    #endregion
    #region - Interaction -
    // This section will need revamping once Raycasting is developed. The triggers are for testing the inventory system for the time being.
    private void PlayerInteract()
    {
        if (inPickupScreen)
        {
            inPickupScreen = false;
            defaultInput.Character.Inventory.Enable();
            for (int i = 0; i < itemPickUpScreen.transform.childCount; i++)
            {
                itemPickUpScreen.transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("PickUp", false);
            }
            StartCoroutine(WaitForPickUpAnimation());
            Resume();
            inventoryScreenFlash.SetBool("ToInventory", gameIsPaused);
        }

        bool hit;
        Collider collider;
        CalculateInteractionRaycast(out hit, out collider);

        if (hit && collider.gameObject.GetComponent(typeof(Interactable)))
        {
            Interactable interactable = collider.GetComponent(typeof(Interactable)) as Interactable;
            interactableParameters.collider = collider;
            interactable.Interact(interactableParameters);

            if (collider.gameObject.GetComponent<GroundItem>() && !inPickupScreen)
            {
                inPickupScreen = true;
                defaultInput.Character.Inventory.Disable();
                Pause();

                inventoryScreenFlash.SetBool("ToInventory", gameIsPaused);

                itemPickUpScreen.transform.GetChild(0).transform.GetComponent<Image>().sprite = collider.GetComponent<GroundItem>().item.icon;
                itemPickUpScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = collider.GetComponent<GroundItem>().item.data.Name;

                for (int i = 0; i < itemPickUpScreen.transform.childCount; i++)
                {
                    var child = itemPickUpScreen.transform.GetChild(i);

                    child.gameObject.SetActive(true);
                    child.gameObject.GetComponent<Animator>().SetBool("PickUp", true);
                }

            }
        }

    }

    IEnumerator WaitForPickUpAnimation()
    {
        yield return new WaitForSecondsRealtime(.25f);
        itemPickUpScreen.transform.GetChild(0).gameObject.SetActive(false);
        itemPickUpScreen.transform.GetChild(1).gameObject.SetActive(false);
        itemPickUpScreen.transform.GetChild(0).transform.GetComponent<Image>().sprite = null;
        itemPickUpScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
    }

    private void CalculateInteractionRaycast(out bool hit, out Collider collider)
    {
        Ray ray = new Ray(actualCamera.transform.position, actualCamera.transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * raycastDistance); // Show raycast line
        RaycastHit hitInfo; // store collision info
        if (Physics.Raycast(ray, out hitInfo, raycastDistance, raycastMask))
        {
            if (hitInfo.collider.GetComponent<GroundItem>() != null)
            {
                hit = true;
                collider = hitInfo.collider;
                return;
            }
        }
        hit = false;
        collider = null;
    }
    #endregion

    #region  - Inventory / Pausing - 
    private void ToggleInventory()
    {
        CheckPauseState();

        if (gameIsPaused)
        {
            inventoryScreenFlash.SetBool("ToInventory", gameIsPaused);
            StartCoroutine(WaitForInventoryAnimation());
            defaultInput.Character.Interact.Disable();
        }
        else if (!gameIsPaused)
        {
            for (int i = 0; i < pauseScreen.transform.childCount; i++)
            {
                pauseScreen.transform.GetChild(i).gameObject.SetActive(gameIsPaused);
            }
            inventoryScreenFlash.SetBool("ToInventory", gameIsPaused);
            defaultInput.Character.Interact.Enable();
        }
    }

    private void CheckPauseState()
    {
        if (gameIsPaused)
        {
            Resume();
            Cursor.visible = false;
        }
        else
        {
            Pause();
            Cursor.visible = true;
        }
    }

    private void Resume()
    {
        gameObject.GetComponentInChildren<WeaponController>().enabled = true;
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        gameObject.GetComponentInChildren<WeaponController>().enabled = false;
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    IEnumerator WaitForInventoryAnimation()
    {
        yield return new WaitForSecondsRealtime(.25f);
        for (int i = 0; i < pauseScreen.transform.childCount; i++)
        {
            pauseScreen.transform.GetChild(i).gameObject.SetActive(true);
        }

    }
    #endregion
    #region - Gizmos -

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetTransform.position, playerSettings.IsGroundedRadius);
    }

    #endregion
}