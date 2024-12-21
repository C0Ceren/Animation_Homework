using UnityEngine;

public class PosetliKadinAnimatorManager : MonoBehaviour
{
    PosetliKadinManager character;

    
    private void Awake()
    {
        character = GetComponent<PosetliKadinManager>();
    }

    public void UpdateAnimatorMovementParameters(float horizontalValue, float verticalValue)
    {
        character._animator.SetFloat("Horizontal", horizontalValue , 0.1f , Time.deltaTime);
        character._animator.SetFloat("Vertical", verticalValue, 0.1f, Time.deltaTime);
    }
}