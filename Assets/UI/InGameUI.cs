using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameUI : BaseUI
{
    public override void SetActive(UIState state)
    {
        Debug.Log("SetActive ȣ���");
        base.SetActive(state);

    }

    protected override UIState GetUIState()
    {
        return UIState.InGame;
    }

    public Button jumpButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // ���콺�� ���� ��ó�� ó��
            ExecuteEvents.Execute<IPointerClickHandler>(
                target: jumpButton.gameObject,
                eventData: new PointerEventData(EventSystem.current),
                functor: ExecuteEvents.pointerClickHandler
            );
        }
    }
}