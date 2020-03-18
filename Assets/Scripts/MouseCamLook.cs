using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour {

    [SerializeField]
    public float sensitivity = 5.0f;
    
    // parent blir ett object
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;

    //leaning

    //använd vektor 2 för att rotera och ändra position 

    //bobbing
    private float timer = 0.0f;
    float bobbingSpeed = 0.1f;
    float bobbingAmount = 0.2f;
    float midpoint = 0.8f;
    private bool onGround;


    Vector3 cSharpConversion;

    void Start () {
        //parent blir ett gameobject som man kan kalla på
        character = this.transform.parent.gameObject;
    }

    void Update () {
        
        
        //md är raw mouse input. se det som en keypress fast när man drar på musen ändras ett kordinatsystem
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
     
        //adderar värdet man får från musen till rotationen på objectet
        mouseLook += md;
        
        //max/min värde på rotationen
        mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 70f);

        //ändrar rotationen på parent
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        // Charactercon OnGround
        onGround = gameObject.transform.parent.GetComponent<charectercon>().onGround;

        //bobbing
        if (onGround)
            {
            float waveslice = 0.0f;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            cSharpConversion = transform.localPosition;

            if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
            {
                timer = 0.0f;
            }
            else
            {
                waveslice = Mathf.Sin(timer);
                timer = timer + bobbingSpeed;
                if (timer > Mathf.PI * 2)
                {
                    timer = timer - (Mathf.PI * 2);
                }
                
            }
            if (waveslice != 0)
            {
                float translateChange = waveslice * bobbingAmount;
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cSharpConversion.y = midpoint + translateChange;
            }
            else
            {
                cSharpConversion.y = midpoint;
            }

            transform.localPosition = cSharpConversion;
        }
        //leaning
        //left
        if (Input.GetKey("q"))
        {
            transform.localPosition = new Vector3(-0.7f, transform.localPosition.y, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 45f);
        }
        else if (Input.GetKey("e"))
        {
            //right
            transform.localPosition = new Vector3(0.7f, transform.localPosition.y, 0);
            transform.localRotation = Quaternion.Euler(0, 0, -45f);
        }
        else
        {
            transform.localPosition = new Vector3(0, cSharpConversion.y , 0);
           
        }
        
      

    }

 
}



