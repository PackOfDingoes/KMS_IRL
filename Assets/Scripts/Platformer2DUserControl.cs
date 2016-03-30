using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.P);
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            // Pass all parameters to the character control script.
            if (m_Character.onLadder == false)
            {
                m_Character.Move(h, m_Jump);
            }
            if (m_Character.onLadder == true)
            {
                m_Character.Move(h, m_Jump, v);
            }
            m_Jump = false;
        }
    }
}
