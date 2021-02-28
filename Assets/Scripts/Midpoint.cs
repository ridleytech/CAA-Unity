using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midpoint : MonoBehaviour
{

    [Tooltip("The first Vector3")]
        public GameObject firstVector3;
        [Tooltip("The second Vector3")]
        public GameObject secondVector3;
        [Tooltip("The midpoint")]
        public Vector3 storeResult;
        public float offset;
//public GameObject halfwayCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        storeResult = GetPoint();
        gameObject.transform.position = new Vector3(storeResult.x,firstVector3.transform.position.y+1f,storeResult.z);
    }

    Vector3 GetPoint()
 {
    //get the positions of our transforms
    Vector3 pos1 = firstVector3.transform.position;
    Vector3 pos2 = secondVector3.transform.position;
    
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
}
