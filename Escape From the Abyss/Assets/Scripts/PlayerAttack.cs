using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField]
    private float DamageAfterTime;

    [SerializeField]
    private int Damage;

    [SerializeField]
    private AttackArea _attackArea;

    private AudioSource audioSource;
    public AudioClip[] swordswings;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.ResetTrigger("SimpleAttack");
            m_Animator.SetBool("IsAttacking", true);
            m_Animator.SetTrigger("SimpleAttack");

            audioSource.clip = swordswings[0];
            audioSource.Play();

            StartCoroutine("Hit", false);
        }
        if (m_Animator.GetBool("SimpleAttack") == false)
                        m_Animator.SetBool("IsAttacking", false);
        
    }

    private IEnumerator Hit(bool strong)
    {
        yield return new WaitForSeconds(DamageAfterTime);
        foreach (var attackAreaDamageable in _attackArea.Damageables)
        {
            attackAreaDamageable.Damage(Damage);
        }
    }

}
