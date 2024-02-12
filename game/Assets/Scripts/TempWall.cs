using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWall : MonoBehaviour
{
    // Put in sands that need to be collected for door to open
    public List<Sand> sands = new List<Sand>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOpen();
    }


    private void CheckOpen()
    {
        foreach (Sand sand in sands)
        {
            if (sand != null)
            {
                return;
            }
        }

        Destroy(gameObject);
    }
}
