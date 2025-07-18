using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightFish : MonoBehaviour
{

    PlayerInput _playerInput;
    InputAction _fightFishAction;

    bool _isHolding = false; //是否按住鼠标左键

    void Awake()
    {
        //获取PlayerInput组件
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
            Debug.LogError("未找到PlayerInput组件");

        //获取FightAction
        _fightFishAction = _playerInput.actions["Fightfish"];
        if (_fightFishAction == null)
            Debug.LogError("未找到Fightfish动作");
    }

    private void OnMouseLeftHold(InputAction.CallbackContext context)
    {
        _isHolding = true;
    }

    private void OnMouseLeftRelease(InputAction.CallbackContext context)
    {
        _isHolding = false;
    }

    void Start()
    {
        //注册Fightfish动作的回调
        _fightFishAction.started += OnMouseLeftHold;
        _fightFishAction.canceled += OnMouseLeftRelease;
    }

    void OnDestroy()
    {
        //取消订阅
        _fightFishAction.started -= OnMouseLeftHold;
        _fightFishAction.canceled -= OnMouseLeftRelease;
    }

    void Update()
    {
        if (!GameManager._instance._isFishBite) return; //如果鱼没有咬钩，力量值不会改变

        //判断是否按住鼠标，如果按住则每一帧加力，没按住则每帧减少力
        if (_isHolding)
            UIManager._instance.AddForce();
        else
            UIManager._instance.ReduceForce();
    }
}
