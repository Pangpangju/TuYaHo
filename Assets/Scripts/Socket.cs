using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;


public class Socket : MonoBehaviour{
    Thread mThread;
    static List<float> bitcur = new List<float>();
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    static string Name, RSI_Position, MACD_Signal;
    static bool changeTrue = false;
    static float CurrentValue, RSI, MACD, Signal, Depth;
    static int KOR1, KOR2, KOR3, USA1, USA2, USA3;
    bool running;
    int orderCount = 0;
    private void Start(){
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    void GetInfo(){
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();
        client = listener.AcceptTcpClient();
        running = true;
        while (running){
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData(){
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        if (dataReceived != null){
            ListToString(dataReceived);
            if (changeTrue){
                BitControl.addTrends(KOR1,KOR2,KOR3,USA1,USA2,USA3);
                changeTrue = false;
                return;
            }
            if (BitControl.checkfull()){
                if (orderCount > 29) orderCount = 0;
                BitControl.changeNumber(Name, CurrentValue, bitcur[orderCount], RSI, MACD, Signal, Depth, RSI_Position, MACD_Signal);
                bitcur[orderCount] = CurrentValue;
                orderCount++;
            }
            else{
                bitcur.Add(CurrentValue);
                BitControl.addInfo(Name, CurrentValue, RSI, MACD, Signal, Depth, RSI_Position, MACD_Signal);
            }
        }
    }

    public static void ListToString(string list){
        string[] sArray = list.Split(',');
        if (sArray[0] == "trends") {
            KOR1 = int.Parse(sArray[1]);
            KOR2 = int.Parse(sArray[2]);
            KOR3 = int.Parse(sArray[3]);
            USA1 = int.Parse(sArray[5]);
            USA2 = int.Parse(sArray[6]);
            USA3 = int.Parse(sArray[7]);
            changeTrue = true;
            return;
        }
        Name = sArray[0];
        CurrentValue = Mathf.Round(float.Parse(sArray[1])*100)/100;
        RSI = float.Parse(sArray[2]);
        MACD = Mathf.Round(float.Parse(sArray[3]));
        Signal = Mathf.Round(float.Parse(sArray[4]));
        Depth = Mathf.Round(float.Parse(sArray[5])*100)/100;
        RSI_Position = sArray[6];
        MACD_Signal = sArray[7];
    }
}