using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Button jumpButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 마우스로 누른 것처럼 처리
            ExecuteEvents.Execute<IPointerClickHandler>(
                target: jumpButton.gameObject,
                eventData: new PointerEventData(EventSystem.current),
                functor: ExecuteEvents.pointerClickHandler
            );
        }
    }
}