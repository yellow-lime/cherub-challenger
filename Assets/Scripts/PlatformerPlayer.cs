using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public bool facingRight;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPos = this.gameObject.transform.position;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        // float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(oldPos + new Vector3(x, 0f, 0f));

        if ((facingRight && x < 0) || (!facingRight && x > 0))
        {
            ChangeSpriteFacing(x);
        }
    }

    private void ChangeSpriteFacing(float x)
    {
        facingRight = !facingRight;
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.flipX = !sr.flipX;
        }
    }
}
