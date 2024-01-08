using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CORE_BOL.AppConfig   
{

    public class AppConfiguration
    {
        public readonly string _connectionString = string.Empty;
        public readonly string _clientID = string.Empty;
        public readonly string _clientSecret = string.Empty;
        public readonly string _tokenEndPoint = string.Empty; 
        public readonly string _token = string.Empty;
        public readonly string _rcsc_cid_API = string.Empty;
        public readonly string _rcsc_eid_API = string.Empty;        
        public readonly string _citizenAPI = string.Empty;
        public readonly string _citizenImageAPI = string.Empty;
        public readonly string _ESAKOR_Base_URL = string.Empty;
        //public readonly string _contractorAPI = string.Empty;
        //public readonly string _consultantAPI = string.Empty; 
       
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root
            .GetSection("ConnectionStrings")
            .GetSection("ThromdeDbConnection").Value;
            //var appSetting = root.GetSection("ApplicationSettings");

            _token = root.GetSection("DataHubSettings").GetSection("ACCESS_TOKEN").Value;

            _connectionString = root.GetSection("ConnectionString").GetSection("DataConnection").Value;     
            _clientID = root.GetSection("DataHubSettings").GetSection("ClientId").Value;
            _clientSecret = root.GetSection("DataHubSettings").GetSection("ClientSecret").Value;
            _tokenEndPoint = root.GetSection("DataHubSettings").GetSection("TokenUrl").Value;

            _rcsc_cid_API = root.GetSection("DataHubSettings").GetSection("RCSC_CID_API").Value;
            _rcsc_eid_API = root.GetSection("DataHubSettings").GetSection("RCSC_EID_API").Value;
            _citizenAPI = root.GetSection("DataHubSettings").GetSection("CITIZEN_API").Value;
            _citizenImageAPI = root.GetSection("DataHubSettings").GetSection("CITIZEN_IMAGE_API").Value;
            _ESAKOR_Base_URL = root.GetSection("DataHubSettings").GetSection("ESAKOR_Base_URL").Value;
        }
        public string ConnectionString
        {
            get => _connectionString;
        }
        public string Token  
        {
            get => _token; 
        }
        public string ClientID
        {
            get => _clientID;
        }
        public string ClientSecret
        {
            get => _clientSecret;
        }
        public string TokenEndPoint 
        {
            get => _tokenEndPoint;
        }
        public string RCSECidAPI   
        {
            get => _rcsc_cid_API; 
        }
        public string RCSEEidAPI
        {
            get => _rcsc_eid_API;
        }
        public string CitizenAPI 
        {
            get => _citizenAPI;
        }
        public string CitizenImageAPI 
        {
            get => _citizenImageAPI;
        }
        public string ESAKOR_Base_URL
        {
            get => _ESAKOR_Base_URL;
        }

    }
}