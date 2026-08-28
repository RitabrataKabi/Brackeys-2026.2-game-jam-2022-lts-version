using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger : MonoBehaviour
{
    //reference to the parent checkpoint manager script
    private checkpointManager checkpointManager;
    private int checkpointINDEXthis = 0;

    private void Start()
    {
        checkpointManager = transform.GetComponentInParent<checkpointManager>();
        checkpointINDEXthis = transform.GetSiblingIndex();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("triggered by the player, with checkpoint index " + checkpointINDEXthis);

            //actual code goes here
            if (!checkpointManager) return;
            checkpointManager.UpdateCheckpoint(checkpointINDEXthis);
        }
    }
}
