using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StamminaControler : MonoBehaviour
{
    [HideInInspector] public PlayerMovement _PlayerMovement;
    [Header("Stammina")]
    public float playerStammina = 100.0f;
    [SerializeField] public float maxStammina = 100.0f;
    [SerializeField] private float JumpCost = 20;
    [HideInInspector] public bool hasRegen = true;
    [HideInInspector] public bool Sprinting = false;
    

    [Header("Stammina regen")]
    [Range(0, 50)] private float StamminaRegen = 2.5f;
    [Range(0, 50)] private float StamminaDrain = 5f;


    [Header("Stammina UI")]
    [SerializeField] private Image stamminaUI = null;
    [SerializeField] private CanvasGroup slidercanvasGroup;

    private PlayerMovement PlayerController;
    void Start()
    {
        _PlayerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!Sprinting)
        {
            if(playerStammina <= maxStammina - 0.01)
            {
                
                playerStammina += StamminaRegen * Time.deltaTime;
                UptdateStammina(1);
                if (playerStammina > 10)
                {
                    _PlayerMovement.runCooldown = false;
                }
            }

            if (playerStammina >= maxStammina)
            {
                _PlayerMovement.setRunsSpeed(_PlayerMovement.walkspeed);
                slidercanvasGroup.alpha = 0;
                hasRegen = true;
            }
        }
    }

    public void StamminaJump()
    {
        if(playerStammina >= JumpCost)
        {
            playerStammina -= JumpCost;
            _PlayerMovement.PlayerJump();
            UptdateStammina(1);
        }
    }

    public void IsSprinting()
    {
        if (true)
        {
            print("drain");
            Sprinting = true;
            playerStammina -= StamminaDrain * Time.deltaTime;
            UptdateStammina(1);
            if (playerStammina <= 0)
            {
                hasRegen = false;
                _PlayerMovement.setRunsSpeed(_PlayerMovement.walkspeed);
                _PlayerMovement.state = PlayerMovement.MovementState.walking;
                _PlayerMovement.runCooldown = true;
                slidercanvasGroup.alpha = 0;
            }
        }
    }
    void UptdateStammina(int Value)
    {
        if (Value == 0)
        {
            slidercanvasGroup.alpha = 0;
        }
        else
        {
            slidercanvasGroup.alpha = 1;
        }
    }
}
