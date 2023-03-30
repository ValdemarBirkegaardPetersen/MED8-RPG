using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Vector2 currentPos;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactablesLayer;

    public GameObject buy_bread_from_baker;
    public GameObject fish_from_the_docks;

    private BoxCollider2D buy_bread_from_baker_collider;
    private BoxCollider2D fish_from_the_docks_collider;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        buy_bread_from_baker_collider = buy_bread_from_baker.GetComponent<BoxCollider2D>();
        fish_from_the_docks_collider = fish_from_the_docks.GetComponent<BoxCollider2D>();
        currentPos = new Vector2(transform.position.x, transform.position.y);
    }




    // Update is called once per frame
    public void HandleUpdate()
    {
        // checking if player is inside event area
        eventCollisionChecker();


        if (!isMoving)
        {
            // gets input from wasd (0 no movement, 1 up/right, -1 down/left)
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            // removes diagonal moving
            if (input.x != 0) input.y = 0; 

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }

            }
        } 

        animator.SetBool("isMoving", isMoving);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }

        void Interact()
        {
            var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            var interactPos = transform.position + facingDir;

            Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

            var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactablesLayer);
            if(collider != null)
            {
                collider.GetComponent<Interactable>()?.Interact();
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
    
    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactablesLayer) != null)
        {
            return false;
        }
        return true;
    }


    private void insideEventZone(BoxCollider2D eventCollider)
    {
        // remember to set the z-value of the event zones box colliders to 0
        if (eventCollider.bounds.Contains(transform.position))
        {
            Debug.Log("Starting event: " + eventCollider.name);
        }
    }

    private void eventCollisionChecker()
    {
        insideEventZone(buy_bread_from_baker_collider);
        insideEventZone(fish_from_the_docks_collider);
    }

}
