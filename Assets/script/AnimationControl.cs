using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    public Animator animator;
    private bool isJumping = false;
    private float velocity = 0f;
    private bool increasing = true;
    public float speed = 0.1f;
    public GameObject body;
    private Renderer bodyRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (body != null)
        {
            bodyRenderer = body.GetComponent<Renderer>();
        }
    }

    public void OnClickJump()
    {
        isJumping = !isJumping;
        animator.SetBool("isJumping", isJumping);
    }

    void Update()
    {
        ChangeJumpSpeed();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("crazyJump");
          
        }
    }

    private void ChangeJumpSpeed()
    {
        if (increasing)
        {
            velocity += Time.deltaTime * speed;
            if (velocity >= 1f)
            {
                velocity = 1f;
                increasing = false;
            }
        }
        else
        {
            velocity -= Time.deltaTime * speed;
            if (velocity <= 0f)
            {
                velocity = 0f;
                increasing = true;
            }
        }

        animator.SetFloat("jumpSpeed", velocity);
    }

    public void BodyColorChange()
    {
        if (bodyRenderer != null)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            bodyRenderer.material.color = newColor;
        }
    }
}
