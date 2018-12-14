using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DeerAI : MonoBehaviour {

    NavMeshAgent agent;
    Transform player;
    Animator animator;

    [SerializeField] private float closeEnoughDistance = 2f;
    [SerializeField] private AudioClip[] audioSFXes;

    private bool isDead = false;

    void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(FollowPlayerRoutine());
	}

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Projectile")){
            Destroy(collision.gameObject);
            Die();
        }
    }

    IEnumerator FollowPlayerRoutine(){
        while(!isDead)
        {
            bool isCloseEnough = Vector3.Distance(player.position, transform.position) <= closeEnoughDistance;

            if (isCloseEnough)
            {
                agent.velocity = Vector3.zero;
                agent.isStopped = true;

            }
            else
            {
                agent.SetDestination(player.position);
                agent.isStopped = false;
            }

            AnimateWalk(!isCloseEnough);

            yield return null;
        }
    }

    private void AnimateWalk(bool flag){
        animator.SetBool("IsWalking", flag);
    }

    private void Die(){
        isDead = true;
        Destroy(agent);
        animator.SetTrigger("Die");

        int audioIndex = Random.Range(0, audioSFXes.Length);

        GetComponent<AudioSource>().PlayOneShot(audioSFXes[audioIndex]);

        Destroy(GetComponent<Collider>());
        Destroy(this);
    }

}
