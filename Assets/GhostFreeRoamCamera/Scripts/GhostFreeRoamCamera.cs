using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float increaseSpeed = 1.25f;

    public bool allowMovement = true;
    public bool allowRotation = true;

    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backwardButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;

    public float cursorSensitivity = 0.025f;
    public bool cursorToggleAllowed = true;
    public KeyCode cursorToggleButton = KeyCode.Escape;

    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;

    private void OnEnable()
    {
        if (cursorToggleAllowed)
        {
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
                currentSpeed += increaseSpeed * Time.deltaTime;

            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
            CheckMove(leftButton, ref deltaPosition, -transform.right);

            if (moving)
            {
                if (moving != lastMoving)
                    currentSpeed = initialSpeed;

                transform.position += deltaPosition * currentSpeed * Time.deltaTime;
            }
            else currentSpeed = 0f;            
        }

        if (allowRotation)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
            eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
            transform.eulerAngles = eulerAngles;
        }

        if (cursorToggleAllowed)
        {
            if (Input.GetKey(cursorToggleButton))
            {
                if (!togglePressed)
                {
                    togglePressed = true;
                    Screen.lockCursor = !Screen.lockCursor;
                    Cursor.visible = !Cursor.visible;
                }
            }
            else togglePressed = false;
        }
        else
        {
            togglePressed = false;
            Cursor.visible = false;
        }
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
		
	List<Na> listOfLevelOneNa;
	List<Cl> listOfLevelOneCl;

	void Start(){
		Debug.LogWarning ("Hello!");

		GameObject naPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Na/Na.prefab", typeof(GameObject)) as GameObject;
		GameObject clPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Cl/Cl.prefab", typeof(GameObject)) as GameObject;

		createLevelOneOfNa (naPrefab);
		createLevelOneOfCl (clPrefab);

		setNextForLevelOneOfNa ();
		setNextForLevelOneOfCl ();

		//createLevelTwoOfNa (naPrefab);
		//createLevelTwoOfCl (clPrefab);

		//createLevelThreeOfNa (naPrefab);
		//createLevelThreeOfCl (clPrefab);
	}

	public void createLevelOneOfNa(GameObject naPrefab){
		listOfLevelOneNa = new List<Na> ();

		Na na1 = new Na ();
		na1.setX (0);
		na1.setY (0);
		na1.setZ (0);
		GameObject instantiated = na1.instantiate (naPrefab);
		na1.setInstantiated (instantiated);

		listOfLevelOneNa.Add (na1);

		/*instantiateAndMove(0, 0, 0, naPrefab);
		instantiateAndMove(0, 5, 0, naPrefab);
		instantiateAndMove(10, 0, 0, naPrefab);
		instantiateAndMove(10, 5, 0, naPrefab);
		instantiateAndMove(5, 2.5F, 0, naPrefab);*/
	}

	public void createLevelOneOfCl(GameObject clPrefab){
		listOfLevelOneCl = new List<Cl> ();

		Cl cl1 = new Cl ();
		cl1.setX (0);
		cl1.setY (2.5F);
		cl1.setZ (0);
		cl1.instantiate (clPrefab);

		listOfLevelOneCl.Add (cl1);

		/*instantiateAndMove (0, 2.5F, 0, clPrefab);
		instantiateAndMove (5, 0, 0, clPrefab);
		instantiateAndMove (5, 5, 0, clPrefab);
		instantiateAndMove (10, 2.5F, 0, clPrefab);*/
	}

	public void setNextForLevelOneOfNa (){
		Na na = listOfLevelOneNa [0];
		Cl cl = listOfLevelOneCl [0];
		na.getNext ().Add (cl);
		na.drawLinesToNext ();
	}

	public void setNextForLevelOneOfCl(){
		Na na = listOfLevelOneNa [0];
		Cl cl = listOfLevelOneCl [0];
		cl.getNext ().Add (na);
	}

	public void createLevelTwoOfNa(GameObject naPrefab){
		/*instantiateAndMove (0, 2.5F, 5, naPrefab);
		instantiateAndMove (5, 0, 5, naPrefab);
		instantiateAndMove (5, 5, 5, naPrefab);
		instantiateAndMove (10, 2.5F, 5, naPrefab);*/
	}

	public void createLevelTwoOfCl(GameObject clPrefab){
		/*instantiateAndMove (0, 0, 5, clPrefab);
		instantiateAndMove (0, 5, 5, clPrefab);
		instantiateAndMove (5, 2.5F, 5, clPrefab);
		instantiateAndMove (10, 0, 5, clPrefab);
		instantiateAndMove (10, 5, 5, clPrefab);*/
	}

	public void createLevelThreeOfNa(GameObject naPrefab){
		/*instantiateAndMove(0, 0, 10, naPrefab);
		instantiateAndMove(0, 5, 10, naPrefab);
		instantiateAndMove(10, 0, 10, naPrefab);
		instantiateAndMove(10, 5, 10, naPrefab);
		instantiateAndMove(5, 2.5F, 10, naPrefab);*/
	}

	public void createLevelThreeOfCl(GameObject clPrefab){
		/*instantiateAndMove (0, 2.5F, 10, clPrefab);
		instantiateAndMove (5, 0, 10, clPrefab);
		instantiateAndMove (5, 5, 10, clPrefab);
		instantiateAndMove (10, 2.5F, 10, clPrefab);*/
	}
}

class Na : MonoBehaviour{
	private float x;
	private float y;
	private float z;

	private List<Cl> next;

	private GameObject instantiatedObj;

	private GameObject naCylinder = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Na/NaCylinder.prefab",
		typeof(GameObject)) as GameObject;

	public Na(){
		next = new List<Cl> ();
	}

	public GameObject instantiate(GameObject prefab){
		GameObject naObject = Instantiate(prefab) as GameObject;
		naObject.transform.position = new Vector3 (x, y, z);
		return naObject;
	}

	public void drawLinesToNext(){
		foreach (Cl item in next) {
			float newX = x - item.getX ();
			float newY = y - item.getY ();
			float newZ = z - item.getZ ();

			if (newX < 0) drawLineByX (item.getX());
			if (newY < 0) drawLineByY (item.getY(), item);	
			if (newZ < 0) drawLineByZ (item.getZ());
		}
	}

	private void drawLineByX(float nextX){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;
		naCylinder.transform.position = new Vector3 (nextX / 2, getY(), getZ());
	}

	private void drawLineByY(float nextY, Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;
		naCylinder.transform.LookAt (getInstantiated().transform);
		float targerSize = nextY / 2;
		float currentSize = naCylinder.GetComponent<MeshRenderer> ().bounds.size.y;

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 2;
		//scale.y = targerSize * scale.y / currentSize;
		scale.y = targerSize;
		naCylinder.transform.localScale = scale;

		naCylinder.transform.position = new Vector3 (getX(), getY(), getZ());
		//TODO check getZ(), make cylinder y coordinates better, resolve compile error on 250
	}

	private void drawLineByZ(float nextZ){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;
		naCylinder.transform.position = new Vector3 (getX(), getY(), nextZ / 2);
	}

	public float getX(){
		return x;
	}
	public void setX(float value){
		this.x = value;
	}

	public float getY(){
		return y;
	}
	public void setY(float value){
		this.y = value;
	}

	public float getZ(){
		return z;
	}
	public void setZ(float value){
		this.z = value;
	}

	public List<Cl> getNext(){
		return next;
	}

	public GameObject getCylinder(){
		return naCylinder;
	}

	public GameObject getInstantiated(){
		return instantiatedObj;
	}

	public void setInstantiated(GameObject obj){
		this.instantiatedObj = obj;
	}
}

class Cl : MonoBehaviour{
	private float x;
	private float y;
	private float z;

	private List<Na> next;

	private GameObject instantiatedObj;

	public Cl(){
		next = new List<Na> ();
	}

	public GameObject instantiate(GameObject prefab){
		GameObject clObject = Instantiate(prefab) as GameObject;
		clObject.transform.position = new Vector3 (x, y, z);
		return clObject;
	}

		public void drawLinesToNext(){
			// TODO
		}

		public float getX(){
			return x;
		}
		public void setX(float value){
			this.x = value;
		}

		public float getY(){
			return y;
		}
		public void setY(float value){
			this.y = value;
		}

		public float getZ(){
			return z;
		}
		public void setZ(float value){
			this.z = value;
		}

		public List<Na> getNext(){
			return next;
		}

		public GameObject getInstantiated(){
			return instantiatedObj;
		}

		public void setInstantiated(GameObject obj){
			this.instantiatedObj = obj;
		}
}
