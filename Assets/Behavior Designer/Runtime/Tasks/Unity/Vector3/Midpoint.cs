using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityVector3
{
    [TaskCategory("Unity/Vector3")]
    [TaskDescription("Returns the distance between two Vector3s.")]
    public class Midpoint : Action
    {
        [Tooltip("The first Vector3")]
        public SharedVector3 firstVector3;
        [Tooltip("The second Vector3")]
        public SharedVector3 secondVector3;
        [Tooltip("The midpoint")]
        [RequiredField]
        public SharedVector3 storeResult;
        public SharedFloat offset;

        public override TaskStatus OnUpdate()
        {
            //storeResult.Value = Vector3.Distance(firstVector3.Value, secondVector3.Value);

            storeResult.Value = GetPoint() ;

            return TaskStatus.Success;
        }

        Vector3 GetPoint()
 {
    //get the positions of our transforms
    Vector3 pos1 = firstVector3.Value;
    Vector3 pos2 = secondVector3.Value;
    
    //get the direction between the two transforms -->
    Vector3 dir = (pos2 - pos1).normalized ;
 
    //get a direction that crosses our [dir] direction
    //NOTE! : this can be any of a buhgillion directions that cross our [dir] in 3D space
    //To alter which direction we're crossing in, assign another directional value to the 2nd parameter
    Vector3 perpDir = Vector3.Cross(dir, Vector3.right) ;
 
    //get our midway point
    Vector3 midPoint = (pos1 + pos2) / 2f ;
 
    //get the offset point
    //This is the point you're looking for.
    //Vector3 offsetPoint = midPoint + (perpDir * offset) ;
     Vector3 offsetPoint = midPoint + perpDir ;

    return offsetPoint ;
 }

        public override void OnReset()
        {
            firstVector3 = Vector3.zero;
            secondVector3 = Vector3.zero;
            storeResult = new Vector3();
        }
    }
}
