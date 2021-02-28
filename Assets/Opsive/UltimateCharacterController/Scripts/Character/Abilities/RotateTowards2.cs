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

public class RotateTowards2 : Ability
{
    
    private float _maxRotationAngle = 10000; // turnSpeed
    public GameObject _targetGO;

    public override void ApplyRotation()
    {
        var angle = Quaternion.Angle(Quaternion.identity, m_CharacterLocomotion.Torque);
        if (angle > _maxRotationAngle)
        {
            m_CharacterLocomotion.Torque = Quaternion.Slerp(Quaternion.identity, m_CharacterLocomotion.Torque, _maxRotationAngle / angle);
        }
    }

    public override void UpdateRotation()
    {
        var agentPos = m_CharacterLocomotion.transform.position;
        var lookDirection = _targetGO.transform.position - agentPos;
        var rotation = m_Transform.rotation * Quaternion.Euler(m_CharacterLocomotion.DeltaRotation);
        var localLookDirection = m_Transform.InverseTransformDirection(lookDirection).normalized;
        localLookDirection.y = 0;

        lookDirection = MathUtility.TransformDirection(localLookDirection, rotation);
        var targetRotation = Quaternion.LookRotation(lookDirection, rotation * Vector3.up);
        m_CharacterLocomotion.DeltaRotation = (Quaternion.Inverse(m_Transform.rotation) * targetRotation).eulerAngles;

        base.UpdateRotation();
    }
    
}
}