namespace VRTK.Prefabs.CameraRig.CameraRigSwitcher
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.XR;

    /// <summary>
    /// Provides configuration for the XRSettings.
    /// </summary>
    public class XRSettingsConfigurator : MonoBehaviour
    {
        /// <summary>
        /// Enables XR in the Unity Software.
        /// </summary>
        public virtual void EnableXR()
        {
            StartCoroutine("SwitchToVR");
        }

        /// <summary>
        /// Disables XR in the Unity Software.
        /// </summary>
        public virtual void DisableXR()
        {
            XRSettings.enabled = false;
        }

        IEnumerator SwitchToVR()
        {
            XRSettings.LoadDeviceByName("Oculus");

            yield return null;
            XRSettings.enabled = true;
            // TrackingOriginMode.Floor
            transform.root.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.root.GetChild(0).GetChild(0).gameObject.SetActive(true);
            Debug.Log("qweqw");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                InputTracking.Recenter();
            }
        }

    }
}