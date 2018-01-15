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
    GameObject[] flagModel;

    //表示させるモデルの大きさ（メートル単位）
    float flagHeight;
	float height;
    
    /// <summary>
    /// MarkerInfo
    /// </summary>
    //マーカーの大きさ（メートル単位）
    const double markerSize = 0.035;

	// Use this for initialization
	void Start () {
        //Tangoで起きたイベントを受け取れるように登録
        tango = FindObjectOfType<TangoApplication>();
        tango.Register(this);

        markers = new List<TangoSupport.Marker>();
        
        //表示するモデルをスクリプト内で使用できるように
        flagModel = new GameObject[DwarfScript.FLAG_MAX]{
            GameObject.Find("Flag_Blue"),
            GameObject.Find("Flag_Green"),
            GameObject.Find("Flag_LightBlue"),
            GameObject.Find("Flag_Orange"),
            GameObject.Find("Flag_Perple"),
            GameObject.Find("Flag_Pink"),
            GameObject.Find("Flag_Red")
        };

        //モデルの高さを取得（OnTangoImageAvailable...で使用）
        flagHeight = flagModel[0].transform.lossyScale.y;
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

            //switch (marker.m_content)
            //{
            //    case "1":
            //        //マーカーの位置と角度をモデルに反映
            //        flagModel[0].transform.position = marker.m_translation;
            //        flagModel[0].transform.rotation = marker.m_orientation;

            //        //モデルの中心が原点に設定されていることが多いので、ここで調整
            //        flagModel[0].transform.Translate(0, flagHeight * 0.01f, 0, Space.Self);
            //        break;

            //}

            //同時に表示するために1つの分岐にまとめない
            if (marker.m_content == "1") SetFlagLocation(flagModel[0], marker);
            if (marker.m_content == "2") SetFlagLocation(flagModel[1], marker);
            if (marker.m_content == "3") SetFlagLocation(flagModel[2], marker);
            if (marker.m_content == "4") SetFlagLocation(flagModel[3], marker);
            if (marker.m_content == "5") SetFlagLocation(flagModel[4], marker);
            if (marker.m_content == "6") SetFlagLocation(flagModel[5], marker);
            if (marker.m_content == "7") SetFlagLocation(flagModel[6], marker);
        }
    }

    private void SetFlagLocation(GameObject flagModel, TangoSupport.Marker marker)
    {
        //マーカーの位置と角度をモデルに反映
        flagModel.transform.position = marker.m_translation;
        flagModel.transform.rotation = marker.m_orientation;

        //モデルの中心が原点に設定されていることが多いので、ここで調整
        flagModel.transform.Translate(0, flagHeight * 0.005f, 0, Space.Self);
    }
}
