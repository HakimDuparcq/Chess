using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    public GameObject handplayer1;
    public GameObject handplayer2;
    public float timeplayer1 = 15;
    public float timeplayer2 = 15;


    public bool iscylindre1stand = true;
    public bool iscylindre2stand = false;

    public GameObject cylindre1;
    public GameObject cylindre2;

    public Transform Parent;

    void Start()
    {
        

    }


    public void OnTimerClicked()
    {
        ArrayList array = new ArrayList();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //print("1");
            if (Physics.Raycast(ray, out hit, 100.0f) )//&& hit.transform.gameObject != null
            {
                //print(hit.transform.gameObject.name);
                if (hit.transform.gameObject== cylindre1 && iscylindre1stand)
                {
                    cylindre1.transform.localPosition = new Vector3(-0.24f, 0.893f, 6.258118f) ;
                    cylindre2.transform.localPosition = new Vector3(-0.24f, 3.28f, -6.05f) ;
                    iscylindre1stand = false;
                    iscylindre2stand = true;
                }

                if (hit.transform.gameObject==cylindre2 && iscylindre2stand)
                {
                    cylindre1.transform.localPosition = new Vector3(-0.24f, 3.28f, 6.258118f);
                    cylindre2.transform.localPosition =  new Vector3(-0.24f, 0.893f, -6.05f);
                    iscylindre1stand = true;
                    iscylindre2stand = false;
                }
            }
        }
    }

    void Update()
    {
        float angle1 = 90 * timeplayer1 / 15;
        if (timeplayer1 > 0)
            handplayer1.transform.eulerAngles = new Vector3(-angle1, 0, 0);
        else
            handplayer1.transform.Rotate(1, 0, 0);

        float angle2 = 90 * timeplayer2 / 15;
        if (timeplayer2 > 0)
            handplayer2.transform.eulerAngles = new Vector3(-angle2, 0, 0);
        else
            handplayer2.transform.Rotate(1, 0, 0);
     


        if (iscylindre1stand)
        {
            timeplayer1 -= Time.deltaTime / 60;
        }
        if (iscylindre2stand)
        {
            timeplayer2 -= Time.deltaTime / 60;
        }
        
        //print(timeplayer1);


        OnTimerClicked();




    }
}
