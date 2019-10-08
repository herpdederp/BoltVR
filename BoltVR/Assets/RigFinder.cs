using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;
using VRTK.Prefabs.CameraRig.CameraRigSwitcher;
using Zinnia.Tracking.Modification;
using UnityEngine.SceneManagement;
using UdpKit;

public class RigFinder : Bolt.GlobalEventListener
{
    public GameObjectStateSwitcher GOSS;
    public XRSettingsConfigurator XRSC;
    public Transform rigBody;

    public Transform rigBodyXR;
    public Transform rigHeadXR;
    public Transform rigLeftHandXR;
    public Transform rigRightHandXR;

    public Transform body;

    public Transform leftHandAlias;
    public Transform rightHandAlias;




    public override void SceneLoadLocalDone(string scene)
    {
        BoltNetwork.Instantiate(BoltPrefabs.VirtualPlayer);
    }

    // Start is called before the first frame update
    void Start()
    {
        staticData.myRigFinder = this;
    }
    
    public void Test0()
    {
        XRSC.DisableXR();
        GOSS.SwitchTo(1);
    }
    

}
