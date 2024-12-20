using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PosetliKadinMovement : MonoBehaviour //PLAYER INPUT MANAGER KODLARI BURAYA YAZILACAK
{
    private PlayerInput playerControls;

    [SerializeField] Vector2 movementInput;
     public float horizontalInput;
    public float verticalInput;
    public float moveAmount;


    private void Update()
    {
        HandleMovementInput();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerInput();
            //input tuşuna basıldığında  vector2'yi o yönde değiştir.
            playerControls.PosetliKadin.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        }

        playerControls.Enable();

    }

    private void HandleMovementInput()
    {
        //movementInput vektörünün x ve y değerlerini 2 farklı değişkene atar.
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        //Aşağıda moveAmount'u 0 ile 1 değeri arasında kısıtladık. yani vektörün x ve y değerlerinin mutlak değerinin toplamı 1 ila 0 arasında bir değer almak zorunda.
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
        
    }
}
