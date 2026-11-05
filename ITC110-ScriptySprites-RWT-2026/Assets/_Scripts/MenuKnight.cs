using UnityEngine;

public class MenuKnight : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("MenuCycle");
    }
}
