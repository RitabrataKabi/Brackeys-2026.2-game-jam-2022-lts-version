using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class intro_scene_ui_logic : MonoBehaviour
{
    [SerializeField] private intro_scene_transition_panel transition_Panel;
    public void LoadNextScene()
    {
        StartCoroutine(LoadSequence());
    }

    private IEnumerator LoadSequence()
    {
        transition_Panel.Initiate();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
        yield break;
    }
}
