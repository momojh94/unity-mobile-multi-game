﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;    //UI 클릭시 터치 이벤트 발생 방지.

// 이거 아마 이동식 조이스틱 구현할 때 만들었던 것 같음??

public class ControllerUI : MonoBehaviourSingleton<ControllerUI>, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public delegate void UseAllCostInGroupCallBack();

    #region variable
    private Vector2 outPos;
    private Vector2 touchPos;
    private float screenHalfWidth;
    private bool touched;
    private UseAllCostInGroupCallBack emoticonButtonClickedCallback;
    #endregion

    #region controllComponents
    [SerializeField] private MovingJoystick movingJoystick;
    [SerializeField] private SkillButton skillBtn;
    [SerializeField] private EmoticonButton[] emoticonBtnList;
    #endregion

    #region components
    private RectTransform movingJoystickTransform;
    #endregion

    #region unityFunc
    private void Awake()
    {
        movingJoystickTransform = movingJoystick.GetComponent<RectTransform>();

        screenHalfWidth = Screen.width * 0.5f;
        outPos = movingJoystickTransform.position;
        touched = false;
        movingJoystickTransform.position = outPos;
        foreach (EmoticonButton emoticonBtn in emoticonBtnList)
        {
            emoticonButtonClickedCallback += emoticonBtn.UseAllCost;
        }
    }
    #endregion
    
    #region func
    public void IsTouched()
    {
        touched = true;
    }
    public void SetPlayer(UBZ.Owner.MultiPlayer player, ref PlayerController controller)
    {
        movingJoystick.SetPlayer(player);
        skillBtn.SetPlayer(player);
        foreach(EmoticonButton emoticonBtn in emoticonBtnList)
        {
            Debug.Log(emoticonBtn);
            emoticonBtn.SetPlayer(player);
        }
        controller = new PlayerController(movingJoystick);
    }
    void DrawMoveJoyStick()
    {
        movingJoystickTransform.position = touchPos;
    }
    void HideMoveJoyStick()
    {
        movingJoystickTransform.position = outPos;
    }
    #endregion


    #region Handler

    public void OnDrag(PointerEventData eventData)
    {
        movingJoystick.OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HideMoveJoyStick();
        movingJoystick.OnPointerUp(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (touched)
        {
            touched = false;
            return;
        }
        if (eventData.position.x < screenHalfWidth)
        {
            touchPos = eventData.position;
            DrawMoveJoyStick();
        }
    }


    public void EmoticonButtonClicked()
    {
        emoticonButtonClickedCallback();
    }
    #endregion
}