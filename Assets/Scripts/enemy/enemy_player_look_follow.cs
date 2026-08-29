using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_player_look_follow : MonoBehaviour
{
    private Transform player = null;

    [SerializeField] private float maxDistanceDelta = 1f;
    // moveSpeed = 10f, rotationSpeed = 10f,

    //what are we trying to do here?
    /*
    - we will find the player body and have a initiation function call and not start it at well with Start(), anyways, keep the player body reference with us
    - find a look direction vector and constantly look towards the player in the Enumerator function
    - slowly move towards the player, while the player must run away from it
    - the speed of the enemy must be less than the player as it will be flying
    - using Movetowards function to well move towards the player's dynamic position
    */

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void InitiateCoroutine()
    {
        StartCoroutine(MovementCoroutine());
    }

    private IEnumerator MovementCoroutine()
    {
        if (player == null) { Debug.LogError("Player reference not found"); yield break; }

        while (true)
        {
            //finding the direction towards the player
            // Vector3 lookDirection = (player.position - transform.position).normalized; //hate using normalized here but time is short
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(lookDirection), rotationSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, player.position, maxDistanceDelta);

            // transform.Translate(new Vector3(lookDirection.x, 0, lookDirection.z) * moveSpeed);

            yield return null;
        }
    }
}
