using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     }
    public void Drag (){
        GameObject.Find("Image").transform.position = Input.mousePosition;
        print ("We are dragging the mouse");
    }
    public void Drop (){
        for(int i =1; i <=3; i++){
            GameObject ph1 = GameObject.Find("placeHolder"+i);
            float distance = Vector3.Distance(GameObject.Find("Image").transform.position, ph1.transform.position);
            print("distance" + distance);
            if(distance < 50){
                GameObject.Find("image").transform.position = ph1.transform.position;
            }
        }
    }

}
