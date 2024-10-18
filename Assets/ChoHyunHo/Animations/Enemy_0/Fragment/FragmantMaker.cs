using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmantMaker : MonoBehaviour
{
    [Header("유형에 맞는 파편Prefab연결")]
    [SerializeField] List<GameObject> FragmantPrefab;

    private float RandNum;
    private Vector2 makePosition;
    //private Rigidbody2D objRigid2D;

    private void Start()
    {
        makePosition = new Vector2 (transform.position.x, transform.position.y);
    }

    //Enemy_0_Death애니메이터>Death애니메이션>Add Animation Event에서 호출됨
    public void InstantiateFragmant()
    {
        foreach (var obj in FragmantPrefab)
        {
            RandNum = Random.Range(0f, 360f);
            Instantiate(obj, makePosition, Quaternion.Euler(0, 0, RandNum));

            //별도의 스크립트로 처리 여기서는 작동하지않음
            //objRigid2D = obj.GetComponent<Rigidbody2D>();
            //objRigid2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
}
