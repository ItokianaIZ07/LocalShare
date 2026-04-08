using System;
using System.IO;
using System.Text;

namespace LocalShare.Core
{
    public class FileManager
    {
        private string receiveFolder = "ReceivedFiles";

        public FileManager()
        {
            if (!Directory.Exists(receiveFolder))
            {
                Directory.CreateDirectory(receiveFolder);
            }
        }

       
        public (byte[] header, byte[] data) StartSending(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File not found");
            }

            string fileName = Path.GetFileName(filePath);
            byte[] fileData = File.ReadAllBytes(filePath);
            long fileSize = fileData.Length;

            
            string headerStr = $"FILE|{fileName}|{fileSize}";
            byte[] header = Encoding.UTF8.GetBytes(headerStr);

            return (header, fileData);
        }

        public void StartReceiving(string fileName, long fileSize, Stream networkStream)
        {
            string filePath = Path.Combine(receiveFolder, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                long totalBytesRead = 0;

                while (totalBytesRead < fileSize)
                {
                    int bytesToRead = (int)Math.Min(buffer.Length, fileSize - totalBytesRead);
                    int bytesRead = networkStream.Read(buffer, 0, bytesToRead);

                    if (bytesRead == 0)
                    {
                        throw new Exception("Connection lost أثناء réception fichier");
                    }

                    fileStream.Write(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;
                }
            }

            Logger.Log($"File received successfully: {fileName}");
        }
    }
}