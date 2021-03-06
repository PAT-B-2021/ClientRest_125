using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace ClientRest_125_Ridwan
{
    [DataContract]
    public class Mahasiswa
    {
        private string _nama, _nim, _prodi, _angkatan;
        [DataMember]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }
        [DataMember]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            ClassData cl = new ClassData();
            cl.getData();
            Program app = new Program();
            app.BuatMahasiswa();
            Console.ReadLine();
        }
        string baseUrl = "http://localhost:1907/";
        void BuatMahasiswa()
        {
            Mahasiswa mhs = new Mahasiswa();
            Console.Write("Masukkan Nama : ");
            mhs.nama = Console.ReadLine();
            Console.Write("Masukkan NIM : ");
            mhs.nim = Console.ReadLine();
            Console.Write("Masukkan Prodi : ");
            mhs.prodi = Console.ReadLine();
            Console.Write("Masukkan Angkatan : ");
            mhs.angkatan = Console.ReadLine();

            var data = JsonConvert.SerializeObject(mhs);
            var postdata = new WebClient();
            postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postdata.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);
        }
    }
    class ClassData
    {
        public void getData()
        {
            //var type data yang tidak peduli pada bentuk, tapi isinya
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            /* for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(data[i].nama);
                Console.WriteLine(data[i].nim);
                Console.WriteLine(data[i].prodi);
                Console.WriteLine(data[i].angkatan);
            } */

            foreach (var mhs in data)
            {
                Console.WriteLine("Nama: " + mhs.nama);
                Console.WriteLine("NIM: " + mhs.nim);
                Console.WriteLine("Prodi: " + mhs.prodi);
                Console.WriteLine("Angkatan: " + mhs.angkatan);
            }
            Console.ReadLine();
        }
    }
}

