using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PosetliKadinManager : MonoBehaviour
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
