using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimationController : MonoBehaviour {

    [SerializeField] Animator camAnimator, mainMenuAnimator;

    void Start()
    {
        camAnimator.SetBool("Playing", false);
        mainMenuAnimator.SetBool("Playing", false);
        camAnimator.SetBool("goingToMenu", false);
        mainMenuAnimator.SetBool("goingToMainMenu", false);
        camAnimator.SetBool("goingToCredits", false);
        mainMenuAnimator.SetBool("goingToCredits", false);
    }

	public void GoToCredits()
    {
        camAnimator.SetBool("goingToMenu", false);
        mainMenuAnimator.SetBool("goingToMainMenu", false);
        camAnimator.SetBool("goingToCredits", true);
        mainMenuAnimator.SetBool("goingToCredits", true);
    }

    public void GoToMainMenu()
    {
        camAnimator.SetBool("goingToCredits", false);
        mainMenuAnimator.SetBool("goingToCredits", false);
        camAnimator.SetBool("goingToMenu", true);
        mainMenuAnimator.SetBool("goingToMainMenu", true);       
    }
}
