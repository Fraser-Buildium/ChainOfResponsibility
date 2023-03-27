using System.ComponentModel;
using Core.Security.Attributes;

namespace Core.Security;

public enum Permission
{
    //Home
    Dashboard = 1010,
    MyInfo = 1020, //MyPreferences = 1030, 
    RentalOwnerLedger = 1040,
    VendorLedger = 1050,
    DashboardFinancials = 1060,
    Support = 1070,
    DashboardDocuments = 1080,
    //Newly added secondary navigation link, Rental owner requests for Rental owners
    RentalOwnerRequests = 1090,
    //Properties
    [Description("Rental properties and units")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Properties = 2010,
    [Description("Property Rental Owners")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    PropertyRentalOwners = 2020,
    [Description("Listings")]
    [OpenApiSupported(RoleAccessLevel.AddEditDelete)]
    Listings = 2040,
    ResidentSiteContactDirectory = 2050,
    [Description("Announcements")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    ResidentSiteAnnouncements = 2060,
    ResidentWebsiteUsers = 2070,
    PublicSite = 2080,
    //Applications
    //Tenants
    [Description("Tenants")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Tenants = 3010,
    ///<summary>The Leases permission maps to "Rent Roll" in the user-facing application.</summary>
    [Description("Leases")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Leases = 3020,
    [Description("Applicants")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Applications = 3030,
    [Description("Outstanding Balances")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    TenantPaymentsOutstanding = 3040,
    DraftLeases = 3050,
    //Association owners
    [Description("Association owners and tenants")]
    [OpenApiSupported(RoleAccessLevel.AddEditDelete)]
    AssociationOwners = 4010,
    ResidentCommunityDiscussions = 4020,
    [Description("Outstanding Balances")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    AssociationOwnerPaymentsOutstanding = 4030,
    [Description("Ownership account transactions")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    OwnershipAccountLedgers = 4040,
    [Description("Associations and units")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Associations = 4050,
    [Description("Ownership accounts")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    OwnershipAccounts = 4060,
    Violations = 4070,
    ArchitecturalRequests = 4080,
    //Tasks
    MyTasks = 5010,
    UnassignedTasks = 5020,
    [Description("Tasks")]
    [OpenApiSupported(RoleAccessLevel.AddEditDelete)]
    AllTasks = 5030,
    RecurringTasks = 5040,
    TaskVendors = 5050,
    //Financials
    Financials = 6010,
    [Description("General Ledger Transactions")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    GeneralLedger = 6020,
    [Description("Bank Accounts")]
    [NonStaffMemberAccess(false)]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Banking = 6030,
    RecurringTransactions = 6040,
    EftApprovals = 6045,

    //RentalOwners = 6050,
    [Description("Vendors")]
    [NonStaffMemberAccess(false)]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Vendors = 6060,
    [Description("Work Orders")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    WorkOrders = 6070,
    PropertyInspections = 6075,
    [Description("Bills")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Bills = 6080,
    [Description("Budgets")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Budgets = 6090,
    [Description("General Ledger Accounts")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    ChartOfAccounts = 6095,
    //Vendors
    VendorListings = 6510,
    Other = 6520,
    //Files
    [Description("Files")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Files = 7010,

    [NonStaffMemberAccess(false)]
    Misc1099 = 7020,
    //Reports
    Reports = 8010,

    [NonStaffMemberAccess(false)]
    Mailings = 8020,
    //Todo: MailingTemplates should be renamed as MailingAndEmailTemplates as per new design
    [Description("Mailing Templates")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    MailingTemplates = 8030,
    Activity = 8040,
    //Admin
    [NonStaffMemberAccess(false)]
    [Description("Application Settings")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    ApplicationSettings = 9010,
    [Description("Users")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    Users = 9020,
    [Description("User Roles")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    UserRoles = 9030,
    // Sign in as other users
    SignInAsStaffMember = 9031,
    // Skip 2FA
    SetSkip2FA = 9032,
    [NonStaffMemberAccess(false)]
    [Description("Account Information")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    BuildiumAccount = 9040,
    [NonStaffMemberAccess(false)]
    Imports = 9070,
    Exports = 9080,
    //Common
    Help = 1,

    [Description("Lease transactions")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    ResidentLedgers = 991,
    [Description("Emails")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    Emails = 992,
    //Todo: EmailTemplates should be renamed as AutomatedEmailSettings as per new design
    EmailTemplates = 993,
    SMSAccounts = 994,
    //SMSMessages = 995,
    [Description("Timelines (Phone Logs)")]
    [OpenApiSupported(RoleAccessLevel.AddEdit)]
    CommunicationTimelines = 996,

    // External
    /// <summary>
    /// Indicates that the user has permission to access information needed
    /// by the Credit Retriever Admin application.
    /// </summary>
    CreditRetrieverAdmin = 10000,

    [NonStaffMemberAccess(false)]
    Company = 10100,

    [NonStaffMemberAccess(false)]
    [Description("All Property Management")]
    [OpenApiSupported(RoleAccessLevel.ReadOnly)]
    AllPropertyManagement = 10200,
    
    /// <summary>
    /// Indicates that the user has Strongroom API permission to access
    /// sensitive information ex. decrypted Bank Account information
    /// </summary>
    Strongroom = 10300,
    
    //Insights
    InsightsSummary = 10400,
    InsightsResidentCenterUsage = 10401,
    InsightsEPayAdoption = 10402,
    InsightsLeasingPerformance = 10403,
    InsightsBusinessMetrics = 10404,
    InsightsAssociationPerformance = 10405,
    InsightsMaintenance = 10406,
    InsightsExpenses = 10407,   
    InsightsOpenTasks = 10408,
    
    // User level
    FinancialAdmin = 10500,
    
    //Features
    [FeaturePlanAccess(SubscriptionFeature.LeasingInsightFeature)]
    LeasingInsightFeature = 10600,
    
    //Esignatures Settings
    [NonStaffMemberAccess(false)]
    [Description("eSignature settings")]
    EsignatureSettings = 10700,
    
    //Permissions for partner related data, utilized by
    //the partner portal to provide access to specific sections
    //of the application
    [PartnerPortalPermission]
    PartnerSolutions = 10800,
    [PartnerPortalPermission]
    PartnerWebhooks = 10801,
    [PartnerPortalPermission]
    PartnerBasicAuthCredentials = 10802
}