using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientRest_045_RafidFahar
{
    class ClassData
    {
        string baseUrl = "http://localhost:1412/";

        public void insertMahasiswa(string nim, string nama, string prodi, string angkatan)
        {
            Mahasiswa mhs = new Mahasiswa();
            
            mhs.nim = nim;
            mhs.nama = nama;
            mhs.prodi = prodi;
            mhs.angkatan = angkatan;

            var data = JsonConvert.SerializeObject(mhs); //Convert to Json
            var postData = new WebClient();
            postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postData.UploadString(baseUrl + "CreateMahasiswa", data);
        }

        public Mahasiswa search(string nim)
        {
            Mahasiswa data = new Mahasiswa();
            try
            {
                var json = new WebClient().DownloadString("http://localhost:1999/Mahasiswa/" + nim);
                data = JsonConvert.DeserializeObject<Mahasiswa>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
            return data;
        }

        public string Jumlahdata()
        {
            var json = new WebClient().DownloadString("http://localhost:1412/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            int i = data.Count();
            string sum = i.ToString();
            return sum;
        }

        public List<Mahasiswa> getAllData()
        {
            var json = new WebClient().DownloadString("http://localhost:1412/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            return data;
        }

        public bool updateDatabase(Mahasiswa mhs)
        {
            bool updated = false;
            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest("UpdateMahasiswaByNIM", Method.PUT);
                request.AddJsonBody(mhs);
                client.Execute(request);
            }
            catch (Exception ex)
            {

            }
            return updated;
        }

        public bool deleteMahasiswa(string nim)
        {
            bool deleted = false;
            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest("DeleteMahasiswa/" + nim, Method.DELETE);
                client.Execute(request);
            }
            catch (Exception ex)
            {

            }
            return deleted;
        }
    }
}
