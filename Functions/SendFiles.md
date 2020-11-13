# Send Files

### Overview

A piece of code that will send a file to the specified location: `iP` & `port`

### Code

[Code File](https://github.com/joesunley/NEA-Project/blob/master/Resources/Code%20Files/Functions/SendFiles.cs)


``` csharp
using System.IO;
using System.Net;
using System.Net.Sockets;

public static void SendFile(string filePath, string iP, int port)
        {
            byte[] sendingBuffer = null;
            TcpClient client = null;
            NetworkStream netStream = null;

            try
            {
                client = new TcpClient(iP, port);
                //Connected to the server
                netStream = client.GetStream();
                FileStream fS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                int noPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fS.Length) / Convert.ToDouble(bufferSize)));
                int tLength = (int)fS.Length;
                int currPacketLen;
                int counter = 0;

                for (int i = 0; i < noPackets; i++)
                {
                    if (tLength > bufferSize)
                    {
                        currPacketLen = bufferSize;
                        tLength = tLength - currPacketLen;
                    }
                    else
                    {
                        currPacketLen = tLength;
                        sendingBuffer = new byte[currPacketLen];
                        fS.Read(sendingBuffer, 0, currPacketLen);
                        netStream.Write(sendingBuffer, 0, (int)sendingBuffer.Length);
                    }

                    fS.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                netStream.Close();
                client.Close();
            }
        }
```

### Testing

#### Tests

#### Screenshots
