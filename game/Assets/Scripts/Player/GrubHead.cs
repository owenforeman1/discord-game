using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrubHead : MonoBehaviour
{
    public int numSegments = 3;
    public GameObject GrubSegmentHead;
    public GameObject GrubSegmentBody;


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement PlayerMovement = GetComponent<PlayerMovement>();
        
        Transform lastSegment = transform;
        for (int i = 0; i < numSegments; i++)
        {
            GameObject GrubSegment;
            if (i == 0)
            {
                GrubSegment = GrubSegmentHead;
            }
            else
            {
                GrubSegment = GrubSegmentBody;
            }



            GameObject newGrubSegmentObj = Instantiate(GrubSegment, transform.position, Quaternion.identity);
            GrubSegment newGrubSegment = newGrubSegmentObj.GetComponent<GrubSegment>();
            newGrubSegment.playerMovement = PlayerMovement;
            newGrubSegment.followedSegment = lastSegment;
            newGrubSegment.index = i;

            lastSegment = newGrubSegmentObj.transform;
        }
    }

}
