using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour { 

    public float upForce = 200f;

    private bool isdDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    AudioSource audioSource;
    public AudioClip flapSound;
    public AudioClip dieSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2 (0, upForce));
                anim.SetTrigger("Flap");
                PlaySound(flapSound);
            }
        }
    }
     void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        isdDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
        PlaySound(dieSound);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
