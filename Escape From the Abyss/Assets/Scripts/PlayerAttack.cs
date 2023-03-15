using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.ResetTrigger("SimpleAttack");

            m_Animator.SetTrigger("SimpleAttack");
        }
    }
}
