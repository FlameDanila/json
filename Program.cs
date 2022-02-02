using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {
            q:
            int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    {
                        Console.WriteLine("asd");
                        var request = WebRequest.Create("http://localhost:5000/api/analyzer/Ledetect");

                        request.Method = "POST";

                        string data = "{ \"patient\": \"3\", \"services\": [{ \"serviceCode\":543}]}"; // "{ “patient”: “{ id}”, “services”: [{ “serviceCode”: 000 }, { “serviceCode”: 000} }";

                        byte[] byteArray = Encoding.UTF8.GetBytes(data);

                        request.Method = "POST";

                        request.ContentType = "application/json";

                        request.ContentLength = byteArray.Length;

                        using (Stream dataStream = request.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                        }

                        WebResponse response = request.GetResponse();

                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                Console.WriteLine(reader.ReadToEnd());
                            }
                        }
                        response.Close();
                        goto q;
                    }
                case 2:
                    {
                        var request = WebRequest.Create("http://localhost:5000/api/analyzer/Ledetect");

                        request.Method = "GET";

                        WebResponse response = request.GetResponse();

                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                Console.WriteLine(reader.ReadToEnd());
                            }
                        }
                        response.Close();
                        goto q;
                    }
            }
        }
    }
}
