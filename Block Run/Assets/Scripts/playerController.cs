using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float gravityModifier;
    public float jumpForce;
    private bool inAir;
    private Animator playerAnim;
    private string[] obstacles = {"Wall", "barrel", "Barrier"};
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        inAir = transform.position.y > 0.2;
        // jump player on spacebar
        if (Input.GetKeyDown(KeyCode.Space) & !inAir && !FindObjectOfType<gameManager>().gameHasEnded) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
        // Debug.Log(FindObjectOfType<gameManager>().gameHasEnded);
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i=0; i < obstacles.Length; i++) {
            if(collision.gameObject.CompareTag(obstacles[i])) {
                FindObjectOfType<gameManager>().gameHasEnded = true;
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                playerAnim.SetBool("Death_b", true);
                if (obstacles[i] == "Wall")
                    playerAnim.SetInteger("DeathType_int", 2);
                else
                    playerAnim.SetInteger("DeathType_int", 1);
            }
            else {
                dirtParticle.Play();
            }
        }
    }
}