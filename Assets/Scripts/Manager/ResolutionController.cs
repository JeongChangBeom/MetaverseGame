using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionController : MonoBehaviour
{
    void Start()
    {
        //  ���� �̴ϰ����� ���� ���� �����ؾ��ϹǷ� �ػ󵵸� ����
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
