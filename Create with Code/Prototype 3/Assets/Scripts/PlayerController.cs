using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool gameOver = false;
    private Animator animator;
    [Header("Particles")]
    public ParticleSystem explosionParticle; 
    public ParticleSystem dirtyParticle; 
    [Header("Audio Clip")]
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private bool isGround = true;
    private Rigidbody rig;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
            animator.SetTrigger("Jump_trig");
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
            
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtyParticle.Play();
        }   
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
            
    }
}
