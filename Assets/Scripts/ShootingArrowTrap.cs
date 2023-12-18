using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArrowTrap : Trap
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float shootForce;
    private bool _isTrapActive = false;
  
    public void Shoot() 
    {
        var bullet = Instantiate(_bullet, transform.position, Quaternion.identity); // стреляет suriken
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * shootForce); // напрвление стрельбы 
        Debug.Log(transform.root.name);
    }

    public override void PlayAnimation(string name) //проигрывает анимацию
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            Shoot();
            _isTrapActive = true;
        }
            
    }
}
