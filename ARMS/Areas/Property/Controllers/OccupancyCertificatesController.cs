﻿using ARMS.Functions;
using ARMS.Models;
using AspNetCore.Reporting;
using CORE_BLL;
using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Reporting;
//using Microsoft.Reporting.NETCore;
//using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class OccupancyCertificatesController : Controller
    {
        private readonly tt_dbContext _context;
        private readonly IMapper _mapper;
        ICommonFunction _CommonRepo = new CommonFunctionBLL();
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        readonly tt_dbContext _ctx = new tt_dbContext();
        readonly IOccupancyCertificate _repository = new OccupancyCertificateBLL();
        private readonly ILogger<OccupancyCertificatesController> _logger;

        public OccupancyCertificatesController(ILogger<OccupancyCertificatesController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _IWebHostEnvironment = webHostEnvironment;
        }
       

        [Route("Property/Index")]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        [Route("Property/OcCertificates")]
        public async Task<IActionResult> OcCertificates()
        {

            return View();
        }



        [Route("Property/OccupancyCertificates/FetchOccupanyCertificate")]
        public List<OccupancyCertificateVM> FetchOccupanyCertificate(string Cid, string Ttin)
        {

            List<OccupancyCertificateVM> _dList = null;
            return _dList = _repository.FetchOccupanyCertificate(Cid, Ttin);
        }


        [Route("Property/OccupancyCertificates/OccupanyCertificate")]
        public async Task<IActionResult> OccupanyCertificate(int OccupancyCertificateApplicationId)
        {
            try
            {
                string mimetype = "";
                int extension = 1;
              
               
                 
                //sp
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    // Create parameter(s)    
                    new SqlParameter { ParameterName = "@OccupancyCertificateApplicationId", Value = OccupancyCertificateApplicationId }
                };
                var resultS = await _ctx.OccupancyCertificate.FromSqlRaw("EXECUTE [dbo].[OccupancyCertificate] @OccupancyCertificateApplicationId", parms.ToArray()).ToListAsync();
                List<OccupancyCertificateVM> data = resultS.Select(s => new OccupancyCertificateVM
                {
                    sl = s.sl,
                    Ttin = s.Ttin,
                    Cid = s.Cid,
                    TaxPayerName = s.TaxPayerName,
                   
                    PlotNo = s.PlotNo,
                    ThramNo = s.ThramNo,
                    LandUseSubCategory = s.LandUseSubCategory,
                    LandAcerage = s.LandAcerage,
                    LandUseCategory = s.LandUseCategory,                   
                    Plr = s.Plr,
                    BuildingNo = s.BuildingNo,
                    ConstructionType = s.ConstructionType,
                    BuildupArea = s.BuildupArea,
                    NumberOfFloors = s.NumberOfFloors,
                    BuildingUnitUseType = s.BuildingUnitUseType,
                    BuildingUnitClassName = s.BuildingUnitClassName,
                    NoOfUnit = s.NoOfUnit,
                    FloorArea = s.FloorArea,
                    YearOfConstruction = s.YearOfConstruction,
                    DateOfFinalInspection = s.DateOfFinalInspection,
                    OcReferenceNo = s.OcReferenceNo,
                    Location = s.Location,
                   OccupancyType = s.OccupancyType,
                   lapName=s.lapName,
                    landOwnershipType = s.landOwnershipType,
                    FloorName = s.FloorName


                }
                     ).ToList();
               var ReportPath = $"{this._IWebHostEnvironment.WebRootPath}\\Reports\\OccupancyCertificate.rdlc";
                Dictionary<string, string> parameter = new Dictionary<string, string>();
                LocalReport lc = new LocalReport(ReportPath);
                lc.AddDataSource("DataSet1", resultS);

                var result = lc.Execute(RenderType.Pdf, extension, parameter, mimetype);

                return File(result.MainStream, "application/pdf");
            }
            catch (Exception ex)
            {
                return null;
            }


        }



        //oc print
        [Route("Property/OccupancyCertificates/FetchLanddetails")]
        public List<OccupancyCertificateVM> FetchLanddetails(int OccupancyCertificateApplicationId)
        {

            List<OccupancyCertificateVM> _dList = null;
            return _dList = _repository.FetchLanddetails(OccupancyCertificateApplicationId);
        }
        [Route("Property/OccupancyCertificates/FetchTaxpayerdetails")]
        public List<OccupancyCertificateVM> FetchTaxpayerdetails(int OccupancyCertificateApplicationId)
        {

            List<OccupancyCertificateVM> _dList = null;
            return _dList = _repository.FetchTaxpayerdetails(OccupancyCertificateApplicationId);
        }
        [Route("Property/OccupancyCertificates/Fetchbuildingdetails")]
        public List<OccupancyCertificateVM> Fetchbuildingdetails(int OccupancyCertificateApplicationId)
        {

            List<OccupancyCertificateVM> _dList = null;
            return _dList = _repository.Fetchbuildingdetails(OccupancyCertificateApplicationId);
        }
        [Route("Property/OccupancyCertificates/FetchUnitdetails")]
        public List<OccupancyCertificateVM> FetchUnitdetails(int OccupancyCertificateApplicationId)
        {

            List<OccupancyCertificateVM> _dList = null;
            return _dList = _repository.FetchUnitdetails(OccupancyCertificateApplicationId);
        }

    }
}

