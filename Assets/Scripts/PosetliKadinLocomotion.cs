using System;
using UnityEngine;
using UnityEngine.InputSystem;


    public class PosetliKadinLocomotion : MonoBehaviour  //PLAYER LOCOMOTION MANAGER && CHARACTER LOCOMOTION MANAGER KODLARI BURAYA YAZILACAK
    {    
        [SerializeField] float walkingSpeed = 2.0f ;
        [SerializeField] float runningSpeed = 5.0f;
        [SerializeField] private float rotationSpeed = 15.0f;
      
        
        PosetliKadinManager player;
        private PosetliKadinMovement InputManager;
        
        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;
        
        private Vector3 moveDirection;
        private Vector3 targetRotationDirection;

        private void Awake()
        {
            player = GetComponent<PosetliKadinManager>();
            InputManager = GetComponent<PosetliKadinMovement>();
        }
        
        private void Update()
        {
            HandleAllMovement();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
        }
        
        private void GetVerticalAndHorizontalInputs()
        {
            verticalMovement = InputManager.verticalInput;
            horizontalMovement = InputManager.horizontalInput;
            
            //Clamp the movements
        }

        private void HandleGroundedMovement()//Karakterin x-z düzlemindeki hareketi
        {    
            GetVerticalAndHorizontalInputs();
            //Hareket yönü karakterin yönüne ve hareket inputlarına göre belirlenir.
            moveDirection = player.transform.forward * verticalMovement; //Karakterin ileri geri hareket etmesini sağlar
            moveDirection = moveDirection + player.transform.right * horizontalMovement; //Saga sola hareket
            moveDirection.Normalize(); //Normalleştirme, bir vektörün uzunluğunu (magnitude) 1'e indirger, ancak yönünü değiştirmez Bu işlem, oyuncunun farklı yönlere hareket ederken hızının tutarlı olmasını sağlar.
            moveDirection.y = 0; //oyuncunun hareketini x-z düzlemine kısıtlar.

            if (InputManager.moveAmount > 0.5f)
            {
                player._characterController.Move(moveDirection  * runningSpeed * Time.deltaTime);
            }
            else if (InputManager.moveAmount <= 0.5f)
            {
                player._characterController.Move(moveDirection * Time.deltaTime * walkingSpeed);
            }
        }

        private void HandleRotation()
        {
            targetRotationDirection = Vector3.zero; //Başlangıç değerini sıfırla
            targetRotationDirection = player.transform.forward * verticalMovement;
            targetRotationDirection = targetRotationDirection + player.transform.right * horizontalMovement;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            if (targetRotationDirection == Vector3.zero)
            {
                targetRotationDirection = transform.forward;//Nesne mevcut baktığı yönü hedef olarak alır, bu sayede durur vaziyetteyken yön değiştirmez.
            }

            Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection); //Yeni yönü hesaplama
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime); //yumuşak geçiş
            transform.rotation = targetRotation; //hesaplanan dönüş mevcut dönüşe atanır.

        }
        

    
    }
