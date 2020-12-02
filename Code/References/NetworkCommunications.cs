using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class NetworkCommunications
{
    public void SendMessage(string message, string iPA, int port)
    {

    }

    public void ReceiveMessage()
    {

    }

    public void SendFile(string filePath, string iPA, int port)
    {
        const int bufferSize = 1024;
        byte[] sendingBuffer = null;
        TcpClient client = null;
        NetworkStream netStream = null;

        try
        {
            client = new TcpClient(iPA, port);
            netStream = client.GetStream();

            FileStream fS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            int noOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fS.Length) / Convert.ToDouble(bufferSize)));
            int totalLen = (int)fS.Length;
            int currPacketLen;

            for (int i = 0; i < noOfPackets; i++)
            {
                if (totalLen > bufferSize)
                {
                    currPacketLen = bufferSize;
                    totalLen = totalLen - currPacketLen;
                }
                else
                {
                    currPacketLen = totalLen;
                    sendingBuffer = new byte[currPacketLen];

                    fS.Read(sendingBuffer, 0, currPacketLen);
                    netStream.Write(sendingBuffer, 0, (int)sendingBuffer.Length);
                }
            }

            fS.Close();
        }
        catch { }
        finally
        {
            netStream.Close();
            client.Close();
        }
    }

    public void ReceiveFile(string saveLocation, int port)
    {
        const int bufferSize = 1024;
        TcpListener listener = null;

        try
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
        }
        catch { }

        byte[] recData = new byte[bufferSize];
        int recBytes;

        for (; ; )
        {
            TcpClient client = null;
            NetworkStream netStream = null;

            try
            {
                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    netStream = client.GetStream();

                    int totalRecBytes = 0;
                    FileStream fS = new FileStream(saveLocation, FileMode.OpenOrCreate, FileAccess.Write);

                    while ((recBytes = netStream.Read(recData, 0, recData.Length)) > 0)
                    {
                        fS.Write(recData, 0, recBytes);
                        totalRecBytes += recBytes;
                    }

                    fS.Close();
                }

                netStream.Close();
                client.Close();

            }
            catch { }
        }
    }

    public void ConnectToServer(string iPA, int port)
    {

    }

    public void ConnectPlayers(int port)
    {

    }
}
