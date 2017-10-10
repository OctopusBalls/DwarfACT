using System.Collections;
using System.Collections.Generic;
using Tango;
using UnityEngine;

public class MarkerTracking : MonoBehaviour, ITangoVideoOverlay {

    /// <summary>
    /// TangoApp
    /// </summary>
    //マーカーの格納先
    List<TangoSupport.Marker> markers;

    //Tangoの各種情報を取り扱う
    TangoApplication tango;

    /// <summary>
    /// Models
    /// </summary>
    //表示させるモデル
    public GameObject doorPrefab;
    public GameObject dwarfPrefab;

    //表示させるモデルの大きさ（メートル単位）
    float doorHeight;
    float dwarfHeight;

    bool doorCreateFlag = false;

    /// <summary>
    /// MarkerInfo
    /// </summary>
    //マーカーの大きさ（メートル単位）
    const double markerSize = 0.1;

	// Use this for initialization
	void Start () {
        //Tangoで起きたイベントを受け取れるように登録
        tango = FindObjectOfType<TangoApplication>();
        tango.Register(this);

        markers = new List<TangoSupport.Marker>();

        /* プレハブから取得するのでコメントアウト
        //表示するモデルをスクリプト内で使用できるように
        doorPrefab = GameObject.Find("Door");
        dwarfPrefab = GameObject.Find("Dwarf");
        */

        //モデルの高さを取得（OnTangoImageAvailable...で使用）
        doorHeight = doorPrefab.transform.lossyScale.y;
        dwarfHeight = dwarfPrefab.transform.lossyScale.y;
	}
	
    public void OnTangoImageAvailableEventHandler(TangoEnums.TangoCameraId cameraId, TangoUnityImageData imageBuffer)
    {
        //画像処理によるマーカーの検出
        //位置、角度の計算結果がmarkersに格納される
        TangoSupport.DetectMarkers(imageBuffer, cameraId, TangoSupport.MarkerType.ARTAG, markerSize, markers);

        //検出されたマーカーだけ繰り返し（最大16個まで）
        for(int i = 0; i < markers.Count; i++)
        {
            TangoSupport.Marker marker = markers[i];

            switch (marker.m_content)
            {
                case "1":
                    //認識時に一度だけPrefabから生成
                    if (!doorCreateFlag)
                    {
                        //下記でマーカーのロケーションに合わせるのでPrefabをそのまま生成
                        Instantiate(doorPrefab);
                        doorCreateFlag = true;
                    }

                    //マーカーの位置と角度をモデルに反映
                    doorPrefab.transform.position = marker.m_translation;
                    doorPrefab.transform.rotation = marker.m_orientation;
                    
                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    doorPrefab.transform.Translate(0, doorHeight * 0.5f, 0, Space.Self);
                    break;

                case "2":
                    //マーカーの位置と角度をモデルに反映
                    dwarfPrefab.transform.position = marker.m_translation;
                    dwarfPrefab.transform.rotation = marker.m_orientation;

                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    dwarfPrefab.transform.Translate(0, dwarfHeight * 0.5f, 0, Space.Self);
                    break;
            }
        }
    }
}
