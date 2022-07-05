using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
   [SerializeField] CharacterController characterController;

   
    private void Update()
    {
        barrierHack();
    }

    private void barrierHack()
    {
        if (characterController.isHackActive == true)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;

        }
    }
}
