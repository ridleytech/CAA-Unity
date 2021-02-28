namespace Opsive.UltimateCharacterController.Character.Abilities
{
using UnityEngine;
    using Opsive.Shared.Events;
    using Opsive.Shared.Game;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Audio;
    using Opsive.UltimateCharacterController.Input;
    using Opsive.UltimateCharacterController.SurfaceSystem;
    using Opsive.UltimateCharacterController.Utility;
    using UnityEngine;
    //using BehaviorDesigner.Runtime.Tasks.Movement;
   //using BehaviorDesigner.Runtime.Tasks.NavMeshMovement;

   
    
public class RotateTowards3 : Ability
{
    
            [SerializeField] protected bool m_RotateTowardsLookSourceTarget = true;

        public bool RotateTowardsLookSourceTarget { get { return m_RotateTowardsLookSourceTarget; } set { m_RotateTowardsLookSourceTarget = value; } }


    private ILookSource m_LookSource;
    public override void Awake()
    {
        base.Awake();
        EventHandler.RegisterEvent<ILookSource>(m_GameObject, "OnCharacterAttachLookSource", OnAttachLookSource);

        // The look source may have already been assigned if the ability was added to the character after the look source was assigned.
        m_LookSource = m_CharacterLocomotion.LookSource;
    }
    private void OnAttachLookSource(ILookSource lookSource)
    {

        m_LookSource = lookSource;

    }

    public override void UpdateRotation()
        {
            // If the character can look independently then the character does not need to rotate to face the look direction.
            if (m_CharacterLocomotion.ActiveMovementType.UseIndependentLook(true)) {
                return;
            }

            // The look source may be null if a remote player is still being initialized.
            if (m_LookSource == null || !m_RotateTowardsLookSourceTarget) {
                return;
            }

            // Determine the direction that the character should be facing.
            var lookDirection = m_LookSource.LookDirection(m_LookSource.LookPosition(), true, m_CharacterLayerManager.IgnoreInvisibleCharacterLayers, false);
            var rotation = m_Transform.rotation * Quaternion.Euler(m_CharacterLocomotion.DeltaRotation);
            var localLookDirection = MathUtility.InverseTransformDirection(lookDirection, rotation);
            localLookDirection.y = 0;
            lookDirection = MathUtility.TransformDirection(localLookDirection, rotation);
            var targetRotation = Quaternion.LookRotation(lookDirection, rotation * Vector3.up);
            m_CharacterLocomotion.DeltaRotation = (Quaternion.Inverse(m_Transform.rotation) * targetRotation).eulerAngles;
        }


    // public override void UpdateRotation()
    // {

    //     // The look source may be null if a remote player is still being initialized.
    //     if (m_LookSource == null)
    //     {
    //         return;
    //     }

    //     var localLookSourcePos = m_GameObject.GetComponent<LocalLookSource>().Target.position;
    //     // Determine the direction that the character should be facing.
    //     var lookDirection = m_LookSource.LookDirection(m_LookSource.LookPosition(), true, m_CharacterLayerManager.IgnoreInvisibleCharacterLayers, false);
    //     var rotation = m_Transform.rotation * Quaternion.Euler(m_CharacterLocomotion.DeltaRotation);
    //     var localLookDirection = MathUtility.InverseTransformDirection(lookDirection, rotation);
    //     localLookDirection.y = 0;
    //     lookDirection = MathUtility.TransformDirection(localLookDirection, rotation);
    //     var targetRotation = Quaternion.LookRotation(lookDirection, rotation * Vector3.up);
    //     Debug.Log((Quaternion.Inverse(m_Transform.rotation) * targetRotation).eulerAngles);
    //     m_CharacterLocomotion.DeltaRotation = (Quaternion.Inverse(m_Transform.rotation) * targetRotation).eulerAngles;

    // }

    //  public override bool ShouldBlockAbilityStart(Ability startingAbility)
    //     {
            
    //         return startingAbility is NavMeshMovement;
    //     }
}
}