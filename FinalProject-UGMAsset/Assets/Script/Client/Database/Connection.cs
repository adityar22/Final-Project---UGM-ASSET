using System;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Connection
{
    public static async Task Main()
    {
        await GetReportFromApi();
    }
    static async Task GetReportFromApi()
    {
        string apiUrl = "https://api.example.com/data"; // Ganti dengan URL API yang sesuai

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Mengambil data dari API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Memastikan permintaan berhasil
                response.EnsureSuccessStatusCode();

                // Membaca respons sebagai string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Mengonversi string JSON menjadi array atau objek C#
                Report[] dataArray = JsonConvert.DeserializeObject<Report[]>(responseBody);

                // Sekarang Anda dapat bekerja dengan dataArray
                foreach (var dataItem in dataArray)
                {
                    Debug.Log($"ID: {dataItem.Id}, Name: {dataItem.Name}");
                    // Sesuaikan properti dan struktur data sesuai kebutuhan Anda
                }
            }
            catch (HttpRequestException e)
            {
                Debug.Log($"Error: {e.Message}");
            }
        }
    }
}