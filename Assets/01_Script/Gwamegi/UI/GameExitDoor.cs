using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitDoor : MonoBehaviour
{
    [SerializeField] private MessegeBox m_Box;

    public void Exit()
    {
        m_Box.Show("게임을 나가시겠습니까?");
    }
}
