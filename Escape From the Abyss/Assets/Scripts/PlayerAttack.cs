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
        if (Input.GetMouseButtonDown(0) && !ShopUIToggle.ShopIsOpened)
        {
            m_Animator.SetTrigger("SimpleAttack");
        }
        if (this.m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && m_Animator.GetBool("SimpleAttack"))
            m_Animator.SetBool("IsAttacking", true);
        else
            m_Animator.SetBool("IsAttacking", false);
    }

    private IEnumerator Hit(bool strong)
    {
        yield return new WaitForSeconds(DamageAfterTime);
        for (int i = 0; i < _attackArea.Damageables.Count; i++)
        {
            _attackArea.Damageables[i].Damage(Damage);
        }
    }
    public void Attack()
    {
        audioSource.clip = swordswings[0];
        audioSource.Play();
        StartCoroutine("Hit", false);
    }

}
