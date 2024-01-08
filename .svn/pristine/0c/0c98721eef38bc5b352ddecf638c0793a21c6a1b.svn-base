using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CORE_BOL.Entities;

namespace ARMS.Areas.Property.Controllers
{
    [Area("Property")]
    public class MstBuildingDetailsController : Controller
    {
        private readonly tt_dbContext _context;

        public MstBuildingDetailsController(tt_dbContext context)
        {
            _context = context;
        }

        // GET: Property/MstBuildingDetails
        public async Task<IActionResult> Index()
        {
            var tt_dbContext = _context.MstBuildingDetail.Include(m => m.BoundaryType).Include(m => m.BuildingColour).Include(m => m.ConstructionType).Include(m => m.GarbagServiceAccessibility).Include(m => m.LandDetail).Include(m => m.MaterialType).Include(m => m.ParkingSlot).Include(m => m.RoofingType).Include(m => m.StreetLightAccessibility).Include(m => m.StructureCategory).Include(m => m.StructureType).Include(m => m.WaterSupplyAccessibility).Include(m => m.WaterTankLocation);
            return View(await tt_dbContext.ToListAsync());
        }

        // GET: Property/MstBuildingDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingDetail = await _context.MstBuildingDetail
                .Include(m => m.BoundaryType)
                .Include(m => m.BuildingColour)
                .Include(m => m.ConstructionType)
                .Include(m => m.GarbagServiceAccessibility)
                .Include(m => m.LandDetail)
                .Include(m => m.MaterialType)
                .Include(m => m.ParkingSlot)
                .Include(m => m.RoofingType)
                .Include(m => m.StreetLightAccessibility)
                .Include(m => m.StructureCategory)
                .Include(m => m.StructureType)
                .Include(m => m.WaterSupplyAccessibility)
                .Include(m => m.WaterTankLocation)
                .FirstOrDefaultAsync(m => m.BuildingDetailId == id);
            if (mstBuildingDetail == null)
            {
                return NotFound();
            }

            return View(mstBuildingDetail);
        }

        // GET: Property/MstBuildingDetails/Create
        public IActionResult Create()
        {
            ViewData["BoundaryTypeId"] = new SelectList(_context.MstBoundaryType, "BoundaryTypeId", "BoundaryType");
            ViewData["BuildingColourId"] = new SelectList(_context.MstBuildingColour, "BuildingColourId", "BuildingColourType");
            ViewData["ConstructionTypeId"] = new SelectList(_context.MstConstructionType, "ConstructionTypeId", "ConstructionType");
            ViewData["GarbagServiceAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType");
            ViewData["LandDetailId"] = new SelectList(_context.MstLandDetail, "LandDetailId", "PlotAddress");
            ViewData["MaterialTypeId"] = new SelectList(_context.MstMaterialType, "MaterialTypeId", "MaterialType");
            ViewData["ParkingSlotId"] = new SelectList(_context.MstParkingSlot, "ParkingSlotId", "ParkingSlotName");
            ViewData["RoofingTypeId"] = new SelectList(_context.MstRoofingType, "RoofingTypeId", "RoofingType");
            ViewData["StreetLightAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType");
            ViewData["StructureCategoryId"] = new SelectList(_context.MstStructureCategory, "StructureCategoryId", "StructureCategory");
            ViewData["StructureTypeId"] = new SelectList(_context.MstStructureType, "StructureTypeId", "StructureType");
            ViewData["WaterSupplyAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType");
            ViewData["WaterTankLocationId"] = new SelectList(_context.EnumWaterTankLocation, "WaterTankLocationId", "WaterTankLocation");
            return View();
        }

        // POST: Property/MstBuildingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingDetailId,LandDetailId,BuildingClassId,BuildingNo,BuildupArea,PlinthArea,NoOfUnits,NumberOfFloors,GarbagServiceAccessibilityId,StreetLightAccessibilityId,OccupancyCertificateNo,ConstructionTypeId,YearOfConstruction,OccupancyCertificateIssued,OccupancyCertificateIssueDate,PaymentCompletionStatusId,WaterConnection,SewerageConnection,Attic,StructureCategoryId,StructureTypeId,MaterialTypeId,ArchFeature,Roofing,RoofingTypeId,TraditionalPainting,BuildingColourId,BoundaryTypeId,Plantation,WaterTankLocationId,NumberDisplayed,ParkingSlotId,FireExtingusher,WaterSupplyAccessibilityId,RoadAccess,DrainToStormWaterDrain,DateOfFinalInspection,OccupancyAlteredOn,OccupancyAlteredBy,OccupancyReferenceId,AdvanceInfoFedBy,AdvanceInfoInfoFedOn,Remarks,ModificationRemarks,ModificationReasonId,TransactionId,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] MstBuildingDetail mstBuildingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstBuildingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoundaryTypeId"] = new SelectList(_context.MstBoundaryType, "BoundaryTypeId", "BoundaryType", mstBuildingDetail.BoundaryTypeId);
            ViewData["BuildingColourId"] = new SelectList(_context.MstBuildingColour, "BuildingColourId", "BuildingColourType", mstBuildingDetail.BuildingColourId);
            ViewData["ConstructionTypeId"] = new SelectList(_context.MstConstructionType, "ConstructionTypeId", "ConstructionType", mstBuildingDetail.ConstructionTypeId);
            ViewData["GarbagServiceAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.GarbagServiceAccessibilityId);
            ViewData["LandDetailId"] = new SelectList(_context.MstLandDetail, "LandDetailId", "PlotAddress", mstBuildingDetail.LandDetailId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MstMaterialType, "MaterialTypeId", "MaterialType", mstBuildingDetail.MaterialTypeId);
            ViewData["ParkingSlotId"] = new SelectList(_context.MstParkingSlot, "ParkingSlotId", "ParkingSlotName", mstBuildingDetail.ParkingSlotId);
            ViewData["RoofingTypeId"] = new SelectList(_context.MstRoofingType, "RoofingTypeId", "RoofingType", mstBuildingDetail.RoofingTypeId);
            ViewData["StreetLightAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.StreetLightAccessibilityId);
            ViewData["StructureCategoryId"] = new SelectList(_context.MstStructureCategory, "StructureCategoryId", "StructureCategory", mstBuildingDetail.StructureCategoryId);
            ViewData["StructureTypeId"] = new SelectList(_context.MstStructureType, "StructureTypeId", "StructureType", mstBuildingDetail.StructureTypeId);
            ViewData["WaterSupplyAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.WaterSupplyAccessibilityId);
            ViewData["WaterTankLocationId"] = new SelectList(_context.EnumWaterTankLocation, "WaterTankLocationId", "WaterTankLocation", mstBuildingDetail.WaterTankLocationId);
            return View(mstBuildingDetail);
        }

        // GET: Property/MstBuildingDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingDetail = await _context.MstBuildingDetail.FindAsync(id);
            if (mstBuildingDetail == null)
            {
                return NotFound();
            }
            ViewData["BoundaryTypeId"] = new SelectList(_context.MstBoundaryType, "BoundaryTypeId", "BoundaryType", mstBuildingDetail.BoundaryTypeId);
            ViewData["BuildingColourId"] = new SelectList(_context.MstBuildingColour, "BuildingColourId", "BuildingColourType", mstBuildingDetail.BuildingColourId);
            ViewData["ConstructionTypeId"] = new SelectList(_context.MstConstructionType, "ConstructionTypeId", "ConstructionType", mstBuildingDetail.ConstructionTypeId);
            ViewData["GarbagServiceAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.GarbagServiceAccessibilityId);
            ViewData["LandDetailId"] = new SelectList(_context.MstLandDetail, "LandDetailId", "PlotAddress", mstBuildingDetail.LandDetailId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MstMaterialType, "MaterialTypeId", "MaterialType", mstBuildingDetail.MaterialTypeId);
            ViewData["ParkingSlotId"] = new SelectList(_context.MstParkingSlot, "ParkingSlotId", "ParkingSlotName", mstBuildingDetail.ParkingSlotId);
            ViewData["RoofingTypeId"] = new SelectList(_context.MstRoofingType, "RoofingTypeId", "RoofingType", mstBuildingDetail.RoofingTypeId);
            ViewData["StreetLightAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.StreetLightAccessibilityId);
            ViewData["StructureCategoryId"] = new SelectList(_context.MstStructureCategory, "StructureCategoryId", "StructureCategory", mstBuildingDetail.StructureCategoryId);
            ViewData["StructureTypeId"] = new SelectList(_context.MstStructureType, "StructureTypeId", "StructureType", mstBuildingDetail.StructureTypeId);
            ViewData["WaterSupplyAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.WaterSupplyAccessibilityId);
            ViewData["WaterTankLocationId"] = new SelectList(_context.EnumWaterTankLocation, "WaterTankLocationId", "WaterTankLocation", mstBuildingDetail.WaterTankLocationId);
            return View(mstBuildingDetail);
        }

        // POST: Property/MstBuildingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingDetailId,LandDetailId,BuildingClassId,BuildingNo,BuildupArea,PlinthArea,NoOfUnits,NumberOfFloors,GarbagServiceAccessibilityId,StreetLightAccessibilityId,OccupancyCertificateNo,ConstructionTypeId,YearOfConstruction,OccupancyCertificateIssued,OccupancyCertificateIssueDate,PaymentCompletionStatusId,WaterConnection,SewerageConnection,Attic,StructureCategoryId,StructureTypeId,MaterialTypeId,ArchFeature,Roofing,RoofingTypeId,TraditionalPainting,BuildingColourId,BoundaryTypeId,Plantation,WaterTankLocationId,NumberDisplayed,ParkingSlotId,FireExtingusher,WaterSupplyAccessibilityId,RoadAccess,DrainToStormWaterDrain,DateOfFinalInspection,OccupancyAlteredOn,OccupancyAlteredBy,OccupancyReferenceId,AdvanceInfoFedBy,AdvanceInfoInfoFedOn,Remarks,ModificationRemarks,ModificationReasonId,TransactionId,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] MstBuildingDetail mstBuildingDetail)
        {
            if (id != mstBuildingDetail.BuildingDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstBuildingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstBuildingDetailExists(mstBuildingDetail.BuildingDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoundaryTypeId"] = new SelectList(_context.MstBoundaryType, "BoundaryTypeId", "BoundaryType", mstBuildingDetail.BoundaryTypeId);
            ViewData["BuildingColourId"] = new SelectList(_context.MstBuildingColour, "BuildingColourId", "BuildingColourType", mstBuildingDetail.BuildingColourId);
            ViewData["ConstructionTypeId"] = new SelectList(_context.MstConstructionType, "ConstructionTypeId", "ConstructionType", mstBuildingDetail.ConstructionTypeId);
            ViewData["GarbagServiceAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.GarbagServiceAccessibilityId);
            ViewData["LandDetailId"] = new SelectList(_context.MstLandDetail, "LandDetailId", "PlotAddress", mstBuildingDetail.LandDetailId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MstMaterialType, "MaterialTypeId", "MaterialType", mstBuildingDetail.MaterialTypeId);
            ViewData["ParkingSlotId"] = new SelectList(_context.MstParkingSlot, "ParkingSlotId", "ParkingSlotName", mstBuildingDetail.ParkingSlotId);
            ViewData["RoofingTypeId"] = new SelectList(_context.MstRoofingType, "RoofingTypeId", "RoofingType", mstBuildingDetail.RoofingTypeId);
            ViewData["StreetLightAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.StreetLightAccessibilityId);
            ViewData["StructureCategoryId"] = new SelectList(_context.MstStructureCategory, "StructureCategoryId", "StructureCategory", mstBuildingDetail.StructureCategoryId);
            ViewData["StructureTypeId"] = new SelectList(_context.MstStructureType, "StructureTypeId", "StructureType", mstBuildingDetail.StructureTypeId);
            ViewData["WaterSupplyAccessibilityId"] = new SelectList(_context.EnumServiceAccessibilityType, "ServiceAccessibilityId", "ServiceAccessibilityType", mstBuildingDetail.WaterSupplyAccessibilityId);
            ViewData["WaterTankLocationId"] = new SelectList(_context.EnumWaterTankLocation, "WaterTankLocationId", "WaterTankLocation", mstBuildingDetail.WaterTankLocationId);
            return View(mstBuildingDetail);
        }

        // GET: Property/MstBuildingDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstBuildingDetail = await _context.MstBuildingDetail
                .Include(m => m.BoundaryType)
                .Include(m => m.BuildingColour)
                .Include(m => m.ConstructionType)
                .Include(m => m.GarbagServiceAccessibility)
                .Include(m => m.LandDetail)
                .Include(m => m.MaterialType)
                .Include(m => m.ParkingSlot)
                .Include(m => m.RoofingType)
                .Include(m => m.StreetLightAccessibility)
                .Include(m => m.StructureCategory)
                .Include(m => m.StructureType)
                .Include(m => m.WaterSupplyAccessibility)
                .Include(m => m.WaterTankLocation)
                .FirstOrDefaultAsync(m => m.BuildingDetailId == id);
            if (mstBuildingDetail == null)
            {
                return NotFound();
            }

            return View(mstBuildingDetail);
        }

        // POST: Property/MstBuildingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstBuildingDetail = await _context.MstBuildingDetail.FindAsync(id);
            _context.MstBuildingDetail.Remove(mstBuildingDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstBuildingDetailExists(int id)
        {
            return _context.MstBuildingDetail.Any(e => e.BuildingDetailId == id);
        }
    }
}
