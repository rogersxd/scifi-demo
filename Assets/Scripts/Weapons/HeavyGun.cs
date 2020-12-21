using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGun : MonoBehaviour
{
    [SerializeField]
    GameObject _muzzleFlash;

    [SerializeField]
    GameObject _hitMarker;

    [SerializeField]
    AudioSource _fireAudio;

    UIManager _uiManager;

    int ammo = 100;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();

            return;
        }


        if (Input.GetKeyDown(KeyCode.R) && ammo < 30)
        {
            Reload();

            return;
        }

        DisableEffects();
    }

    void Fire()
    {
        if (ammo == 0)
        {
            DisableEffects();

            return;
        }

        FireAudio();

        _muzzleFlash.SetActive(true);

        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hitInfo))
        {
            GameObject hit = Instantiate(_hitMarker, hitInfo.point, Quaternion.identity);
            Destroy(hit, 1f);
        }

        ammo--;

        _uiManager.UpdateAmmo(ammo);
    }

    void FireAudio()
    {
        if (!_fireAudio.isPlaying)
        {
            _fireAudio.Play();
        }
    }


    void Reload()
    {
        ammo = 100 - ammo;

        _uiManager.UpdateAmmo(ammo);
    }

    void DisableEffects()
    {
        _fireAudio.Stop();

        _muzzleFlash.SetActive(false);
    }
}
