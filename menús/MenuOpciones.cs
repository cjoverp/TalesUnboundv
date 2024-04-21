using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class UI_VolumeHandler : MonoBehaviour
    {

        [SerializeField] private AudioMixer mixer;
        

        public void SetVolume(float Amount)
        {
            mixer.SetFloat("Vol",Mathf.Log10(Amount) * 20);
        }

    }

}
