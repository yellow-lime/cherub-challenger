using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    [Tooltip("Seconds of invincibility after being hit.")]
    public float invincibilitySeconds = 2f;
    public float hitAnimationSeconds = 0.5f;
    [Tooltip("Alpha value of 'invincible' sprite (0-1).")]
    public float invincibilityAlpha = 0.5f;
    public AudioSource hitSound;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible;

    public int hp = 3;
    [Tooltip("Tag of the gameObjects that hurt when collided against.")]
    public string hostileTag;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.gameObject.tag == hostileTag && !isInvincible)
        {
            hp -= 1;
            hitSound.Play();
            Color invColor = spriteRenderer.color;
            invColor.a = invincibilityAlpha;
            spriteRenderer.color = invColor;
            isInvincible = true;
            animator.SetBool("isHit", true);
            StartCoroutine(OnEndHitAnimation());
            StartCoroutine(OnEndInvincibility());
        }
    }

    IEnumerator OnEndHitAnimation()
    {
        yield return new WaitForSeconds(hitAnimationSeconds);
        animator.SetBool("isHit", false);
    }

    IEnumerator OnEndInvincibility()
    {
        yield return new WaitForSeconds(invincibilitySeconds);
        isInvincible = false;
    }
}
