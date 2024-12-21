using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PosetliKadinManager : MonoBehaviour //CHARACTER MANAGER && PLAYER MANAGER KODLARI BURAYA YAZILACAK
{   
   public CharacterController _characterController;
   PosetliKadinLocomotion posetliKadinLocomotion;
   
   public Animator _animator;
   public PosetliKadinAnimatorManager posetliKadinAnimatorManager;
  

   public void Awake()
   {
      posetliKadinLocomotion = GetComponent<PosetliKadinLocomotion>();
      _characterController = GetComponent<CharacterController>();
      
      _animator = GetComponent<Animator>();
      posetliKadinAnimatorManager = GetComponent<PosetliKadinAnimatorManager>();
   }

   private void Update()
   {
      posetliKadinLocomotion.HandleAllMovement();
   }
}
