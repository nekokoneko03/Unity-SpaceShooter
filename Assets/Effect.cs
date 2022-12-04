using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private float _upMove;
    [SerializeField] private float _downMove;
    [SerializeField] private float _leftMove;
    [SerializeField] private float _rightMove;

    [SerializeField] private float _exsitsTime;

    private float _timer;

    void Start()
    {
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((_leftMove + _rightMove), (_upMove + _downMove)) * Time.deltaTime;

        if (_timer >= _exsitsTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}
