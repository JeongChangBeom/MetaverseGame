using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : BaseInteractiveObjects
{
    UIManager uiManager;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            uiManager = canvas.GetComponent<UIManager>();
        }
        else
        {
            Debug.LogError("Canvas�� �����ϴ�.");
        }
    }

    //  �������忡�� ��ȣ�ۿ��ϸ� ���������� UI�� Ȱ��ȭ ��
    public override void Interactive()
    {
        base.Interactive();
        uiManager.ChangeState(UIState.Leaderboard);
    }

    // �������忡�� �������� ���������� UI�� ��Ȱ��ȭ �ǰ� �ٽ� ���� UI�� Ȱ��ȭ ��
    public override void OffKey()
    {
        base.OffKey();
        uiManager.ChangeState(UIState.Game);
    }
}
