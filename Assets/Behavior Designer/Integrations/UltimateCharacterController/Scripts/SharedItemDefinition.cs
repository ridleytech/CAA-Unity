using Opsive.Shared.Inventory;

namespace BehaviorDesigner.Runtime.Tasks.UltimateCharacterController
{
    /// <summary>
    /// Creates a SharedVariable for the ItemType class.
    /// </summary>
    [System.Serializable]
    public class SharedItemDefinition : SharedVariable<ItemDefinitionBase>
    {
        public static implicit operator SharedItemDefinition(ItemDefinitionBase value) { var sharedVariable = new SharedItemDefinition(); sharedVariable.SetValue(value); return sharedVariable; }
    }
}