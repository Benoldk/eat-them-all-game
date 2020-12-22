using Assets.Scripts.Base;
using System;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NPCCharacter : GameCharacter
    {
        public Action ReduceCrowdSizeEvent;

        private void OnTriggerEnter(Collider other)
        {
            var gameChar = GetComponent<GameCharacter>();
            if (other != null && other.gameObject != null)
            {
                var colliderChar = other.gameObject.GetComponent<GameCharacter>();
                if (colliderChar != null && colliderChar.IsInfected && !gameChar.IsInfected)
                {
                    gameChar.IsInfected = true;
                    var renderers = GetComponentsInChildren<Renderer>();
                    foreach (var rend in renderers)
                    {
                        rend.materials[0].color = Color.green;
                    }

                    if (ReduceCrowdSizeEvent != null)
                    {
                        ReduceCrowdSizeEvent();
                    }
                }
            }
        }
    }
}