using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    //how are we doing it
    /* simple no saving checkpoint data, no saving player state, or env state, simply focusing on keeping track of the latest checkpoint and spawning the player at the latest check point upon functional call to respawn
    
    - using the transform children array to know which checkpoint is ranked what, 
    - based on a checkpoint index to know the progression
    - keeping a local active vector and updating it in case the triggered index is higher than the last kept in memory for the duration of the game check point index, i.e. the last triggered checkpoint, e.g. if new index is 3, and old is 2, we update the spawnPoint vector3 to the position of the new checkpoint and old one is discarded, in case say the triggered index is coming to be 1, then it is simply ignored

    - this script only handles the storing and keeping in RAM the latest checkpoint index and its corresponding position, along with the function that the player can with a reference call to respawn at whatever the latest checkpoint is that the time

    - each children trigger checkpoint contain a simple script that does the following:
        1. they find and keep in memory a reference to the parent checkpointManager script (i.e. this one)
        2. upon getting triggered by the player they call a UpdateCheckpoint function in this script
            the update checkpoint script checks and evaluates whether to do update or skip the call
        3. it de-activates its own collider (which is unnecessary but no point in keeping redundancies)
    */

    //simplest boilerplate singleton I could think of rn at 10:13 pm 26.08.2026

    private static checkpointManager _instance;
    public static checkpointManager instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        latestCheckpointPos = transform.GetChild(0).transform.position + _offset;
        latestCheckpointINDEX = 0;
    }

    //checkpoint code stuff

    public Vector3 latestCheckpointPos;
    private Vector3 _offset = new Vector3(0, 1.1f, 0);
    public int latestCheckpointINDEX = 0;

    public void UpdateCheckpoint(int triggeredIndex = 0)
    {
        if (triggeredIndex <= latestCheckpointINDEX) return;
        latestCheckpointINDEX = triggeredIndex;
    }

    public void RespawnPlayer(Transform playerTransform)
    {
        if (!playerTransform) return;
        Vector3 newPos = transform.GetChild(latestCheckpointINDEX).transform.position + _offset;
        playerTransform.position = newPos;
    }
}
