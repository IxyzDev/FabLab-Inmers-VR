using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnImput : MonoBehaviour
{
    //Variable Tipo Nombre
    public InputActionProperty pinchAnimationAction;

    public InputActionProperty gripAnimationAction;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta la presion con la que se apreta el pinch
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        // Detecta la presion con la que se apreta el grip
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

        // Para mostrar el valor en consola
        // Debug.Log(triggerValue);
    }
}
