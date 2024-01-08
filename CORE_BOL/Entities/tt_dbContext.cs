﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CORE_BOL.Entities
{
    public partial class tt_dbContext : DbContext
    {
        public tt_dbContext()
        {
        }

        public tt_dbContext(DbContextOptions<tt_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RevenueIOVM> RevenuetransferRC { get; set; }


        public virtual DbSet<RevenueIOVM> RevenueOnline { get; set; }
        public virtual DbSet<RevenueIOVM> Revenuetransfer { get; set; }
        public virtual DbSet<RevenueIOVM> RevenueMannual { get; set; }
        public virtual DbSet<RevenueIOVM> Revenueopeningbalance { get; set; }
        public virtual DbSet<spTaxCalculationAPIModel> TaxCalculationAPI { get; set; }
        public virtual DbSet<DemandYearsModel> DemandYearsModel { get; set; }
        public virtual DbSet<ARevenueVM> Revenue { get; set; }
        public virtual DbSet<AwaterVM> water { get; set; }
        public virtual DbSet<AwaterHeadwiseVM> Waterheadwise { get; set; }
        public virtual DbSet<AwaterReceiptwiseVM> WaterRecepitwise { get; set; }
        public virtual DbSet<wisedetailVM> detailwise { get; set; }
        public virtual DbSet<ModeWiseCollectionVM> ModeWisecollect { get; set; }
        public virtual DbSet<ApropertyVM> property { get; set; }
        public virtual DbSet<ApropertyheadwiseVM> Propertyheadwise { get; set; }
        public virtual DbSet<ApropertyrecepitwiseVM> PropertyRecepitwise { get; set; }
        public virtual DbSet<wiseCollectionVM> wiseCollection { get; set; }
        public virtual DbSet<wiseCollectionVM> IndividualwiseCollection { get; set; }
        public virtual DbSet<wiseCollectedVM> IndividualCollectionReport { get; set; }
        public virtual DbSet<SavewiseCollectionVM> SaveIndividualwiseCollection { get; set; }
        public virtual DbSet<PrecinctWiseCountReportVM> PrecinctWiseCountReport { get; set; }
        public virtual DbSet<AssetManagementVM> AssetManagement { get; set; }
        public virtual DbSet<PaymentModeWiseReport> PaymentModeWiseReport { get; set; }
        public virtual DbSet<ConnectionTypeWiseRevenue> ConnectionTypeWiseRevenue { get; set; }
        public virtual DbSet<ConnectionTypeWiseConsumption> ConnectionTypeWiseConsumption { get; set; }
        public virtual DbSet<ZoneWiseWaterConsumptionFromToDate> ZoneWiseWaterConsumptionFromToDate { get; set; }
        public virtual DbSet<OnlinePaymentReconciliationsReport> OnlinePaymentReconciliationsReport { get; set; }
        public virtual DbSet<NoOfConnectionZoneWiseReport> NoOfConnectionZoneWiseReport { get; set; }
        public virtual DbSet<NoOfConnectionCategoryWiseReport> NoOfConnectionCategoryWiseReport { get; set; }
        public virtual DbSet<DifferentSizesMeterNoReport> DifferentSizesMeterNoReport { get; set; }
        public virtual DbSet<AssetMaintenanceReport> AssetMaintenanceReport { get; set; }
        public virtual DbSet<AssetTransferReport> AssetTransferReport { get; set; }
        public virtual DbSet<AssetListing> AssetListing { get; set; }
        public virtual DbSet<AssetListByResponsiblePerson> AssetListByResponsiblePerson { get; set; }
        public virtual DbSet<AssetStatusReport> AssetStatusReport { get; set; }
        public virtual DbSet<LongandShortTermCollection> LongandShortTermCollection { get; set; }
        public virtual DbSet<LongandShortLeaseList> LongandShortLeaseList { get; set; }
        public virtual DbSet<ConsolidatePropertyWaterCollection> ConsolidatePropertyCollection { get; set; }
        public virtual DbSet<ConsolidateWaterCollection> ConsolidateWaterCollection { get; set; }
        public virtual DbSet<GenerateAllModel> GetOwnershipDetailByLandOwnershipId { get; set; }
        public virtual DbSet<LongtermleaseVM> LongTermLandLeaseDemandSchedule { get; set; }
        public virtual DbSet<GenerateAllDisplayModel> GetOwnershipDetailByTaxPayerId { get; set; }
        public virtual DbSet<OccupancyCertificateVM> OccupancyCertificate { get; set; }
        public virtual DbSet<WaterTransactionReport> WaterTransactionReport { get; set; }
        public virtual DbSet<PropertyandWaterCollectionReport> PropertyandWaterCollectionReport { get; set; }
        public virtual DbSet<DemandCancelModel> DemandCancel { get; set; }
        public virtual DbSet<ZoneWiseWaterConsumption> GetZoneWiseWaterConsumption { get; set; }
        public virtual DbSet<MonthlyZoneWiseWaterConsumption> GetMonthlyZoneWiseWaterConsumption { get; set; }
        public virtual DbSet<ZoneWiseWaterCollection> GetZoneWiseWaterCollection { get; set; }
        public virtual DbSet<WaterAccountWiseReport> GetWaterAccountWiseReport { get; set; }
        public virtual DbSet<FloorsWiseCountReportVM> FloorsWiseCount { get; set; }
        public virtual DbSet<MissedOutReadingReportVM> MissedOutReading { get; set; }
        public virtual DbSet<OnlinePaymentByFromDateToDateModel> OnlinePaymentByFromDateToDate { get; set; }
        public virtual DbSet<Report2VM> GetMonthlyMeterReading { get; set; }
        public virtual DbSet<rptGetWaterConsumptionVM> GetWaterConsumption { get; set; }
        public virtual DbSet<PaymentDepositReportVM> PaymentDepositReport { get; set; }
        public virtual DbSet<DefaulterWaterList> GetDefaulterWaterList { get; set; }
        public virtual DbSet<DailyMinorHeadWiseCollection> DailyMinorHeadWise { get; set; }
        public virtual DbSet<YearlyMinorHeadWiseCollection> YearlyMinorHeadWise { get; set; }
        public virtual DbSet<IndividaulReceiptWiseDemandCollection> IndividaulReceiptWiseCollection { get; set; }
        public virtual DbSet<DefaulterPropertyList> GetDefaulterPropertyList { get; set; }
        public virtual DbSet<FinancialYearWiseReportVM> FinancialYearWiseReport { get; set; }
        public virtual DbSet<TaxRateVM> GetTaxRate { get; set; }
        public virtual DbSet<ReconcilingReport> GetReconcilingReport { get; set; }
        public virtual DbSet<DailyReceiptWiseCollection> GetDailyRecepitWiseCollection { get; set; }
        public virtual DbSet<DailyPaymentModeWisedemandCollectionSUMVM> DailyPaymentModeWiseDemandCollectionSUM { get; set; }
        public virtual DbSet<DailyPaymentModeWisedemandCollectionVM> DailyPaymentModeWiseDemandCollection { get; set; }
        public virtual DbSet<DepositVM> CollectionByFromDateToDate { get; set; }
        public virtual DbSet<ReportVM> DailyWiseReport { get; set; }
        public virtual DbSet<HouseRentDemandScheduleModule> HouseRentDemandSchedule { get; set; }
        public virtual DbSet<StallRentDemandScheduleModel> StallRentDemandSchedule { get; set; }
        public virtual DbSet<LandLeaseDemandScheduleModel> LandLeaseDemandSchedule { get; set; }
        public virtual DbSet<VendorDemandScheduleModel> VendorDemandSchedule { get; set; }
        public virtual DbSet<MenuMapModel> MenuMapModel { get; set; }


        public virtual DbSet<Abc> Abc { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<EnumApprovalStatus> EnumApprovalStatus { get; set; }
        public virtual DbSet<EnumAssetEntryStatus> EnumAssetEntryStatus { get; set; }
        public virtual DbSet<EnumAssetTransferType> EnumAssetTransferType { get; set; }
        public virtual DbSet<EnumBillingSchedule> EnumBillingSchedule { get; set; }
        public virtual DbSet<EnumBuildingEditReason> EnumBuildingEditReason { get; set; }
        public virtual DbSet<EnumComplainStatus> EnumComplainStatus { get; set; }
        public virtual DbSet<EnumComplainType> EnumComplainType { get; set; }
        public virtual DbSet<EnumDemandGenerateSchedule> EnumDemandGenerateSchedule { get; set; }
        public virtual DbSet<EnumDepreciationType> EnumDepreciationType { get; set; }
        public virtual DbSet<EnumEcuseType> EnumEcuseType { get; set; }
        public virtual DbSet<EnumFeeType> EnumFeeType { get; set; }
        public virtual DbSet<EnumGender> EnumGender { get; set; }
        public virtual DbSet<EnumIndustryType> EnumIndustryType { get; set; }
        public virtual DbSet<EnumLandOwnershipType> EnumLandOwnershipType { get; set; }
        public virtual DbSet<EnumLandTransferType> EnumLandTransferType { get; set; }
        public virtual DbSet<EnumLeaseActivityType> EnumLeaseActivityType { get; set; }
        public virtual DbSet<EnumLeaseType> EnumLeaseType { get; set; }
        public virtual DbSet<EnumMenuFor> EnumMenuFor { get; set; }
        public virtual DbSet<EnumMeterReplacementType> EnumMeterReplacementType { get; set; }
        public virtual DbSet<EnumOccupancyType> EnumOccupancyType { get; set; }
        public virtual DbSet<EnumOwnerType> EnumOwnerType { get; set; }
        public virtual DbSet<EnumPaymentMode> EnumPaymentMode { get; set; }
        public virtual DbSet<EnumPaymentStatus> EnumPaymentStatus { get; set; }
        public virtual DbSet<EnumProjectStatus> EnumProjectStatus { get; set; }
        public virtual DbSet<EnumPropertyType> EnumPropertyType { get; set; }
        public virtual DbSet<EnumServiceAccessibilityType> EnumServiceAccessibilityType { get; set; }
        public virtual DbSet<EnumSlabFor> EnumSlabFor { get; set; }
        public virtual DbSet<EnumStoryType> EnumStoryType { get; set; }
        public virtual DbSet<EnumTaxPayerType> EnumTaxPayerType { get; set; }
        public virtual DbSet<EnumTitle> EnumTitle { get; set; }
        public virtual DbSet<EnumTransactorType> EnumTransactorType { get; set; }
        public virtual DbSet<EnumUnitOwnerType> EnumUnitOwnerType { get; set; }
        public virtual DbSet<EnumVendorType> EnumVendorType { get; set; }
        public virtual DbSet<EnumWaterBillEditReason> EnumWaterBillEditReason { get; set; }
        public virtual DbSet<EnumWaterConnectionStatus> EnumWaterConnectionStatus { get; set; }
        public virtual DbSet<EnumWaterTankLocation> EnumWaterTankLocation { get; set; }
        public virtual DbSet<EnumWorkLevel> EnumWorkLevel { get; set; }
        public virtual DbSet<MstArea> MstArea { get; set; }
        public virtual DbSet<MstAsset> MstAsset { get; set; }
        public virtual DbSet<MstAssetAttribute> MstAssetAttribute { get; set; }
        public virtual DbSet<MstAssetFunction> MstAssetFunction { get; set; }
        public virtual DbSet<MstAssetStatus> MstAssetStatus { get; set; }
        public virtual DbSet<MstAttributeUnitMap> MstAttributeUnitMap { get; set; }
        public virtual DbSet<MstBank> MstBank { get; set; }
        public virtual DbSet<MstBankBranch> MstBankBranch { get; set; }
        public virtual DbSet<MstBoundaryType> MstBoundaryType { get; set; }
        public virtual DbSet<MstBuildingClass> MstBuildingClass { get; set; }
        public virtual DbSet<MstBuildingColour> MstBuildingColour { get; set; }
        public virtual DbSet<MstBuildingDetail> MstBuildingDetail { get; set; }
        public virtual DbSet<MstBuildingType> MstBuildingType { get; set; }
        public virtual DbSet<MstBuildingUnitClass> MstBuildingUnitClass { get; set; }
        public virtual DbSet<MstBuildingUnitDetail> MstBuildingUnitDetail { get; set; }
        public virtual DbSet<MstBuildingUnitUseType> MstBuildingUnitUseType { get; set; }
        public virtual DbSet<MstCalendarYear> MstCalendarYear { get; set; }
        public virtual DbSet<MstConditionRating> MstConditionRating { get; set; }
        public virtual DbSet<MstConstructionType> MstConstructionType { get; set; }
        public virtual DbSet<MstDcdsignUpload> MstDcdsignUpload { get; set; }
        public virtual DbSet<MstDemkhong> MstDemkhong { get; set; }
        public virtual DbSet<MstDepreciationType> MstDepreciationType { get; set; }
        public virtual DbSet<MstDesignation> MstDesignation { get; set; }
        public virtual DbSet<MstDetailHead> MstDetailHead { get; set; }
        public virtual DbSet<MstDetailTechnicalAttribute> MstDetailTechnicalAttribute { get; set; }
        public virtual DbSet<MstDisposalType> MstDisposalType { get; set; }
        public virtual DbSet<MstDivision> MstDivision { get; set; }
        public virtual DbSet<MstDzongkhag> MstDzongkhag { get; set; }
        public virtual DbSet<MstEcactivityType> MstEcactivityType { get; set; }
        public virtual DbSet<MstEcapplicantdetail> MstEcapplicantdetail { get; set; }
        public virtual DbSet<MstEsSignUpload> MstEsSignUpload { get; set; }
        public virtual DbSet<MstFinancialYear> MstFinancialYear { get; set; }
        public virtual DbSet<MstFloorName> MstFloorName { get; set; }
        public virtual DbSet<MstGewog> MstGewog { get; set; }
        public virtual DbSet<MstInspectionType> MstInspectionType { get; set; }
        public virtual DbSet<MstLandDetail> MstLandDetail { get; set; }
        public virtual DbSet<MstLandServiceType> MstLandServiceType { get; set; }
        public virtual DbSet<MstLandType> MstLandType { get; set; }
        public virtual DbSet<MstLandUseCategory> MstLandUseCategory { get; set; }
        public virtual DbSet<MstLandUseSubCategory> MstLandUseSubCategory { get; set; }
        public virtual DbSet<MstLap> MstLap { get; set; }
        public virtual DbSet<MstLogoSignMap> MstLogoSignMap { get; set; }
        public virtual DbSet<MstLogoUpload> MstLogoUpload { get; set; }
        public virtual DbSet<MstMaintenanceType> MstMaintenanceType { get; set; }
        public virtual DbSet<MstMajorHead> MstMajorHead { get; set; }
        public virtual DbSet<MstMaterialType> MstMaterialType { get; set; }
        public virtual DbSet<MstMeasurementUnit> MstMeasurementUnit { get; set; }
        public virtual DbSet<MstMinorHead> MstMinorHead { get; set; }
        public virtual DbSet<MstModificationReason> MstModificationReason { get; set; }
        public virtual DbSet<MstOccupation> MstOccupation { get; set; }
        public virtual DbSet<MstParentAttribute> MstParentAttribute { get; set; }
        public virtual DbSet<MstParkingSlot> MstParkingSlot { get; set; }
        public virtual DbSet<MstParkingZone> MstParkingZone { get; set; }
        public virtual DbSet<MstPavaRate> MstPavaRate { get; set; }
        public virtual DbSet<MstPrimaryAccountHead> MstPrimaryAccountHead { get; set; }
        public virtual DbSet<MstProcessLevel> MstProcessLevel { get; set; }
        public virtual DbSet<MstRate> MstRate { get; set; }
        public virtual DbSet<MstRoofingType> MstRoofingType { get; set; }
        public virtual DbSet<MstSecondaryAccountHead> MstSecondaryAccountHead { get; set; }
        public virtual DbSet<MstSection> MstSection { get; set; }
        public virtual DbSet<MstSlab> MstSlab { get; set; }
        public virtual DbSet<MstStallLocation> MstStallLocation { get; set; }
        public virtual DbSet<MstStallType> MstStallType { get; set; }
        public virtual DbSet<MstStreetName> MstStreetName { get; set; }
        public virtual DbSet<MstStructureCategory> MstStructureCategory { get; set; }
        public virtual DbSet<MstStructureType> MstStructureType { get; set; }
        public virtual DbSet<MstSuppliers> MstSuppliers { get; set; }
        public virtual DbSet<MstTaxMaster> MstTaxMaster { get; set; }
        public virtual DbSet<MstTaxPayerProfile> MstTaxPayerProfile { get; set; }
        public virtual DbSet<MstTaxPeriod> MstTaxPeriod { get; set; }
        public virtual DbSet<MstTaxTypeClassification> MstTaxTypeClassification { get; set; }
        public virtual DbSet<MstTechnicalAttribute> MstTechnicalAttribute { get; set; }
        public virtual DbSet<MstTertiaryAccountHead> MstTertiaryAccountHead { get; set; }
        public virtual DbSet<MstTransactionType> MstTransactionType { get; set; }
        public virtual DbSet<MstTransactionTypeTaxMap> MstTransactionTypeTaxMap { get; set; }
        public virtual DbSet<MstUser> MstUser { get; set; }
        public virtual DbSet<MstVillage> MstVillage { get; set; }
        public virtual DbSet<MstWaterConnection> MstWaterConnection { get; set; }
        public virtual DbSet<MstWaterConnectionType> MstWaterConnectionType { get; set; }
        public virtual DbSet<MstWaterLineType> MstWaterLineType { get; set; }
        public virtual DbSet<MstWaterMeterType> MstWaterMeterType { get; set; }
        public virtual DbSet<MstZone> MstZone { get; set; }
        public virtual DbSet<OccupancyCertificateUnitMap> OccupancyCertificateUnitMap { get; set; }
        public virtual DbSet<TblAssetDepreciation> TblAssetDepreciation { get; set; }
        public virtual DbSet<TblAssetMaintenance> TblAssetMaintenance { get; set; }
        public virtual DbSet<TblAssetTransfer> TblAssetTransfer { get; set; }
        public virtual DbSet<TblBfsTransactiondetails> TblBfsTransactiondetails { get; set; }
        public virtual DbSet<TblBuildingOwnership> TblBuildingOwnership { get; set; }
        public virtual DbSet<TblComplainDetail> TblComplainDetail { get; set; }
        public virtual DbSet<TblComplainReading> TblComplainReading { get; set; }
        public virtual DbSet<TblConstructionApprovedDetail> TblConstructionApprovedDetail { get; set; }
        public virtual DbSet<TblDemand> TblDemand { get; set; }
        public virtual DbSet<TblDemandCancel> TblDemandCancel { get; set; }
        public virtual DbSet<TblDemandLedgerPaymentUpdate> TblDemandLedgerPaymentUpdate { get; set; }
        public virtual DbSet<TblDemandNo> TblDemandNo { get; set; }
        public virtual DbSet<TblDeposit> TblDeposit { get; set; }
        public virtual DbSet<TblEcdetail> TblEcdetail { get; set; }
        public virtual DbSet<TblEcrenewalDetail> TblEcrenewalDetail { get; set; }
        public virtual DbSet<TblEsakorThramJointOwnerDetail> TblEsakorThramJointOwnerDetail { get; set; }
        public virtual DbSet<TblEsakorThramPlotDetail> TblEsakorThramPlotDetail { get; set; }
        public virtual DbSet<TblEsakorTransaction> TblEsakorTransaction { get; set; }
        public virtual DbSet<TblFinancialInformation> TblFinancialInformation { get; set; }
        public virtual DbSet<TblFreezPropertyDetail> TblFreezPropertyDetail { get; set; }
        public virtual DbSet<TblHouseAllocation> TblHouseAllocation { get; set; }
        public virtual DbSet<TblHouseDetail> TblHouseDetail { get; set; }
        public virtual DbSet<TblHouseRentDemandDetail> TblHouseRentDemandDetail { get; set; }
        public virtual DbSet<TblHouseRentPeriod> TblHouseRentPeriod { get; set; }
        public virtual DbSet<TblInaccessibleWaterMeterDetail> TblInaccessibleWaterMeterDetail { get; set; }
        public virtual DbSet<TblInchargeCollection> TblInchargeCollection { get; set; }
        public virtual DbSet<TblLandLease> TblLandLease { get; set; }
        public virtual DbSet<TblLandLeaseDemandDetail> TblLandLeaseDemandDetail { get; set; }
        public virtual DbSet<TblLandLeasePeriod> TblLandLeasePeriod { get; set; }
        public virtual DbSet<TblLandOwnershipDetail> TblLandOwnershipDetail { get; set; }
        public virtual DbSet<TblLedger> TblLedger { get; set; }
        public virtual DbSet<TblManualReceipt> TblManualReceipt { get; set; }
        public virtual DbSet<TblMenu> TblMenu { get; set; }
        public virtual DbSet<TblMenumap> TblMenumap { get; set; }
        public virtual DbSet<TblMiscellaneousRecord> TblMiscellaneousRecord { get; set; }
        public virtual DbSet<TblOccupancyCertificateUnitMap> TblOccupancyCertificateUnitMap { get; set; }
        public virtual DbSet<TblOpeningBalance> TblOpeningBalance { get; set; }
        public virtual DbSet<TblParkingFeeDemandDetail> TblParkingFeeDemandDetail { get; set; }
        public virtual DbSet<TblParkingFeePeriod> TblParkingFeePeriod { get; set; }
        public virtual DbSet<TblParkingfeeDetail> TblParkingfeeDetail { get; set; }
        public virtual DbSet<TblPaymentLeger> TblPaymentLeger { get; set; }
        public virtual DbSet<TblReceipt> TblReceipt { get; set; }
        public virtual DbSet<TblRevenueTransfer> TblRevenueTransfer { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblStallAllocation> TblStallAllocation { get; set; }
        public virtual DbSet<TblStallDetail> TblStallDetail { get; set; }
        public virtual DbSet<TblStallDetailDemand> TblStallDetailDemand { get; set; }
        public virtual DbSet<TblStallPeriod> TblStallPeriod { get; set; }
        public virtual DbSet<TblTechnicalInformation> TblTechnicalInformation { get; set; }
        public virtual DbSet<TblTransactionDetail> TblTransactionDetail { get; set; }
        public virtual DbSet<TblUnScheduledParkingRecord> TblUnScheduledParkingRecord { get; set; }
        public virtual DbSet<TblVersionControl> TblVersionControl { get; set; }
        public virtual DbSet<TblWaterBillChangeHistory> TblWaterBillChangeHistory { get; set; }
        public virtual DbSet<TblWaterMeterReading> TblWaterMeterReading { get; set; }
        public virtual DbSet<Tblaudit> Tblaudit { get; set; }
        public virtual DbSet<TrnConstructionApprovalApplicationFeeDetail> TrnConstructionApprovalApplicationFeeDetail { get; set; }
        public virtual DbSet<TrnLandDetail> TrnLandDetail { get; set; }
        public virtual DbSet<TrnLandFeeDetail> TrnLandFeeDetail { get; set; }
        public virtual DbSet<TrnLandTransferDetail> TrnLandTransferDetail { get; set; }
        public virtual DbSet<TrnOccupancyCertificateApplication> TrnOccupancyCertificateApplication { get; set; }
        public virtual DbSet<TrnSewerageConnection> TrnSewerageConnection { get; set; }
        public virtual DbSet<TrnTaxDetail> TrnTaxDetail { get; set; }
        public virtual DbSet<TrnTaxPayerInformation> TrnTaxPayerInformation { get; set; }
        public virtual DbSet<TrnVacuumTankerService> TrnVacuumTankerService { get; set; }
        public virtual DbSet<TrnWaterConnection> TrnWaterConnection { get; set; }
        public virtual DbSet<TrnWaterMeterReading> TrnWaterMeterReading { get; set; }
        public virtual DbSet<ViewLatestOcDetail> ViewLatestOcDetail { get; set; }
        public virtual DbSet<ViewLatestTop1Oc> ViewLatestTop1Oc { get; set; }
        public virtual DbSet<ViewNotJointLandTax> ViewNotJointLandTax { get; set; }
        public virtual DbSet<ViewProertyTaxLedger> ViewProertyTaxLedger { get; set; }
        public virtual DbSet<ViewReadingSeet> ViewReadingSeet { get; set; }
        public virtual DbSet<ViewSlabAndRates> ViewSlabAndRates { get; set; }
        public virtual DbSet<ViewSlabAndRatesForLandTax> ViewSlabAndRatesForLandTax { get; set; }
        public virtual DbSet<ViewTaxCalculationApi> ViewTaxCalculationApi { get; set; }
        public virtual DbSet<ViewUnitTax> ViewUnitTax { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile("appsettings.json")
                              .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ThromdeDBConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abc>(entity =>
            {
                entity.ToTable("abc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rno)
                    .HasColumnName("rno")
                    .HasMaxLength(100);

                entity.Property(e => e.Sl)
                    .HasColumnName("sl")
                    .HasComputedColumnSql("([yr]+(1))");

                entity.Property(e => e.Yr)
                    .HasColumnName("yr")
                    .HasDefaultValueSql("(datepart(year,getdate()))");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUsers_ToTable");
            });

            modelBuilder.Entity<EnumApprovalStatus>(entity =>
            {
                entity.HasKey(e => e.ApprovalStatusId)
                    .HasName("PK__enumAppr__AFBE8B54AE45F63D");

                entity.ToTable("enumApprovalStatus");

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approvalStatusId");

                entity.Property(e => e.ApprovalStatus)
                    .IsRequired()
                    .HasColumnName("approvalStatus")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumAssetEntryStatus>(entity =>
            {
                entity.HasKey(e => e.AssetEntryStatusId)
                    .HasName("PK__enumAsse__5377989750719F6F");

                entity.ToTable("enumAssetEntryStatus");

                entity.Property(e => e.AssetEntryStatusId).HasColumnName("assetEntryStatusId");

                entity.Property(e => e.AssetEntryStatus)
                    .IsRequired()
                    .HasColumnName("assetEntryStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumAssetTransferType>(entity =>
            {
                entity.HasKey(e => e.AssetTransferTypeId)
                    .HasName("PK__enumAsse__3F9D38BA884DBF9E");

                entity.ToTable("enumAssetTransferType");

                entity.Property(e => e.AssetTransferTypeId).HasColumnName("assetTransferTypeId");

                entity.Property(e => e.AssetTransferType)
                    .IsRequired()
                    .HasColumnName("assetTransferType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumBillingSchedule>(entity =>
            {
                entity.HasKey(e => e.BillingScheduleId)
                    .HasName("PK__enumBill__A47708C9E9A025E1");

                entity.ToTable("enumBillingSchedule");

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.BillingSchedule)
                    .IsRequired()
                    .HasColumnName("billingSchedule")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumBuildingEditReason>(entity =>
            {
                entity.HasKey(e => e.BuildingEditReasonId)
                    .HasName("PK__enumBuil__C42F8B500C4E60F5");

                entity.ToTable("enumBuildingEditReason");

                entity.Property(e => e.BuildingEditReasonId).HasColumnName("buildingEditReasonId");

                entity.Property(e => e.BuildingEditReason)
                    .IsRequired()
                    .HasColumnName("buildingEditReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumComplainStatus>(entity =>
            {
                entity.HasKey(e => e.ComplainStatusId)
                    .HasName("PK__enumComp__E87F6D63B4D61219");

                entity.ToTable("enumComplainStatus");

                entity.Property(e => e.ComplainStatusId).HasColumnName("complainStatusId");

                entity.Property(e => e.ComplainStatus)
                    .IsRequired()
                    .HasColumnName("complainStatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumComplainType>(entity =>
            {
                entity.HasKey(e => e.ComplainTypeId)
                    .HasName("PK__enumComp__A98B7AF622D7BD42");

                entity.ToTable("enumComplainType");

                entity.Property(e => e.ComplainTypeId).HasColumnName("complainTypeId");

                entity.Property(e => e.ComplainType)
                    .IsRequired()
                    .HasColumnName("complainType")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumDemandGenerateSchedule>(entity =>
            {
                entity.HasKey(e => e.DemandGenerateScheduleId)
                    .HasName("PK__enumDema__F3757D7A54F4F07A");

                entity.ToTable("enumDemandGenerateSchedule");

                entity.Property(e => e.DemandGenerateScheduleId)
                    .HasColumnName("demandGenerateScheduleId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.DemandGenerateSchedule)
                    .IsRequired()
                    .HasColumnName("demandGenerateSchedule")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.BillingSchedule)
                    .WithMany(p => p.EnumDemandGenerateSchedule)
                    .HasForeignKey(d => d.BillingScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_enumDemandGenerateSchedule_ToTable");
            });

            modelBuilder.Entity<EnumDepreciationType>(entity =>
            {
                entity.HasKey(e => e.DepreciationTypeId)
                    .HasName("PK__enumDepr__C378E8F208E3C4B5");

                entity.ToTable("enumDepreciationType");

                entity.Property(e => e.DepreciationTypeId).HasColumnName("depreciationTypeId");

                entity.Property(e => e.DepreciationType)
                    .IsRequired()
                    .HasColumnName("depreciationType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumEcuseType>(entity =>
            {
                entity.HasKey(e => e.EcUseTypeId)
                    .HasName("PK_enumecusetype_EcUseTypeID");

                entity.ToTable("enumECUseType");

                entity.Property(e => e.EcUseTypeId).HasColumnName("EcUseTypeID");

                entity.Property(e => e.EcUseType)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumFeeType>(entity =>
            {
                entity.HasKey(e => e.FeeTypeId)
                    .HasName("PK__enumFeeT__42583F72833E0FF2");

                entity.ToTable("enumFeeType");

                entity.Property(e => e.FeeTypeId).HasColumnName("feeTypeId");

                entity.Property(e => e.FeeType)
                    .IsRequired()
                    .HasColumnName("feeType")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumGender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PK_enumgender_ID");

                entity.ToTable("enumGender");

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumIndustryType>(entity =>
            {
                entity.HasKey(e => e.IndustryTypeId)
                    .HasName("PK_enumindustrytype_IndustryTypeID");

                entity.ToTable("enumIndustryType");

                entity.Property(e => e.IndustryTypeId).HasColumnName("industryTypeID");

                entity.Property(e => e.IndustryTypeName)
                    .IsRequired()
                    .HasColumnName("industryTypeName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumLandOwnershipType>(entity =>
            {
                entity.HasKey(e => e.LandOwnershipTypeId)
                    .HasName("PK__enumLand__0B9829E02247D3D9");

                entity.ToTable("enumLandOwnershipType");

                entity.Property(e => e.LandOwnershipTypeId).HasColumnName("landOwnershipTypeId");

                entity.Property(e => e.LandOwnershipType)
                    .IsRequired()
                    .HasColumnName("landOwnershipType")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LandOwnershipTypeDescription)
                    .IsRequired()
                    .HasColumnName("landOwnershipTypeDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumLandTransferType>(entity =>
            {
                entity.HasKey(e => e.LandTransferTypeId)
                    .HasName("PK__enumLand__A43785FED5D10293");

                entity.ToTable("enumLandTransferType");

                entity.Property(e => e.LandTransferTypeId).HasColumnName("landTransferTypeId");

                entity.Property(e => e.LandTransferType)
                    .IsRequired()
                    .HasColumnName("landTransferType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumLeaseActivityType>(entity =>
            {
                entity.HasKey(e => e.LeaseActivityTypeId)
                    .HasName("PK__enumLeas__D3CCDA8D4490A687");

                entity.ToTable("enumLeaseActivityType");

                entity.Property(e => e.LeaseActivityTypeId).HasColumnName("leaseActivityTypeId");

                entity.Property(e => e.LeaseActivity)
                    .IsRequired()
                    .HasColumnName("leaseActivity")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumLeaseType>(entity =>
            {
                entity.HasKey(e => e.LeaseTypeId)
                    .HasName("PK__enumLeas__99F9292A99BF127C");

                entity.ToTable("enumLeaseType");

                entity.Property(e => e.LeaseTypeId).HasColumnName("leaseTypeId");

                entity.Property(e => e.LeaseType)
                    .IsRequired()
                    .HasColumnName("leaseType")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumMenuFor>(entity =>
            {
                entity.HasKey(e => e.MenuForId)
                    .HasName("PK__EnumMenu__442396AC6CED3765");

                entity.Property(e => e.MenuForId).HasColumnName("menuForId");

                entity.Property(e => e.MenuFor)
                    .IsRequired()
                    .HasColumnName("menuFor")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumMeterReplacementType>(entity =>
            {
                entity.HasKey(e => e.ReplacementTypeId)
                    .HasName("PK_enumchangetype_ID");

                entity.ToTable("enumMeterReplacementType");

                entity.Property(e => e.ReplacementTypeId).HasColumnName("replacementTypeId");

                entity.Property(e => e.ReplacementType)
                    .IsRequired()
                    .HasColumnName("replacementType")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumOccupancyType>(entity =>
            {
                entity.HasKey(e => e.OccupancyTypeId)
                    .HasName("PK_enumoccupancytype_OccupancyTypeID");

                entity.ToTable("enumOccupancyType");

                entity.Property(e => e.OccupancyTypeId).HasColumnName("occupancyTypeId");

                entity.Property(e => e.OccupancyType)
                    .IsRequired()
                    .HasColumnName("occupancyType")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumOwnerType>(entity =>
            {
                entity.HasKey(e => e.OwnerTypeId)
                    .HasName("PK_enumOwnertype_ownerTypeId");

                entity.ToTable("enumOwnerType");

                entity.Property(e => e.OwnerTypeId).HasColumnName("ownerTypeId");

                entity.Property(e => e.OwnerType)
                    .IsRequired()
                    .HasColumnName("ownerType")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumPaymentMode>(entity =>
            {
                entity.HasKey(e => e.PaymentModeId)
                    .HasName("PK_enumpaymentmode_PaymentModeID");

                entity.ToTable("enumPaymentMode");

                entity.Property(e => e.PaymentModeId).HasColumnName("paymentModeId");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasColumnName("paymentMode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentModeDetails)
                    .HasColumnName("paymentModeDetails")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumPaymentStatus>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusId)
                    .HasName("PK__enumPaym__29CD0BBCBAD469A5");

                entity.ToTable("enumPaymentStatus");

                entity.Property(e => e.PaymentStatusId).HasColumnName("paymentStatusId");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnName("paymentStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumProjectStatus>(entity =>
            {
                entity.HasKey(e => e.ProjectStatusId)
                    .HasName("PK_enumprojectstatus_ProjectStatusID");

                entity.ToTable("enumProjectStatus");

                entity.Property(e => e.ProjectStatusId).HasColumnName("projectStatusId");

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasColumnName("projectStatus")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumPropertyType>(entity =>
            {
                entity.HasKey(e => e.PropertyTypeId)
                    .HasName("PK__enumProp__97B944DAF2924E12");

                entity.ToTable("enumPropertyType");

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasColumnName("propertyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumServiceAccessibilityType>(entity =>
            {
                entity.HasKey(e => e.ServiceAccessibilityId)
                    .HasName("PK_enumgarbagecollectionusestatus_ID");

                entity.ToTable("enumServiceAccessibilityType");

                entity.Property(e => e.ServiceAccessibilityId).HasColumnName("serviceAccessibilityId");

                entity.Property(e => e.ServiceAccessibilityType)
                    .IsRequired()
                    .HasColumnName("serviceAccessibilityType")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumSlabFor>(entity =>
            {
                entity.HasKey(e => e.SlabForId)
                    .HasName("PK__enumSlab__CBBB02F5A7384476");

                entity.ToTable("enumSlabFor");

                entity.Property(e => e.SlabForId).HasColumnName("slabForId");

                entity.Property(e => e.SlabFor)
                    .IsRequired()
                    .HasColumnName("slabFor")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumStoryType>(entity =>
            {
                entity.HasKey(e => e.StoryTypeId)
                    .HasName("PK__enumStor__787D69238DF1E915");

                entity.ToTable("enumStoryType");

                entity.Property(e => e.StoryTypeId).HasColumnName("storyTypeId");

                entity.Property(e => e.StoryType)
                    .IsRequired()
                    .HasColumnName("storyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumTaxPayerType>(entity =>
            {
                entity.HasKey(e => e.TaxPayerTypeId)
                    .HasName("PK__enumTaxP__E78F8CE58648B03F");

                entity.ToTable("enumTaxPayerType");

                entity.Property(e => e.TaxPayerTypeId).HasColumnName("taxPayerTypeId");

                entity.Property(e => e.TaxPayerType)
                    .IsRequired()
                    .HasColumnName("taxPayerType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumTitle>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("PK_enumTitleId");

                entity.ToTable("enumTitle");

                entity.Property(e => e.TitleId).HasColumnName("titleId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumTransactorType>(entity =>
            {
                entity.HasKey(e => e.TransactorTypeId)
                    .HasName("PK__enumTran__60E76D98DEC48F36");

                entity.ToTable("enumTransactorType");

                entity.Property(e => e.TransactorTypeId).HasColumnName("transactorTypeId");

                entity.Property(e => e.TransactorType)
                    .IsRequired()
                    .HasColumnName("transactorType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumUnitOwnerType>(entity =>
            {
                entity.HasKey(e => e.UnitOwnerTypeId);

                entity.ToTable("enumUnitOwnerType");

                entity.Property(e => e.UnitOwnerTypeId).HasColumnName("unitOwnerTypeId");

                entity.Property(e => e.UnitOwnerType)
                    .IsRequired()
                    .HasColumnName("unitOwnerType")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumVendorType>(entity =>
            {
                entity.HasKey(e => e.VendorTypeId)
                    .HasName("PK__enumVend__7AEC025977CEC729");

                entity.ToTable("enumVendorType");

                entity.Property(e => e.VendorTypeId).HasColumnName("vendorTypeId");

                entity.Property(e => e.VendorType)
                    .HasColumnName("vendorType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumWaterBillEditReason>(entity =>
            {
                entity.HasKey(e => e.WaterBillEditReasonId)
                    .HasName("PK__enumWate__24602D67D5B0A457");

                entity.ToTable("enumWaterBillEditReason");

                entity.Property(e => e.WaterBillEditReasonId).HasColumnName("waterBillEditReasonId");

                entity.Property(e => e.WaterBillEditReason)
                    .IsRequired()
                    .HasColumnName("waterBillEditReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumWaterConnectionStatus>(entity =>
            {
                entity.HasKey(e => e.WaterConnectionStatusId)
                    .HasName("PK__enumWate__E98BDB2CE8ACDF39");

                entity.ToTable("enumWaterConnectionStatus");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionStatus)
                    .IsRequired()
                    .HasColumnName("waterConnectionStatus")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumWaterTankLocation>(entity =>
            {
                entity.HasKey(e => e.WaterTankLocationId)
                    .HasName("PK__enumWate__48E7A4F775D7EF68");

                entity.ToTable("enumWaterTankLocation");

                entity.Property(e => e.WaterTankLocationId).HasColumnName("waterTankLocationId");

                entity.Property(e => e.WaterTankLocation)
                    .IsRequired()
                    .HasColumnName("waterTankLocation")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnumWorkLevel>(entity =>
            {
                entity.HasKey(e => e.WorkLevelId)
                    .HasName("PK__enumWork__96B097CDACB56E9F");

                entity.ToTable("enumWorkLevel");

                entity.Property(e => e.WorkLevelId).HasColumnName("workLevelId");

                entity.Property(e => e.WorkLevel)
                    .IsRequired()
                    .HasColumnName("workLevel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PK__tmp_ms_x__52936C57D0D189AD");

                entity.ToTable("mstArea");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("areaCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasColumnName("areaName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAsset>(entity =>
            {
                entity.HasKey(e => e.AssetId)
                    .HasName("PK__tmp_ms_x__7D3DF4916B01BC5F");

                entity.ToTable("mstAsset");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.AssetCode)
                    .IsRequired()
                    .HasColumnName("assetCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AssetEntryStatusId)
                    .HasColumnName("assetEntryStatusId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AssetFunctionId).HasColumnName("assetFunctionId");

                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasColumnName("assetName")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AssetStatusId).HasColumnName("assetStatusId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemkhongId).HasColumnName("demkhongId");

                entity.Property(e => e.GisCode)
                    .IsRequired()
                    .HasColumnName("gisCode")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.GoodReceiveBy).HasColumnName("goodReceiveBy");

                entity.Property(e => e.GoodReceiveDate)
                    .HasColumnName("goodReceiveDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.LapId).HasColumnName("lapId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePerson)
                    .IsRequired()
                    .HasColumnName("responsiblePerson")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.TertiaryAccountHeadId).HasColumnName("tertiaryAccountHeadId");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");

                entity.HasOne(d => d.AssetEntryStatus)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.AssetEntryStatusId)
                    .HasConstraintName("FK_mstAsset_ToTable_7");

                entity.HasOne(d => d.AssetFunction)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.AssetFunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAsset_ToTable_3");

                entity.HasOne(d => d.AssetStatus)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.AssetStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAsset_ToTable_2");

                entity.HasOne(d => d.Demkhong)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.DemkhongId)
                    .HasConstraintName("FK_mstAsset_ToTable_5");

                entity.HasOne(d => d.Lap)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.LapId)
                    .HasConstraintName("FK_mstAsset_ToTable_6");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAsset_ToTable_1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_mstAsset_ToTable_4");

                entity.HasOne(d => d.TertiaryAccountHead)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.TertiaryAccountHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAsset_ToTable");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.MstAsset)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_mstAsset_ToTable_8");
            });

            modelBuilder.Entity<MstAssetAttribute>(entity =>
            {
                entity.HasKey(e => e.AssetAttributeId)
                    .HasName("PK__mstAsset__C465123B5BF1959C");

                entity.ToTable("mstAssetAttribute");

                entity.Property(e => e.AssetAttributeId).HasColumnName("assetAttributeId");

                entity.Property(e => e.AttributeDescription)
                    .HasColumnName("attributeDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasColumnName("attributeName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParentAttributeId).HasColumnName("parentAttributeId");

                entity.HasOne(d => d.ParentAttribute)
                    .WithMany(p => p.MstAssetAttribute)
                    .HasForeignKey(d => d.ParentAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAttribute_ToTable");
            });

            modelBuilder.Entity<MstAssetFunction>(entity =>
            {
                entity.HasKey(e => e.AssetFunctionId)
                    .HasName("PK__mstAsset__DC16AA8D4708D28E");

                entity.ToTable("mstAssetFunction");

                entity.Property(e => e.AssetFunctionId).HasColumnName("assetFunctionId");

                entity.Property(e => e.AssetFunctionDescription)
                    .HasColumnName("assetFunctionDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AssetFunctionName)
                    .IsRequired()
                    .HasColumnName("assetFunctionName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.FunctionCode)
                    .HasColumnName("functionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstAssetStatus>(entity =>
            {
                entity.HasKey(e => e.AssetStatusId)
                    .HasName("PK__mstAsset__2A410BFD6704D03C");

                entity.ToTable("mstAssetStatus");

                entity.Property(e => e.AssetStatusId).HasColumnName("assetStatusId");

                entity.Property(e => e.AssetStatus)
                    .IsRequired()
                    .HasColumnName("assetStatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstAttributeUnitMap>(entity =>
            {
                entity.HasKey(e => e.AttributeUnitMapId)
                    .HasName("PK__mstAttri__A2242EBE61A5CB39");

                entity.ToTable("mstAttributeUnitMap");

                entity.Property(e => e.AttributeUnitMapId).HasColumnName("attributeUnitMapId");

                entity.Property(e => e.AssetAttributeId).HasColumnName("assetAttributeId");

                entity.Property(e => e.AttributeUnitMapDescription)
                    .HasColumnName("attributeUnitMapDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeUnitMapName)
                    .IsRequired()
                    .HasColumnName("attributeUnitMapName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MeasurementUnitId).HasColumnName("measurementUnitId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AssetAttribute)
                    .WithMany(p => p.MstAttributeUnitMap)
                    .HasForeignKey(d => d.AssetAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAttributeUnitMap_ToTable_1");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.MstAttributeUnitMap)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstAttributeUnitMap_ToTable");
            });

            modelBuilder.Entity<MstBank>(entity =>
            {
                entity.HasKey(e => e.BankId)
                    .HasName("PK__mstBank__E710188C6A2F38AD");

                entity.ToTable("mstBank");

                entity.Property(e => e.BankId).HasColumnName("bankId");

                entity.Property(e => e.BankCode)
                    .HasColumnName("bankCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bankName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBankBranch>(entity =>
            {
                entity.HasKey(e => e.BankBranchId)
                    .HasName("PK__mstBankB__BE6F971521AA2EE4");

                entity.ToTable("mstBankBranch");

                entity.Property(e => e.BankBranchId).HasColumnName("bankBranchId");

                entity.Property(e => e.BankId).HasColumnName("bankId");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.BranchOfficeAddress)
                    .HasColumnName("branchOfficeAddress")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("contactEmail")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contactPerson")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasColumnName("faxNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phoneNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.MstBankBranch)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBankBranch_ToTable");
            });

            modelBuilder.Entity<MstBoundaryType>(entity =>
            {
                entity.HasKey(e => e.BoundaryTypeId)
                    .HasName("PK__mstBound__D5CCEF3AC8E89CA6");

                entity.ToTable("mstBoundaryType");

                entity.Property(e => e.BoundaryTypeId).HasColumnName("boundaryTypeId");

                entity.Property(e => e.BoundaryType)
                    .IsRequired()
                    .HasColumnName("boundaryType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BoundaryTypeDescription)
                    .HasColumnName("boundaryTypeDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBuildingClass>(entity =>
            {
                entity.HasKey(e => e.BuildingClassId)
                    .HasName("PK__mstBuild__709FE18FA4A321F1");

                entity.ToTable("mstBuildingClass");

                entity.Property(e => e.BuildingClassId).HasColumnName("buildingClassId");

                entity.Property(e => e.BuildingClassDescription)
                    .HasColumnName("buildingClassDescription")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingClassName)
                    .IsRequired()
                    .HasColumnName("buildingClassName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<MstBuildingColour>(entity =>
            {
                entity.HasKey(e => e.BuildingColourId)
                    .HasName("PK__mstBuild__41DA00D2869871E5");

                entity.ToTable("mstBuildingColour");

                entity.Property(e => e.BuildingColourId).HasColumnName("buildingColourId");

                entity.Property(e => e.BuildingColourDescription)
                    .HasColumnName("buildingColourDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingColourType)
                    .IsRequired()
                    .HasColumnName("buildingColourType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBuildingDetail>(entity =>
            {
                entity.HasKey(e => e.BuildingDetailId)
                    .HasName("PK__tmp_ms_x__ED057FB69874968C");

                entity.ToTable("mstBuildingDetail");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.AdvanceInfoFedBy)
                    .HasColumnName("advanceInfoFedBy")
                    .HasComment("who entered advance info/userid");

                entity.Property(e => e.AdvanceInfoInfoFedOn)
                    .HasColumnName("advanceInfoInfoFedOn")
                    .HasColumnType("date");

                entity.Property(e => e.ArchFeature).HasColumnName("archFeature");

                entity.Property(e => e.Attic).HasColumnName("attic");

                entity.Property(e => e.BoundaryTypeId).HasColumnName("boundaryTypeId");

                entity.Property(e => e.BuildingClassId)
                    .HasColumnName("buildingClassId")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BuildingColourId).HasColumnName("buildingColourId");

                entity.Property(e => e.BuildingNo)
                    .HasColumnName("buildingNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BuildupArea)
                    .HasColumnName("buildupArea")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ConstructionTypeId).HasColumnName("constructionTypeId");

                entity.Property(e => e.CreateG2cApplicationNo)
                    .HasColumnName("createG2cApplicationNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfFinalInspection)
                    .HasColumnName("dateOfFinalInspection")
                    .HasColumnType("date");

                entity.Property(e => e.DrainToStormWaterDrain).HasColumnName("drainToStormWaterDrain");

                entity.Property(e => e.FireExtingusher).HasColumnName("fireExtingusher");

                entity.Property(e => e.GarbagServiceAccessibilityId).HasColumnName("garbagServiceAccessibilityId");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.MaterialTypeId).HasColumnName("materialTypeId");

                entity.Property(e => e.ModificationReasonId).HasColumnName("modificationReasonId");

                entity.Property(e => e.ModificationRemarks)
                    .HasColumnName("modificationRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoOfUnits).HasColumnName("noOfUnits");

                entity.Property(e => e.NumberDisplayed).HasColumnName("numberDisplayed");

                entity.Property(e => e.NumberOfFloors).HasColumnName("numberOfFloors");

                entity.Property(e => e.OccupancyAlteredBy).HasColumnName("occupancyAlteredBy");

                entity.Property(e => e.OccupancyAlteredOn)
                    .HasColumnName("occupancyAlteredOn")
                    .HasColumnType("date");

                entity.Property(e => e.OccupancyCertificateIssueDate)
                    .HasColumnName("occupancyCertificateIssueDate")
                    .HasColumnType("date");

                entity.Property(e => e.OccupancyCertificateIssued).HasColumnName("occupancyCertificateIssued");

                entity.Property(e => e.OccupancyCertificateNo)
                    .HasColumnName("occupancyCertificateNo")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.OccupancyReferenceId).HasColumnName("occupancyReferenceId");

                entity.Property(e => e.ParkingSlotId).HasColumnName("parkingSlotId");

                entity.Property(e => e.PaymentCompletionStatusId)
                    .IsRequired()
                    .HasColumnName("paymentCompletionStatusId")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Plantation).HasColumnName("plantation");

                entity.Property(e => e.PlinthArea)
                    .HasColumnName("plinthArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.Property(e => e.RoadAccess).HasColumnName("roadAccess");

                entity.Property(e => e.Roofing).HasColumnName("roofing");

                entity.Property(e => e.RoofingTypeId).HasColumnName("roofingTypeId");

                entity.Property(e => e.SewerageConnection).HasColumnName("sewerageConnection");

                entity.Property(e => e.StoryTypeId).HasColumnName("storyTypeId");

                entity.Property(e => e.StreetLightAccessibilityId).HasColumnName("streetLightAccessibilityId");

                entity.Property(e => e.StructureCategoryId).HasColumnName("structureCategoryId");

                entity.Property(e => e.StructureTypeId).HasColumnName("structureTypeId");

                entity.Property(e => e.TraditionalPainting).HasColumnName("traditionalPainting");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.UpdateG2cApplicationNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.WaterConnection).HasColumnName("waterConnection");

                entity.Property(e => e.WaterSupplyAccessibilityId).HasColumnName("waterSupplyAccessibilityId");

                entity.Property(e => e.WaterTankLocationId).HasColumnName("waterTankLocationId");

                entity.Property(e => e.YearOfConstruction).HasColumnName("yearOfConstruction");

                entity.HasOne(d => d.BoundaryType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.BoundaryTypeId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_7");

                entity.HasOne(d => d.BuildingColour)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.BuildingColourId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_6");

                entity.HasOne(d => d.ConstructionType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.ConstructionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_1");

                entity.HasOne(d => d.GarbagServiceAccessibility)
                    .WithMany(p => p.MstBuildingDetailGarbagServiceAccessibility)
                    .HasForeignKey(d => d.GarbagServiceAccessibilityId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_11");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable");

                entity.HasOne(d => d.MaterialType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.MaterialTypeId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_4");

                entity.HasOne(d => d.ParkingSlot)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.ParkingSlotId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_9");

                entity.HasOne(d => d.RoofingType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.RoofingTypeId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_5");

                entity.HasOne(d => d.StoryType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.StoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_13");

                entity.HasOne(d => d.StreetLightAccessibility)
                    .WithMany(p => p.MstBuildingDetailStreetLightAccessibility)
                    .HasForeignKey(d => d.StreetLightAccessibilityId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_12");

                entity.HasOne(d => d.StructureCategory)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.StructureCategoryId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_2");

                entity.HasOne(d => d.StructureType)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.StructureTypeId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_3");

                entity.HasOne(d => d.WaterSupplyAccessibility)
                    .WithMany(p => p.MstBuildingDetailWaterSupplyAccessibility)
                    .HasForeignKey(d => d.WaterSupplyAccessibilityId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_10");

                entity.HasOne(d => d.WaterTankLocation)
                    .WithMany(p => p.MstBuildingDetail)
                    .HasForeignKey(d => d.WaterTankLocationId)
                    .HasConstraintName("FK_mstBuildingDetail_ToTable_8");
            });

            modelBuilder.Entity<MstBuildingType>(entity =>
            {
                entity.HasKey(e => e.BuildingTypeId)
                    .HasName("PK__mstBuild__9584612E6F89A6C6");

                entity.ToTable("mstBuildingType");

                entity.Property(e => e.BuildingTypeId).HasColumnName("buildingTypeId");

                entity.Property(e => e.BuildingType)
                    .IsRequired()
                    .HasColumnName("buildingType")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstBuildingUnitClass>(entity =>
            {
                entity.HasKey(e => e.BuildingUnitClassId)
                    .HasName("PK__mstBuild__A6E3B9B25E7B6CC1");

                entity.ToTable("mstBuildingUnitClass");

                entity.Property(e => e.BuildingUnitClassId).HasColumnName("buildingUnitClassId");

                entity.Property(e => e.BuildingUnitClassDescription)
                    .HasColumnName("buildingUnitClassDescription")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingUnitClassName)
                    .IsRequired()
                    .HasColumnName("buildingUnitClassName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<MstBuildingUnitDetail>(entity =>
            {
                entity.HasKey(e => e.BuildingUnitDetailId)
                    .HasName("PK__tmp_ms_x__7713892275873A6C");

                entity.ToTable("mstBuildingUnitDetail");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.BuildingUnitClassId).HasColumnName("buildingUnitClassId");

                entity.Property(e => e.BuildingUnitUseTypeId).HasColumnName("buildingUnitUseTypeId");

                entity.Property(e => e.CreateG2cApplicationNo)
                    .HasColumnName("createG2cApplicationNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.FlatNo)
                    .IsRequired()
                    .HasColumnName("flatNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FloorArea)
                    .HasColumnName("floorArea")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FloorNameId).HasColumnName("floorNameId");

                entity.Property(e => e.FloorNo)
                    .IsRequired()
                    .HasColumnName("floorNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.HasIssue).HasColumnName("hasIssue");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsMainOwner).HasColumnName("isMainOwner");

                entity.Property(e => e.IsRegularized).HasColumnName("isRegularized");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.NoOfUnit)
                    .HasColumnName("noOfUnit")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoOfrooms).HasColumnName("noOfrooms");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TransferStatusId).HasColumnName("transferStatusId");

                entity.Property(e => e.UnitOwnerTypeId).HasColumnName("unitOwnerTypeId");

                entity.Property(e => e.UpdateG2cApplicationNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.BuildingDetail)
                    .WithMany(p => p.MstBuildingUnitDetail)
                    .HasForeignKey(d => d.BuildingDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingUnitDetail_ToTable");

                entity.HasOne(d => d.BuildingUnitClass)
                    .WithMany(p => p.MstBuildingUnitDetail)
                    .HasForeignKey(d => d.BuildingUnitClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingUnitDetail_ToTable_3");

                entity.HasOne(d => d.BuildingUnitUseType)
                    .WithMany(p => p.MstBuildingUnitDetail)
                    .HasForeignKey(d => d.BuildingUnitUseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingUnitDetail_ToTable_1");

                entity.HasOne(d => d.FloorName)
                    .WithMany(p => p.MstBuildingUnitDetail)
                    .HasForeignKey(d => d.FloorNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingUnitDetail_ToTable_2");

                entity.HasOne(d => d.UnitOwnerType)
                    .WithMany(p => p.MstBuildingUnitDetail)
                    .HasForeignKey(d => d.UnitOwnerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstBuildingUnitDetail_ToTable_4");
            });

            modelBuilder.Entity<MstBuildingUnitUseType>(entity =>
            {
                entity.HasKey(e => e.BuildingUnitUseTypeId)
                    .HasName("PK__mstBuild__034771CC21F69F4C");

                entity.ToTable("mstBuildingUnitUseType");

                entity.Property(e => e.BuildingUnitUseTypeId).HasColumnName("buildingUnitUseTypeId");

                entity.Property(e => e.BuildingUnitUseType)
                    .IsRequired()
                    .HasColumnName("buildingUnitUseType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingUnitUseTypeDescription)
                    .HasColumnName("buildingUnitUseTypeDescription")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstCalendarYear>(entity =>
            {
                entity.HasKey(e => e.CalendarYearId);

                entity.ToTable("mstCalendarYear");

                entity.Property(e => e.CalendarYearId).HasColumnName("calendarYearId");

                entity.Property(e => e.CalendarYear)
                    .IsRequired()
                    .HasColumnName("calendarYear")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<MstConditionRating>(entity =>
            {
                entity.HasKey(e => e.ConditionRatingId)
                    .HasName("PK__mstCondi__251F50392A8A7C1F");

                entity.ToTable("mstConditionRating");

                entity.Property(e => e.ConditionRatingId).HasColumnName("conditionRatingId");

                entity.Property(e => e.ConditionRating)
                    .IsRequired()
                    .HasColumnName("conditionRating")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionRatingDescription)
                    .IsRequired()
                    .HasColumnName("conditionRatingDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstConstructionType>(entity =>
            {
                entity.HasKey(e => e.ConstructionTypeId)
                    .HasName("PK__mstConst__DB4613F393C7F26D");

                entity.ToTable("mstConstructionType");

                entity.Property(e => e.ConstructionTypeId).HasColumnName("constructionTypeId");

                entity.Property(e => e.ConstructionType)
                    .IsRequired()
                    .HasColumnName("constructionType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ConstructionTypeDescription)
                    .HasColumnName("constructionTypeDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDcdsignUpload>(entity =>
            {
                entity.HasKey(e => e.DcdSignId)
                    .HasName("PK__mstDCDSi__7B47F0E88E4B2D78");

                entity.ToTable("mstDCDSignUpload");

                entity.Property(e => e.DcdSignId).HasColumnName("dcdSignId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SignPath)
                    .IsRequired()
                    .HasColumnName("signPath")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MstDcdsignUpload)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstDCDSignUpload_ToTable");
            });

            modelBuilder.Entity<MstDemkhong>(entity =>
            {
                entity.HasKey(e => e.DemkhongId)
                    .HasName("PK__mstDemkh__4CA3F674136DB35B");

                entity.ToTable("mstDemkhong");

                entity.Property(e => e.DemkhongId).HasColumnName("demkhongId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemkhongName)
                    .IsRequired()
                    .HasColumnName("demkhongName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDepreciationType>(entity =>
            {
                entity.HasKey(e => e.DepreciationTypeId)
                    .HasName("PK__mstDepre__8905DD25EEDBCE03");

                entity.ToTable("mstDepreciationType");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepreciationType)
                    .IsRequired()
                    .HasColumnName("depreciationType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DepreciationTypeDescription)
                    .IsRequired()
                    .HasColumnName("depreciationTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDesignation>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__mstDesig__197CE32A4CC5FA7B");

                entity.ToTable("mstDesignation");

                entity.Property(e => e.DesignationId).HasColumnName("designationId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("designation")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.MstDesignation)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstDesignation_ToTable");
            });

            modelBuilder.Entity<MstDetailHead>(entity =>
            {
                entity.HasKey(e => e.DetailHeadId)
                    .HasName("PK__tmp_ms_x__BBB1DE9AC1D17386");

                entity.ToTable("mstDetailHead");

                entity.Property(e => e.DetailHeadId).HasColumnName("detailHeadId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DetailHeadCode)
                    .IsRequired()
                    .HasColumnName("detailHeadCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DetailHeadDescription)
                    .HasColumnName("detailHeadDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DetailHeadName)
                    .IsRequired()
                    .HasColumnName("detailHeadName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DetailHeadSymbol)
                    .IsRequired()
                    .HasColumnName("detailHeadSymbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MinorHeadId).HasColumnName("minorHeadId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MinorHead)
                    .WithMany(p => p.MstDetailHead)
                    .HasForeignKey(d => d.MinorHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstDetailHead_ToTable");
            });

            modelBuilder.Entity<MstDetailTechnicalAttribute>(entity =>
            {
                entity.HasKey(e => e.DetailTechnicalAttributeId)
                    .HasName("PK__mstDetai__EFE291EBE9DE2E66");

                entity.ToTable("mstDetailTechnicalAttribute");

                entity.Property(e => e.DetailTechnicalAttributeId).HasColumnName("detailTechnicalAttributeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DetailTechnicalAttribute)
                    .IsRequired()
                    .HasColumnName("detailTechnicalAttribute")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DetailTechnicalAttributeDescription)
                    .HasColumnName("detailTechnicalAttributeDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TechnicalAttributeId).HasColumnName("technicalAttributeId");

                entity.HasOne(d => d.TechnicalAttribute)
                    .WithMany(p => p.MstDetailTechnicalAttribute)
                    .HasForeignKey(d => d.TechnicalAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstDetailTechnicalAttribute_ToTable");
            });

            modelBuilder.Entity<MstDisposalType>(entity =>
            {
                entity.HasKey(e => e.DisposalTypeId)
                    .HasName("PK__mstDispo__DB156362038F680D");

                entity.ToTable("mstDisposalType");

                entity.Property(e => e.DisposalTypeId).HasColumnName("disposalTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisposalType)
                    .IsRequired()
                    .HasColumnName("disposalType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalTypeDescription)
                    .HasColumnName("disposalTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDivision>(entity =>
            {
                entity.HasKey(e => e.DivisionId)
                    .HasName("PK__mstDivis__B294A6EFCF687A85");

                entity.ToTable("mstDivision");

                entity.Property(e => e.DivisionId).HasColumnName("divisionId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DivisionCode)
                    .HasColumnName("divisionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasColumnName("divisionName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDzongkhag>(entity =>
            {
                entity.HasKey(e => e.DzongkhagId)
                    .HasName("PK__tmp_ms_x__C53A68DC7861242F");

                entity.ToTable("mstDzongkhag");

                entity.Property(e => e.DzongkhagId).HasColumnName("dzongkhagId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DzongkhagName)
                    .IsRequired()
                    .HasColumnName("dzongkhagName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstEcactivityType>(entity =>
            {
                entity.HasKey(e => e.EcActivityTypeId)
                    .HasName("PK__mstECAct__71C79DBD83C3539E");

                entity.ToTable("mstECActivityType");

                entity.Property(e => e.EcActivityTypeId).HasColumnName("ecActivityTypeId");

                entity.Property(e => e.ActivityDescription)
                    .HasColumnName("activityDescription")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityType)
                    .IsRequired()
                    .HasColumnName("activityType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstEcapplicantdetail>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PK__mstECApp__8DB30461ADE943F0");

                entity.ToTable("mstECApplicantdetail");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicantName)
                    .IsRequired()
                    .HasColumnName("applicantName")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasColumnName("contactNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.FaxNo)
                    .HasColumnName("faxNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LicenceNo)
                    .IsRequired()
                    .HasColumnName("licenceNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.PostBoxNo)
                    .HasColumnName("postBoxNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstEsSignUpload>(entity =>
            {
                entity.HasKey(e => e.EsSignId)
                    .HasName("PK__mstEsSig__E497DA6008305539");

                entity.ToTable("mstEsSignUpload");

                entity.Property(e => e.EsSignId).HasColumnName("esSignId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SignPath)
                    .IsRequired()
                    .HasColumnName("signPath")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MstEsSignUpload)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstEsSignUpload_ToTable");
            });

            modelBuilder.Entity<MstFinancialYear>(entity =>
            {
                entity.HasKey(e => e.FinancialYearId)
                    .HasName("PK__mstFinan__FE30A41171BFC147");

                entity.ToTable("mstFinancialYear");

                entity.Property(e => e.FinancialYearId).HasColumnName("financialYearId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.FinancialYear)
                    .IsRequired()
                    .HasColumnName("financialYear")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<MstFloorName>(entity =>
            {
                entity.HasKey(e => e.FloorNameId)
                    .HasName("PK__mstFloor__91F6412A16F03C8A");

                entity.ToTable("mstFloorName");

                entity.Property(e => e.FloorNameId).HasColumnName("floorNameId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.FloorName)
                    .IsRequired()
                    .HasColumnName("floorName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FloorNameDescription)
                    .HasColumnName("floorNameDescription")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstGewog>(entity =>
            {
                entity.HasKey(e => e.GewogId)
                    .HasName("PK__tmp_ms_x__69A56B50420D68BC");

                entity.ToTable("mstGewog");

                entity.Property(e => e.GewogId).HasColumnName("gewogId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DzongkhagId).HasColumnName("dzongkhagId");

                entity.Property(e => e.GewogName)
                    .IsRequired()
                    .HasColumnName("gewogName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Dzongkhag)
                    .WithMany(p => p.MstGewog)
                    .HasForeignKey(d => d.DzongkhagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstGewog_ToTable");
            });

            modelBuilder.Entity<MstInspectionType>(entity =>
            {
                entity.HasKey(e => e.InspectionTypeId)
                    .HasName("PK__mstInspe__A0E1B8FDF137B8DE");

                entity.ToTable("mstInspectionType");

                entity.Property(e => e.InspectionTypeId).HasColumnName("inspectionTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.InspectionType)
                    .IsRequired()
                    .HasColumnName("inspectionType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InspectionTypeDescription)
                    .HasColumnName("inspectionTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLandDetail>(entity =>
            {
                entity.HasKey(e => e.LandDetailId)
                    .HasName("PK__tmp_ms_x__9337EE51DFD5D555");

                entity.ToTable("mstLandDetail");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreationOn)
                    .HasColumnName("creationOn")
                    .HasColumnType("date");

                entity.Property(e => e.DemkhongId).HasColumnName("demkhongId");

                entity.Property(e => e.GarbageApplicable).HasColumnName("garbageApplicable");

                entity.Property(e => e.IsApportioned)
                    .IsRequired()
                    .HasColumnName("isApportioned")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSubdivided).HasColumnName("isSubdivided");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandPoolingRate)
                    .HasColumnName("landPoolingRate")
                    .HasColumnType("decimal(10, 3)");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LandValue)
                    .HasColumnName("landValue")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LapId).HasColumnName("lapId");

                entity.Property(e => e.LastTaxPaidYear).HasColumnName("lastTaxPaidYear");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlotAddress)
                    .IsRequired()
                    .HasColumnName("plotAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.StreetLightApplicable).HasColumnName("streetLightApplicable");

                entity.Property(e => e.StreetNameId).HasColumnName("streetNameId");

                entity.Property(e => e.StructureAvailable).HasColumnName("structureAvailable");

                entity.Property(e => e.ThramNo)
                    .HasColumnName("thramNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.VacantLandTaxApplicable).HasColumnName("vacantLandTaxApplicable");

                entity.HasOne(d => d.Demkhong)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.DemkhongId)
                    .HasConstraintName("FK_mstLandDetail_ToTable_4");

                entity.HasOne(d => d.LandType)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.LandTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLandDetail_ToTable_2");

                entity.HasOne(d => d.LandUseSubCategory)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.LandUseSubCategoryId)
                    .HasConstraintName("FK_mstLandDetail_ToTable_1");

                entity.HasOne(d => d.Lap)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.LapId)
                    .HasConstraintName("FK_mstLandDetail_ToTable");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLandDetail_ToTable_6");

                entity.HasOne(d => d.StreetName)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.StreetNameId)
                    .HasConstraintName("FK_mstLandDetail_ToTable_5");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.MstLandDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_mstLandDetail_ToTable_3");
            });

            modelBuilder.Entity<MstLandServiceType>(entity =>
            {
                entity.HasKey(e => e.LandServiceTypeId)
                    .HasName("PK__tmp_ms_x__0495905C8BA8A198");

                entity.ToTable("mstLandServiceType");

                entity.Property(e => e.LandServiceTypeId).HasColumnName("landServiceTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandServiceType)
                    .IsRequired()
                    .HasColumnName("landServiceType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLandType>(entity =>
            {
                entity.HasKey(e => e.LandTypeId)
                    .HasName("PK__tmp_ms_x__2F19471395D196F7");

                entity.ToTable("mstLandType");

                entity.Property(e => e.LandTypeId)
                    .HasColumnName("landTypeId")
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.LandTypeName)
                    .IsRequired()
                    .HasColumnName("landTypeName")
                    .HasMaxLength(245)
                    .IsUnicode(false)
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasComment("Previous Property Type is Land Type No");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime")
                    .HasComment("Previous Property Type is Land Type No");
            });

            modelBuilder.Entity<MstLandUseCategory>(entity =>
            {
                entity.HasKey(e => e.LandUseCategoryId)
                    .HasName("PK__mstLandU__CBCC094E1B243DE3");

                entity.ToTable("mstLandUseCategory");

                entity.Property(e => e.LandUseCategoryId).HasColumnName("landUseCategoryId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandUseCategory)
                    .IsRequired()
                    .HasColumnName("landUseCategory")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.LandUseCategoryDescription)
                    .IsRequired()
                    .HasColumnName("landUseCategoryDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLandUseSubCategory>(entity =>
            {
                entity.HasKey(e => e.LandUseSubCategoryId)
                    .HasName("PK__tmp_ms_x__77BC5829F9717B7E");

                entity.ToTable("mstLandUseSubCategory");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandTaxId)
                    .HasColumnName("landTaxId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LandUseCategoryDescription)
                    .HasColumnName("landUseCategoryDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LandUseCategoryId).HasColumnName("landUseCategoryId");

                entity.Property(e => e.LandUseSubCategory)
                    .IsRequired()
                    .HasColumnName("landUseSubCategory")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.UdTaxId)
                    .HasColumnName("udTaxId")
                    .HasDefaultValueSql("((9))");

                entity.HasOne(d => d.LandTax)
                    .WithMany(p => p.MstLandUseSubCategoryLandTax)
                    .HasForeignKey(d => d.LandTaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLandUseSubCategory_ToTable_1");

                entity.HasOne(d => d.LandUseCategory)
                    .WithMany(p => p.MstLandUseSubCategory)
                    .HasForeignKey(d => d.LandUseCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLandUseSubCategory_ToTable");

                entity.HasOne(d => d.UdTax)
                    .WithMany(p => p.MstLandUseSubCategoryUdTax)
                    .HasForeignKey(d => d.UdTaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLandUseSubCategory_ToTable_2");
            });

            modelBuilder.Entity<MstLap>(entity =>
            {
                entity.HasKey(e => e.LapId)
                    .HasName("PK__tmp_ms_x__5CACEC59B4F4A2B0");

                entity.ToTable("mstLap");

                entity.Property(e => e.LapId).HasColumnName("lapId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LapDescription)
                    .IsRequired()
                    .HasColumnName("lapDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LapName)
                    .IsRequired()
                    .HasColumnName("lapName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstLogoSignMap>(entity =>
            {
                entity.HasKey(e => e.LogoSignMapId)
                    .HasName("PK__mstLogoS__08AB9823F7A896DE");

                entity.ToTable("mstLogoSignMap");

                entity.Property(e => e.LogoSignMapId).HasColumnName("logoSignMapId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DcdSignId).HasColumnName("dcdSignId");

                entity.Property(e => e.EsSignId).HasColumnName("esSignId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LogoId).HasColumnName("logoId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DcdSign)
                    .WithMany(p => p.MstLogoSignMap)
                    .HasForeignKey(d => d.DcdSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLogoSignMap_ToTable_1");

                entity.HasOne(d => d.EsSign)
                    .WithMany(p => p.MstLogoSignMap)
                    .HasForeignKey(d => d.EsSignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLogoSignMap_ToTable_2");

                entity.HasOne(d => d.Logo)
                    .WithMany(p => p.MstLogoSignMap)
                    .HasForeignKey(d => d.LogoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstLogoSignMap_ToTable");
            });

            modelBuilder.Entity<MstLogoUpload>(entity =>
            {
                entity.HasKey(e => e.LogoId)
                    .HasName("PK__mstLogoU__499C8F7B65146495");

                entity.ToTable("mstLogoUpload");

                entity.Property(e => e.LogoId).HasColumnName("logoId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LogoName)
                    .IsRequired()
                    .HasColumnName("logoName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.LogoPath)
                    .IsRequired()
                    .HasColumnName("logoPath")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstMaintenanceType>(entity =>
            {
                entity.HasKey(e => e.MaintenanceTypeId)
                    .HasName("PK__mstMaint__B89CEE0C094CB35D");

                entity.ToTable("mstMaintenanceType");

                entity.Property(e => e.MaintenanceTypeId).HasColumnName("maintenanceTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MaintenanceType)
                    .IsRequired()
                    .HasColumnName("maintenanceType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MaintenanceTypeDescription)
                    .IsRequired()
                    .HasColumnName("maintenanceTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstMajorHead>(entity =>
            {
                entity.HasKey(e => e.MajorHeadId)
                    .HasName("PK__mstMajor__B491427874E96778");

                entity.ToTable("mstMajorHead");

                entity.Property(e => e.MajorHeadId).HasColumnName("majorHeadId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MajorHeadCode)
                    .IsRequired()
                    .HasColumnName("majorHeadCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MajorHeadDescription)
                    .HasColumnName("majorHeadDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MajorHeadName)
                    .IsRequired()
                    .HasColumnName("majorHeadName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MajorHeadSymbol)
                    .IsRequired()
                    .HasColumnName("majorHeadSymbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstMaterialType>(entity =>
            {
                entity.HasKey(e => e.MaterialTypeId)
                    .HasName("PK__mstMater__774313706B489F21");

                entity.ToTable("mstMaterialType");

                entity.Property(e => e.MaterialTypeId).HasColumnName("materialTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MaterialType)
                    .IsRequired()
                    .HasColumnName("materialType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialTypeDescription)
                    .HasColumnName("materialTypeDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstMeasurementUnit>(entity =>
            {
                entity.HasKey(e => e.MeasurementUnitId)
                    .HasName("PK__mstMeasu__F066FAEA7C21CD78");

                entity.ToTable("mstMeasurementUnit");

                entity.Property(e => e.MeasurementUnitId).HasColumnName("measurementUnitId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MeasurementUnit)
                    .IsRequired()
                    .HasColumnName("measurementUnit")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MeasurementUnitDescription)
                    .HasColumnName("measurementUnitDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MeasurementUnitSymbol)
                    .IsRequired()
                    .HasColumnName("measurementUnitSymbol")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MstMinorHead>(entity =>
            {
                entity.HasKey(e => e.MinorHeadId)
                    .HasName("PK__mstMinor__FACD8957FCD2DD35");

                entity.ToTable("mstMinorHead");

                entity.Property(e => e.MinorHeadId).HasColumnName("minorHeadId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MajorHeadId).HasColumnName("majorHeadId");

                entity.Property(e => e.MinorHeadCode)
                    .IsRequired()
                    .HasColumnName("minorHeadCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MinorHeadDescription)
                    .HasColumnName("minorHeadDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MinorHeadName)
                    .IsRequired()
                    .HasColumnName("minorHeadName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MinorHeadSymbol)
                    .IsRequired()
                    .HasColumnName("minorHeadSymbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MajorHead)
                    .WithMany(p => p.MstMinorHead)
                    .HasForeignKey(d => d.MajorHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstMinorHead_ToTable");
            });

            modelBuilder.Entity<MstModificationReason>(entity =>
            {
                entity.HasKey(e => e.ModificationReasonId)
                    .HasName("PK__mstModif__6D7CE52B328A78A8");

                entity.ToTable("mstModificationReason");

                entity.Property(e => e.ModificationReasonId).HasColumnName("modificationReasonId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModificationReason)
                    .IsRequired()
                    .HasColumnName("modificationReason")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("reasonCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonDescription)
                    .HasColumnName("reasonDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstOccupation>(entity =>
            {
                entity.HasKey(e => e.OccupationId)
                    .HasName("PK__mstOccup__AD8338B03EBFB72A");

                entity.ToTable("mstOccupation");

                entity.Property(e => e.OccupationId).HasColumnName("occupationId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasColumnName("occupation")
                    .HasMaxLength(245)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstParentAttribute>(entity =>
            {
                entity.HasKey(e => e.ParentAttributeId)
                    .HasName("PK__mstParen__41ED7913F76F9B87");

                entity.ToTable("mstParentAttribute");

                entity.Property(e => e.ParentAttributeId).HasColumnName("parentAttributeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParentAttribute)
                    .IsRequired()
                    .HasColumnName("parentAttribute")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ParentAttributeDescription)
                    .HasColumnName("parentAttributeDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TertiaryAccountHeadId).HasColumnName("tertiaryAccountHeadId");

                entity.HasOne(d => d.TertiaryAccountHead)
                    .WithMany(p => p.MstParentAttribute)
                    .HasForeignKey(d => d.TertiaryAccountHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstParentAttribute_ToTable");
            });

            modelBuilder.Entity<MstParkingSlot>(entity =>
            {
                entity.HasKey(e => e.ParkingSlotId)
                    .HasName("PK__mstParki__013602D0F4A37A95");

                entity.ToTable("mstParkingSlot");

                entity.Property(e => e.ParkingSlotId).HasColumnName("parkingSlotId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingSlotDescription)
                    .HasColumnName("parkingSlotDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingSlotName)
                    .IsRequired()
                    .HasColumnName("parkingSlotName")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstParkingZone>(entity =>
            {
                entity.HasKey(e => e.ParkingZoneId)
                    .HasName("PK__mstParki__018424BBAF9FC108");

                entity.ToTable("mstParkingZone");

                entity.Property(e => e.ParkingZoneId).HasColumnName("parkingZoneId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingzoneDesc)
                    .IsRequired()
                    .HasColumnName("parkingzoneDesc")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ParkingzoneName)
                    .IsRequired()
                    .HasColumnName("parkingzoneName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstPavaRate>(entity =>
            {
                entity.HasKey(e => e.PavaRateId)
                    .HasName("PK__mstPavaR__F6C33FCEDE8D0C6B");

                entity.ToTable("mstPavaRate");

                entity.Property(e => e.PavaRateId).HasColumnName("pavaRateId");

                entity.Property(e => e.ApplicableDate)
                    .HasColumnName("applicableDate")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LandValue)
                    .HasColumnName("landValue")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.LandUseSubCategory)
                    .WithMany(p => p.MstPavaRate)
                    .HasForeignKey(d => d.LandUseSubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstPavaRate_ToTable");
            });

            modelBuilder.Entity<MstPrimaryAccountHead>(entity =>
            {
                entity.HasKey(e => e.PrimaryAccountHeadId)
                    .HasName("PK__mstPrima__7EA7DAFDE04FA09E");

                entity.ToTable("mstPrimaryAccountHead");

                entity.Property(e => e.PrimaryAccountHeadId).HasColumnName("primaryAccountHeadId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrimaryAccountHeadCode)
                    .HasColumnName("primaryAccountHeadCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryAccountHeadDescription)
                    .IsRequired()
                    .HasColumnName("primaryAccountHeadDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryAccountHeadName)
                    .IsRequired()
                    .HasColumnName("primaryAccountHeadName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryAccountHeadSymbol)
                    .IsRequired()
                    .HasColumnName("primaryAccountHeadSymbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstProcessLevel>(entity =>
            {
                entity.HasKey(e => e.ProcessLevelId)
                    .HasName("PK__mstProce__7B6B1D5B74DCBB23");

                entity.ToTable("mstProcessLevel");

                entity.Property(e => e.ProcessLevelId).HasColumnName("processLevelId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.Process2Approval).HasColumnName("process2Approval");

                entity.Property(e => e.Process3Approval).HasColumnName("process3Approval");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.MstProcessLevel)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .HasConstraintName("FK_mstProcessLevel_ToTable");
            });

            modelBuilder.Entity<MstRate>(entity =>
            {
                entity.HasKey(e => e.RateId)
                    .HasName("PK__tmp_ms_x__5705EA14C94C8CC3");

                entity.ToTable("mstRate");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effectiveDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MinimumRate)
                    .HasColumnName("minimumRate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.HasOne(d => d.Slab)
                    .WithMany(p => p.MstRate)
                    .HasForeignKey(d => d.SlabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstRate_ToTable_1");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.MstRate)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstRate_ToTable");
            });

            modelBuilder.Entity<MstRoofingType>(entity =>
            {
                entity.HasKey(e => e.RoofingTypeId)
                    .HasName("PK__mstRoofi__BC8418819C437B70");

                entity.ToTable("mstRoofingType");

                entity.Property(e => e.RoofingTypeId).HasColumnName("roofingTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoofingType)
                    .IsRequired()
                    .HasColumnName("roofingType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RoofingTypeDescription)
                    .HasColumnName("roofingTypeDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstSecondaryAccountHead>(entity =>
            {
                entity.HasKey(e => e.SecondaryAccountHeadId)
                    .HasName("PK__mstSecon__AF4D8BA32BE76322");

                entity.ToTable("mstSecondaryAccountHead");

                entity.Property(e => e.SecondaryAccountHeadId).HasColumnName("secondaryAccountHeadId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrimaryAccountHeadId).HasColumnName("primaryAccountHeadId");

                entity.Property(e => e.SecondaryAccountHeadName)
                    .IsRequired()
                    .HasColumnName("secondaryAccountHeadName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryaccountHeadCode)
                    .HasColumnName("secondaryaccountHeadCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryaccountHeadDescription)
                    .IsRequired()
                    .HasColumnName("secondaryaccountHeadDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryaccountHeadSymbol)
                    .IsRequired()
                    .HasColumnName("secondaryaccountHeadSymbol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrimaryAccountHead)
                    .WithMany(p => p.MstSecondaryAccountHead)
                    .HasForeignKey(d => d.PrimaryAccountHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstSecondaryAccountHead_ToTable");
            });

            modelBuilder.Entity<MstSection>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("PK__mstSecti__3F58FD52C3E386FB");

                entity.ToTable("mstSection");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DivisionId).HasColumnName("divisionId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SectionCode)
                    .IsRequired()
                    .HasColumnName("sectionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("sectionName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.MstSection)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstSection_ToTable");
            });

            modelBuilder.Entity<MstSlab>(entity =>
            {
                entity.HasKey(e => e.SlabId)
                    .HasName("PK__tmp_ms_x__F11335E605F61B7B");

                entity.ToTable("mstSlab");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.BuildingUnitClassId).HasColumnName("buildingUnitClassId");

                entity.Property(e => e.BuildingUnitUseTypeId).HasColumnName("buildingUnitUseTypeId");

                entity.Property(e => e.ConstructionTypeId).HasColumnName("constructionTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Define1).HasColumnName("define1");

                entity.Property(e => e.Define2).HasColumnName("define2");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effectiveDate")
                    .HasColumnType("date");

                entity.Property(e => e.IndustryTypeId).HasColumnName("industryTypeId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LeaseActivityTypeId).HasColumnName("leaseActivityTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SlabEnd)
                    .HasColumnName("slabEnd")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SlabName)
                    .IsRequired()
                    .HasColumnName("slabName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SlabStart)
                    .HasColumnName("slabStart")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.HasOne(d => d.BuildingUnitClass)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.BuildingUnitClassId)
                    .HasConstraintName("FK_mstSlab_ToTable_2");

                entity.HasOne(d => d.BuildingUnitUseType)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.BuildingUnitUseTypeId)
                    .HasConstraintName("FK_mstSlab_ToTable_1");

                entity.HasOne(d => d.ConstructionType)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.ConstructionTypeId)
                    .HasConstraintName("FK_mstSlab_ToTable_4");

                entity.HasOne(d => d.LandUseSubCategory)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.LandUseSubCategoryId)
                    .HasConstraintName("FK_mstSlab_ToTable_3");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstSlab_ToTable");

                entity.HasOne(d => d.WaterLineType)
                    .WithMany(p => p.MstSlab)
                    .HasForeignKey(d => d.WaterLineTypeId)
                    .HasConstraintName("FK_mstSlab_ToTable_5");
            });

            modelBuilder.Entity<MstStallLocation>(entity =>
            {
                entity.HasKey(e => e.StallLocationId)
                    .HasName("PK__mstStall__EBC69283A85B0F29");

                entity.ToTable("mstStallLocation");

                entity.Property(e => e.StallLocationId).HasColumnName("stallLocationId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StallLocation)
                    .IsRequired()
                    .HasColumnName("stallLocation")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StallLocationDetail)
                    .IsRequired()
                    .HasColumnName("stallLocationDetail")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStallType>(entity =>
            {
                entity.HasKey(e => e.StallTypeId)
                    .HasName("PK__mstStall__CF47B1B564268EAF");

                entity.ToTable("mstStallType");

                entity.Property(e => e.StallTypeId).HasColumnName("stallTypeId");

                entity.Property(e => e.StallType)
                    .IsRequired()
                    .HasColumnName("stallType")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStreetName>(entity =>
            {
                entity.HasKey(e => e.StreetNameId)
                    .HasName("PK__mstStree__2FC39A06825486F2");

                entity.ToTable("mstStreetName");

                entity.Property(e => e.StreetNameId).HasColumnName("streetNameId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreationOn)
                    .HasColumnName("creationOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("streetName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStructureCategory>(entity =>
            {
                entity.HasKey(e => e.StructureCategoryId)
                    .HasName("PK__mstStruc__344E4D2D5CEBBB50");

                entity.ToTable("mstStructureCategory");

                entity.Property(e => e.StructureCategoryId).HasColumnName("structureCategoryId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StructureCategory)
                    .IsRequired()
                    .HasColumnName("structureCategory")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StructureCategoryDescription)
                    .IsRequired()
                    .HasColumnName("structureCategoryDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStructureType>(entity =>
            {
                entity.HasKey(e => e.StructureTypeId)
                    .HasName("PK__mstStruc__D7188B4C5541CA89");

                entity.ToTable("mstStructureType");

                entity.Property(e => e.StructureTypeId).HasColumnName("structureTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StructureType)
                    .IsRequired()
                    .HasColumnName("structureType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StructureTypeDescription)
                    .IsRequired()
                    .HasColumnName("structureTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstSuppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__mstSuppl__DB8E62ED788CE0B4");

                entity.ToTable("mstSuppliers");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LicenseNo)
                    .IsRequired()
                    .HasColumnName("licenseNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasColumnName("supplierAddress")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCode)
                    .IsRequired()
                    .HasColumnName("supplierCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierContactNumber)
                    .HasColumnName("supplierContactNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierContactPerson)
                    .HasColumnName("supplierContactPerson")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierFaxNumber)
                    .HasColumnName("supplierFaxNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnName("supplierName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstTaxMaster>(entity =>
            {
                entity.HasKey(e => e.TaxId)
                    .HasName("PK__tmp_ms_x__24D28839C5F7FA29");

                entity.ToTable("mstTaxMaster");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DetailHeadId).HasColumnName("detailHeadId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasColumnName("taxName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.DetailHead)
                    .WithMany(p => p.MstTaxMaster)
                    .HasForeignKey(d => d.DetailHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxMaster_ToTable");
            });

            modelBuilder.Entity<MstTaxPayerProfile>(entity =>
            {
                entity.HasKey(e => e.TaxPayerId)
                    .HasName("PK__tmp_ms_x__4C0CE6D3475CB6B6");

                entity.ToTable("mstTaxPayerProfile");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.BankAccountNo)
                    .HasColumnName("bankAccountNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.BankBranchId).HasColumnName("bankBranchId");

                entity.Property(e => e.CAddress)
                    .HasColumnName("cAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CDzongkhagId).HasColumnName("cDzongkhagId");

                entity.Property(e => e.CensusSmssentYrId).HasColumnName("censusSMSsentYrId");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contactPerson")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("date");

                entity.Property(e => e.OccupationId).HasColumnName("occupationId");

                entity.Property(e => e.PVillageId).HasColumnName("pVillageId");

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phoneNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerTypeId).HasColumnName("taxPayerTypeId");

                entity.Property(e => e.TaxSmssentYearId).HasColumnName("taxSMSSentYearId");

                entity.Property(e => e.TitleId).HasColumnName("titleId");

                entity.Property(e => e.Tpn)
                    .HasColumnName("tpn")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Ttin)
                    .IsRequired()
                    .HasColumnName("ttin")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VendorTypeId).HasColumnName("vendorTypeId");

                entity.Property(e => e.WorkingAgency)
                    .HasColumnName("workingAgency")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankBranch)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.BankBranchId)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_5");

                entity.HasOne(d => d.CDzongkhag)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.CDzongkhagId)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_2");

                entity.HasOne(d => d.CensusSmssentYr)
                    .WithMany(p => p.MstTaxPayerProfileCensusSmssentYr)
                    .HasForeignKey(d => d.CensusSmssentYrId)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_8");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_4");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_3");

                entity.HasOne(d => d.PVillage)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.PVillageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_1");

                entity.HasOne(d => d.TaxPayerType)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.TaxPayerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPayer_ToTable");

                entity.HasOne(d => d.TaxSmssentYear)
                    .WithMany(p => p.MstTaxPayerProfileTaxSmssentYear)
                    .HasForeignKey(d => d.TaxSmssentYearId)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_7");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPayer_ToTable_6");

                entity.HasOne(d => d.VendorType)
                    .WithMany(p => p.MstTaxPayerProfile)
                    .HasForeignKey(d => d.VendorTypeId)
                    .HasConstraintName("FK_mstTaxPayerProfile_ToTable");
            });

            modelBuilder.Entity<MstTaxPeriod>(entity =>
            {
                entity.HasKey(e => e.TaxPeriodId)
                    .HasName("PK__tmp_ms_x__C7AB898DE43119BD");

                entity.ToTable("mstTaxPeriod");

                entity.Property(e => e.TaxPeriodId).HasColumnName("taxPeriodId");

                entity.Property(e => e.CalendarYearId).HasColumnName("calendarYearId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effectiveDate")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PenaltyOrRate)
                    .HasColumnName("penaltyOrRate")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.HasOne(d => d.CalendarYear)
                    .WithMany(p => p.MstTaxPeriod)
                    .HasForeignKey(d => d.CalendarYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPeriod_ToTable");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.MstTaxPeriod)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTaxPeriod_ToTable_1");
            });

            modelBuilder.Entity<MstTaxTypeClassification>(entity =>
            {
                entity.HasKey(e => e.TaxTypeClassificationId)
                    .HasName("PK__mstTaxTy__D73D1D10F48FC736");

                entity.ToTable("mstTaxTypeClassification");

                entity.Property(e => e.TaxTypeClassificationId).HasColumnName("taxTypeClassificationId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxTypeClassificationName)
                    .IsRequired()
                    .HasColumnName("taxTypeClassificationName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TaxTypeDescription)
                    .HasColumnName("taxTypeDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstTechnicalAttribute>(entity =>
            {
                entity.HasKey(e => e.TechnicalAttributeId)
                    .HasName("PK__mstTechn__A08C0CF658193992");

                entity.ToTable("mstTechnicalAttribute");

                entity.Property(e => e.TechnicalAttributeId).HasColumnName("technicalAttributeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParentAttributeId).HasColumnName("parentAttributeId");

                entity.Property(e => e.TechnicalAttribute)
                    .IsRequired()
                    .HasColumnName("technicalAttribute")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalAttributeDescription)
                    .HasColumnName("technicalAttributeDescription")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentAttribute)
                    .WithMany(p => p.MstTechnicalAttribute)
                    .HasForeignKey(d => d.ParentAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTechnicalAttribute_ToTable");
            });

            modelBuilder.Entity<MstTertiaryAccountHead>(entity =>
            {
                entity.HasKey(e => e.TertiaryAccountHeadId)
                    .HasName("PK__mstTerti__921E8F638FA622F2");

                entity.ToTable("mstTertiaryAccountHead");

                entity.Property(e => e.AssetType)
                    .HasColumnName("assetType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.SecondaryAccountHeadId).HasColumnName("secondaryAccountHeadId");

                entity.Property(e => e.TertiaryAccountHeadCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TertiaryAccountHeadDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TertiaryAccountHeadName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TertiaryAccountHeadSymbol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SecondaryAccountHead)
                    .WithMany(p => p.MstTertiaryAccountHead)
                    .HasForeignKey(d => d.SecondaryAccountHeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTertiaryAccountHead_ToTable");
            });

            modelBuilder.Entity<MstTransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeId)
                    .HasName("PK__mstTrans__483B179A56BE9904");

                entity.ToTable("mstTransactionType");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.HasApprovalProcess).HasColumnName("hasApprovalProcess");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.Node)
                    .IsRequired()
                    .HasColumnName("node")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transactionType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionTypeDescription)
                    .HasColumnName("transactionTypeDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.MstTransactionType)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTransactionType_ToTable");
            });

            modelBuilder.Entity<MstTransactionTypeTaxMap>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeTaxMapId)
                    .HasName("PK__mstTrans__1D2CBA72ECB7EA30");

                entity.ToTable("mstTransactionTypeTaxMap");

                entity.Property(e => e.TransactionTypeTaxMapId).HasColumnName("transactionTypeTaxMapId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.MstTransactionTypeTaxMap)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTransactionTypeTaxMap_ToTable_1");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.MstTransactionTypeTaxMap)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstTransactionTypeTaxMap_ToTable");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("mstUser");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DivisionId).HasColumnName("divisionId");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Eid)
                    .HasColumnName("eid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.TitleId).HasColumnName("titleId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_mstUser_ToTable_3");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstUser_ToTable");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_mstUser_ToTable_1");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.MstUser)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstUser_ToTable_2");
            });

            modelBuilder.Entity<MstVillage>(entity =>
            {
                entity.HasKey(e => e.VillageId)
                    .HasName("PK__tmp_ms_x__C53B3E8886C236B1");

                entity.ToTable("mstVillage");

                entity.Property(e => e.VillageId).HasColumnName("villageId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.GewogId).HasColumnName("gewogId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.VillageName)
                    .IsRequired()
                    .HasColumnName("villageName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gewog)
                    .WithMany(p => p.MstVillage)
                    .HasForeignKey(d => d.GewogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstVillage_ToTable");
            });

            modelBuilder.Entity<MstWaterConnection>(entity =>
            {
                entity.HasKey(e => e.WaterConnectionId)
                    .HasName("PK__tmp_ms_x__5874CD6422C93494");

                entity.ToTable("mstWaterConnection");

                entity.Property(e => e.WaterConnectionId).HasColumnName("waterConnectionId");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTypeId).HasColumnName("changeTypeId");

                entity.Property(e => e.ConnectionDate)
                    .HasColumnName("connectionDate")
                    .HasColumnType("date");

                entity.Property(e => e.ConsumerNo)
                    .IsRequired()
                    .HasColumnName("consumerNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnName("disconnectDate")
                    .HasColumnType("date");

                entity.Property(e => e.FlatNo)
                    .HasColumnName("flatNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.InitialReading)
                    .HasColumnName("initialReading")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsPermanentConnection).HasColumnName("isPermanentConnection");

                entity.Property(e => e.IsPermanentDisconnect).HasColumnName("isPermanentDisconnect");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MaxReadingDate)
                    .HasColumnName("maxReadingDate")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.NoOfUnits)
                    .HasColumnName("noOfUnits")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrganisationName)
                    .HasColumnName("organisationName")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerTypeId).HasColumnName("ownerTypeId");

                entity.Property(e => e.PrimaryMobileNo)
                    .IsRequired()
                    .HasColumnName("primaryMobileNo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ReconnectionDate)
                    .HasColumnName("reconnectionDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNo)
                    .HasColumnName("secondaryMobileNo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SewarageConnectedBy).HasColumnName("sewarageConnectedBy");

                entity.Property(e => e.SewarageConnectionDate)
                    .HasColumnName("sewarageConnectionDate")
                    .HasColumnType("date");

                entity.Property(e => e.SewerageConnection).HasColumnName("sewerageConnection");

                entity.Property(e => e.SolidWaste).HasColumnName("solidWaste");

                entity.Property(e => e.StandardConsumption).HasColumnName("standardConsumption");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.WaterMeterNo)
                    .IsRequired()
                    .HasColumnName("waterMeterNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_7");

                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_6");

                entity.HasOne(d => d.WaterConnectionStatus)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.WaterConnectionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_2");

                entity.HasOne(d => d.WaterConnectionType)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.WaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_3");

                entity.HasOne(d => d.WaterLineType)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.WaterLineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_4");

                entity.HasOne(d => d.WaterMeterType)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.WaterMeterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_1");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.MstWaterConnection)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mstWaterConnection_ToTable_5");
            });

            modelBuilder.Entity<MstWaterConnectionType>(entity =>
            {
                entity.HasKey(e => e.WaterConnectionTypeId)
                    .HasName("PK__mstWater__E5520EB046F99861");

                entity.ToTable("mstWaterConnectionType");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.WaterConnectionType)
                    .IsRequired()
                    .HasColumnName("waterConnectionType")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstWaterLineType>(entity =>
            {
                entity.HasKey(e => e.WaterLineTypeId)
                    .HasName("PK__mstWater__C3D0ADB30FB8324D");

                entity.ToTable("mstWaterLineType");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.WaterLineType)
                    .IsRequired()
                    .HasColumnName("waterLineType")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstWaterMeterType>(entity =>
            {
                entity.HasKey(e => e.WaterMeterTypeId)
                    .HasName("PK__mstWater__A20AD9E04A371140");

                entity.ToTable("mstWaterMeterType");

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.WaterMeterType)
                    .IsRequired()
                    .HasColumnName("waterMeterType")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstZone>(entity =>
            {
                entity.HasKey(e => e.ZoneId)
                    .HasName("PK__mstZone__2F75DF798BB5D7A6");

                entity.ToTable("mstZone");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasColumnName("zoneCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneName)
                    .IsRequired()
                    .HasColumnName("zoneName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneReader)
                    .IsRequired()
                    .HasColumnName("zoneReader")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OccupancyCertificateUnitMap>(entity =>
            {
                entity.ToTable("occupancyCertificateUnitMap");

                entity.Property(e => e.OccupancyCertificateUnitMapId).HasColumnName("occupancyCertificateUnitMapId");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.OccupancyCertificateApplicationId).HasColumnName("occupancyCertificateApplicationId");
            });

            modelBuilder.Entity<TblAssetDepreciation>(entity =>
            {
                entity.HasKey(e => e.DepreciationId)
                    .HasName("PK__tblAsset__62F9A1355ECCB39A");

                entity.ToTable("tblAssetDepreciation");

                entity.Property(e => e.DepreciationId).HasColumnName("depreciationId");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepreciationTypeId).HasColumnName("depreciationTypeId");

                entity.Property(e => e.DepreciationValue)
                    .HasColumnName("depreciationValue")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FinancialYearId).HasColumnName("financialYearId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.TblAssetDepreciation)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetDepreciation_ToTable");

                entity.HasOne(d => d.DepreciationType)
                    .WithMany(p => p.TblAssetDepreciation)
                    .HasForeignKey(d => d.DepreciationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetDepreciation_ToTable_1");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.TblAssetDepreciation)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetDepreciation_ToTable_2");
            });

            modelBuilder.Entity<TblAssetMaintenance>(entity =>
            {
                entity.HasKey(e => e.AssetMaintenanceId)
                    .HasName("PK__tblAsset__A5713FF77286DF97");

                entity.ToTable("tblAssetMaintenance");

                entity.Property(e => e.AssetMaintenanceId).HasColumnName("assetMaintenanceId");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateofNextMaintenance)
                    .HasColumnName("dateofNextMaintenance")
                    .HasColumnType("date");

                entity.Property(e => e.MaintainedById).HasColumnName("maintainedById");

                entity.Property(e => e.MaintenanceCost)
                    .HasColumnName("maintenanceCost")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaintenanceDate)
                    .HasColumnName("maintenanceDate")
                    .HasColumnType("date");

                entity.Property(e => e.MaintenanceTypeId).HasColumnName("maintenanceTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceOrderDate)
                    .HasColumnName("serviceOrderDate")
                    .HasColumnType("date");

                entity.Property(e => e.ServiceOrderNo)
                    .HasColumnName("serviceOrderNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SparePartUsed)
                    .HasColumnName("sparePartUsed")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.TblAssetMaintenance)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetMaintenance_ToTable");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.TblAssetMaintenance)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetMaintenance_ToTable_1");
            });

            modelBuilder.Entity<TblAssetTransfer>(entity =>
            {
                entity.HasKey(e => e.AssetTransferId)
                    .HasName("PK__tblAsset__172F86F3CF6AFD57");

                entity.ToTable("tblAssetTransfer");

                entity.Property(e => e.AssetTransferId).HasColumnName("assetTransferId");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.AssetTransferTypeId).HasColumnName("assetTransferTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePersonFrom)
                    .HasColumnName("responsiblePersonFrom")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePersonTo)
                    .HasColumnName("responsiblePersonTo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransferDate)
                    .HasColumnName("transferDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransferFromDivisionId).HasColumnName("transferFromDivisionId");

                entity.Property(e => e.TransferFromSectionId).HasColumnName("transferFromSectionId");

                entity.Property(e => e.TransferToDivisionId).HasColumnName("transferToDivisionId");

                entity.Property(e => e.TransferToSectionId).HasColumnName("transferToSectionId");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.TblAssetTransfer)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetTransfer_ToTable");

                entity.HasOne(d => d.AssetTransferType)
                    .WithMany(p => p.TblAssetTransfer)
                    .HasForeignKey(d => d.AssetTransferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAssetTransfer_ToTable_1");
            });

            modelBuilder.Entity<TblBfsTransactiondetails>(entity =>
            {
                entity.HasKey(e => e.BfsTransactionDetailId)
                    .HasName("PK__tblBfsTr__43AC77CE8AB1C902");

                entity.ToTable("tblBfsTransactiondetails");

                entity.Property(e => e.BfsTransactionDetailId).HasColumnName("bfsTransactionDetailId");

                entity.Property(e => e.BfsBankId)
                    .HasColumnName("bfs_bankId")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BfsBankName)
                    .HasColumnName("bfs_bankName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BfsBenfBankCode)
                    .HasColumnName("bfs_benfBankCode")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsBenfId)
                    .HasColumnName("bfs_benfId")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsBenfTxnTime)
                    .HasColumnName("bfs_benfTxnTime")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsBfsTxnId)
                    .HasColumnName("bfs_bfsTxnId")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsChecksum)
                    .HasColumnName("bfs_checksum")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BfsDebitAuthCode)
                    .HasColumnName("bfs_debitAuthCode")
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.BfsDebitAuthNo)
                    .HasColumnName("bfs_debitAuthNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BfsMsgType)
                    .HasColumnName("bfs_msgType")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsOrderNo)
                    .HasColumnName("bfs_orderNo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BfsPaymentDesc)
                    .HasColumnName("bfs_paymentDesc")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BfsRemitterAccNo)
                    .HasColumnName("bfs_remitterAccNo")
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.BfsRemitterBankId)
                    .HasColumnName("bfs_remitterBankId")
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.Property(e => e.BfsRemitterEmail)
                    .HasColumnName("bfs_remitterEmail")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BfsRemitterName)
                    .HasColumnName("bfs_remitterName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BfsRemitterOtp)
                    .HasColumnName("bfs_remitterOtp")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BfsResponseChecksum)
                    .HasColumnName("bfs_responseChecksum")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BfsResponseCode)
                    .HasColumnName("bfs_responseCode")
                    .IsUnicode(false);

                entity.Property(e => e.BfsResponseDesc)
                    .HasColumnName("bfs_responseDesc")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BfsStatusState)
                    .HasColumnName("bfs_statusState")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BfsTxnAmount)
                    .HasColumnName("bfs_txnAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BfsTxnCurrency)
                    .HasColumnName("bfs_txnCurrency")
                    .HasMaxLength(230)
                    .IsUnicode(false);

                entity.Property(e => e.BfsTxnTime)
                    .HasColumnName("bfs_txnTime")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BfsVersion)
                    .HasColumnName("bfs_version")
                    .HasMaxLength(230)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandIds)
                    .HasColumnName("demandIds")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBuildingOwnership>(entity =>
            {
                entity.HasKey(e => e.BuildingOwnershipId)
                    .HasName("PK__tblBuild__AE57EA906BF0583B");

                entity.ToTable("tblBuildingOwnership");

                entity.Property(e => e.BuildingOwnershipId).HasColumnName("buildingOwnershipId");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");

                entity.Property(e => e.DeletedOn)
                    .HasColumnName("deletedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BuildingDetail)
                    .WithMany(p => p.TblBuildingOwnership)
                    .HasForeignKey(d => d.BuildingDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBuildingOwnership_ToTable_1");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TblBuildingOwnership)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBuildingOwnership_ToTable");
            });

            modelBuilder.Entity<TblComplainDetail>(entity =>
            {
                entity.HasKey(e => e.ComplainDetailId)
                    .HasName("PK__tmp_ms_x__4E267F1B8EC213A0");

                entity.ToTable("tblComplainDetail");

                entity.Property(e => e.ComplainDetailId).HasColumnName("complainDetailId");

                entity.Property(e => e.ComplainApprovalRemarks)
                    .HasColumnName("complainApprovalRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ComplainApprovedBy).HasColumnName("complainApprovedBy");

                entity.Property(e => e.ComplainApprovedOn)
                    .HasColumnName("complainApprovedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComplainRejectRemarks)
                    .HasColumnName("complainRejectRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ComplainRejectedBy).HasColumnName("complainRejectedBy");

                entity.Property(e => e.ComplainRejectedOn)
                    .HasColumnName("complainRejectedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComplainReviewRemarks)
                    .HasColumnName("complainReviewRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ComplainReviewedBy).HasColumnName("complainReviewedBy");

                entity.Property(e => e.ComplainReviewedOn)
                    .HasColumnName("complainReviewedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComplainStatusId)
                    .HasColumnName("complainStatusId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ComplainTypeId).HasColumnName("complainTypeId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.DeadLine)
                    .HasColumnName("deadLine ")
                    .HasColumnType("datetime");

                entity.Property(e => e.Instruction)
                    .IsRequired()
                    .HasColumnName("instruction")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.WaterConnectionId).HasColumnName("waterConnectionId");

                entity.HasOne(d => d.ComplainStatus)
                    .WithMany(p => p.TblComplainDetail)
                    .HasForeignKey(d => d.ComplainStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComplainDetail_ToTable_1");

                entity.HasOne(d => d.ComplainType)
                    .WithMany(p => p.TblComplainDetail)
                    .HasForeignKey(d => d.ComplainTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComplainDetail_ToTable");

                entity.HasOne(d => d.WaterConnection)
                    .WithMany(p => p.TblComplainDetail)
                    .HasForeignKey(d => d.WaterConnectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComplainDetail_ToTable_2");
            });

            modelBuilder.Entity<TblComplainReading>(entity =>
            {
                entity.HasKey(e => e.ComplainReadingId)
                    .HasName("PK__tmp_ms_x__EE829CAD8297FB96");

                entity.ToTable("tblComplainReading");

                entity.Property(e => e.ComplainReadingId).HasColumnName("complainReadingId");

                entity.Property(e => e.ComplainDetailId).HasColumnName("complainDetailId");

                entity.Property(e => e.ComplainPhotoPath)
                    .IsRequired()
                    .HasColumnName("complainPhotoPath")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.ComplainDetail)
                    .WithMany(p => p.TblComplainReading)
                    .HasForeignKey(d => d.ComplainDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComplainReading_ToTable");
            });

            modelBuilder.Entity<TblConstructionApprovedDetail>(entity =>
            {
                entity.HasKey(e => e.ConstructionApprovedDetailId)
                    .HasName("PK__tblConst__AAFABA4AE275EB3E");

                entity.ToTable("tblConstructionApprovedDetail");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.G2cApplicationNo)
                    .IsRequired()
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScrutinyFee)
                    .HasColumnName("scrutinyFee")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceFee)
                    .HasColumnName("serviceFee")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkLevelId).HasColumnName("workLevelId");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TblConstructionApprovedDetail)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConstructionApprovedDetail_ToTable");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.TblConstructionApprovedDetail)
                    .HasForeignKey(d => d.WorkLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblConstructionApprovedDetail_ToTable_1");
            });

            modelBuilder.Entity<TblDemand>(entity =>
            {
                entity.HasKey(e => e.DemandId)
                    .HasName("PK__tmp_ms_x__B160C117D11902CB");

                entity.ToTable("tblDemand");

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantId");

                entity.Property(e => e.BfsTransactionDetailId).HasColumnName("bfsTransactionDetailId");

                entity.Property(e => e.BillingDate)
                    .HasColumnName("billingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.CalendarYearId).HasColumnName("calendarYearId");

                entity.Property(e => e.CancelDemandAmount)
                    .HasColumnName("cancelDemandAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CancelTotalAmount)
                    .HasColumnName("cancelTotalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandAmount)
                    .HasColumnName("demandAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.EcRenewalId).HasColumnName("ecRenewalId");

                entity.Property(e => e.ExemptionAmount)
                    .HasColumnName("exemptionAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExemptionLetter)
                    .HasColumnName("exemptionLetter")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FinancialYearId).HasColumnName("financialYearId");

                entity.Property(e => e.G2cApplicationNo)
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HouseRentDemandDetailId).HasColumnName("houseRentDemandDetailId");

                entity.Property(e => e.IsCancelled).HasColumnName("isCancelled");

                entity.Property(e => e.IsPaymentMade).HasColumnName("isPaymentMade");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandLeaseDemandDetailId).HasColumnName("landLeaseDemandDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MiscellaneousRecordId).HasColumnName("miscellaneousRecordId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingDemandDetailId).HasColumnName("parkingDemandDetailId");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("paymentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StallDemandDetailId).HasColumnName("stallDemandDetailId");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterMeterReadingId).HasColumnName("waterMeterReadingId");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.ApplicantId)
                    .HasConstraintName("FK_tblDemand_ToTable_6");

                entity.HasOne(d => d.BfsTransactionDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.BfsTransactionDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_16");

                entity.HasOne(d => d.BuildingUnitDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.BuildingUnitDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_13");

                entity.HasOne(d => d.CalendarYear)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.CalendarYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemand_ToTable_1");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemand_ToTable");

                entity.HasOne(d => d.EcRenewal)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.EcRenewalId)
                    .HasConstraintName("FK_tblDemand_ToTable_7");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemand_ToTable_2");

                entity.HasOne(d => d.HouseRentDemandDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.HouseRentDemandDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_11");

                entity.HasOne(d => d.LandLeaseDemandDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.LandLeaseDemandDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_8");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .HasConstraintName("FK_tblDemand_ToTable_5");

                entity.HasOne(d => d.MiscellaneousRecord)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.MiscellaneousRecordId)
                    .HasConstraintName("FK_tblDemand_ToTable_12");

                entity.HasOne(d => d.ParkingDemandDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.ParkingDemandDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_9");

                entity.HasOne(d => d.StallDemandDetail)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.StallDemandDetailId)
                    .HasConstraintName("FK_tblDemand_ToTable_10");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemand_ToTable_3");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemand_ToTable_4");

                entity.HasOne(d => d.UnScheduledParkingRecord)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.UnScheduledParkingRecordId)
                    .HasConstraintName("FK_tblDemand_ToTable_15");

                entity.HasOne(d => d.WaterMeterReading)
                    .WithMany(p => p.TblDemand)
                    .HasForeignKey(d => d.WaterMeterReadingId)
                    .HasConstraintName("FK_tblDemand_ToTable_14");
            });

            modelBuilder.Entity<TblDemandCancel>(entity =>
            {
                entity.HasKey(e => e.DemandCancelId)
                    .HasName("PK__tmp_ms_x__506B519B770434FE");

                entity.ToTable("tblDemandCancel");

                entity.Property(e => e.DemandCancelId).HasColumnName("demandCancelId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCancelAmount)
                    .HasColumnName("totalCancelAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblDemandCancel)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDemandCancel_ToTable");
            });

            modelBuilder.Entity<TblDemandLedgerPaymentUpdate>(entity =>
            {
                entity.HasKey(e => e.PaymentUpdateId)
                    .HasName("PK__tblDeman__CA02BC858C4CE621");

                entity.ToTable("tblDemandLedgerPaymentUpdate");

                entity.Property(e => e.PaymentUpdateId).HasColumnName("paymentUpdateId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId).HasColumnName("ledgerId");

                entity.Property(e => e.NewAmount)
                    .HasColumnName("newAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OldAmount)
                    .HasColumnName("oldAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentLedgerId).HasColumnName("paymentLedgerId");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.TblDemandLedgerPaymentUpdate)
                    .HasForeignKey(d => d.DemandId)
                    .HasConstraintName("FK_tblDemandLedgerPaymentUpdate_ToTable_1");

                entity.HasOne(d => d.Ledger)
                    .WithMany(p => p.TblDemandLedgerPaymentUpdate)
                    .HasForeignKey(d => d.LedgerId)
                    .HasConstraintName("FK_tblDemandLedgerPaymentUpdate_ToTable");

                entity.HasOne(d => d.PaymentLedger)
                    .WithMany(p => p.TblDemandLedgerPaymentUpdate)
                    .HasForeignKey(d => d.PaymentLedgerId)
                    .HasConstraintName("FK_tblDemandLedgerPaymentUpdate_ToTable_2");
            });

            modelBuilder.Entity<TblDemandNo>(entity =>
            {
                entity.HasKey(e => e.DemandNoId)
                    .HasName("PK__tmp_ms_x__F005DF7AAB5C0F5A");

                entity.ToTable("tblDemandNo");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandNo)
                    .IsRequired()
                    .HasColumnName("demandNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DemandYear).HasColumnName("demandYear");

                entity.Property(e => e.Sl).HasColumnName("sl");
            });

            modelBuilder.Entity<TblDeposit>(entity =>
            {
                entity.HasKey(e => e.DepositId)
                    .HasName("PK__tmp_ms_x__53F0C164E40AEB61");

                entity.ToTable("tblDeposit");

                entity.Property(e => e.DepositId).HasColumnName("depositId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepositAmount)
                    .HasColumnName("depositAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DepositDate)
                    .HasColumnName("depositDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentFromDate)
                    .HasColumnName("paymentFromDate")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentLedgerId).HasColumnName("paymentLedgerId");

                entity.Property(e => e.PaymentStatusId)
                    .HasColumnName("paymentStatusId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PaymentToDate)
                    .HasColumnName("paymentToDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.PaymentLedger)
                    .WithMany(p => p.TblDeposit)
                    .HasForeignKey(d => d.PaymentLedgerId)
                    .HasConstraintName("FK_tblDeposit_ToTable");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.TblDeposit)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_tblDeposit_ToTable_1");
            });

            modelBuilder.Entity<TblEcdetail>(entity =>
            {
                entity.HasKey(e => e.EcDetailId)
                    .HasName("PK__tblECdet__773692DD37815465");

                entity.ToTable("tblECdetail");

                entity.Property(e => e.EcDetailId).HasColumnName("ecDetailId");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantId");

                entity.Property(e => e.ApprovalOn)
                    .HasColumnName("approvalOn")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalRemarks)
                    .HasColumnName("approvalRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approvalStatusId");

                entity.Property(e => e.ApprovedBy).HasColumnName("approvedBy");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EcActivityTypeId).HasColumnName("ecActivityTypeId");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.IndustryTypeId).HasColumnName("industryTypeId");

                entity.Property(e => e.InitialAmount)
                    .HasColumnName("initialAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectCloseDate)
                    .HasColumnName("projectCloseDate")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectCloseRemarks)
                    .HasColumnName("projectCloseRemarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectClosedBy).HasColumnName("projectClosedBy");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("projectName")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusId).HasColumnName("projectStatusId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.TblEcdetail)
                    .HasForeignKey(d => d.ApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblECdetail_ToTable");

                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.TblEcdetail)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_tblECdetail_ToTable_4");

                entity.HasOne(d => d.EcActivityType)
                    .WithMany(p => p.TblEcdetail)
                    .HasForeignKey(d => d.EcActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblECdetail_ToTable_1");

                entity.HasOne(d => d.IndustryType)
                    .WithMany(p => p.TblEcdetail)
                    .HasForeignKey(d => d.IndustryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblECdetail_ToTable_2");

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany(p => p.TblEcdetail)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .HasConstraintName("FK_tblECdetail_ToTable_3");
            });

            modelBuilder.Entity<TblEcrenewalDetail>(entity =>
            {
                entity.HasKey(e => e.EcRenewalId)
                    .HasName("PK__tblECRen__26765D9F0FA2716B");

                entity.ToTable("tblECRenewalDetail");

                entity.Property(e => e.EcRenewalId).HasColumnName("ecRenewalId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CalendarYear).HasColumnName("calendarYear");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.EcDetailId).HasColumnName("ecDetailId");

                entity.Property(e => e.EcRefNo)
                    .HasColumnName("ecRefNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EcSl).HasColumnName("ecSl");

                entity.Property(e => e.EcUseTypeId).HasColumnName("ecUseTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ValidUpTo)
                    .HasColumnName("validUpTo")
                    .HasColumnType("date");

                entity.HasOne(d => d.EcDetail)
                    .WithMany(p => p.TblEcrenewalDetail)
                    .HasForeignKey(d => d.EcDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblECRenewalDetail_ToTable_1");

                entity.HasOne(d => d.EcUseType)
                    .WithMany(p => p.TblEcrenewalDetail)
                    .HasForeignKey(d => d.EcUseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblECRenewalDetail_ToTable");
            });

            modelBuilder.Entity<TblEsakorThramJointOwnerDetail>(entity =>
            {
                entity.HasKey(e => e.ESakorThramOwnerDetailId)
                    .HasName("PK__tblEsako__4D62E72625686D76");

                entity.ToTable("tblEsakorThramJointOwnerDetail");

                entity.Property(e => e.ESakorThramOwnerDetailId)
                    .HasColumnName("eSakorThramOwnerDetailId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationId).HasColumnName("applicationId");

                entity.Property(e => e.ApprovalStatus).HasColumnName("approvalStatus");

                entity.Property(e => e.ApprovedOrRejectOn)
                    .HasColumnName("approvedOrRejectOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedRejectedBy).HasColumnName("approvedRejectedBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OwnName)
                    .IsRequired()
                    .HasColumnName("ownName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerCid)
                    .IsRequired()
                    .HasColumnName("ownerCid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerStatus)
                    .HasColumnName("ownerStatus")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ThramNo)
                    .IsRequired()
                    .HasColumnName("thramNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionFee)
                    .HasColumnName("transactionFee")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transactionType")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEsakorThramPlotDetail>(entity =>
            {
                entity.HasKey(e => e.ESakorThramPlotTransactionId)
                    .HasName("PK__tmp_ms_x__8ADF032AEDFA40D8");

                entity.ToTable("tblEsakorThramPlotDetail");

                entity.Property(e => e.ESakorThramPlotTransactionId).HasColumnName("eSakorThramPlotTransactionId");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationId");

                entity.Property(e => e.ApprovalStatus).HasColumnName("approvalStatus");

                entity.Property(e => e.ApprovedOrRejectOn)
                    .HasColumnName("approvedOrRejectOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedRejectedBy).HasColumnName("approvedRejectedBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NetArea)
                    .HasColumnName("netArea")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OwnName)
                    .IsRequired()
                    .HasColumnName("ownName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerCid)
                    .IsRequired()
                    .HasColumnName("ownerCid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerType)
                    .IsRequired()
                    .HasColumnName("ownerType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PartyType)
                    .HasColumnName("partyType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PlotId)
                    .IsRequired()
                    .HasColumnName("plotId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlotStatus)
                    .HasColumnName("plotStatus")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrecinctName)
                    .IsRequired()
                    .HasColumnName("precinctName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ThramNo)
                    .IsRequired()
                    .HasColumnName("thramNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThramStatus)
                    .HasColumnName("thramStatus")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionFee)
                    .HasColumnName("transactionFee")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transactionType")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEsakorTransaction>(entity =>
            {
                entity.HasKey(e => e.EsakorTransactionId);

                entity.ToTable("tblEsakorTransaction");

                entity.Property(e => e.EsakorTransactionId).HasColumnName("esakorTransactionId");

                entity.Property(e => e.ApprovalStatus).HasColumnName("approvalStatus");

                entity.Property(e => e.ApprovedOrRejectOn)
                    .HasColumnName("approvedOrRejectOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedRejectedBy).HasColumnName("approvedRejectedBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Precinct)
                    .IsRequired()
                    .HasColumnName("precinct")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousPlotId)
                    .IsRequired()
                    .HasColumnName("previousPlotId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousThramNo)
                    .IsRequired()
                    .HasColumnName("previousThramNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalArea)
                    .HasColumnName("totalArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TranfereeOwnershipType)
                    .HasColumnName("tranfereeOwnershipType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TranferorNetArea)
                    .HasColumnName("tranferorNetArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TranferorOwnershipType)
                    .IsRequired()
                    .HasColumnName("tranferorOwnershipType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TranferorPlr)
                    .HasColumnName("tranferorPLR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionApproveDate)
                    .HasColumnName("transactionApproveDate")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionNo)
                    .IsRequired()
                    .HasColumnName("transactionNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transactionType")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransactorType)
                    .IsRequired()
                    .HasColumnName("transactorType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Transferor/Transferee");

                entity.Property(e => e.TransfereeCid)
                    .HasColumnName("transfereeCid")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TransfereeName)
                    .HasColumnName("transfereeName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransfereeNetArea)
                    .HasColumnName("transfereeNetArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransfereePlr)
                    .HasColumnName("transfereePLR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransferereePlotId)
                    .HasColumnName("transferereePlotId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransferereeThramNo)
                    .HasColumnName("transferereeThramNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransfererorPlotId)
                    .HasColumnName("transfererorPlotId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransferorCid)
                    .IsRequired()
                    .HasColumnName("transferorCid")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TransferorName)
                    .IsRequired()
                    .HasColumnName("transferorName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransferorThramNo)
                    .HasColumnName("transferorThramNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFinancialInformation>(entity =>
            {
                entity.HasKey(e => e.FinancialInfoId);

                entity.ToTable("tblFinancialInformation");

                entity.Property(e => e.FinancialInfoId).HasColumnName("financialInfoId");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.CostofProcurement)
                    .HasColumnName("costofProcurement")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateofCommissioning)
                    .HasColumnName("dateofCommissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateofProcurement)
                    .HasColumnName("dateofProcurement")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcurementOrderDate)
                    .HasColumnName("procurementOrderDate")
                    .HasColumnType("date");

                entity.Property(e => e.ProcurementOrderRefNo)
                    .IsRequired()
                    .HasColumnName("procurementOrderRefNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UsefulLife)
                    .HasColumnName("usefulLife")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblFreezPropertyDetail>(entity =>
            {
                entity.HasKey(e => e.FreezePropertyId)
                    .HasName("PK__tblFreez__1CB1BEA408881053");

                entity.ToTable("tblFreezPropertyDetail");

                entity.Property(e => e.FreezePropertyId).HasColumnName("freezePropertyId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsFreeze).HasColumnName("isFreeze");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LetterDate)
                    .HasColumnName("letterDate")
                    .HasColumnType("date");

                entity.Property(e => e.LetterNo)
                    .IsRequired()
                    .HasColumnName("letterNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHouseAllocation>(entity =>
            {
                entity.HasKey(e => e.HouseAllocationId);

                entity.ToTable("tblHouseAllocation");

                entity.Property(e => e.HouseAllocationId).HasColumnName("houseAllocationId");

                entity.Property(e => e.AllocationDate)
                    .HasColumnName("allocationDate")
                    .HasColumnType("date");

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.HasSecurityDeposit).HasColumnName("hasSecurityDeposit");

                entity.Property(e => e.HouseDetailId).HasColumnName("houseDetailId");

                entity.Property(e => e.IsTerminated).HasColumnName("isTerminated");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.RentalAmount)
                    .HasColumnName("rentalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SecurityAmount)
                    .HasColumnName("securityAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TerminateDate)
                    .HasColumnName("terminateDate")
                    .HasColumnType("date");

                entity.Property(e => e.TerminateReason)
                    .HasColumnName("terminateReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TerminatedBy).HasColumnName("terminatedBy");

                entity.HasOne(d => d.BillingSchedule)
                    .WithMany(p => p.TblHouseAllocation)
                    .HasForeignKey(d => d.BillingScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseAllocation_ToTable_2");

                entity.HasOne(d => d.HouseDetail)
                    .WithMany(p => p.TblHouseAllocation)
                    .HasForeignKey(d => d.HouseDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseAllocation_ToTable");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TblHouseAllocation)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseAllocation_ToTable_1");
            });

            modelBuilder.Entity<TblHouseDetail>(entity =>
            {
                entity.HasKey(e => e.HouseDetailId)
                    .HasName("PK__tmp_ms_x__053A4BB014F7FFCA");

                entity.ToTable("tblHouseDetail");

                entity.Property(e => e.HouseDetailId).HasColumnName("houseDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.HouseAddress)
                    .IsRequired()
                    .HasColumnName("houseAddress")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNo)
                    .IsRequired()
                    .HasColumnName("houseNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHouseRentDemandDetail>(entity =>
            {
                entity.HasKey(e => e.HouseRentDemandDetailId)
                    .HasName("PK__tmp_ms_x__F78D723FDFB711C7");

                entity.ToTable("tblHouseRentDemandDetail");

                entity.Property(e => e.HouseRentDemandDetailId).HasColumnName("houseRentDemandDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandDays).HasColumnName("demandDays");

                entity.Property(e => e.DemandGenerateScheduleId).HasColumnName("demandGenerateScheduleId");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.DemandYear).HasColumnName("demandYear");

                entity.Property(e => e.HouseAllocationId).HasColumnName("houseAllocationId");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnName("installmentAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstallmentDate)
                    .HasColumnName("installmentDate")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DemandGenerateSchedule)
                    .WithMany(p => p.TblHouseRentDemandDetail)
                    .HasForeignKey(d => d.DemandGenerateScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseRentDemandDetail_ToTable_1");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblHouseRentDemandDetail)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseRentDemandDetail_ToTable_2");

                entity.HasOne(d => d.HouseAllocation)
                    .WithMany(p => p.TblHouseRentDemandDetail)
                    .HasForeignKey(d => d.HouseAllocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseRentDemandDetail_ToTable");
            });

            modelBuilder.Entity<TblHouseRentPeriod>(entity =>
            {
                entity.HasKey(e => e.HouseRentPeriodId)
                    .HasName("PK__tmp_ms_x__9190ED1561DB2267");

                entity.ToTable("tblHouseRentPeriod");

                entity.Property(e => e.HouseRentPeriodId).HasColumnName("houseRentPeriodId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.HouseAllocationId).HasColumnName("houseAllocationId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.HouseAllocation)
                    .WithMany(p => p.TblHouseRentPeriod)
                    .HasForeignKey(d => d.HouseAllocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHouseRentPeriod_ToTable");
            });

            modelBuilder.Entity<TblInaccessibleWaterMeterDetail>(entity =>
            {
                entity.HasKey(e => e.InaccessibleWaterMeterDetailId)
                    .HasName("PK__tblInacc__BE45CC0FADDE5B4A");

                entity.ToTable("tblInaccessibleWaterMeterDetail");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhotoUrl)
                    .IsRequired()
                    .HasColumnName("photoUrl")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReadingDate)
                    .HasColumnName("readingDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.WaterConnectionId).HasColumnName("waterConnectionId");

                entity.HasOne(d => d.WaterConnection)
                    .WithMany(p => p.TblInaccessibleWaterMeterDetail)
                    .HasForeignKey(d => d.WaterConnectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInaccessibleWaterMeterDetail_ToTable");
            });

            modelBuilder.Entity<TblInchargeCollection>(entity =>
            {
                entity.HasKey(e => e.InchargeCollectionId)
                    .HasName("PK__tblIncha__3596B8037E515063");

                entity.ToTable("tblInchargeCollection");

                entity.Property(e => e.InchargeCollectionId).HasColumnName("inchargeCollectionId");

                entity.Property(e => e.CheckedAmount)
                    .HasColumnName("checkedAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectionEndDate)
                    .HasColumnName("collectionEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.CollectionStartDate)
                    .HasColumnName("collectionStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TblLandLease>(entity =>
            {
                entity.HasKey(e => e.LandLeaseId)
                    .HasName("PK__tmp_ms_x__581230234B5BD313");

                entity.ToTable("tblLandLease");

                entity.Property(e => e.LandLeaseId).HasColumnName("landLeaseId");

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.HasShed).HasColumnName("hasShed");

                entity.Property(e => e.HassecurityDeposit).HasColumnName("hassecurityDeposit");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LeaseActivityTypeId).HasColumnName("leaseActivityTypeId");

                entity.Property(e => e.LeaseAmount)
                    .HasColumnName("leaseAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LeaseApprovalNo)
                    .HasColumnName("leaseApprovalNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LeaseTypeId).HasColumnName("leaseTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ShedAmount)
                    .HasColumnName("shedAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TerminateDate)
                    .HasColumnName("terminateDate")
                    .HasColumnType("date");

                entity.Property(e => e.TerminateReason)
                    .HasColumnName("terminateReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.BillingSchedule)
                    .WithMany(p => p.TblLandLease)
                    .HasForeignKey(d => d.BillingScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLease_ToTable");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.TblLandLease)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLease_ToTable_1");

                entity.HasOne(d => d.LeaseActivityType)
                    .WithMany(p => p.TblLandLease)
                    .HasForeignKey(d => d.LeaseActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLease_ToTable_4");

                entity.HasOne(d => d.LeaseType)
                    .WithMany(p => p.TblLandLease)
                    .HasForeignKey(d => d.LeaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLease_ToTable_3");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TblLandLease)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLease_ToTable_2");
            });

            modelBuilder.Entity<TblLandLeaseDemandDetail>(entity =>
            {
                entity.HasKey(e => e.LandLeaseDemandDetailId)
                    .HasName("PK__tmp_ms_x__4E6625B1BD227FF6");

                entity.ToTable("tblLandLeaseDemandDetail");

                entity.Property(e => e.LandLeaseDemandDetailId).HasColumnName("landLeaseDemandDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandDays).HasColumnName("demandDays");

                entity.Property(e => e.DemandGenerateScheduleId).HasColumnName("demandGenerateScheduleId");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.DemandYear).HasColumnName("demandYear");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnName("installmentAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstallmentDate)
                    .HasColumnName("installmentDate")
                    .HasColumnType("date");

                entity.Property(e => e.LandLeaseId).HasColumnName("landLeaseId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DemandGenerateSchedule)
                    .WithMany(p => p.TblLandLeaseDemandDetail)
                    .HasForeignKey(d => d.DemandGenerateScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLeaseDemandDetail_ToTable_1");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblLandLeaseDemandDetail)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLeaseDemandDetail_ToTable_2");

                entity.HasOne(d => d.LandLease)
                    .WithMany(p => p.TblLandLeaseDemandDetail)
                    .HasForeignKey(d => d.LandLeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLeaseDemandDetail_ToTable");
            });

            modelBuilder.Entity<TblLandLeasePeriod>(entity =>
            {
                entity.HasKey(e => e.LandLeasePeriodId)
                    .HasName("PK__tmp_ms_x__7412223B850990D0");

                entity.ToTable("tblLandLeasePeriod");

                entity.Property(e => e.LandLeasePeriodId).HasColumnName("landLeasePeriodId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LandLeaseId).HasColumnName("landLeaseId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.LandLease)
                    .WithMany(p => p.TblLandLeasePeriod)
                    .HasForeignKey(d => d.LandLeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandLeasePeriod_ToTable");
            });

            modelBuilder.Entity<TblLandOwnershipDetail>(entity =>
            {
                entity.HasKey(e => e.LandOwnershipId)
                    .HasName("PK__tmp_ms_x__15B22CC1783BBBDE");

                entity.ToTable("tblLandOwnershipDetail");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipTypeId).HasColumnName("landOwnershipTypeId");

                entity.Property(e => e.LastTaxPaidYear).HasColumnName("lastTaxPaidYear");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.OwnershipPercentage)
                    .HasColumnName("ownershipPercentage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PLr)
                    .HasColumnName("pLR")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PreviousTaxPayerId).HasColumnName("previousTaxPayerId");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.ThramNo)
                    .IsRequired()
                    .HasColumnName("thramNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.TblLandOwnershipDetail)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandOwnershipDetail_ToTable");

                entity.HasOne(d => d.LandOwnershipType)
                    .WithMany(p => p.TblLandOwnershipDetail)
                    .HasForeignKey(d => d.LandOwnershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandOwnershipDetail_ToTable_1");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TblLandOwnershipDetail)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLandOwnershipDetail_ToTable_2");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblLandOwnershipDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_tblLandOwnershipDetail_ToTable_3");
            });

            modelBuilder.Entity<TblLedger>(entity =>
            {
                entity.HasKey(e => e.LedgerId)
                    .HasName("PK__tmp_ms_x__298DF4D57BD75755");

                entity.ToTable("tblLedger");

                entity.Property(e => e.LedgerId).HasColumnName("ledgerId");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantId");

                entity.Property(e => e.BfsTransactionDetailId).HasColumnName("bfsTransactionDetailId");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.CalendarYearId).HasColumnName("calendarYearId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandId).HasColumnName("demandId");

                entity.Property(e => e.EcRenewalId).HasColumnName("ecRenewalId");

                entity.Property(e => e.FinancialYearId).HasColumnName("financialYearId");

                entity.Property(e => e.HouseRentDemandDetailId).HasColumnName("houseRentDemandDetailId");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandLeaseDemandDetailId).HasColumnName("landLeaseDemandDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MiscellaneousRecordId).HasColumnName("miscellaneousRecordId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingDemandDetailId).HasColumnName("parkingDemandDetailId");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("paymentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentStatusId)
                    .HasColumnName("paymentStatusId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PenaltyAmount)
                    .HasColumnName("penaltyAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PenaltyPeriod).HasColumnName("penaltyPeriod");

                entity.Property(e => e.RHeadChecked).HasColumnName("rHeadChecked");

                entity.Property(e => e.ReceiptId).HasColumnName("receiptId");

                entity.Property(e => e.ReconciledOn)
                    .HasColumnName("reconciledOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordedOn)
                    .HasColumnName("recordedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StallDemandDetailId).HasColumnName("stallDemandDetailId");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterMeterReadingId).HasColumnName("waterMeterReadingId");

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.ApplicantId)
                    .HasConstraintName("FK_tblLedger_ToTable_1");

                entity.HasOne(d => d.BfsTransactionDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.BfsTransactionDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_17");

                entity.HasOne(d => d.BuildingUnitDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.BuildingUnitDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_14");

                entity.HasOne(d => d.CalendarYear)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.CalendarYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable_8");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.DemandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable");

                entity.HasOne(d => d.EcRenewal)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.EcRenewalId)
                    .HasConstraintName("FK_tblLedger_ToTable_2");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable_7");

                entity.HasOne(d => d.HouseRentDemandDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.HouseRentDemandDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_6");

                entity.HasOne(d => d.LandLeaseDemandDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.LandLeaseDemandDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_3");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .HasConstraintName("FK_tblLedger_ToTable_12");

                entity.HasOne(d => d.MiscellaneousRecord)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.MiscellaneousRecordId)
                    .HasConstraintName("FK_tblLedger_ToTable_9");

                entity.HasOne(d => d.ParkingDemandDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.ParkingDemandDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_4");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_tblLedger_ToTable_13");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable_11");

                entity.HasOne(d => d.StallDemandDetail)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.StallDemandDetailId)
                    .HasConstraintName("FK_tblLedger_ToTable_5");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable_0");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLedger_ToTable_10");

                entity.HasOne(d => d.UnScheduledParkingRecord)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.UnScheduledParkingRecordId)
                    .HasConstraintName("FK_tblLedger_ToTable_16");

                entity.HasOne(d => d.WaterMeterReading)
                    .WithMany(p => p.TblLedger)
                    .HasForeignKey(d => d.WaterMeterReadingId)
                    .HasConstraintName("FK_tblLedger_ToTable_15");
            });

            modelBuilder.Entity<TblManualReceipt>(entity =>
            {
                entity.HasKey(e => e.ManualReceiptId)
                    .HasName("PK__tblManua__51E2247E8B9C7B32");

                entity.ToTable("tblManualReceipt");

                entity.Property(e => e.ManualReceiptId).HasColumnName("manualReceiptId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectedBy)
                    .IsRequired()
                    .HasColumnName("collectedBy")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ManualReceiptNo)
                    .IsRequired()
                    .HasColumnName("manualReceiptNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ManualTaxName)
                    .IsRequired()
                    .HasColumnName("manualTaxName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receiptDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("tbl_menu");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .HasColumnName("action_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AreaName)
                    .HasColumnName("area_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasColumnName("controller_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.MenuFor).HasColumnName("menuFor");

                entity.Property(e => e.MenuIconName)
                    .HasColumnName("menuIconName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnName("menu_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MenuParentId).HasColumnName("menu_parent_id");

                entity.Property(e => e.MenuSequence).HasColumnName("menuSequence");

                entity.Property(e => e.OrderFor).HasColumnName("orderFor");
            });

            modelBuilder.Entity<TblMenumap>(entity =>
            {
                entity.HasKey(e => e.MenumapId);

                entity.ToTable("tbl_menumap");

                entity.Property(e => e.MenumapId).HasColumnName("menumap_id");

                entity.Property(e => e.ChildmenuId).HasColumnName("childmenu_id");

                entity.Property(e => e.IsAdd).HasColumnName("is_add");

                entity.Property(e => e.IsEdit).HasColumnName("is_edit");

                entity.Property(e => e.IsView).HasColumnName("is_view");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblMenumap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tbl_menumap_ToTable");
            });

            modelBuilder.Entity<TblMiscellaneousRecord>(entity =>
            {
                entity.HasKey(e => e.MiscellaneousRecordId)
                    .HasName("PK__tmp_ms_x__7273C9CA1F0EEA08");

                entity.ToTable("tblMiscellaneousRecord");

                entity.Property(e => e.MiscellaneousRecordId).HasColumnName("miscellaneousRecordId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus).HasColumnName("paymentStatus");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.Slab)
                    .WithMany(p => p.TblMiscellaneousRecord)
                    .HasForeignKey(d => d.SlabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMiscellaneousRecord_ToTable_2");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.TblMiscellaneousRecord)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMiscellaneousRecord_ToTable_1");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblMiscellaneousRecord)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMiscellaneousRecord_ToTable");
            });

            modelBuilder.Entity<TblOccupancyCertificateUnitMap>(entity =>
            {
                entity.HasKey(e => e.OccupancyCertificateUnitMapId)
                    .HasName("PK__tblOccup__2B546CAFF9D37189");

                entity.ToTable("tblOccupancyCertificateUnitMap");

                entity.Property(e => e.OccupancyCertificateUnitMapId).HasColumnName("occupancyCertificateUnitMapId");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.OccupancyCertificateApplicationId).HasColumnName("occupancyCertificateApplicationId");
            });

            modelBuilder.Entity<TblOpeningBalance>(entity =>
            {
                entity.HasKey(e => e.OpeningBalanceId)
                    .HasName("PK__tblOpeni__5E1AFE19A4BB66C5");

                entity.ToTable("tblOpeningBalance");

                entity.Property(e => e.OpeningBalanceId).HasColumnName("openingBalanceId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpeningBalanceCarriedOn)
                    .HasColumnName("openingBalanceCarriedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Particular)
                    .HasColumnName("particular")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblParkingFeeDemandDetail>(entity =>
            {
                entity.HasKey(e => e.ParkingDemandDetailId)
                    .HasName("PK__tmp_ms_x__FFE427E4B2DB40E5");

                entity.ToTable("tblParkingFeeDemandDetail");

                entity.Property(e => e.ParkingDemandDetailId).HasColumnName("parkingDemandDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandDays).HasColumnName("demandDays");

                entity.Property(e => e.DemandGenerateScheduleId).HasColumnName("demandGenerateScheduleId");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.DemandYear).HasColumnName("demandYear");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnName("installmentAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstallmentDate)
                    .HasColumnName("installmentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingFeeDetailId).HasColumnName("parkingFeeDetailId");

                entity.HasOne(d => d.DemandGenerateSchedule)
                    .WithMany(p => p.TblParkingFeeDemandDetail)
                    .HasForeignKey(d => d.DemandGenerateScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingFeeDemandDetail_ToTable_1");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblParkingFeeDemandDetail)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingFeeDemandDetail_ToTable_2");

                entity.HasOne(d => d.ParkingFeeDetail)
                    .WithMany(p => p.TblParkingFeeDemandDetail)
                    .HasForeignKey(d => d.ParkingFeeDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingFeeDemandDetail_ToTable");
            });

            modelBuilder.Entity<TblParkingFeePeriod>(entity =>
            {
                entity.HasKey(e => e.ParkingFeePeriodId)
                    .HasName("PK__tblParki__9F7F4236D6036BD4");

                entity.ToTable("tblParkingFeePeriod");

                entity.Property(e => e.ParkingFeePeriodId).HasColumnName("parkingFeePeriodId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingFeeDetailId).HasColumnName("parkingFeeDetailId");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.ParkingFeeDetail)
                    .WithMany(p => p.TblParkingFeePeriod)
                    .HasForeignKey(d => d.ParkingFeeDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingFeePeriod_ToTable");
            });

            modelBuilder.Entity<TblParkingfeeDetail>(entity =>
            {
                entity.HasKey(e => e.ParkingFeeDetailId)
                    .HasName("PK__tmp_ms_x__A6B5D8C548E5AC5F");

                entity.ToTable("tblParkingfeeDetail");

                entity.Property(e => e.ParkingFeeDetailId).HasColumnName("parkingFeeDetailId");

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnName("installmentAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParkingZoneId).HasColumnName("parkingZoneId");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TerminateDate)
                    .HasColumnName("terminateDate")
                    .HasColumnType("date");

                entity.Property(e => e.TerminateReason)
                    .HasColumnName("terminateReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TerminatedBy).HasColumnName("terminatedBy");

                entity.HasOne(d => d.BillingSchedule)
                    .WithMany(p => p.TblParkingfeeDetail)
                    .HasForeignKey(d => d.BillingScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingfeeDetail_ToTable_1");

                entity.HasOne(d => d.ParkingZone)
                    .WithMany(p => p.TblParkingfeeDetail)
                    .HasForeignKey(d => d.ParkingZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingfeeDetail_ToTable");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TblParkingfeeDetail)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblParkingfeeDetail_ToTable_2");
            });

            modelBuilder.Entity<TblPaymentLeger>(entity =>
            {
                entity.HasKey(e => e.PaymentLedgerId)
                    .HasName("PK__tmp_ms_x__E67DFF0E03BA777B");

                entity.ToTable("tblPaymentLeger");

                entity.Property(e => e.PaymentLedgerId).HasColumnName("paymentLedgerId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BankBranchId).HasColumnName("bankBranchId");

                entity.Property(e => e.BfsTransactionDetailId).HasColumnName("bfsTransactionDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentModeDate)
                    .HasColumnName("paymentModeDate")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentModeId).HasColumnName("paymentModeId");

                entity.Property(e => e.PaymentModeNo)
                    .HasColumnName("paymentModeNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatusId)
                    .HasColumnName("paymentStatusId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReceiptId).HasColumnName("receiptId");

                entity.Property(e => e.RecordedOn)
                    .HasColumnName("recordedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankBranch)
                    .WithMany(p => p.TblPaymentLeger)
                    .HasForeignKey(d => d.BankBranchId)
                    .HasConstraintName("FK_tblPaymentLeger_ToTable_3");

                entity.HasOne(d => d.BfsTransactionDetail)
                    .WithMany(p => p.TblPaymentLeger)
                    .HasForeignKey(d => d.BfsTransactionDetailId)
                    .HasConstraintName("FK_tblPaymentLeger_ToTable_4");

                entity.HasOne(d => d.PaymentMode)
                    .WithMany(p => p.TblPaymentLeger)
                    .HasForeignKey(d => d.PaymentModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPaymentLeger_ToTable_1");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.TblPaymentLeger)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_tblPaymentLeger_ToTable");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.TblPaymentLeger)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPaymentLeger_ToTable_2");
            });

            modelBuilder.Entity<TblReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId)
                    .HasName("PK__tmp_ms_x__CAA7E8B83777177B");

                entity.ToTable("tblReceipt");

                entity.Property(e => e.ReceiptId).HasColumnName("receiptId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReceiptNo)
                    .IsRequired()
                    .HasColumnName("receiptNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptYear).HasColumnName("receiptYear");

                entity.Property(e => e.RecordedOn)
                    .HasColumnName("recordedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sl).HasColumnName("sl");
            });

            modelBuilder.Entity<TblRevenueTransfer>(entity =>
            {
                entity.HasKey(e => e.RevenueTransferId)
                    .HasName("PK__tblReven__063D2DEB920D40C5");

                entity.ToTable("tblRevenueTransfer");

                entity.Property(e => e.RevenueTransferId).HasColumnName("revenueTransferId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.RevenueTakenBy)
                    .IsRequired()
                    .HasColumnName("revenueTakenBy")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RevenueTransferAmount)
                    .HasColumnName("revenueTransferAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RevenueTransferDate)
                    .HasColumnName("revenueTransferDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tbl_role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("roleName")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStallAllocation>(entity =>
            {
                entity.HasKey(e => e.StallAllocationId);

                entity.ToTable("tblStallAllocation");

                entity.Property(e => e.StallAllocationId).HasColumnName("stallAllocationId");

                entity.Property(e => e.AllocationDate)
                    .HasColumnName("allocationDate")
                    .HasColumnType("date");

                entity.Property(e => e.BillingScheduleId).HasColumnName("billingScheduleId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.HasSecurityDeposit).HasColumnName("hasSecurityDeposit");

                entity.Property(e => e.IsTerminated).HasColumnName("isTerminated");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.RentalAmount)
                    .HasColumnName("rentalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SecurityAmount)
                    .HasColumnName("securityAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StallDetailId).HasColumnName("stallDetailId");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TerminateDate)
                    .HasColumnName("terminateDate")
                    .HasColumnType("date");

                entity.Property(e => e.TerminateReason)
                    .HasColumnName("terminateReason")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TerminatedBy).HasColumnName("terminatedBy");

                entity.HasOne(d => d.BillingSchedule)
                    .WithMany(p => p.TblStallAllocation)
                    .HasForeignKey(d => d.BillingScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallAllocation_ToTable_2");

                entity.HasOne(d => d.StallDetail)
                    .WithMany(p => p.TblStallAllocation)
                    .HasForeignKey(d => d.StallDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallAllocation_ToTable");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TblStallAllocation)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallAllocation_ToTable_1");
            });

            modelBuilder.Entity<TblStallDetail>(entity =>
            {
                entity.HasKey(e => e.StallDetailId)
                    .HasName("PK__tmp_ms_x__36E9CC6487621173");

                entity.ToTable("tblStallDetail");

                entity.Property(e => e.StallDetailId).HasColumnName("stallDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.StallArea)
                    .HasColumnName("stallArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StallLocationId).HasColumnName("stallLocationId");

                entity.Property(e => e.StallName)
                    .IsRequired()
                    .HasColumnName("stallName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.StallNo)
                    .IsRequired()
                    .HasColumnName("stallNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StallTypeId).HasColumnName("stallTypeId");

                entity.HasOne(d => d.StallLocation)
                    .WithMany(p => p.TblStallDetail)
                    .HasForeignKey(d => d.StallLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallDetail_ToTable");

                entity.HasOne(d => d.StallType)
                    .WithMany(p => p.TblStallDetail)
                    .HasForeignKey(d => d.StallTypeId)
                    .HasConstraintName("FK_tblStallDetail_ToTable_1");
            });

            modelBuilder.Entity<TblStallDetailDemand>(entity =>
            {
                entity.HasKey(e => e.StallDemandDetailId)
                    .HasName("PK__tmp_ms_x__4A24346D83057D7C");

                entity.ToTable("tblStallDetailDemand");

                entity.Property(e => e.StallDemandDetailId).HasColumnName("stallDemandDetailId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DemandDays).HasColumnName("demandDays");

                entity.Property(e => e.DemandGenerateScheduleId).HasColumnName("demandGenerateScheduleId");

                entity.Property(e => e.DemandNoId).HasColumnName("demandNoId");

                entity.Property(e => e.DemandYear).HasColumnName("demandYear");

                entity.Property(e => e.InstallmentDate)
                    .HasColumnName("installmentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.StallAllocationId).HasColumnName("stallAllocationId");

                entity.Property(e => e.StallTypeId).HasColumnName("stallTypeId");

                entity.HasOne(d => d.DemandGenerateSchedule)
                    .WithMany(p => p.TblStallDetailDemand)
                    .HasForeignKey(d => d.DemandGenerateScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallDetailDemand_ToTable_1");

                entity.HasOne(d => d.DemandNo)
                    .WithMany(p => p.TblStallDetailDemand)
                    .HasForeignKey(d => d.DemandNoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallDetailDemand_ToTable_2");

                entity.HasOne(d => d.StallAllocation)
                    .WithMany(p => p.TblStallDetailDemand)
                    .HasForeignKey(d => d.StallAllocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallDetailDemand_ToTable");

                entity.HasOne(d => d.StallType)
                    .WithMany(p => p.TblStallDetailDemand)
                    .HasForeignKey(d => d.StallTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallDetailDemand_ToTable_3");
            });

            modelBuilder.Entity<TblStallPeriod>(entity =>
            {
                entity.HasKey(e => e.StallPeriodId)
                    .HasName("PK__tmp_ms_x__FBCBF210647247DC");

                entity.ToTable("tblStallPeriod");

                entity.Property(e => e.StallPeriodId).HasColumnName("stallPeriodId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StallAllocationId).HasColumnName("stallAllocationId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.StallAllocation)
                    .WithMany(p => p.TblStallPeriod)
                    .HasForeignKey(d => d.StallAllocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStallPeriod_ToTable");
            });

            modelBuilder.Entity<TblTechnicalInformation>(entity =>
            {
                entity.HasKey(e => e.TechicalInformationId)
                    .HasName("PK__tblTechn__B9D3EBF77CDC664F");

                entity.ToTable("tblTechnicalInformation");

                entity.Property(e => e.TechicalInformationId).HasColumnName("techicalInformationId");

                entity.Property(e => e.AssetAttributeId).HasColumnName("assetAttributeId");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.MeasurementUnitId).HasColumnName("measurementUnitId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AssetAttribute)
                    .WithMany(p => p.TblTechnicalInformation)
                    .HasForeignKey(d => d.AssetAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTechnicalInformation_ToTable");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.TblTechnicalInformation)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTechnicalInformation_ToTable_1");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.TblTechnicalInformation)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTechnicalInformation_ToTable_2");
            });

            modelBuilder.Entity<TblTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__tmp_ms_x__9B57CF72554A948D");

                entity.ToTable("tblTransactionDetail");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.Property(e => e.TransactionValue)
                    .HasColumnName("transactionValue")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WorkLevelId).HasColumnName("workLevelId");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.TblTransactionDetail)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransactionDetail_ToTable");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.TblTransactionDetail)
                    .HasForeignKey(d => d.WorkLevelId)
                    .HasConstraintName("FK_tblTransactionDetail_ToTable_7");
            });

            modelBuilder.Entity<TblUnScheduledParkingRecord>(entity =>
            {
                entity.HasKey(e => e.UnScheduledParkingRecordId)
                    .HasName("PK__tmp_ms_x__B8D102393A8F5980");

                entity.ToTable("tblUnScheduledParkingRecord");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.VendorAddress)
                    .IsRequired()
                    .HasColumnName("vendorAddress")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendorName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblUnScheduledParkingRecord)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUnScheduledParkingRecord_ToTable");
            });

            modelBuilder.Entity<TblVersionControl>(entity =>
            {
                entity.ToTable("tblVersionControl");

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasColumnName("device")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblWaterBillChangeHistory>(entity =>
            {
                entity.HasKey(e => e.WaterBillChangeHistoryId)
                    .HasName("PK__tblWater__4708D2C72FA9973F");

                entity.ToTable("tblWaterBillChangeHistory");

                entity.Property(e => e.WaterBillChangeHistoryId).HasColumnName("waterBillChangeHistoryId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentAmount)
                    .HasColumnName("currentAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NewAmount)
                    .HasColumnName("newAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NewConsumption).HasColumnName("newConsumption");

                entity.Property(e => e.NewPreviousReading).HasColumnName("newPreviousReading");

                entity.Property(e => e.NewReading).HasColumnName("newReading");

                entity.Property(e => e.NewSewerage).HasColumnName("newSewerage");

                entity.Property(e => e.NewStdConsumption).HasColumnName("newStdConsumption");

                entity.Property(e => e.NewUnit).HasColumnName("newUnit");

                entity.Property(e => e.NewWaterConnectionTypeId).HasColumnName("newWaterConnectionTypeId");

                entity.Property(e => e.OldConsumption).HasColumnName("oldConsumption");

                entity.Property(e => e.OldPreviousReading).HasColumnName("oldPreviousReading");

                entity.Property(e => e.OldReading).HasColumnName("oldReading");

                entity.Property(e => e.OldSewerage).HasColumnName("oldSewerage");

                entity.Property(e => e.OldStdConsumption).HasColumnName("oldStdConsumption");

                entity.Property(e => e.OldUnit).HasColumnName("oldUnit");

                entity.Property(e => e.OldWaterConnectionTypeId).HasColumnName("oldWaterConnectionTypeId");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterBillEditReasonId).HasColumnName("waterBillEditReasonId");

                entity.Property(e => e.WaterMeterReadingId).HasColumnName("waterMeterReadingId");

                entity.HasOne(d => d.NewWaterConnectionType)
                    .WithMany(p => p.TblWaterBillChangeHistoryNewWaterConnectionType)
                    .HasForeignKey(d => d.NewWaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterBillChangeHistory_ToTable_3");

                entity.HasOne(d => d.OldWaterConnectionType)
                    .WithMany(p => p.TblWaterBillChangeHistoryOldWaterConnectionType)
                    .HasForeignKey(d => d.OldWaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterBillChangeHistory_ToTable_2");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblWaterBillChangeHistory)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterBillChangeHistory_ToTable_1");

                entity.HasOne(d => d.WaterBillEditReason)
                    .WithMany(p => p.TblWaterBillChangeHistory)
                    .HasForeignKey(d => d.WaterBillEditReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterBillChangeHistory_ToTable_4");

                entity.HasOne(d => d.WaterMeterReading)
                    .WithMany(p => p.TblWaterBillChangeHistory)
                    .HasForeignKey(d => d.WaterMeterReadingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterBillChangeHistory_ToTable");
            });

            modelBuilder.Entity<TblWaterMeterReading>(entity =>
            {
                entity.HasKey(e => e.WaterMeterReadingId)
                    .HasName("PK__tmp_ms_x__64FDFAFC46ED65FB");

                entity.ToTable("tblWaterMeterReading");

                entity.Property(e => e.WaterMeterReadingId).HasColumnName("waterMeterReadingId");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Bucid).HasColumnName("bucid");

                entity.Property(e => e.Consumption).HasColumnName("consumption");

                entity.Property(e => e.CreateTransactionId).HasColumnName("createTransactionId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlatNo)
                    .HasColumnName("flatNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDisconnected).HasColumnName("isDisconnected");

                entity.Property(e => e.IsPermanentConnection).HasColumnName("isPermanentConnection");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoOfUnit).HasColumnName("noOfUnit");

                entity.Property(e => e.PreviousReading).HasColumnName("previousReading");

                entity.Property(e => e.PreviousReadingDate)
                    .HasColumnName("previousReadingDate")
                    .HasColumnType("date");

                entity.Property(e => e.PrimaryMobileNo)
                    .IsRequired()
                    .HasColumnName("primaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReadBy).HasColumnName("readBy");

                entity.Property(e => e.Reading).HasColumnName("reading");

                entity.Property(e => e.ReadingDate)
                    .HasColumnName("readingDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNo)
                    .HasColumnName("secondaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sewerage).HasColumnName("sewerage");

                entity.Property(e => e.SolidWaste).HasColumnName("solidWaste");

                entity.Property(e => e.StandardConsumption).HasColumnName("standardConsumption");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterConnectionId).HasColumnName("waterConnectionId");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");

                entity.HasOne(d => d.CreateTransaction)
                    .WithMany(p => p.TblWaterMeterReadingCreateTransaction)
                    .HasForeignKey(d => d.CreateTransactionId)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_6");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblWaterMeterReadingTransaction)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_5");

                entity.HasOne(d => d.WaterConnection)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.WaterConnectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable");

                entity.HasOne(d => d.WaterConnectionStatus)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.WaterConnectionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_4");

                entity.HasOne(d => d.WaterConnectionType)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.WaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_1");

                entity.HasOne(d => d.WaterLineType)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.WaterLineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_3");

                entity.HasOne(d => d.WaterMeterType)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.WaterMeterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_2");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblWaterMeterReading)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWaterMeterReading_ToTable_7");
            });

            modelBuilder.Entity<Tblaudit>(entity =>
            {
                entity.ToTable("tblaudit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NewValue)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.OldValue)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Pk)
                    .HasColumnName("PK")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TrnConstructionApprovalApplicationFeeDetail>(entity =>
            {
                entity.HasKey(e => e.ConstructionApprovalApplicationFeeId)
                    .HasName("PK__tmp_ms_x__E07DF714C6771A24");

                entity.ToTable("trnConstructionApprovalApplicationFeeDetail");

                entity.Property(e => e.ConstructionApprovalApplicationFeeId).HasColumnName("constructionApprovalApplicationFeeId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G2cApplicationNo)
                    .IsRequired()
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnConstructionApprovalApplicationFeeDetail)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnConstructionApprovalApplicationFeeDetail_ToTable");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnConstructionApprovalApplicationFeeDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnConstructionApprovalApplicationFeeDetail_ToTable_1");
            });

            modelBuilder.Entity<TrnLandDetail>(entity =>
            {
                entity.HasKey(e => e.TrnFtlandDetailId)
                    .HasName("PK__trnLandD__8369FF978EC07B9D");

                entity.ToTable("trnLandDetail");

                entity.Property(e => e.TrnFtlandDetailId).HasColumnName("trnFTLandDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreationOn)
                    .HasColumnName("creationOn")
                    .HasColumnType("date");

                entity.Property(e => e.DemkhongId).HasColumnName("demkhongId");

                entity.Property(e => e.ESakorTransactionId)
                    .IsRequired()
                    .HasColumnName("eSakorTransactionId")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GarbageApplicable).HasColumnName("garbageApplicable");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandPoolingRate)
                    .HasColumnName("landPoolingRate")
                    .HasColumnType("decimal(10, 3)");

                entity.Property(e => e.LandTransferTypeId).HasColumnName("landTransferTypeId");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LandValue)
                    .HasColumnName("landValue")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LapId).HasColumnName("lapId");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlotAddress)
                    .IsRequired()
                    .HasColumnName("plotAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.StreetLightApplicable).HasColumnName("streetLightApplicable");

                entity.Property(e => e.StreetNameId).HasColumnName("streetNameId");

                entity.Property(e => e.StructureAvailable).HasColumnName("structureAvailable");

                entity.Property(e => e.TransactorTypeId).HasColumnName("transactorTypeId");

                entity.Property(e => e.VacantLandTaxApplicable).HasColumnName("vacantLandTaxApplicable");

                entity.HasOne(d => d.Demkhong)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.DemkhongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_4");

                entity.HasOne(d => d.LandTransferType)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.LandTransferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_3");

                entity.HasOne(d => d.LandType)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.LandTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_2");

                entity.HasOne(d => d.LandUseSubCategory)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.LandUseSubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_1");

                entity.HasOne(d => d.Lap)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.LapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_7");

                entity.HasOne(d => d.StreetName)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.StreetNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_5");

                entity.HasOne(d => d.TransactorType)
                    .WithMany(p => p.TrnLandDetail)
                    .HasForeignKey(d => d.TransactorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandDetail_ToTable_6");
            });

            modelBuilder.Entity<TrnLandFeeDetail>(entity =>
            {
                entity.HasKey(e => e.LandFeeDetailId)
                    .HasName("PK__tmp_ms_x__CF9243B6D5E93E9A");

                entity.ToTable("trnLandFeeDetail");

                entity.Property(e => e.LandFeeDetailId).HasColumnName("landFeeDetailId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.LandServiceTypeId).HasColumnName("landServiceTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnLandFeeDetail)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandFeeDetail_ToTable");

                entity.HasOne(d => d.LandServiceType)
                    .WithMany(p => p.TrnLandFeeDetail)
                    .HasForeignKey(d => d.LandServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandFeeDetail_ToTable_1");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnLandFeeDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandFeeDetail_ToTable_2");
            });

            modelBuilder.Entity<TrnLandTransferDetail>(entity =>
            {
                entity.HasKey(e => e.LandTransferDetailId)
                    .HasName("PK__tmp_ms_x__7F0AC2641FD17BA1");

                entity.ToTable("trnLandTransferDetail");

                entity.Property(e => e.LandTransferDetailId).HasColumnName("landTransferDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.FromLandOwnershipId).HasColumnName("fromLandOwnershipId");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToTaxPayerIds)
                    .IsRequired()
                    .HasColumnName("toTaxPayerIds")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.FromLandOwnership)
                    .WithMany(p => p.TrnLandTransferDetail)
                    .HasForeignKey(d => d.FromLandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandTransferDetail_ToTable_2");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.TrnLandTransferDetail)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandTransferDetail_ToTable_1");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnLandTransferDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnLandTransferDetail_ToTable");
            });

            modelBuilder.Entity<TrnOccupancyCertificateApplication>(entity =>
            {
                entity.HasKey(e => e.OccupancyCertificateApplicationId)
                    .HasName("PK__tmp_ms_x__9F4AA068069E0DC9");

                entity.ToTable("trnOccupancyCertificateApplication");

                entity.Property(e => e.OccupancyCertificateApplicationId).HasColumnName("occupancyCertificateApplicationId");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.BuildingUnitDetailId).HasColumnName("buildingUnitDetailId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfFinalInspection)
                    .HasColumnName("dateOfFinalInspection")
                    .HasColumnType("date");

                entity.Property(e => e.G2cApplicationNo)
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsBuildingOc)
                    .IsRequired()
                    .HasColumnName("isBuildingOC")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsNewOc).HasColumnName("isNewOc");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipId)
                    .HasColumnName("landOwnershipId")
                    .HasDefaultValueSql("((103270))");

                entity.Property(e => e.LogoSignMapId).HasColumnName("logoSignMapId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.OcReferenceNo)
                    .IsRequired()
                    .HasColumnName("ocReferenceNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.OccupancyTypeId).HasColumnName("occupancyTypeId");

                entity.Property(e => e.Sl).HasColumnName("sl");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.ValidTillDate)
                    .HasColumnName("validTillDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Yr).HasColumnName("yr");

                entity.HasOne(d => d.BuildingDetail)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.BuildingDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable_2");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable_4");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable_5");

                entity.HasOne(d => d.LogoSignMap)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.LogoSignMapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable_6");

                entity.HasOne(d => d.OccupancyType)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.OccupancyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable");

                entity.HasOne(d => d.TaxPayer)
                    .WithMany(p => p.TrnOccupancyCertificateApplication)
                    .HasForeignKey(d => d.TaxPayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnOccupancyCertificateApplication_ToTable_3");
            });

            modelBuilder.Entity<TrnSewerageConnection>(entity =>
            {
                entity.HasKey(e => e.SewerageConnectionId)
                    .HasName("PK__tmp_ms_x__FD34958F45C7858F");

                entity.ToTable("trnSewerageConnection");

                entity.Property(e => e.SewerageConnectionId).HasColumnName("sewerageConnectionId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContactAddress)
                    .IsRequired()
                    .HasColumnName("contactAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.G2cApplicationNo)
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WorkLevelId)
                    .HasColumnName("workLevelId")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnSewerageConnection)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnSewerageConnection_ToTable_1");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnSewerageConnection)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnSewerageConnection_ToTable");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.TrnSewerageConnection)
                    .HasForeignKey(d => d.WorkLevelId)
                    .HasConstraintName("FK_trnSewerageConnection_ToTable_2");
            });

            modelBuilder.Entity<TrnTaxDetail>(entity =>
            {
                entity.ToTable("trnTaxDetail");

                entity.Property(e => e.TrnTaxDetailId).HasColumnName("trnTaxDetailId");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.ESakorTransactionId)
                    .IsRequired()
                    .HasColumnName("eSakorTransactionId")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LandTransferTypeId).HasColumnName("landTransferTypeId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("date");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.HasOne(d => d.LandTransferType)
                    .WithMany(p => p.TrnTaxDetail)
                    .HasForeignKey(d => d.LandTransferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxDetail_ToTable_1");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.TrnTaxDetail)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxDetail_ToTable");
            });

            modelBuilder.Entity<TrnTaxPayerInformation>(entity =>
            {
                entity.HasKey(e => e.TrnTaxpayerId)
                    .HasName("PK__trnTaxPa__2329AEB9EE1AC242");

                entity.ToTable("trnTaxPayerInformation");

                entity.Property(e => e.TrnTaxpayerId).HasColumnName("trnTaxpayerId");

                entity.Property(e => e.BankAccountNo)
                    .HasColumnName("bankAccountNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.BankBranchId).HasColumnName("bankBranchId");

                entity.Property(e => e.CAddress)
                    .HasColumnName("cAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CDzongkhagId).HasColumnName("cDzongkhagId");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasColumnName("cid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contactPerson")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.ESakorTransactionId)
                    .HasColumnName("eSakorTransactionId")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("genderId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LandTransferTypeId).HasColumnName("landTransferTypeId");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("date");

                entity.Property(e => e.OccupationId).HasColumnName("occupationId");

                entity.Property(e => e.OrgEmail)
                    .HasColumnName("orgEmail")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrgPhone)
                    .HasColumnName("orgPhone")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .HasColumnName("organizationName")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.PVillageId).HasColumnName("pVillageId");

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phoneNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerTypeId).HasColumnName("taxPayerTypeId");

                entity.Property(e => e.TitleId).HasColumnName("titleId");

                entity.Property(e => e.Tpn)
                    .HasColumnName("tpn")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransactorTypeId).HasColumnName("transactorTypeId");

                entity.Property(e => e.Ttin)
                    .IsRequired()
                    .HasColumnName("ttin")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkingAgency)
                    .HasColumnName("workingAgency")
                    .HasMaxLength(345)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankBranch)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.BankBranchId)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_5");

                entity.HasOne(d => d.CDzongkhag)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.CDzongkhagId)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_2");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_4");

                entity.HasOne(d => d.LandTransferType)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.LandTransferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_8");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_3");

                entity.HasOne(d => d.PVillage)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.PVillageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_1");

                entity.HasOne(d => d.TaxPayerType)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.TaxPayerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_6");

                entity.HasOne(d => d.TransactorType)
                    .WithMany(p => p.TrnTaxPayerInformation)
                    .HasForeignKey(d => d.TransactorTypeId)
                    .HasConstraintName("FK_trnTaxPayerInformation_ToTable_7");
            });

            modelBuilder.Entity<TrnVacuumTankerService>(entity =>
            {
                entity.HasKey(e => e.VacuumTankerServiceId)
                    .HasName("PK__tmp_ms_x__4A3F2DF46CB6C1FF");

                entity.ToTable("trnVacuumTankerService");

                entity.Property(e => e.VacuumTankerServiceId).HasColumnName("vacuumTankerServiceId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContactAddress)
                    .IsRequired()
                    .HasColumnName("contactAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasColumnName("contactName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.G2cApplicationNo)
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoOfTrips).HasColumnName("noOfTrips");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WorkLevelId).HasColumnName("workLevelId");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnVacuumTankerService)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .HasConstraintName("FK_trnVacuumTankerService_ToTable_1");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnVacuumTankerService)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnVacuumTankerService_ToTable");
            });

            modelBuilder.Entity<TrnWaterConnection>(entity =>
            {
                entity.ToTable("trnWaterConnection");

                entity.Property(e => e.TrnWaterConnectionId).HasColumnName("trnWaterConnectionId");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnName("applicationDate")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approvalStatusId");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeTypeId).HasColumnName("changeTypeId");

                entity.Property(e => e.ConsumerNo)
                    .IsRequired()
                    .HasColumnName("consumerNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("date");

                entity.Property(e => e.DisconnectDate)
                    .HasColumnName("disconnectDate")
                    .HasColumnType("date");

                entity.Property(e => e.FlatNo)
                    .HasColumnName("flatNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.G2cApplicationNo)
                    .HasColumnName("g2cApplicationNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.InitialReading)
                    .HasColumnName("initialReading")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsPermanent).HasColumnName("isPermanent");

                entity.Property(e => e.IsPermanentDisconnect).HasColumnName("isPermanentDisconnect");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("date");

                entity.Property(e => e.NoOfUnits)
                    .HasColumnName("noOfUnits")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OldWaterConnectionId).HasColumnName("oldWaterConnectionId");

                entity.Property(e => e.OrganisationName)
                    .HasColumnName("organisationName")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerTypeId).HasColumnName("ownerTypeId");

                entity.Property(e => e.PreviousReading).HasColumnName("previousReading");

                entity.Property(e => e.PreviousReadingDate)
                    .HasColumnName("previousReadingDate")
                    .HasColumnType("date");

                entity.Property(e => e.PrimaryMobileNo)
                    .IsRequired()
                    .HasColumnName("primaryMobileNo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ReUse).HasColumnName("reUse");

                entity.Property(e => e.ReadingDate)
                    .HasColumnName("readingDate")
                    .HasColumnType("date");

                entity.Property(e => e.ReconnectionDate)
                    .HasColumnName("reconnectionDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNo)
                    .HasColumnName("secondaryMobileNo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SewarageConnectedBy).HasColumnName("sewarageConnectedBy");

                entity.Property(e => e.SewarageConnectionDate)
                    .HasColumnName("sewarageConnectionDate")
                    .HasColumnType("date");

                entity.Property(e => e.SewerageConnection).HasColumnName("sewerageConnection");

                entity.Property(e => e.StandardCosumption).HasColumnName("standardCosumption");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.WaterMeterNo)
                    .IsRequired()
                    .HasColumnName("waterMeterNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.Property(e => e.WorkLevelId).HasColumnName("workLevelId");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");

                entity.HasOne(d => d.LandDetail)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.LandDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable");

                entity.HasOne(d => d.LandOwnership)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.LandOwnershipId)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_9");

                entity.HasOne(d => d.OldWaterConnection)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.OldWaterConnectionId)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_10");

                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_6");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_8");

                entity.HasOne(d => d.WaterConnectionStatus)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.WaterConnectionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_2");

                entity.HasOne(d => d.WaterConnectionType)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.WaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_3");

                entity.HasOne(d => d.WaterLineType)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.WaterLineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_4");

                entity.HasOne(d => d.WaterMeterType)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.WaterMeterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_1");

                entity.HasOne(d => d.WorkLevel)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.WorkLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_7");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TrnWaterConnection)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterConnection_ToTable_5");
            });

            modelBuilder.Entity<TrnWaterMeterReading>(entity =>
            {
                entity.ToTable("trnWaterMeterReading");

                entity.Property(e => e.TrnWaterMeterReadingId).HasColumnName("trnWaterMeterReadingId");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Bucid).HasColumnName("bucid");

                entity.Property(e => e.Consumption).HasColumnName("consumption");

                entity.Property(e => e.IsPermanentConnection).HasColumnName("isPermanentConnection");

                entity.Property(e => e.NoOfUnit).HasColumnName("noOfUnit");

                entity.Property(e => e.PreviousReading).HasColumnName("previousReading");

                entity.Property(e => e.PreviousReadingDate)
                    .HasColumnName("previousReadingDate")
                    .HasColumnType("date");

                entity.Property(e => e.PrimaryMobileNo)
                    .IsRequired()
                    .HasColumnName("primaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReadBy).HasColumnName("readBy");

                entity.Property(e => e.Reading).HasColumnName("reading");

                entity.Property(e => e.ReadingDate)
                    .HasColumnName("readingDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNo)
                    .HasColumnName("secondaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sewerage).HasColumnName("sewerage");

                entity.Property(e => e.SolidWaste).HasColumnName("solidWaste");

                entity.Property(e => e.StandardConsumption).HasColumnName("standardConsumption");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.TrnWaterConnectionId).HasColumnName("trnWaterConnectionId");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.HasOne(d => d.TrnWaterConnection)
                    .WithMany(p => p.TrnWaterMeterReading)
                    .HasForeignKey(d => d.TrnWaterConnectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterMeterReading_ToTable");

                entity.HasOne(d => d.WaterConnectionStatus)
                    .WithMany(p => p.TrnWaterMeterReading)
                    .HasForeignKey(d => d.WaterConnectionStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterMeterReading_ToTable_4");

                entity.HasOne(d => d.WaterConnectionType)
                    .WithMany(p => p.TrnWaterMeterReading)
                    .HasForeignKey(d => d.WaterConnectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterMeterReading_ToTable_1");

                entity.HasOne(d => d.WaterLineType)
                    .WithMany(p => p.TrnWaterMeterReading)
                    .HasForeignKey(d => d.WaterLineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterMeterReading_ToTable_3");

                entity.HasOne(d => d.WaterMeterType)
                    .WithMany(p => p.TrnWaterMeterReading)
                    .HasForeignKey(d => d.WaterMeterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trnWaterMeterReading_ToTable_2");
            });

            modelBuilder.Entity<ViewLatestOcDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewLatestOcDetail");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.OcReferenceNo)
                    .IsRequired()
                    .HasColumnName("ocReferenceNo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");
            });

            modelBuilder.Entity<ViewLatestTop1Oc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewLatestTop1OC");

                entity.Property(e => e.BuildingDetailId).HasColumnName("buildingDetailId");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OccupancyCertificateApplicationId)
                    .HasColumnName("occupancyCertificateApplicationId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rn).HasColumnName("rn");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");
            });

            modelBuilder.Entity<ViewNotJointLandTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewNotJointLandTax");

                entity.Property(e => e.IsApportioned).HasColumnName("isApportioned");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.LandOwnershipTypeId).HasColumnName("landOwnershipTypeId");

                entity.Property(e => e.LandTaxRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LastTaxPaidYear).HasColumnName("lastTaxPaidYear");

                entity.Property(e => e.PLr)
                    .HasColumnName("pLR")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.StructureAvailable).HasColumnName("structureAvailable");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TotalLandTaxAmount).HasColumnType("decimal(38, 5)");

                entity.Property(e => e.UdtaxAmount)
                    .HasColumnName("UDTaxAmount")
                    .HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<ViewProertyTaxLedger>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewProertyTaxLedger");

                entity.Property(e => e.Caddress)
                    .HasColumnName("CAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CalendarYear)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasMaxLength(4000);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(746)
                    .IsUnicode(false);

                entity.Property(e => e.IsApportioned).HasColumnName("isApportioned");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LastColumnTotal)
                    .HasColumnName("lastColumnTotal")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PenaltyAmount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptId).HasColumnName("receiptId");

                entity.Property(e => e.TaxId).HasColumnName("taxId");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Ttin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewReadingSeet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ReadingSeet");

                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasColumnName("billingAddress")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Bucid).HasColumnName("bucid");

                entity.Property(e => e.ConsumerNo)
                    .HasColumnName("consumerNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.Consumption).HasColumnName("consumption");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlatNo)
                    .HasColumnName("flatNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDisconnected).HasColumnName("isDisconnected");

                entity.Property(e => e.IsPermanentConnection).HasColumnName("isPermanentConnection");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoOfUnit).HasColumnName("noOfUnit");

                entity.Property(e => e.PreviousReading).HasColumnName("previousReading");

                entity.Property(e => e.PreviousReadingDate)
                    .HasColumnName("previousReadingDate")
                    .HasColumnType("date");

                entity.Property(e => e.PrimaryMobileNo)
                    .IsRequired()
                    .HasColumnName("primaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReadBy).HasColumnName("readBy");

                entity.Property(e => e.Reading).HasColumnName("reading");

                entity.Property(e => e.ReadingDate)
                    .HasColumnName("readingDate")
                    .HasColumnType("date");

                entity.Property(e => e.ReadingYm)
                    .HasColumnName("ReadingYM")
                    .HasMaxLength(4000);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryMobileNo)
                    .HasColumnName("secondaryMobileNo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sewerage).HasColumnName("sewerage");

                entity.Property(e => e.SolidWaste).HasColumnName("solidWaste");

                entity.Property(e => e.StandardConsumption).HasColumnName("standardConsumption");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.WaterConnectionId).HasColumnName("waterConnectionId");

                entity.Property(e => e.WaterConnectionStatusId).HasColumnName("waterConnectionStatusId");

                entity.Property(e => e.WaterConnectionTypeId).HasColumnName("waterConnectionTypeId");

                entity.Property(e => e.WaterLineTypeId).HasColumnName("waterLineTypeId");

                entity.Property(e => e.WaterMeterNo)
                    .HasColumnName("waterMeterNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.WaterMeterReadingId).HasColumnName("waterMeterReadingId");

                entity.Property(e => e.WaterMeterTypeId).HasColumnName("waterMeterTypeId");

                entity.Property(e => e.ZoneId).HasColumnName("zoneId");
            });

            modelBuilder.Entity<ViewSlabAndRates>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSlabAndRates");

                entity.Property(e => e.IsApportioned).HasColumnName("isApportioned");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.StructureAvailable).HasColumnName("structureAvailable");
            });

            modelBuilder.Entity<ViewSlabAndRatesForLandTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSlabAndRatesForLandTax");

                entity.Property(e => e.IsApportioned).HasColumnName("isApportioned");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.SlabId).HasColumnName("slabId");

                entity.Property(e => e.StructureAvailable).HasColumnName("structureAvailable");

                entity.Property(e => e.ThramNo)
                    .HasColumnName("thramNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewTaxCalculationApi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_TaxCalculationAPI");

                entity.Property(e => e.CalendarYear)
                    .IsRequired()
                    .HasColumnName("calendarYear")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CalendarYearId).HasColumnName("calendarYearId");

                entity.Property(e => e.DemkhongId).HasColumnName("demkhongId");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsActiveCalendarYear).HasColumnName("isActiveCalendarYear");

                entity.Property(e => e.IsApportioned).HasColumnName("isApportioned");

                entity.Property(e => e.LandAcerage)
                    .HasColumnName("landAcerage")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.LandOwnershipId).HasColumnName("landOwnershipId");

                entity.Property(e => e.LandOwnershipTypeId).HasColumnName("landOwnershipTypeId");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.LandUseCategory)
                    .IsRequired()
                    .HasColumnName("landUseCategory")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.LandUseSubCategory)
                    .IsRequired()
                    .HasColumnName("landUseSubCategory")
                    .HasMaxLength(245)
                    .IsUnicode(false);

                entity.Property(e => e.LandUseSubCategoryId).HasColumnName("landUseSubCategoryId");

                entity.Property(e => e.LapId).HasColumnName("lapId");

                entity.Property(e => e.LastTaxPaidYear).HasColumnName("lastTaxPaidYear");

                entity.Property(e => e.PLr)
                    .HasColumnName("pLR")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PlotNo)
                    .IsRequired()
                    .HasColumnName("plotNo")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId).HasColumnName("propertyTypeId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.StreetNameId).HasColumnName("streetNameId");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.ThramNo)
                    .HasColumnName("thramNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewUnitTax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewUnitTax");

                entity.Property(e => e.GarbageTaxAmount).HasColumnType("decimal(38, 3)");

                entity.Property(e => e.LandDetailId).HasColumnName("landDetailId");

                entity.Property(e => e.NoOfUnit).HasColumnName("noOfUnit");

                entity.Property(e => e.StreetLightTaxAmount).HasColumnType("decimal(38, 3)");

                entity.Property(e => e.TaxPayerId).HasColumnName("taxPayerId");

                entity.Property(e => e.UnitTaxAmount)
                    .HasColumnName("unitTaxAmount")
                    .HasColumnType("decimal(38, 3)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}