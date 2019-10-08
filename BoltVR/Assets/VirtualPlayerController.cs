using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPlayerController : Bolt.EntityEventListener<IVirtualPlayerState>
{
    RigFinder RF;
    public override void Attached()
    {
        RF = GameObject.Find("RigFinder").GetComponent<RigFinder>();
        if (entity.IsOwner == true)
        {
            Component[] MeshRenderers;
            MeshRenderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer MR in MeshRenderers)
            {
                MR.enabled = false;
            }

            //transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            if (staticData.isModeVR == true)
            {
                Debug.Log("ISVR");
                SetTransformsXR();
            }
            else
            {
                Debug.Log("NOTVR");
                RF.Test0();
                SetTransformSimulated();
                RF.leftHandAlias.GetComponent<MeshRenderer>().enabled = false;
                RF.leftHandAlias.GetComponent<BoxCollider>().enabled = false;
                RF.rightHandAlias.GetComponent<MeshRenderer>().enabled = false;
                RF.rightHandAlias.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            SetTransformsProxy();
        }
    }



    void SetTransformsProxy()
    {
        state.SetTransforms(state.body, transform);
        state.SetTransforms(state.head, transform.GetChild(0));
        state.SetTransforms(state.leftHand, transform.GetChild(1));
        state.SetTransforms(state.rightHand, transform.GetChild(2));
    }

    void SetTransformNull()
    {
        state.SetTransforms(state.body, null);
        state.SetTransforms(state.head, null);
        state.SetTransforms(state.leftHand, null);
        state.SetTransforms(state.rightHand, null);
    }

    void SetTransformsXR()
    {
        state.SetTransforms(state.body, RF.rigBodyXR);
        state.SetTransforms(state.head, RF.rigHeadXR);
        state.SetTransforms(state.leftHand, RF.rigLeftHandXR);
        state.SetTransforms(state.rightHand, RF.rigRightHandXR);
    }

    void SetTransformSimulated()
    {
        state.SetTransforms(state.body, RF.rigBody);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            SetTransformNull();
            SetTransformSimulated();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            SetTransformNull();
            SetTransformsXR();
        }

    }
    */
}
