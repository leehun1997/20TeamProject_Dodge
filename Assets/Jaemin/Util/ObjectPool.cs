using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name; //이름
        public GameObject prefab; //오브젝트 프리펩
        public int size; //생성할 사이즈
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>(); 
            for(int i = 0;  i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform); //이 스크립트를 가지고 있는 오브젝트 자식으로 넣어준다.
                obj.SetActive(false);
                queue.Enqueue(obj);//queue에 넣는다
            }

            PoolDictionary.Add(pool.name, queue); //1개의 대한 오브젝트를 풀을 넣어준다 : 이름마다 다르다
        }
    }

    public GameObject SpawnFromPool(string name)
    {
        if (!PoolDictionary.ContainsKey(name)) //name이 존재하는지 확인하고 없으면 null
        {
            return null;
        }

        Queue<GameObject> queue = PoolDictionary[name];
        int originalQueueCount = queue.Count;

        // 비활성화된 오브젝트를 찾을 때까지 반복
        for (int i = 0; i < originalQueueCount; i++)
        {
            GameObject obj = queue.Dequeue();

            // 만약 오브젝트가 비활성화 상태라면 사용하고, 그렇지 않다면 큐 뒤로 보낸다
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                queue.Enqueue(obj);
                return obj; // 활성화된 오브젝트를 반환
            }

            // 오브젝트가 이미 활성화된 경우 큐 뒤로 보낸다
            queue.Enqueue(obj);
        }

        // 사용할 수 있는 비활성화된 오브젝트가 없는 경우 null을 반환
        return null;
    }
}
