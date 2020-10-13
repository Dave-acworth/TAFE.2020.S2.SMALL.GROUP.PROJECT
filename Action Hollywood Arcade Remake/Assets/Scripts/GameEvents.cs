﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using AidensWork;

namespace AidensWork
{
    /// <summary>
    /// Author: Aiden Cran
    /// Date:
    /// Last Edited:
    /// 
    /// </summary>
    public class GameEvents : MonoBehaviour
    {
        [SerializeField] UnityEvent onLeftClick;

        [SerializeField] UnityEvent onEscape;

        [SerializeField] UnityEvent OnStart;

        [SerializeField] UnityEvent onEnemyHit;

        [SerializeField] UnityEvent onPlayerHit;


        private void Start()
        {
            OnStart?.Invoke();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                onLeftClick?.Invoke();
            }

            if (Input.GetButtonDown("Cancel"))
            {
                onEscape?.Invoke();
            }
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.tag == "Player")
        //    {
        //        onPlayerHit?.Invoke();
        //    }
        //    if (other.gameObject.tag == "Enemy")
        //    {
        //        onEnemyHit?.Invoke();
        //    }
        //    else
        //    {
        //        Debug.Log("Event Collision = Null");
        //    }
        //}
    }
}