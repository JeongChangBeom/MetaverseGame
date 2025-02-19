using UnityEngine;

public abstract class StackBaseUI : MonoBehaviour
{
    protected StackUIManager uiManager;

    public virtual void Init(StackUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract StackUIState GetUIState();

    public void SetActive(StackUIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
