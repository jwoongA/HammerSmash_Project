using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();
    public virtual void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state); //같다면 키고 다르면 끈다.
    }
}