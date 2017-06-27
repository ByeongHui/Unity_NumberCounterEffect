using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UINumCounter : MonoBehaviour
{
    // 카운트 방식.
    public enum COUNT_TYPE
    {
        INCREASE = 0,   // 증가.
        DECREASE        // 감소.
    };

    [SerializeField] public COUNT_TYPE countDirection = COUNT_TYPE.INCREASE;    // 기본값 : 증가.
    [SerializeField] public float m_DisplayNumber;                              // 텍스트에 표시되는 값.
    [SerializeField] public float m_DestinationNumber;                          // 도달하고자하는 최종 목표 값.
    [SerializeField] public float m_CountSpeed = 50f;                           // 속도.

    public Text m_TextLabel;

    void Awake()
    {
        if (m_TextLabel == null)
            m_TextLabel = this.gameObject.GetComponent<Text>();

        /// Ex) 0부터 1000까지 초당 100의 속도로 증가. = 10초면 1000의 값 도달.
        /// 원하는 지점에서 해당 함수 호출.
        //StartCounter(0, 1000, 100f);
    }

    /// <summary>
    /// 목표한 값까지 속도 값에 맞춰서 지속적으로 증가 혹은 감소합니다.
    /// </summary>
    /// <param name="startValue">시작 값 ( 현재 표기중인 값 )</param>
    /// <param name="endValue">목표 값 ( 증감에 따라 이동할 최종 값 )</param>
    /// <param name="speed">속도</param>
    public void StartCounter(int startValue, int endValue, float speed)
    {
        if (m_TextLabel != null)
        {
            m_DisplayNumber = startValue;
            m_DestinationNumber = endValue;
            m_CountSpeed = speed;
            m_TextLabel.text = startValue.ToString();
        }
    }


    void Update()
    {
        if (m_CountSpeed != 0)
        {
            if (countDirection == COUNT_TYPE.DECREASE)
            {
                m_DisplayNumber -= (m_CountSpeed * Time.deltaTime);
                if (m_DisplayNumber <= m_DestinationNumber)
                {
                    m_DisplayNumber = m_DestinationNumber;
                    m_CountSpeed = 0;
                    if (m_DisplayNumber < 0)
                        m_DisplayNumber = 0;
                }
            }
            else
            {
                m_DisplayNumber += (m_CountSpeed * Time.deltaTime);
                if (m_DisplayNumber > m_DestinationNumber)
                {
                    m_DisplayNumber = m_DestinationNumber;
                    m_CountSpeed = 0;
                }
            }

            m_TextLabel.text = ((int)m_DisplayNumber).ToString();
        }
    }

}