using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

/// <summary>
/// ボールセンサの情報を受け取る
/// </summary>
public class UdpReceiver : MonoBehaviour
{
	[SerializeField] private int _rcvPort;	// 受信ポート番号

	private UdpClient _client;				// UDPクライアント
	private string _rcvMsg = "";			// 受信データ
	
	private static readonly float[] s_dummyData = new float[14];	// エラー対策
	
	private void OnDisable()
	{
		_client?.Close();
	}
	
	private void Start()
	{
		var endPoint = new IPEndPoint(IPAddress.Any, _rcvPort);
		_client = new UdpClient(endPoint);
		var udpState = new UdpState() { Client = _client, EndPoint = endPoint };
		_client.BeginReceive(ReceiveCallback, udpState);			// 受信開始
	}
	
	private void ReceiveCallback(IAsyncResult ar)
	{
		UdpClient client = ((UdpState)ar.AsyncState).Client;
		IPEndPoint endPoint = ((UdpState)ar.AsyncState).EndPoint;
		
		byte[] rcvBytes = client.EndReceive(ar, ref endPoint);		// 受信終了
		string rcvString = Encoding.ASCII.GetString(rcvBytes);		// byteからstringに変換
		_rcvMsg = rcvString;										// _rcvMsgを更新
		Debug.Log(_rcvMsg);											// コンソールに出力
		
		client.BeginReceive(ReceiveCallback, (UdpState)ar.AsyncState);	//受信再開
	}
	
	private struct UdpState
	{
		public UdpClient Client;
		public IPEndPoint EndPoint;
	}

    public float[] GetData()
    {
        if (_rcvMsg == "") return s_dummyData;	// エラー対策
    
        string[] msgs = _rcvMsg.Split(" ");		// 半角スペースで分割
        float[] vals = new float[msgs.Length];	// 配列の長さはLengthプロパティで取得できる
        for(int i = 0; i < vals.Length; i++)
        {
            vals[i] = float.Parse(msgs[i]);		// float型に変換
        }
        return vals;
    }

}