using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionController : MonoBehaviour
{
    void Start()
    {
        //  스택 미니게임은 세로 모드로 진행해야하므로 해상도를 변경
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else if (SceneManager.GetActiveScene().name == "StackScene")
        {
            Screen.SetResolution(540, 960, false);
        }
    }
}
