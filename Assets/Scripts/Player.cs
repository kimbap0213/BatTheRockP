using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected bool IsAttack = false;
    protected Player _targetPlayer = null;
    protected float _xspeed = 10;
    protected GameObject _mySpawnProjectile = null;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.AddPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAttack()
    {
        IsAttack = true;
        Vector2 _projectileVector;
        _targetPlayer = PlayerManager.Instance.GetRandomPlayer(this);
        Vector2 _gap = _targetPlayer.transform.position - transform.position;
        int LeftRight;
        if(_gap.x > 0)
        {
            LeftRight = 1;
        }
        else
        {
            LeftRight = -1;
        }
        Debug.Log(name + " attack " + _targetPlayer.name + "    " +LeftRight.ToString());
        _projectileVector = new Vector2(_xspeed * LeftRight, 5 * (Mathf.Abs(_gap.x) / _xspeed) + (_gap.y / (Mathf.Abs(_gap.x) / _xspeed)));
        //_projectileVector = (_projectileVector.normalized + Vector2.up * Random.Range(-0.1f, 0.1f)) * _projectileVector.magnitude;
        
        _mySpawnProjectile = Instantiate(PlayerManager.Instance.GetProjectilePrefap(), transform.position, Quaternion.Euler(Vector3.zero));
        _mySpawnProjectile.GetComponent<Projectile>().SetInitialVelocity(_projectileVector);
        Invoke("AttackEnd", 5f);
    }

    public void AttackEnd()
    {
        IsAttack = false;
        PlayerManager.Instance.NextTurn();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != _mySpawnProjectile)
        {
            collision.gameObject.SetActive(false);
            PlayerManager.Instance.DestroyPlayer(this);
            gameObject.SetActive(false);
        }
    }
}
