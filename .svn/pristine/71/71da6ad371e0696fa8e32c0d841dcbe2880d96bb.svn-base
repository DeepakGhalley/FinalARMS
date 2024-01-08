using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;
using AutoMapper;
using CORE_DLL;
using CORE_BLL;
using CORE_BOL;
using Microsoft.AspNetCore.Http;
using ARMS.Functions;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class DashboardsController : Controller
    { 
    private readonly tt_dbContext _context;

    private readonly IMapper _mapper;
    ICommonFunction _CommonRepo = new CommonFunctionBLL();
    private readonly ITokenService tokenService;

    string _G2CAPIBaseUrl = "";
    ILogger _logger;
    IConfiguration _Configure;
    readonly ILandDetail _repository = new LandDetailBLL();
    readonly ILandDetail _repo = new LandDetailBLL();
    public DashboardsController(tt_dbContext context, IMapper mapper, ILogger<DashboardsController> logger, IConfiguration configuration, ITokenService tokenService)
    {
        _context = context; _mapper = mapper;
        _logger = logger;

        _Configure = configuration;
        _G2CAPIBaseUrl = _Configure.GetValue<string>("G2CAPIBaseUrl");

    }
    
        [Route("Property/Dashboards")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Property/Dashboards/G2Services")]
        public async Task<IActionResult> G2Services()
        {
            return View();
        }

        [Route("Property/Dashboards/G2CApplicantDetail")]
        [HttpGet]
        public async Task<IActionResult> G2CApplicantDetail(string applicationNo)//G2CApplicantModel obj
        {

            G2CApplicantModel ApplicantList = new G2CApplicantModel();
         
            string gnhc_token;
            gnhc_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJTdWJqZWN0IEhlcmUiLCJqdGkiOiJqdGkiLCJpYXQiOjE2MTY3NTAwMjUsImlkIjoiMSIsImFjY2Vzc19yb2xlIjoiQWRtaW4iLCJleHAiOjE2MTY3NTcyMjUsImlzcyI6ImV4YW1wbGUuY29tIiwiYXVkIjoiZXhhbXBsZS5jb20ifQ.fspHJ51ZDObblRKD6RDA8eg2U7Cxo5TkRbV7PJ0U5e0";
            HttpResponseMessage res;
            HttpClient client = new HttpClient();
            
            res = await client.GetAsync("http://103.80.110.239:3306/api/g2cservice/GeNewWaterConnectionByApplicationNo?_id=WS/504/2019/9/Baybina/001");
            if (res.IsSuccessStatusCode)
            {
                string apiResponse = await res.Content.ReadAsStringAsync();
                try
                {
                    ApplicantList = JsonConvert.DeserializeObject<G2CApplicantModel>(apiResponse);
                    ViewBag.ApplicantList = ApplicantList;
                }
                catch (Exception ex) { }
            }
            else if (res.StatusCode.ToString() == "500")
            {
                return View();
                //server not found
            }
            else if (res.StatusCode.ToString() == "404")
            {
                return View();

                //authenticationfailed
            }


            //else
            //{
            //    return View(obj);
            //}



            //var s1List = await _repo.getSection1IDByApaID(obj.Apa_id);
            //if (s1List.Count > 0)
            //{
            //    obj.PreambleSection1Id = s1List.FirstOrDefault().PreambleSection1Id;
            //    obj.Mission = s1List.FirstOrDefault().Mission;
            //    obj.Vision = s1List.FirstOrDefault().Vision;
            //    //obj.objective= s1List.FirstOrDefault().ApaObjective;
            //}
            return View();

        }
    }

}