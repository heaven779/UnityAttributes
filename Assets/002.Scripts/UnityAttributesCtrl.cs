using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//클래스 직렬화
//이것을 추가하면 유니티 에디터의 인스펙터에 노출가능
[System.Serializable]
public class Player
{
    public string name;
    public float hp;

}

//사용자 정의 문서 추가
[HelpURL("https://docs.unity3d.com/Manual/index.html")]
//해당 컴포넌트를 추가한다. 이 스크립트가 먼저 삭제되지 않는 이상 이것으로 
//추가된 컴포넌트는 제거 불가능
[RequireComponent(typeof(Add))]
//Add컴포넌트에 메뉴를 추가한다.
[AddComponentMenu("MyMenuCom/AttributesCtrl")]
public class UnityAttributesCtrl : MonoBehaviour
{

    public Player player;

    //변수위에 헤더를 추가!
    [Header("UserName")]
    public string name = "string";
    //텍스트 영역의 줄 수 만큼 임의로 노출한다.
    [Multiline(3)]
    public string job = "";
    //텍스트 영역의 표시 초소 최대 줄수를 임의로 조절하여 노출한다.
    [TextArea(3, 5)]
    public string job2 = "";

    //인스펙터에서 변수 사이의 공간을 넣는다.
    [Space(50)]
    //해당 범위만큼의 슬라이더를 추가한다.
    [Range(0, 5)]
    public float m_Hp;
    [Tooltip("이것은 툴팁입니다.")]
    public float m_Mp;

    //인스펙터에서 숨깁니다.
    [HideInInspector]
    public float m_atk;

    //에디터에 메뉴추가 정적 함수여야한다.
    [UnityEditor.MenuItem("MyMenu/DebugLog")]
    public static void OnDebugLog()
    {
        Debug.Log("불렀어?");
    }

    [System.Obsolete("이건 ㄴㄴ")]
    public void OnDebugLogTest()
    {

    }

    //실행시 처음에 무조건 실행되는 함수, 오브젝트가 비활성화 상태라도 실행된다. 
    //After은 Awake 후에 호출되고(Start보다는 전) Before는 Awake전에 실행된다. 
    //단, 정적 함수에만 사용해야한다.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void OnRuntimeInitialize()
    {
        Debug.Log("RuntimeInitializeOnLoadMethod Test");
    }

    // 컬러 변수의 알파 표시, HDR로 처리할지를 선택 가능.
    [ColorUsage(true, true)]
    public Color color;

    // 변수에서 우측 클릭했을때 나오는 메뉴
    [ContextMenuItem("Reset", "ResetPos")]                
    public Vector3 pos;
    private void ResetPos()
    { 
        pos = Vector3.zero;
    }

    // 컴포넌트의 톱니바퀴를 누르면 표시되는 메뉴에 추가!
    [ContextMenu("톱니메뉴추가!")]                      
    private void OnDebugLog5()
    {
        Debug.Log("추가됨!");
    }

}
