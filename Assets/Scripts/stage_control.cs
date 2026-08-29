using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_control : MonoBehaviour
{
    // public enum currentStage
    // {
    //     stage1 = 0,
    //     stage2 = 1,
    //     stage3 = 2
    // }

    // [SerializeField] private currentStage _currentStage = 0;


    private player_movement playerMovement;

    [SerializeField] private enemy_player_look_follow enemy_Player_Look_Follow;

    [SerializeField] private GameObject endScreenCanvas;

    void Start()
    {
        playerMovement = GetComponent<player_movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stage2"))
        {
            OnStageChange("stage2");
        }
        else if (other.CompareTag("stage3"))
        {
            OnStageChange("stage3");
        }
        else if (other.CompareTag("stop_enemy"))
        {
            enemy_Player_Look_Follow.StopAllCoroutines();
        }
        else if (other.CompareTag("Finish"))
        {
            Debug.Log("game is won, finished");
            if (endScreenCanvas != null)
                endScreenCanvas.SetActive(true);
            Application.Quit();
        }
    }

    public void OnStageChange(string stageTag)
    {
        if (stageTag == "stage2")
        {
            Debug.Log("entering stage 2");
            //invert controls   
            playerMovement.inputInverterMultiplier = -1;

        }
        else if (stageTag == "stage3")
        {
            Debug.Log("entering stage 3");
            //initiate the enemy follow script
            enemy_Player_Look_Follow.InitiateCoroutine();
        }
    }
}
