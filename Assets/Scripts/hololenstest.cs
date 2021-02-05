using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace Microsoft.MixedReality.Toolkit.Examples.Demos {

    public class hololenstest : MonoBehaviour
    {

        public GameObject holointerface;

        void Start()
        {
            holointerface.SetActive(false);
        }

        public void On()
        {
            holointerface.SetActive(true);
        }

        public void Off()
        {
            holointerface.SetActive(false);
        }
    }
//}