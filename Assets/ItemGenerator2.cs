using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour
{

    //Unityちゃんのオブジェクト
    private GameObject unitychan;


    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private float startPos = -160;
    //ゴール地点
    private float goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    Vector3 lastitem;


    // Use this for initialization
    void Start()
    {

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        this.lastitem = new Vector3(this.unitychan.transform.position.x, this.unitychan.transform.position.y, this.unitychan.transform.position.z + 40.0f);

    }

    // Update is called once per frame
    void Update()
    {

        if (unitychan.transform.position.z >= lastitem.z - 25.0f && unitychan.transform.position.z <= goalPos - 40.0f)
        {


            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);

            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40.0f);

                    this.lastitem = cone.transform.position;

                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 40.0f + offsetZ);

                        this.lastitem = coin.transform.position;
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 40.0f + offsetZ);

                        this.lastitem = car.transform.position;
                    }
                }
            }

        }

    }
}
    

