using CORE_DLL;
using System.Net.Http;

namespace CORE_BLL
{
    public class APIServiceBLL: IAPIService
    {
        private HttpClient myclient = new HttpClient();
        //for getvalues only
        //private readonly ITokenService tokenService;
        //public APIServiceBLL(ITokenService tokenService)
        //{
        //    this.tokenService = tokenService;
        //}
       
        //public async Task<IList<CitizenDetail>> GetCitizenByCID(string cid)
        //{
        //    List<CitizenDetail> citizenList = new List<CitizenDetail>();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            //AppConfiguration con = new AppConfiguration();
        //            //string api = con.CitizenAPI;
        //            var token1 = await tokenService.GetToken();
        //            var token = "a640386b-eea3-39b0-b6ce-42bf1b25d233";//
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.ToString());
        //            var res = await client.GetAsync(api + "/citizendetails/" + cid);
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var json = res.Content.ReadAsStringAsync().Result;
        //                dynamic json_result = JsonConvert.DeserializeObject(json);
        //                if (json_result = true)
        //                {
        //                    if (JObject.Parse(json)["citizenDetailsResponse"].ToString() == "{}")
        //                    {
        //                        //citizenList.Add(new CitizenDetail
        //                        //{
        //                        //    apistatus = "NoData"
        //                        //}) ;

        //                    }
        //                    else
        //                    {
        //                        //List<citizenDetail> ds1 =List<citizenDetail> JObject.Parse(json)["citizenDetailsResponse"];

        //                        //List<citizenDetail> myClassWithCollection = JsonConvert.DeserializeObject<List<citizenDetail>>(json.ToString());
        //                        //var result = JsonConvert.DeserializeObject<citizenDetail>(json);
        //                        DataSet ds = JObject.Parse(json)["citizenDetailsResponse"].ToObject<DataSet>();
        //                        //DataTable dt = ds.Tables[0];
        //                        // Employee should contain  EmployeeId, EmployeeName as properties
        //                        foreach (DataRow dr in ds.Tables[0].Rows)
        //                        {
        //                            citizenList.Add(new CitizenDetail
        //                            {
        //                                cid = Convert.ToString(dr["cid"]),
        //                                country = Convert.ToString(dr["country"]),
        //                                dob = Convert.ToString(dr["dob"]),
        //                                fatherName = Convert.ToString(dr["fatherName"]),
        //                                firstIssuedDate = Convert.ToString(dr["firstIssuedDate"]),
        //                                firstName = Convert.ToString(dr["firstname"]),
        //                                gender = Convert.ToString(dr["gender"]),
        //                                householdNo = Convert.ToString(dr["householdNo"]),
        //                                lastName = Convert.ToString(dr["lastName"]),
        //                                middleName = Convert.ToString(dr["middleName"]),
        //                                mobileNumber = Convert.ToString(dr["mobileNumber"]),
        //                                motherName = Convert.ToString(dr["motherName"]),
        //                                occupation = Convert.ToString(dr["occupation"]),
        //                                dzongkhagId = Convert.ToString(dr["dzongkhagId"]),
        //                                dzongkhagName = Convert.ToString(dr["dzongkhagName"]),
        //                                gewogId = Convert.ToString(dr["gewogId"]),
        //                                gewogName = Convert.ToString(dr["gewogName"]),
        //                                houseNo = Convert.ToString(dr["houseNo"]),
        //                                thramNo = Convert.ToString(dr["thramNo"]),
        //                                villageSerialNo = Convert.ToString(dr["villageSerialNo"]),
        //                                villageName = Convert.ToString(dr["villageName"]),
        //                                placeOfBirth = Convert.ToString(dr["placeOfBirth"]),
        //                                firstDzoName = Convert.ToString(dr["firstDzoName"]),
        //                                middleDzoName = Convert.ToString(dr["middleDzoName"]),
        //                                lastDzoName = Convert.ToString(dr["lastDzoName"]),
        //                                religion = Convert.ToString(dr["religion"]),
        //                                qualification = Convert.ToString(dr["qualification"]),
        //                                //firstDzoName = Convert.ToString(dr["firstDzoName"]) == "" ? "No Data" : "success"

        //                            });
        //                            //return citizenList;

        //                        }
        //                    }
        //                }
        //            }
        //            //else
        //            //{
        //            //    citizenList.Add(new CitizenDetailsByCID
        //            //    {
        //            //        apistatus = "fail"
        //            //    });
        //            //}
        //        }
        //        return citizenList;

        //    }
        //    catch (Exception ex)
        //    {
        //        return citizenList;

        //    }
        //}
        //public async Task<IList<LandTransactionDetail>> GetPreTransactionByTransactionID(string TransactionID)
        //{
        //    List<LandTransactionDetail> LandTransactionList = new List<LandTransactionDetail>();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            //AppConfiguration con = new AppConfiguration();
        //            //string ESAKOR_Base_URL = con.ESAKOR_Base_URL;
        //            var token1 = await tokenService.GetToken();
        //            var token = "812c2d79-36f4-3610-937c-6363d8e18b2d";//
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.ToString());
        //            var res = await client.GetAsync(ESAKOR_Base_URL + "/transactiondetails/" + TransactionID);
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var json = res.Content.ReadAsStringAsync().Result;
        //                dynamic json_result = JsonConvert.DeserializeObject(json);
        //                if (json_result = true)
        //                {
        //                    if (JObject.Parse(json)["transactions"].ToString() == "{}")
        //                    {
        //                        //citizenList.Add(new CitizenDetail
        //                        //{
        //                        //    apistatus = "NoData"
        //                        //}) ;

        //                    }
        //                    else
        //                    {
        //                        //List<citizenDetail> ds1 =List<citizenDetail> JObject.Parse(json)["citizenDetailsResponse"];

        //                        //List<citizenDetail> myClassWithCollection = JsonConvert.DeserializeObject<List<citizenDetail>>(json.ToString());
        //                        //var result = JsonConvert.DeserializeObject<citizenDetail>(json);
        //                        DataSet ds = JObject.Parse(json)["transactions"].ToObject<DataSet>();
        //                        //DataTable dt = ds.Tables[0];
        //                        // Employee should contain  EmployeeId, EmployeeName as properties
        //                        foreach (DataRow dr in ds.Tables[0].Rows)
        //                        {
        //                            LandTransactionList.Add(new LandTransactionDetail
        //                            {
        //                                thromde = Convert.ToString(dr["thromde"]),
        //                                thromdeVillage = Convert.ToString(dr["thromdeVillage"]),
        //                                transactionType = Convert.ToString(dr["transactionType"]),
        //                                party = Convert.ToString(dr["party"]),
        //                                thram = Convert.ToString(dr["thram"]),
        //                                ownershipType = Convert.ToString(dr["ownershipType"]),
        //                                ownerCID = Convert.ToString(dr["ownerCID"]),
        //                                ownerName = Convert.ToString(dr["ownerName"]),
        //                                plotID = Convert.ToString(dr["plotID"]),
        //                                plotArea = Convert.ToString(dr["plotArea"]),
        //                                transactionArea = Convert.ToString(dr["transactionArea"]),
        //                                landValue = Convert.ToString(dr["landValue"]),
        //                                buildingValue = Convert.ToString(dr["buildingValue"]),
        //                                subdivisionFee = Convert.ToString(dr["subdivisionFee"]),
        //                                demarcationFee = Convert.ToString(dr["demarcationFee"]),
        //                                lagthramFee = Convert.ToString(dr["lagthramFee"]),
        //                                totalPayable = Convert.ToString(dr["totalPayable"]),


        //                            });
        //                            //return citizenList;

        //                        }
        //                    }
        //                }
        //            }
        //            //else
        //            //{
        //            //    citizenList.Add(new CitizenDetailsByCID
        //            //    {
        //            //        apistatus = "fail"
        //            //    });
        //            //}
        //        }
        //        return LandTransactionList;

        //    }
        //    catch (Exception ex)
        //    {
        //        return LandTransactionList;

        //    }
        //}

        //public async Task<IList<ApiTransactionPostApproval>> GetPostTransactionByTransactionID(string TransactionID)
        //{
        //    List<ApiTransactionPostApproval> LandTransactionList = new List<ApiTransactionPostApproval>();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            //    AppConfiguration con = new AppConfiguration();
        //            //    string ESAKOR_Base_URL = con.ESAKOR_Base_URL;
        //            var token1 = await tokenService.GetToken();
        //            var token = "812c2d79-36f4-3610-937c-6363d8e18b2d";//
        //            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.ToString());
        //            var res = await client.GetAsync(ESAKOR_Base_URL + "/postapprovaltransaction/" + TransactionID);
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var json = res.Content.ReadAsStringAsync().Result;
        //                dynamic json_result = JsonConvert.DeserializeObject(json);
        //                if (json_result = true)
        //                {
        //                    if (JObject.Parse(json)["postapprovals"].ToString() == "{}")
        //                    {
        //                        //citizenList.Add(new CitizenDetail
        //                        //{
        //                        //    apistatus = "NoData"
        //                        //}) ;

        //                    }
        //                    else
        //                    {
        //                        //List<citizenDetail> ds1 =List<citizenDetail> JObject.Parse(json)["citizenDetailsResponse"];

        //                        //List<citizenDetail> myClassWithCollection = JsonConvert.DeserializeObject<List<citizenDetail>>(json.ToString());
        //                        //var result = JsonConvert.DeserializeObject<citizenDetail>(json);
        //                        DataSet ds = JObject.Parse(json)["postapprovals"].ToObject<DataSet>();
        //                        //DataTable dt = ds.Tables[0];
        //                        // Employee should contain  EmployeeId, EmployeeName as properties
        //                        foreach (DataRow dr in ds.Tables[0].Rows)
        //                        {
        //                            LandTransactionList.Add(new ApiTransactionPostApproval
        //                            {
        //                                thromde = Convert.ToString(dr["thromde"]),
        //                                thromdeVillage = Convert.ToString(dr["thromdeVillage"]),
        //                                transactionType = Convert.ToString(dr["transactionType"]),
        //                                party = Convert.ToString(dr["party"]),
        //                                thram = Convert.ToString(dr["thram"]),
        //                                ownershipType = Convert.ToString(dr["ownershipType"]),
        //                                ownerCID = Convert.ToString(dr["ownerCID"]),
        //                                ownerName = Convert.ToString(dr["ownerName"]),
        //                                plotID = Convert.ToString(dr["plotID"]),
        //                                area = Convert.ToString(dr["area"]),
        //                                //transactionArea = Convert.ToString(dr["transactionArea"]),
        //                                landValue = Convert.ToString(dr["landValue"]),
        //                                buildingValue = Convert.ToString(dr["buildingValue"]),
        //                                subdivisionFee = Convert.ToString(dr["subdivisionFee"]),
        //                                demarcationFee = Convert.ToString(dr["demarcationFee"]),
        //                                lagthramFee = Convert.ToString(dr["lagthramFee"]),
        //                                totalPayable = Convert.ToString(dr["totalPayable"]),


        //                            });
        //                            //return citizenList;

        //                        }
        //                    }
        //                }
        //            }
        //            //else
        //            //{
        //            //    citizenList.Add(new CitizenDetailsByCID
        //            //    {
        //            //        apistatus = "fail"
        //            //    });
        //            //}
        //        }
        //        return LandTransactionList;

        //    }
        //    catch (Exception ex)
        //    {
        //        return LandTransactionList;

        //    }
        //}

    }
}
