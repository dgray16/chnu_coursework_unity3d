using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// TODO 
// 1. White Skybox
// 2. Hide/Show cylinders button

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
		//if (cursorToggleAllowed)
		//{
		//	Screen.lockCursor = true;
		//	Cursor.visible = false;
		//}
	}

	private void Update()
	{
		//if (allowMovement)
		//{
		//	bool lastMoving = moving;
		//	Vector3 deltaPosition = Vector3.zero;

		//	if (moving)
		//		currentSpeed += increaseSpeed * Time.deltaTime;

		//	moving = false;

		//	CheckMove(forwardButton, ref deltaPosition, transform.forward);
		//	CheckMove(backwardButton, ref deltaPosition, -transform.forward);
		//	CheckMove(rightButton, ref deltaPosition, transform.right);
		//	CheckMove(leftButton, ref deltaPosition, -transform.right);

		//	if (moving)
		//	{
		//		if (moving != lastMoving)
		//			currentSpeed = initialSpeed;

		//		transform.position += deltaPosition * currentSpeed * Time.deltaTime;
		//	}
		//	else currentSpeed = 0f;            
		//}

		//if (allowRotation)
		//{
		//	Vector3 eulerAngles = transform.eulerAngles;
		//	eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
		//	eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
		//	transform.eulerAngles = eulerAngles;
		//}

		//if (cursorToggleAllowed)
		//{
		//	if (Input.GetKey(cursorToggleButton))
		//	{
		//		if (!togglePressed)
		//		{
		//			togglePressed = true;
		//			Screen.lockCursor = !Screen.lockCursor;
		//			Cursor.visible = !Cursor.visible;
		//		}
		//	}
		//	else togglePressed = false;
		//}
		//else
		//{
		//	togglePressed = false;
		//	Cursor.visible = false;
		//}
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

	List<Na> listOfLevelTwoNa;
	List<Cl> listOfLevelTwoCl;

	List<Na> listOfLevelThreeNa;
	List<Cl> listOfLevelThreeCl;

	void Start(){
		GameObject naPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Na/Na.prefab", typeof(GameObject)) as GameObject;
		GameObject clPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Cl/Cl.prefab", typeof(GameObject)) as GameObject;

		createLevelOneOfNa (naPrefab);
		createLevelOneOfCl (clPrefab);

		createLevelTwoOfNa (naPrefab);
		createLevelTwoOfCl (clPrefab);

		createLevelThreeOfNa (naPrefab);
		createLevelThreeOfCl (clPrefab);

		setNextForLevelOneOfNa ();
		setNextForLevelOneOfCl ();

		setNextForLevelTwoOfNa ();
		setNextForLevelTwoOfCl ();

		setNextForLevelThreeOfNa ();
		setNextForLevelThreeOfCl ();
	}

	public void createLevelOneOfNa(GameObject naPrefab){
		listOfLevelOneNa = new List<Na> ();

		Na na1 = new Na ();
		na1.setX (0);
		na1.setY (0);
		na1.setZ (0);
		GameObject instantiated = na1.instantiate (naPrefab);
		instantiated.transform.name = "Na 1_1";
		na1.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na1);

		Na na2 = new Na ();
		na2.setX (0);
		na2.setY (5);
		na2.setZ (0);
		instantiated = na2.instantiate (naPrefab);
		instantiated.transform.name = "Na 1_2";
		na2.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na2);

		Na na3 = new Na ();
		na3.setX (10);
		na3.setY (0);
		na3.setZ (0);
		instantiated = na3.instantiate (naPrefab);
		instantiated.transform.name = "Na 1_3";
		na3.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na3);

		Na na4 = new Na ();
		na4.setX (10);
		na4.setY (5);
		na4.setZ (0);
		instantiated = na4.instantiate (naPrefab);
		instantiated.transform.name = "Na 1_4";
		na4.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na4);

		Na na5 = new Na ();
		na5.setX (5);
		na5.setY (2.5F);
		na5.setZ (0);
		instantiated = na5.instantiate (naPrefab);
		instantiated.transform.name = "Na 1_5";
		na5.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na5);

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
		GameObject instantiated = cl1.instantiate (clPrefab);
		instantiated.transform.name = "Cl 1_1";
		cl1.setInstantiated (instantiated);
		listOfLevelOneCl.Add (cl1);

		Cl cl2 = new Cl ();
		cl2.setX (5);
		cl2.setY (0);
		cl2.setZ (0);
		instantiated = cl2.instantiate (clPrefab);
		instantiated.transform.name = "Cl 1_2";
		cl2.setInstantiated (instantiated);
		listOfLevelOneCl.Add (cl2);

		Cl cl3 = new Cl ();
		cl3.setX (5);
		cl3.setY (5);
		cl3.setZ (0);
		instantiated = cl3.instantiate (clPrefab);
		instantiated.transform.name = "Cl 1_3";
		cl3.setInstantiated (instantiated);
		listOfLevelOneCl.Add (cl3);

		Cl cl4 = new Cl ();
		cl4.setX (10);
		cl4.setY (2.5F);
		cl4.setZ (0);
		instantiated = cl4.instantiate (clPrefab);
		instantiated.transform.name = "Cl 1_4";
		cl4.setInstantiated (instantiated);
		listOfLevelOneCl.Add (cl4);

		/*instantiateAndMove (0, 2.5F, 0, clPrefab);
		instantiateAndMove (5, 0, 0, clPrefab);
		instantiateAndMove (5, 5, 0, clPrefab);
		instantiateAndMove (10, 2.5F, 0, clPrefab);*/
	}

	public void setNextForLevelOneOfNa (){
		// TODO refactor it, so no need to call it on my own
		// TODO refactor from linesReverse to Up/Down

		Na na1 = listOfLevelOneNa [0];
		Na na2 = listOfLevelOneNa [1];
		Na na3 = listOfLevelOneNa [2];
		Na na4 = listOfLevelOneNa[3];
		Na na5 = listOfLevelOneNa[4];

		Cl cl1 = listOfLevelOneCl [0];
		Cl cl2 = listOfLevelOneCl [1];
		Cl cl3 = listOfLevelOneCl [2];
		Cl cl4 = listOfLevelOneCl [3];

		Cl cl2_1 = listOfLevelTwoCl [0];
		Cl cl2_2 = listOfLevelTwoCl [1];
		Cl cl2_3 = listOfLevelTwoCl [2];
		Cl cl2_4 = listOfLevelTwoCl [3];
		Cl cl2_5 = listOfLevelTwoCl [4];

		na1.getNext ().Add (cl1);
		na1.getNext ().Add (cl2);
		na1.getNext ().Add (cl2_1);
		na1.drawLinesToNext ();

		na2.getNext ().Add (cl1);
		na2.getNext ().Add (cl3);
		na2.getNext ().Add (cl2_2);
		na2.drawLinesToNext ();

		na3.getNext ().Add (cl2);
		na3.getNext ().Add (cl4);
		na3.getNext ().Add (cl2_4);
		na3.drawLinesToNext ();

		na4.getNext ().Add (cl3);
		na4.getNext ().Add (cl4);
		na4.getNext ().Add (cl2_5);
		na4.drawLinesToNext ();

		na5.getNext ().Add (cl1);
		na5.getNext ().Add (cl2);
		na5.getNext ().Add (cl3);
		na5.getNext ().Add (cl4);
		na5.getNext ().Add (cl2_3);
		na5.drawLinesToNext ();

	}

	public void setNextForLevelOneOfCl(){
		Cl cl1 = listOfLevelOneCl [0];
		Cl cl2 = listOfLevelOneCl [1];
		Cl cl3 = listOfLevelOneCl [2];
		Cl cl4 = listOfLevelOneCl [3];

		Na na1 = listOfLevelOneNa [0];
		Na na2 = listOfLevelOneNa [1];
		Na na3 = listOfLevelOneNa [2];
		Na na4 = listOfLevelOneNa [3];
		Na na5 = listOfLevelOneNa [4];

		Na na2_1 = listOfLevelTwoNa [0];
		Na na2_2 = listOfLevelTwoNa [1];
		Na na2_3 = listOfLevelTwoNa [2];
		Na na2_4 = listOfLevelTwoNa [3];

		cl1.getNext ().Add (na1);
		cl1.getNext ().Add (na2);
		cl1.getNext ().Add (na5);
		cl1.getNext ().Add (na2_1);
		cl1.drawLinesToNext ();

		cl2.getNext ().Add (na1);
		cl2.getNext ().Add (na3);
		cl2.getNext ().Add (na5);
		cl2.getNext ().Add (na2_2);
		cl2.drawLinesToNext ();

		cl3.getNext ().Add (na2);
		cl3.getNext ().Add (na4);
		cl3.getNext ().Add (na5);
		cl3.getNext ().Add (na2_3);
		cl3.drawLinesToNext ();

		cl4.getNext ().Add (na3);
		cl4.getNext ().Add (na4);
		cl4.getNext ().Add (na5);
		cl4.getNext ().Add (na2_4);
		cl4.drawLinesToNext ();
	}


	public void createLevelTwoOfNa(GameObject naPrefab){
		listOfLevelTwoNa = new List<Na> ();

		Na na1 = new Na ();
		na1.setX (0);
		na1.setY (2.5F);
		na1.setZ (5);
		GameObject instantiated = na1.instantiate (naPrefab);
		instantiated.transform.name = "Na 2_1";
		na1.setInstantiated (instantiated);
		listOfLevelTwoNa.Add (na1);

		Na na2 = new Na ();
		na2.setX (5);
		na2.setY (0);
		na2.setZ (5);
		instantiated = na2.instantiate (naPrefab);
		instantiated.transform.name = "Na 2_2";
		na2.setInstantiated (instantiated);
		listOfLevelTwoNa.Add (na2);

		Na na3 = new Na ();
		na3.setX (5);
		na3.setY (5);
		na3.setZ (5);
		instantiated = na3.instantiate (naPrefab);
		instantiated.transform.name = "Na 2_3";
		na3.setInstantiated (instantiated);
		listOfLevelTwoNa.Add (na3);

		Na na4 = new Na ();
		na4.setX (10);
		na4.setY (2.5F);
		na4.setZ (5);
		instantiated = na4.instantiate (naPrefab);
		instantiated.transform.name = "Na 2_4";
		na4.setInstantiated (instantiated);
		listOfLevelTwoNa.Add (na4);

		/*instantiateAndMove (0, 2.5F, 5, naPrefab);
		instantiateAndMove (5, 0, 5, naPrefab);
		instantiateAndMove (5, 5, 5, naPrefab);
		instantiateAndMove (10, 2.5F, 5, naPrefab);*/
	}

	public void setNextForLevelTwoOfNa(){

		Na na1 = listOfLevelTwoNa [0];
		Na na2 = listOfLevelTwoNa [1];
		Na na3 = listOfLevelTwoNa [2];
		Na na4 = listOfLevelTwoNa [3];

		Cl cl1 = listOfLevelTwoCl [0];
		Cl cl2 = listOfLevelTwoCl [1];
		Cl cl3 = listOfLevelTwoCl [2];
		Cl cl4 = listOfLevelTwoCl [3];
		Cl cl5 = listOfLevelTwoCl [4];

		Cl cl1_1 = listOfLevelOneCl [0];
		Cl cl1_2 = listOfLevelOneCl [1];
		Cl cl1_3 = listOfLevelOneCl [2];
		Cl cl1_4 = listOfLevelOneCl [3];

		Cl cl3_1 = listOfLevelThreeCl [0];
		Cl cl3_2 = listOfLevelThreeCl [1];
		Cl cl3_3 = listOfLevelThreeCl [2];
		Cl cl3_4 = listOfLevelThreeCl [3];

		na1.getNext ().Add (cl1);
		na1.getNext ().Add (cl2);
		na1.getNext ().Add (cl3);
		na1.getNext ().Add (cl1_1);
		na1.getNext ().Add (cl3_1);
		na1.drawLinesToNext ();

		na2.getNext ().Add (cl1);
		na2.getNext ().Add (cl3);
		na2.getNext ().Add (cl4);
		na2.getNext ().Add (cl1_2);
		na2.getNext ().Add (cl3_2);
		na2.drawLinesToNext ();

		na3.getNext ().Add (cl2);
		na3.getNext ().Add (cl3);
		na3.getNext ().Add (cl5);
		na3.getNext ().Add (cl1_3);
		na3.getNext ().Add (cl3_3);
		na3.drawLinesToNext ();

		na4.getNext ().Add (cl3);
		na4.getNext ().Add (cl4);
		na4.getNext ().Add (cl5);
		na4.getNext ().Add (cl1_4);
		na4.getNext ().Add (cl3_4);
		na4.drawLinesToNext ();
	}

	public void createLevelTwoOfCl(GameObject clPrefab){
		listOfLevelTwoCl = new List<Cl> ();

		Cl cl1 = new Cl ();
		cl1.setX (0);
		cl1.setY (0);
		cl1.setZ (5);
		GameObject instantiated = cl1.instantiate (clPrefab);
		instantiated.transform.name = "Cl 2_1";
		cl1.setInstantiated (instantiated);
		listOfLevelTwoCl.Add (cl1);

		Cl cl2 = new Cl ();
		cl2.setX (0);
		cl2.setY (5);
		cl2.setZ (5);
		instantiated = cl2.instantiate (clPrefab);
		instantiated.transform.name = "Cl 2_2";
		cl2.setInstantiated (instantiated);
		listOfLevelTwoCl.Add (cl2);

		Cl cl3 = new Cl ();
		cl3.setX (5);
		cl3.setY (2.5F);
		cl3.setZ (5);
		instantiated = cl3.instantiate (clPrefab);
		instantiated.transform.name = "Cl 2_3";
		cl3.setInstantiated (instantiated);
		listOfLevelTwoCl.Add (cl3);

		Cl cl4 = new Cl ();
		cl4.setX (10);
		cl4.setY (0);
		cl4.setZ (5);
		instantiated = cl4.instantiate (clPrefab);
		instantiated.transform.name = "Cl 2_4";
		cl4.setInstantiated (instantiated);
		listOfLevelTwoCl.Add (cl4);

		Cl cl5 = new Cl ();
		cl5.setX (10);
		cl5.setY (5);
		cl5.setZ (5);
		instantiated = cl5.instantiate (clPrefab);
		instantiated.transform.name = "Cl 2_5";
		cl5.setInstantiated (instantiated);
		listOfLevelTwoCl.Add (cl5);

		/*instantiateAndMove (0, 0, 5, clPrefab);
		instantiateAndMove (0, 5, 5, clPrefab);
		instantiateAndMove (5, 2.5F, 5, clPrefab);
		instantiateAndMove (10, 0, 5, clPrefab);
		instantiateAndMove (10, 5, 5, clPrefab);*/
	}

	public void setNextForLevelTwoOfCl(){

		// TODO resolve correct coordinates with 5 spheres
		// now they are in different position ( 0, 1, 2, 3, 4, 5 )

		Na na1 = listOfLevelTwoNa [0];
		Na na2 = listOfLevelTwoNa [1];
		Na na3 = listOfLevelTwoNa [2];
		Na na4 = listOfLevelTwoNa [3];

		Na na1_1 = listOfLevelOneNa [0];
		Na na1_2 = listOfLevelOneNa [1];
		Na na1_3 = listOfLevelOneNa [2];
		Na na1_4 = listOfLevelOneNa [3];
		Na na1_5 = listOfLevelOneNa [4];

		Na na3_1 = listOfLevelThreeNa [0];
		Na na3_2 = listOfLevelThreeNa [1];
		Na na3_3 = listOfLevelThreeNa [2];
		Na na3_4 = listOfLevelThreeNa [3];
		Na na3_5 = listOfLevelThreeNa [4];

		Cl cl1 = listOfLevelTwoCl [0];
		Cl cl2 = listOfLevelTwoCl [1];
		Cl cl3 = listOfLevelTwoCl [2];
		Cl cl4 = listOfLevelTwoCl [3];
		Cl cl5 = listOfLevelTwoCl [4];

		cl1.getNext ().Add (na1);
		cl1.getNext ().Add (na2);
		cl1.getNext ().Add (na1_1);
		cl1.getNext ().Add (na3_1);
		cl1.drawLinesToNext ();

		cl2.getNext ().Add (na1);
		cl2.getNext ().Add (na3);
		cl2.getNext ().Add (na1_2);
		cl2.getNext ().Add (na3_2);
		cl2.drawLinesToNext ();

		cl3.getNext ().Add (na1);
		cl3.getNext ().Add (na2);
		cl3.getNext ().Add (na3);
		cl3.getNext ().Add (na4);
		cl3.getNext ().Add (na1_5);
		cl3.getNext ().Add (na3_5);
		cl3.drawLinesToNext ();

		cl4.getNext ().Add(na2);
		cl4.getNext ().Add(na4);
		cl4.getNext ().Add (na1_3);
		cl4.getNext ().Add (na3_3);
		cl4.drawLinesToNext ();

		cl5.getNext ().Add (na3);
		cl5.getNext ().Add (na4);
		cl5.getNext ().Add (na1_4);
		cl5.getNext ().Add (na3_4);
		cl5.drawLinesToNext ();
	}


	public void createLevelThreeOfNa(GameObject naPrefab){
		listOfLevelThreeNa = new List<Na> ();

		Na na1 = new Na ();
		na1.setX (0);
		na1.setY (0);
		na1.setZ (10);
		GameObject instantiated = na1.instantiate (naPrefab);
		instantiated.transform.name = "Na 3_1";
		na1.setInstantiated (instantiated);
		listOfLevelThreeNa.Add (na1);

		Na na2 = new Na ();
		na2.setX (0);
		na2.setY (5);
		na2.setZ (10);
		instantiated = na2.instantiate (naPrefab);
		instantiated.transform.name = "Na 3_2";
		na2.setInstantiated (instantiated);
		listOfLevelThreeNa.Add (na2);

		Na na3 = new Na ();
		na3.setX (10);
		na3.setY (0);
		na3.setZ (10);
		instantiated = na3.instantiate (naPrefab);
		instantiated.transform.name = "Na 3_3";
		na3.setInstantiated (instantiated);
		listOfLevelThreeNa.Add (na3);

		Na na4 = new Na ();
		na4.setX (10);
		na4.setY (5);
		na4.setZ (10);
		instantiated = na4.instantiate (naPrefab);
		instantiated.transform.name = "Na 3_4";
		na4.setInstantiated (instantiated);
		listOfLevelThreeNa.Add (na4);

		Na na5 = new Na ();
		na5.setX (5);
		na5.setY (2.5F);
		na5.setZ (10);
		instantiated = na5.instantiate (naPrefab);
		instantiated.transform.name = "Na 3_5";
		na5.setInstantiated (instantiated);
		listOfLevelThreeNa.Add (na5);

		/*instantiateAndMove(0, 0, 10, naPrefab);
		instantiateAndMove(0, 5, 10, naPrefab);
		instantiateAndMove(10, 0, 10, naPrefab);
		instantiateAndMove(10, 5, 10, naPrefab);
		instantiateAndMove(5, 2.5F, 10, naPrefab);*/
	}

	public void setNextForLevelThreeOfNa(){
		Na na1 = listOfLevelThreeNa [0];
		Na na2 = listOfLevelThreeNa [1];
		Na na3 = listOfLevelThreeNa [2];
		Na na4 = listOfLevelThreeNa [3];
		Na na5 = listOfLevelThreeNa [4];

		Cl cl1 = listOfLevelThreeCl [0];
		Cl cl2 = listOfLevelThreeCl [1];
		Cl cl3 = listOfLevelThreeCl [2];
		Cl cl4 = listOfLevelThreeCl [3];

        Cl cl2_1 = listOfLevelTwoCl[0];
        Cl cl2_2 = listOfLevelTwoCl[1];
        Cl cl2_3 = listOfLevelTwoCl[2];
        Cl cl2_4 = listOfLevelTwoCl[3];
        Cl cl2_5 = listOfLevelTwoCl[4];

		na1.getNext ().Add (cl1);
		na1.getNext ().Add (cl2);
        na1.getNext().Add(cl2_1);
		na1.drawLinesToNext ();

		na2.getNext ().Add (cl1);
		na2.getNext ().Add (cl3);
        na2.getNext().Add(cl2_2);
		na2.drawLinesToNext ();

		na3.getNext ().Add (cl2);
		na3.getNext ().Add (cl4);
        na3.getNext().Add(cl2_4);
		na3.drawLinesToNext ();

		na4.getNext ().Add (cl3);
		na4.getNext ().Add (cl4);
        na4.getNext().Add(cl2_5);
		na4.drawLinesToNext ();

		na5.getNext ().Add (cl1);
		na5.getNext ().Add (cl2);
		na5.getNext ().Add (cl3);
		na5.getNext ().Add (cl4);
        na5.getNext().Add(cl2_3);
		na5.drawLinesToNext ();
	}

	public void createLevelThreeOfCl(GameObject clPrefab){
		listOfLevelThreeCl = new List<Cl> ();

		Cl cl1 = new Cl ();
		cl1.setX (0);
		cl1.setY (2.5F);
		cl1.setZ (10);
		GameObject instantiated = cl1.instantiate (clPrefab);
		instantiated.transform.name = "Cl 3_1";
		cl1.setInstantiated (instantiated);
		listOfLevelThreeCl.Add (cl1);

		Cl cl2 = new Cl ();
		cl2.setX (5);
		cl2.setY (0);
		cl2.setZ (10);
		instantiated = cl2.instantiate (clPrefab);
		instantiated.transform.name = "Cl 3_2";
		cl2.setInstantiated (instantiated);
		listOfLevelThreeCl.Add (cl2);

		Cl cl3 = new Cl ();
		cl3.setX (5);
		cl3.setY (5);
		cl3.setZ (10);
		instantiated = cl3.instantiate (clPrefab);
		instantiated.transform.name = "Cl 3_3";
		cl3.setInstantiated (instantiated);
		listOfLevelThreeCl.Add (cl3);

		Cl cl4 = new Cl ();
		cl4.setX (10);
		cl4.setY (2.5F);
		cl4.setZ (10);
		instantiated = cl4.instantiate (clPrefab);
		instantiated.transform.name = "Cl 3_4";
		cl4.setInstantiated (instantiated);
		listOfLevelThreeCl.Add (cl4);

		/*instantiateAndMove (0, 2.5F, 10, clPrefab);
		instantiateAndMove (5, 0, 10, clPrefab);
		instantiateAndMove (5, 5, 10, clPrefab);
		instantiateAndMove (10, 2.5F, 10, clPrefab);*/
	}

	public void setNextForLevelThreeOfCl(){
		Na na1 = listOfLevelThreeNa [0];
		Na na2 = listOfLevelThreeNa [1];
		Na na3 = listOfLevelThreeNa [2];
		Na na4 = listOfLevelThreeNa [3];
		Na na5 = listOfLevelThreeNa [4];

		Na na2_1 = listOfLevelTwoNa [0];
		Na na2_2 = listOfLevelTwoNa [1];
		Na na2_3 = listOfLevelTwoNa [2];
		Na na2_4 = listOfLevelTwoNa [3];

		Cl cl1 = listOfLevelThreeCl [0];
		Cl cl2 = listOfLevelThreeCl [1];
		Cl cl3 = listOfLevelThreeCl [2];
		Cl cl4 = listOfLevelThreeCl [3];

		cl1.getNext ().Add (na1);
		cl1.getNext ().Add (na2);
		cl1.getNext ().Add (na5);
		cl1.getNext ().Add (na2_1);
		cl1.drawLinesToNext ();

		cl2.getNext ().Add (na1);
		cl2.getNext ().Add (na3);
		cl2.getNext ().Add (na5);
        cl2.getNext().Add(na2_2);
		cl2.drawLinesToNext ();

		cl3.getNext ().Add (na2);
		cl3.getNext ().Add (na4);
		cl3.getNext ().Add (na5);
        cl3.getNext().Add(na2_3);
		cl3.drawLinesToNext ();

		cl4.getNext ().Add (na3);
		cl4.getNext ().Add (na4);
		cl4.getNext ().Add (na5);
        cl4.getNext().Add(na2_4);
		cl4.drawLinesToNext ();
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

			if ( newX < 0 ) drawLineByX (item);
			else 
				if ( newY < 0 ) drawLineByY (item);
				else
					if ( newZ < 0 ) drawLineByZ (item);

			if (newX > 0) drawLineReverseByX (item);
			else 
				if (newY > 0) drawLineReverseByY (item);
				else 
					if (newZ > 0) drawLineReverseByZ (item);
		}
	}

	private void drawLineByX(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getX () - getX () ) / 4;

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( (getX() + scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		naCylinder.transform.Rotate (rotation);
	}

	private void drawLineReverseByX(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( (getX() - scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		naCylinder.transform.Rotate (rotation);
	}

	private void drawLineByY(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getY () - getY () ) / 4;
	 
		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( getX(), (getY() + scale.y), getZ() );
	}

	private void drawLineReverseByY(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 (getX(), (getY() - scale.y), getZ());
	}

	private void drawLineByZ(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getZ () - getZ () ) / 4;

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( getX(), getY(), (getZ() + scale.y) );

		Vector3 rotation = new Vector3 (90, 0, 0);
		naCylinder.transform.Rotate (rotation);
	}

	private void drawLineReverseByZ(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 (getX(), getY(), (getZ() - scale.y));

		Vector3 rotation = new Vector3 (90, 0, 0);
		naCylinder.transform.Rotate (rotation);
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

	private GameObject clCylinder = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Cl/ClCylinder.prefab",
		typeof(GameObject)) as GameObject;


	public Cl(){
		next = new List<Na> ();
	}

	public GameObject instantiate(GameObject prefab){
		GameObject clObject = Instantiate(prefab) as GameObject;
		clObject.transform.position = new Vector3 (x, y, z);
		return clObject;
	}

	public void drawLinesToNext(){
		foreach (Na item in next) {
			float newX = x - item.getX ();
			float newY = y - item.getY ();
			float newZ = z - item.getZ ();

			if ( newX < 0 ) drawLineByX (item);
				else if ( newY < 0 ) drawLineByY (item);	
					else if ( newZ < 0 ) drawLineByZ (item);

			if ( newX > 0 ) drawLineReverseByX (item);
				else if ( newY > 0 ) drawLineReverseByY (item);
					else if ( newZ > 0 ) drawLineReverseByZ (item);
		}
	}

	private void drawLineByX(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 ( (getX() + scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		clCylinder.transform.Rotate (rotation);
	}

	private void drawLineReverseByX(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 ( (getX() - scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		clCylinder.transform.Rotate (rotation);
	}

	private void drawLineByY(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (getY() + scale.y), getZ());
	}

	private void drawLineReverseByY(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (getY() - scale.y), getZ());
	}

	private void drawLineByZ(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 ( getX(), getY(), (getZ() + scale.y) );

		Vector3 rotation = new Vector3 (90, 0, 0);
		clCylinder.transform.Rotate (rotation);
	}

	private void drawLineReverseByZ(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), getY(), (getZ() - scale.y));

		Vector3 rotation = new Vector3 (90, 0, 0);
		clCylinder.transform.Rotate (rotation);
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

	public GameObject getCylinder(){
		return clCylinder;
	}

	public GameObject getInstantiated(){
		return instantiatedObj;
	}

	public void setInstantiated(GameObject obj){
		this.instantiatedObj = obj;
	}

}
