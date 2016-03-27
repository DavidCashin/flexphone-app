using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class ForceFlowScript : MonoBehaviour {
    
    private Vector3 objectSpeed;
    /*
    private int[] btData;
    private int topDog;
    private int midSpine;
    private int bottomDog;
    private int topDogRest;
    private int midSpineRest;
    private int bottomDogRest;
    */
    //SerialPort stream = new SerialPort("msm_serial_hs", 115200); //Set the port (com3) and the baud rate (9600, is standard on most devices)
    ///public string receivedData = "EMPTY";
    //public string sendToArduino = "1";
	private string message;
    private int topDog;
    private int bottomDog;
    private int midSpine;
    private float v1;
    private float v2;
	private float tuningConst1 = 1f;
	private float tuningConst2 = 15f;

    private Vector3 topCorner;
    private Vector3 bottomCorner;
    private Vector3 middle;
    void Start()
    {
        objectSpeed = Vector3.zero;
		
		BtConnector.moduleName("HC-05");
		// "00001101-0000-1000-8000-00805f9b34fb";
		BtConnector.connect();
		
    }
    void OnGUI() {
		//string debugInfo = "Velocity: " + v1 + "," + v2 + "  (" + topDog + ", " + midSpine + ", " + bottomDog + ")";
        //GUI.Label(new Rect(10, 10, 250, 250), "BT:" + debugInfo);
		
		string debugInfo = "Velocity: " + objectSpeed.z + "," + objectSpeed.x + "  (" + topDog + ", " + midSpine + ", " + bottomDog + ")";
        GUI.Label(new Rect(10, 10, 250, 250), "BT:" + debugInfo);
					 
    }
    void Update()
    {
				message = BtConnector.readLine();
				string firstWord = message.Substring(0,3); //bottom dog ear
				string secondWord = message.Substring(4,3);
				string thirdWord = message.Substring(8,3);
				bottomDog = int.Parse(firstWord);
				topDog = int.Parse(secondWord);
				midSpine = int.Parse(thirdWord);
				
				float topDogRest = 586f;
				float midSpineRest = 465f;
				float bottomDogRest = 351f;
				
				float topDogContr = 0f;
				float midSpineContr = 0f;
				float bottomDogContr = 0f;
				
				if(topDogRest - topDog < 0) { //indicates bent up (ie, push lava left-down)
					//we need to do this because bend up and bend down offsets are not constant
					//calculate percentage of max contribution of this bend sensor
					topDogContr = (topDog - topDogRest) / 126f;
					topCorner = new Vector3(-topDogContr/.2f,0,-topDogContr*.8f)*tuningConst1;
				}else{
					//was bent down, so lava right-up
					topDogContr = (topDogRest - topDog) / 114f;
					topCorner = new Vector3(topDogContr*.2f,0,topDogContr*.8f)*tuningConst1;
				}
					
				if(midSpineRest - midSpine < 0) { 
					midSpineContr = (midSpine - midSpineRest) / 115f;
					middle = new Vector3(-midSpineContr, 0, 0)*tuningConst2;
				}else{
					midSpineContr = (midSpineRest - midSpine) / 140f;
					middle = new Vector3(midSpineContr, 0, 0)*tuningConst2;
				}
				
				if(bottomDogRest - bottomDog < 0) { 
					bottomDogContr = (bottomDog - bottomDogRest) / 109f;
					bottomCorner = new Vector3(-bottomDogContr*.2f, 0, bottomDogContr*.8f)*tuningConst1;

				}else{
					bottomDogContr = (bottomDogRest - bottomDog) / 99f;
					bottomCorner = new Vector3(bottomDogContr*.2f, 0, -bottomDogContr*.8f)*tuningConst1;

				}
				
				
				
				objectSpeed = topCorner + bottomCorner + middle;
				objectSpeed.z = objectSpeed.z *10;

        //objectSpeed = new Vector3(10, 0, 10);

        //transform.Translate(objectSpeed * Time.deltaTime);


        /*//debug the below
        v1 = z;
        v2 = x;
        objectSpeed = new Vector3(x,0,z);*/

        //flowObject.velocity = objectSpeed;
        //flowObject.angularVelocity = objectSpeed;
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, objectSpeed, out hit, 0.5f))
        {
            if (hit.transform.tag == "Static" || hit.transform.tag == "Rock")
            {
                Debug.Log("Land ho! " + Time.time);
            }
            else
            {
                transform.Translate(objectSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(objectSpeed * Time.deltaTime);
        }

    }

    /*
    Vector3 BendData()
    {
        //we're always assuming they never bend more than the limits set at the beginning of this file, so error checking will need to be implemnted in case a user bends very hard

        float topDogContr, midSpineContr, bottomDogContr;
        if (topDogRest - topDog < 0)
        { //indicates bent up (ie, push lava left-down)
          //we need to do this because bend up and bend down offsets are not constant
          //calculate percentage of max contribution of this bend sensor
            topDogContr = (topDogRest - topDog) / 126;
        }
        else {
            //was bent down, so lava right-up
            topDogContr = (topDog - topDogRest) / 114;
        }

        if (midSpineRest - midSpine < 0)
        {
            midSpineContr = (midSpineRest - midSpine) / 115;
        }
        else {
            midSpineContr = (midSpine - midSpineRest) / 140;
        }

        if (bottomDogRest - bottomDog < 0)
        {
            bottomDogContr = (bottomDogRest - bottomDog) / 109;
        }
        else {
            bottomDogContr = (bottomDog - bottomDogRest) / 99;
        }

        float tuningConst1 = 0.8f; //modify during actual game testing, just a placeholder for now.
        float z = (topDogContr - bottomDogContr) * tuningConst1;
        float x = midSpineContr * tuningConst1;

        return new Vector3(x, 0, z);
    }
    */
}
