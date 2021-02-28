using Opsive.Shared.Game;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.UltimateCharacterController
{
    [TaskDescription("Damages the agent.")]
    [TaskCategory("Ultimate Character Controller")]
    [TaskIcon("Assets/Behavior Designer/Integrations/UltimateCharacterController/Editor/Icon.png")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer/integrations/opsive-character-controllers/")]
    public class Damage : Action
    {
        [Tooltip("A reference to the agent. If null it will be retrieved from the current GameObject.")]
        public SharedGameObject m_TargetGameObject;
        [Tooltip("The amount of damage to inflict.")]
        public SharedFloat m_Amount;

        private GameObject m_PrevTarget;
        private Health m_Health;

        /// <summary>
        /// Retrieves the health component.
        /// </summary>
        public override void OnStart()
        {
            var target = GetDefaultGameObject(m_TargetGameObject.Value);
            if (target != m_PrevTarget) {
                m_Health = target.GetCachedComponent<Health>();
                m_PrevTarget = target;
            }
        }

        /// <summary>
        /// Returns succes if the agent is damaged.
        /// </summary>
        /// <returns>Success if the agent is damaged.</returns>
        public override TaskStatus OnUpdate()
        {
            if (m_Health == null || m_Amount.Value <= 0) {
                return TaskStatus.Failure;
            }

            m_Health.Damage(m_Amount.Value);
            return TaskStatus.Success;
        }

        /// <summary>
        /// Resets the objects back to their default values.
        /// </summary>
        public override void OnReset()
        {
            m_TargetGameObject = null;
            m_Amount = 0;
        }
    }
}