using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVC.ApiServices
{
    public class ApplicantApiService
    {
        //this class is an intermediate between MVC ApplicantController and API ApplicantController
        //I had to install Newtonsoft.json nuget package to deserialize responses from the API Controller methods
        //I had to install Microsoft.AspNet.WebApi.Client to be able to send our entities from ApplicantAPIService to the API Controller methods in Post/Put methods



        private readonly HttpClient _httpClient;
        public ApplicantApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Applicant> GetByIdAsync(int id)
        {
            string responseString = await _httpClient.GetStringAsync("Applicant/get/" + id.ToString());
            var entity = JsonConvert.DeserializeObject<Applicant>(responseString);
            return entity;
        }
        public async Task<List<Applicant>> GetAllAsync()
        {
            string responseString = await _httpClient.GetStringAsync("Applicant/get");
            var entities = JsonConvert.DeserializeObject<List<Applicant>>(responseString);
            return entities;
        }
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Applicant/delete/"+id.ToString());
            return response;
        }
        public async Task<HttpResponseMessage> PostAsync(Applicant entity)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Applicant/create/", entity);
            return response;
        }
        public async Task<HttpResponseMessage> PutAsync(int id, Applicant entity)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Applicant/update/"+id.ToString(), entity);
            return response;
        }
    }
}
