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
    GameObject doorModel;
    GameObject dwarfModel;
    GameObject flagModel;

    //表示させるモデルの大きさ（メートル単位）
    float doorHeight;
    float dwarfHeight;
    float flagHeight;
	float height;

    bool doorCreateFlag = false;

    /// <summary>
    /// MarkerInfo
    /// </summary>
    //マーカーの大きさ（メートル単位）
    const double markerSize = 0.14;

	// Use this for initialization
	void Start () {
        //Tangoで起きたイベントを受け取れるように登録
        tango = FindObjectOfType<TangoApplication>();
        tango.Register(this);

        markers = new List<TangoSupport.Marker>();
        
        //表示するモデルをスクリプト内で使用できるように
        //doorModel = GameObject.Find("Door");
        dwarfModel = GameObject.Find("Dwarf");
        flagModel = GameObject.Find("Flag");

        //モデルの高さを取得（OnTangoImageAvailable...で使用）
        //doorHeight = doorModel.transform.lossyScale.y;
        dwarfHeight = dwarfModel.transform.lossyScale.y;
        flagHeight = flagModel.transform.lossyScale.y;
        
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
                //case "1":
                case "2":
                    //マーカーの位置と角度をモデルに反映
                    /*doorModel.transform.position = marker.m_translation;
                    doorModel.transform.rotation = marker.m_orientation;
                    
                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    doorModel.transform.Translate(0, doorHeight * 0.001f, 0, Space.Self); */
                    break;

                //case "2":
                case "3":
                    //マーカーの位置と角度をモデルに反映
                    dwarfModel.transform.position = marker.m_translation;
                    dwarfModel.transform.rotation = marker.m_orientation;

                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    dwarfModel.transform.Translate(0, dwarfHeight * 0.5f, 0, Space.Self);
                    break;

                //case "3":
                case "1":
                    //マーカーの位置と角度をモデルに反映
                    flagModel.transform.position = marker.m_translation;
                    flagModel.transform.rotation = marker.m_orientation;

                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    flagModel.transform.Translate(0, flagHeight * 0.05f + 0.1f, 0, Space.Self);
                    break;

            }
        }
    }
}
