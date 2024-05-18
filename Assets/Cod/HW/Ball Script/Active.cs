using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    internal bool _finish;
    internal bool _wasFinish;
    internal bool _lose;
    internal bool _newRecordBool;
    internal int _levelNumber;
    internal int _passedPlatforms;
    internal int _maxPassedPlatforms;
    internal Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }
    
    private void OnCollisionEnter(Collision collision) //считывает столкновение*-
    {
        if (collision.gameObject.tag == "Finish") //с финишем
        {
            _finish = true;
            _wasFinish = true;
        }
        if (collision.gameObject.tag == "KillZone") //с килл зоной
            _lose = true;
    }

    public void ChangedKinematic(bool isKinematic) //переведение из пассивного состояния в активное и наоборот
    {
        Rigidbody _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = isKinematic;
    }
    
    private void OnTriggerExit(Collider other) //При выходе из тригера в отверстии платформы добавляется 1
                                               //к количеству пройденных платформ и проверяется не рекорд ли это
    {
        _passedPlatforms++;

        if (_passedPlatforms > _maxPassedPlatforms)
        {
            _maxPassedPlatforms = _passedPlatforms;
            _newRecordBool = true;
        }
    }
}
