using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class intro_scene_ui_logic : MonoBehaviour
{
    [SerializeField] private GameObject transition_Panel;
    public void LoadNextScene()
    {
        soundManager.instance.PlaySound("button_click");
        StartCoroutine(LoadSequence());
    }

    private IEnumerator LoadSequence()
    {
        transition_Panel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
        yield break;
    }
}
