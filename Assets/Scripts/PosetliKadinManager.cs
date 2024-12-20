using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PosetliKadinManager : MonoBehaviour //CHARACTER MANAGER && PLAYER MANAGER KODLARI BURAYA YAZILACAK
{   
   public CharacterController _characterController;
   PosetliKadinLocomotion posetliKadinLocomotion;
  

   public void Awake()
   {
      posetliKadinLocomotion = GetComponent<PosetliKadinLocomotion>();
      _characterController = GetComponent<CharacterController>();
   }

   private void Update()
   {
      posetliKadinLocomotion.HandleAllMovement();
   }
}
