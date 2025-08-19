using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SenmagHaptic
{
	public class telerobotParamControl : MonoBehaviour
	{

		public GameObject Button_WeightHigh;
		public GameObject Button_WeightMed;
		public GameObject Button_WeightLow;

		public GameObject Button_StrengthHigh;
		public GameObject Button_StrengthMed;
		public GameObject Button_StrengthLow;

		public GameObject Button_GripperOpen;
		public GameObject Button_GripperClosed;

		public Vector3 GripStrengthPresets;
		public Vector3 RobotWeightPresets;

		public GameObject robotTip;
		public ConfigurableJoint objectGrabJoint;

		// Start is called before the first frame update
		void Start()
		{
			openGripper();
            setDrag(1);
            GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(10, 0, 0);
			GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(-10, 0, 0);
			Physics.IgnoreCollision(GameObject.Find("gripper1_tip").GetComponent<MeshCollider>(), GameObject.Find("gripper2_tip").GetComponent<MeshCollider>());
			Physics.IgnoreCollision(GameObject.Find("gripper1_tip").GetComponent<MeshCollider>(), GameObject.Find("Arm_joint6").GetComponent<MeshCollider>());
			Physics.IgnoreCollision(GameObject.Find("gripper2_tip").GetComponent<MeshCollider>(), GameObject.Find("Arm_joint6").GetComponent<MeshCollider>());
			//Physics.FrictionType

			setGripStrength(1);
			setDrag(1);
			/*Button_WeightHigh.GetComponent<Senmag_button>().isHighlighted = false;
			Button_StrengthMed.GetComponent<Senmag_button>().isHighlighted = true;
			Button_WeightLow.GetComponent<Senmag_button>().isHighlighted = false;
			Button_StrengthHigh.GetComponent<Senmag_button>().isHighlighted = false;
			Button_WeightMed.GetComponent<Senmag_button>().isHighlighted = true;
			Button_StrengthLow.GetComponent<Senmag_button>().isHighlighted = false;*/
		}

		// Update is called once per frame
		void Update()
		{
			/*if (Button_WeightHigh.GetComponent<Senmag_button>().wasClicked())
			{
				setDrag(2);
				Button_WeightHigh.GetComponent<Senmag_button>().isHighlighted = true;
				Button_WeightMed.GetComponent<Senmag_button>().isHighlighted = false;
				Button_WeightLow.GetComponent<Senmag_button>().isHighlighted = false;
			}
			if (Button_WeightMed.GetComponent<Senmag_button>().wasClicked())
			{
				setDrag(1);
				Button_WeightHigh.GetComponent<Senmag_button>().isHighlighted = false;
				Button_WeightMed.GetComponent<Senmag_button>().isHighlighted = true;
				Button_WeightLow.GetComponent<Senmag_button>().isHighlighted = false;
			}
			if (Button_WeightLow.GetComponent<Senmag_button>().wasClicked())
			{
				setDrag(0);
				Button_WeightHigh.GetComponent<Senmag_button>().isHighlighted = false;
				Button_WeightMed.GetComponent<Senmag_button>().isHighlighted = false;
				Button_WeightLow.GetComponent<Senmag_button>().isHighlighted = true;
			}


			if (Button_StrengthHigh.GetComponent<Senmag_button>().wasClicked())
			{
				setGripStrength(2);
				Button_StrengthHigh.GetComponent<Senmag_button>().isHighlighted = true;
				Button_StrengthMed.GetComponent<Senmag_button>().isHighlighted = false;
				Button_StrengthLow.GetComponent<Senmag_button>().isHighlighted = false;
			}
			if (Button_StrengthMed.GetComponent<Senmag_button>().wasClicked())
			{
				setGripStrength(1);
				Button_StrengthHigh.GetComponent<Senmag_button>().isHighlighted = false;
				Button_StrengthMed.GetComponent<Senmag_button>().isHighlighted = true;
				Button_StrengthLow.GetComponent<Senmag_button>().isHighlighted = false;
			}
			if (Button_StrengthLow.GetComponent<Senmag_button>().wasClicked())
			{
				setGripStrength(0);
				Button_StrengthHigh.GetComponent<Senmag_button>().isHighlighted = false;
				Button_StrengthMed.GetComponent<Senmag_button>().isHighlighted = false;
				Button_StrengthLow.GetComponent<Senmag_button>().isHighlighted = true;
			}*/
			/*
			if (Button_GripperOpen.GetComponent<Senmag_button>().wasClicked())
			{
				openGripper();
			}

			if (Button_GripperClosed.GetComponent<Senmag_button>().wasClicked())
			{
				closeGripper();
			}*/
		}
		

		public void setGripStrength(int preset)
		{
			JointDrive tmp = new JointDrive();
			tmp.positionDamper = 0f;
			tmp.positionSpring = GripStrengthPresets[preset];
			tmp.maximumForce = 1000;

			GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().angularXDrive = tmp;
			GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().angularXDrive = tmp;
		}

		public void grabObject(GameObject objectToGrab)
		{

            UnityEngine.Debug.Log("grabbing an object!");

            objectGrabJoint = robotTip.AddComponent<ConfigurableJoint>();



            objectGrabJoint.enableCollision = false;
            objectGrabJoint.autoConfigureConnectedAnchor = true;
            //objectGrabJoint.anchor = new Vector3(0, 0, 0);


            
           /* objectGrabJoint.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked; //.set(locked);
            objectGrabJoint.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked; //.set(locked);
            objectGrabJoint.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked; //.set(locked);
            objectGrabJoint.GetComponent<ConfigurableJoint>().angularXMotion = ConfigurableJointMotion.Locked;
            objectGrabJoint.GetComponent<ConfigurableJoint>().angularYMotion = ConfigurableJointMotion.Locked;
            objectGrabJoint.GetComponent<ConfigurableJoint>().angularZMotion = ConfigurableJointMotion.Locked;*/
            objectGrabJoint.connectedBody = objectToGrab.GetComponent<Rigidbody>();


            objectGrabJoint.xMotion = ConfigurableJointMotion.Free; //.set(locked);
            objectGrabJoint.yMotion = ConfigurableJointMotion.Free; //.set(locked);
            objectGrabJoint.zMotion = ConfigurableJointMotion.Free; //.set(locked);

            objectGrabJoint.angularXMotion = ConfigurableJointMotion.Free; //.set(locked);
            objectGrabJoint.angularYMotion = ConfigurableJointMotion.Free; //.set(locked);
            objectGrabJoint.angularZMotion = ConfigurableJointMotion.Free; //.set(locked);

            JointDrive springDrive = new JointDrive();
            springDrive.positionSpring = 1000000f;
            springDrive.maximumForce = 1000000;
            springDrive.positionDamper = 3000;
            objectGrabJoint.xDrive = springDrive;
            objectGrabJoint.yDrive = springDrive;
            objectGrabJoint.zDrive = springDrive;

            springDrive.positionSpring = 200;
            springDrive.maximumForce = 1000000;
            springDrive.positionDamper = 30;
            
            objectGrabJoint.angularXDrive = springDrive;
            objectGrabJoint.angularYZDrive = springDrive;
            

        }

		public void dropObject()
		{
			if (objectGrabJoint != null)
			{
				objectGrabJoint.connectedBody = null;
                Destroy(objectGrabJoint);
                UnityEngine.Debug.Log("removing joint from object!");
			}
        }

		public void closeGripper()
		{
			UnityEngine.Debug.Log("gripper close");
			float gripperCloseAngle = 35;
			GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(-gripperCloseAngle, 0, 0);
			GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(gripperCloseAngle, 0, 0);

			if(robotTip.GetComponent<CollisionTracker>().collidedObject != null)
			{
				grabObject(robotTip.GetComponent<CollisionTracker>().collidedObject);

            }



            else if (GameObject.Find("gripper1").GetComponent<CollisionTracker>().collidedObject != null)
            {
                grabObject(GameObject.Find("gripper1").GetComponent<CollisionTracker>().collidedObject);
            }
            else if(GameObject.Find("gripper2").GetComponent<CollisionTracker>().collidedObject != null)
			{
                grabObject(GameObject.Find("gripper2").GetComponent<CollisionTracker>().collidedObject);
            }


            //GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, .01f);
            //GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, -.01f);


                    /*float openVal = 20f;

                    Vector3 tmp;
                    tmp = GameObject.Find("gripper1_dummy").transform.localPosition;
                    tmp.x += openVal;
                    GameObject.Find("gripper1_dummy").transform.localPosition = tmp;

                    tmp = GameObject.Find("gripper2_dummy").transform.localPosition;
                    tmp.x -= openVal;
                    GameObject.Find("gripper2_dummy").transform.localPosition = tmp;*/


                    /*Vector3 tmp;
                    tmp = GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().connectedAnchor;// = new Vector3(0, 0, -.05f);
                    tmp.x -= gripperadj;
                    GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().connectedAnchor = tmp;

                    tmp = GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().connectedAnchor;// = new Vector3(0, 0, -.05f);
                    tmp.x += gripperadj;
                    GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().connectedAnchor = tmp;*/

           // Button_GripperOpen.GetComponent<Senmag_button>().isHighlighted = false;
		//	Button_GripperClosed.GetComponent<Senmag_button>().isHighlighted = true;
		}
		public void openGripper()
		{
			UnityEngine.Debug.Log("gripper open");
			GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(10, 0, 0);
			GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(-10, 0, 0);
			dropObject();
            //GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, -.04f);
            //GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, .04f);

            /*float openVal = 20f;

			Vector3 tmp;
			tmp = GameObject.Find("gripper1_dummy").transform.localPosition;
			tmp.x -= openVal;
			GameObject.Find("gripper1_dummy").transform.localPosition = tmp;

			tmp = GameObject.Find("gripper2_dummy").transform.localPosition;
			tmp.x += openVal;
			GameObject.Find("gripper2_dummy").transform.localPosition = tmp;*/
            /*Vector3 tmp;
			tmp = GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().connectedAnchor;// = new Vector3(0, 0, -.05f);
			tmp.x += gripperadj;
			GameObject.Find("gripper1").GetComponent<ConfigurableJoint>().connectedAnchor = tmp;

			tmp = GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().connectedAnchor;// = new Vector3(0, 0, -.05f);
			tmp.x -= gripperadj;
			GameObject.Find("gripper2").GetComponent<ConfigurableJoint>().connectedAnchor = tmp;*/


           // Button_GripperOpen.GetComponent<Senmag_button>().isHighlighted = true;
			//Button_GripperClosed.GetComponent<Senmag_button>().isHighlighted = false;
		}

		private void setDrag(int preset)
		{
			UnityEngine.Debug.Log("Setting robot drag");
			foreach (Transform child in transform.GetComponentsInChildren<Transform>())
			{
				try
				{
					child.gameObject.GetComponent<Rigidbody>().drag = RobotWeightPresets[preset];
					child.gameObject.GetComponent<Rigidbody>().angularDrag = RobotWeightPresets[preset];

				}
				catch
				{

				}
				try
				{
					JointSpring tmp = new JointSpring();
					tmp.spring = 0;
					tmp.damper = RobotWeightPresets[preset];
					child.gameObject.GetComponent<HingeJoint>().spring = tmp;
				}
				catch
				{

				}
			}
		}




	}
}