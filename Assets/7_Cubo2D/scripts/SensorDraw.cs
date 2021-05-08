using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SensorDraw : MonoBehaviour
{
    public enum mode
    {
        force,
        delta
    }
    [SerializeField]
    mode DrawMode = mode.force;
    Vector3 StartPosition;
    [SerializeField]
    GameObject Owner;
    bool LookMoveOnZoom = false;
    bool valid = false;
    bool SmoothDeltaDraw = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            LookMoveOnZoom = true;
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Owner.SendMessage("OnClickZoom", deltaMagnitudeDiff);

            return;
        }else if (DrawMode.Equals(mode.delta) && SmoothDeltaDraw) {
            Vector2 delta = new Vector2();

            delta.x = StartPosition.x - Input.mousePosition.x ;
            delta.y = StartPosition.y - Input.mousePosition.y;
            /*delta.x = Input.mousePosition.x - StartPosition.x;
            delta.y = Input.mousePosition.y - StartPosition.y;*/
            Owner.SendMessage("OnDrawUpdateDelta", delta);
        }
        else
        {
            LookMoveOnZoom = false;

        }

        
    }



    private void OnMouseDown()
    {
       
        if (!valid ) {
            valid = true;
        }

        if (DrawMode.Equals(mode.delta))
        {
            StartPosition = Input.mousePosition;
            Owner.SendMessage("StartPosition");
            SmoothDeltaDraw = true;
        }

       

    }

    private void OnMouseUp()
    {
        //posicionInicial = Input.mousePosition;
        valid = false;
        SmoothDeltaDraw = false;
    }

    private void OnMouseDrag()
    {

        Debug.Log("Draw !!");
        if (!valid)
            return;
       // if (EventSystem.current.IsPointerOverGameObject(-1)) return;

        if (LookMoveOnZoom)
            return;


        if (DrawMode.Equals(mode.delta))
        {

        }
        else
        {

            if (Input.mousePosition.x + Screen.width * 0.01f > StartPosition.x)
            {
                if (Owner != null)
                {
                    Owner.SendMessage("OnClickRight");
                    //Owner.SendMessage("OnClickLeft");
                    //Owner.SendMessage("OnClickUp");

                }
            }

            if (Input.mousePosition.x - Screen.width * 0.01f < StartPosition.x)
            {
                if (Owner != null)
                {
                    Owner.SendMessage("OnClickLeft");
                    //StartPosition.x = Input.mousePosition.x;
                    // Owner.SendMessage("OnClickRight");
                    // Owner.SendMessage("OnClickDown");
                }
            }

            if (Input.mousePosition.y + Screen.height * 0.01f > StartPosition.y)
            {
                if (Owner != null)
                {
                    //Owner.SendMessage("OnClickLeft");
                    // Owner.SendMessage("OnClickRight");
                    // Owner.SendMessage("OnClickUp");
                    Owner.SendMessage("OnClickDown");

                }
            }

            if (Input.mousePosition.y - Screen.height * 0.01f < StartPosition.y)
            {
                if (Owner != null)
                {
                    // Owner.SendMessage("OnClickLeft");
                    //Owner.SendMessage("OnClickDown");
                    Owner.SendMessage("OnClickUp");
                    // StartPosition.y = Input.mousePosition.y;
                }
            }
            StartPosition = Input.mousePosition;

            /* if (Input.mousePosition.x + Screen.width*0.05f > StartPosition.x) {
                 if (Owner != null) {
                     Owner.SendMessage("OnClickRight");
                     //Owner.SendMessage("OnClickLeft");
                     //Owner.SendMessage("OnClickUp");

                 }
             }

             if (Input.mousePosition.x - Screen.width * 0.05f < StartPosition.x)
             {
                 if (Owner != null)
                 {
                     Owner.SendMessage("OnClickLeft");
                    // Owner.SendMessage("OnClickRight");
                     // Owner.SendMessage("OnClickDown");
                 }
             }

             if (Input.mousePosition.y + Screen.height * 0.05f > StartPosition.y)
             {
                 if (Owner != null)
                 {
                     //Owner.SendMessage("OnClickLeft");
                     // Owner.SendMessage("OnClickRight");
                    // Owner.SendMessage("OnClickUp");
                     Owner.SendMessage("OnClickDown");

                 }
             }

             if (Input.mousePosition.y - Screen.height * 0.05f < StartPosition.y)
             {
                 if (Owner != null)
                 {
                     // Owner.SendMessage("OnClickLeft");
                     //Owner.SendMessage("OnClickDown");
                     Owner.SendMessage("OnClickUp");
                 }
             }*/
        }
    }
}
