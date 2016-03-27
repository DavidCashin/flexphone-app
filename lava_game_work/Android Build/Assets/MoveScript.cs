using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    private Vector3 endPoint;
    private Vector3 moveDirection;
    private Animation animu;

    private float endDistance;
    private float speed;
    private float gravity;

    private bool moveFlag;

    void Start()
    {
        //physics variables
        speed = 1.0F;
        gravity = 20.0F;
        moveDirection = Vector3.zero;

        //animation speeds
        animu = gameObject.GetComponent<Animation>();
        animu["Snowman@Idle"].speed = 1.75f;
        animu["Snowman@Idle2"].speed = 0.4f;
        animu["Snowman@Idle2 Look"].speed = 0.4f;

        //flags
        moveFlag = false;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if ((Input.touchCount > 0 && (Input.GetTouch(0).tapCount == 2)) || (Input.GetMouseButtonDown(0)))
        {
            


                RaycastHit hit; //declare a variable of RaycastHit struct
                Ray ray; //create a Ray on the tapped / clicked position

                //for unity editor
#if UNITY_EDITOR
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif

                //check if the ray hits any collider
                if (Physics.Raycast(ray, out hit))
                {
                    transform.parent = null;
                    moveFlag = true;

                    endPoint = hit.point;
                    Debug.Log(endPoint);

                    Quaternion targetRotation = Quaternion.LookRotation(endPoint - transform.position);
                    transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                }
            
        }

        endDistance = Vector3.Distance(endPoint, transform.position);

        //if (moveFlag && Mathf.Approximately(Mathf.Round(gameObject.transform.position.x * 10), Mathf.Round(endPoint.x * 10)) && Mathf.Approximately(Mathf.Round(gameObject.transform.position.z * 10), Mathf.Round(endPoint.z * 10)))
        if (moveFlag && endDistance > .1f)
        {
            if (controller.isGrounded)
            {
                moveDirection = endPoint - transform.position;
                moveDirection = moveDirection.normalized * speed;
                gameObject.GetComponent<Animation>().Play("Snowman@Idle");
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        //else if (moveFlag && !(Mathf.Approximately(Mathf.Round(gameObject.transform.position.x * 10), Mathf.Round(endPoint.x * 10)) && Mathf.Approximately(Mathf.Round(gameObject.transform.position.z * 10), Mathf.Round(endPoint.z * 10))))
        else if (moveFlag && endDistance < .1f)
        {
            moveFlag = false;
            Debug.Log("I am here");
        }
    }
    
    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        if (coll.transform.tag == "Rock")
        {
            transform.parent = coll.transform.parent;
        }
        else if (coll.transform.tag == "Static")
        {
            transform.parent = null;
        }
    }
}