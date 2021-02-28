using Opsive.Shared.Game;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.UltimateCharacterController
{
    [TaskDescription("Is the player being attacked?")]
    [TaskCategory("Ultimate Character Controller")]
    [TaskIcon("Assets/Behavior Designer/Integrations/UltimateCharacterController/Editor/Icon.png")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer/integrations/opsive-character-controllers/")]
    public class IsEngaged : Conditional
    {
        [Tooltip("A reference to the agent. If null it will be retrieved from the current GameObject.")]
        public SharedGameObject m_TargetGameObject;

        private GameObject m_PrevTarget;
        private CombatManager m_Engaged;

        /// <summary>
        /// Retrieves the Engaged component.
        /// </summary>
        public override void OnStart()
        {
            var target = GetDefaultGameObject(m_TargetGameObject.Value);
            if (target != m_PrevTarget) {
                //m_Engaged = target.GetCachedParentComponent<CombatManager>();
                m_Engaged = GameObject.Find("CombatManager").GetCachedParentComponent<CombatManager>();

                m_PrevTarget = target;
            }
        }

        /// <summary>
        /// Returns succes if the agent is alive.
        /// </summary>
        /// <returns>Success if the agent is alive.</returns>
        public override TaskStatus OnUpdate()
        {
            if (m_Engaged == null) {
                return TaskStatus.Failure;
            }

            return m_Engaged.isEngaged ? TaskStatus.Failure : TaskStatus.Success;
        }

        /// <summary>
        /// Resets the objects back to their default values.
        /// </summary>
        public override void OnReset()
        {
            m_TargetGameObject = null;
        }
    }
}