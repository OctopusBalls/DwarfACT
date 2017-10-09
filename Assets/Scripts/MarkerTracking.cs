﻿using System.Collections;
using System.Collections.Generic;
using Tango;
using UnityEngine;

public class MarkerTracking : MonoBehaviour, ITangoVideoOverlay {

    //マーカーの格納先
    List<TangoSupport.Marker> markers;

    //Tangoの各種情報を取り扱う
    TangoApplication tango;

    //表示させるモデル
    GameObject doorModel;
    GameObject dwarfModel;

    //表示させるモデルの大きさ（メートル単位）
    float doorHeight;
    float dwarfHeight;

    //マーカーの大きさ（メートル単位）
    double markerSize = 0.1;

	// Use this for initialization
	void Start () {
        //Tangoで起きたイベントを受け取れるように登録
        tango = FindObjectOfType<TangoApplication>();
        tango.Register(this);

        markers = new List<TangoSupport.Marker>();

        //表示するモデルをスクリプト内で使用できるように
        doorModel = GameObject.Find("Door");
        dwarfModel = GameObject.Find("Dwarf");

        //モデルの高さを取得（OnTangoImageAvailable...で使用）
        doorHeight = doorModel.transform.lossyScale.y;
        dwarfHeight = dwarfModel.transform.lossyScale.y;
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
                    //マーカーの位置と角度をモデルに反映
                    doorModel.transform.position = marker.m_translation;
                    doorModel.transform.rotation = marker.m_orientation;
                    
                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    doorModel.transform.Translate(0, doorHeight * 0.5f, 0, Space.Self);
                    break;

                case "2":
                    //マーカーの位置と角度をモデルに反映
                    dwarfModel.transform.position = marker.m_translation;
                    dwarfModel.transform.rotation = marker.m_orientation;

                    //モデルの中心が原点に設定されていることが多いので、ここで調整
                    dwarfModel.transform.Translate(0, dwarfHeight * 0.5f, 0, Space.Self);
                    break;
            }
        }
    }
}
