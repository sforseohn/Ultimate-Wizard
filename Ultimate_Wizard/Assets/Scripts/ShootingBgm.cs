using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBgm : MonoBehaviour
{

    private void Awake() {
        SoundManager.instance.BgmPlay(2);
    }
}
