namespace Core.Errors
{
    public enum ErrorCode
    {
        // Generic codes should be in 1 - 99 range.
        ResultsLimitExceeded = 1,
        FeatureNotEnabled = 2,
        UserNotFound = 3,
        EmailUnsubscribed = 4,
        QueryTimeout = 5,

        ReportBatchNotFound = 100,

        ResetPasswordInvalidToken = 201,
        ResetPasswordExpiredToken = 202,
        ResetPasswordMissingEmail = 203,
        ResetPasswordSameAsPreviousPassword = 204,
        ChangePasswordIncorrectPassword = 205,
        ResidentSelfRegistrationNoMatchingAccounts = 206,
        ResidentSelfRegistrationAccountExists = 207,
        PasswordFoundInDataBreach = 208,
        ResetPasswordBlockedUser = 209,
        ResetPasswordAlreadyUsedToken = 210,
        PasswordStrengthScoreIsInsufficient = 211,
        PasswordLengthIsInsufficient = 212,
        PasswordIsNullOrEmpty = 213,
        PasswordDoesNotContainDigit = 214,
        PasswordDoesNotContainUpperCase = 215,
        PasswordDoesNotContainLowerCase = 216,
        PasswordDoesNotSpecialCharacters = 217,
        RequestedPublicFlagNotWhitelisted = 218,
        PasswordTooSimilarToAnOldPassword = 219,

        // Two factor authentication related codes
        TwoFactorAuthenticationConfigNotFound = 211,
        MoreThanOneSubscriberFound = 212,

        // Authentication related codes
        SuperAdminCannotLoginFromGlobalSignin = 220,
        InactiveAccount = 221,
        PaymentMethodInvalid = 222,
        ExpiredTrial = 223,
        InactiveUser = 224,
        BlockedUser = 225,
        InvalidEmailAddressToken = 226,
        InvalidLoginToken = 227,
        TooManyInvalidRequests = 228,
        UserAlreadyRegistered = 229,
        EmailIsTiedToApplicantUser = 230,
        NoPartnerPortalAccess = 231,

        // Payment related code
        InvalidBankAccountOrRoutingNumber = 301,
        InvalidForteTransaction = 302,
        CannotSaveEftDetails = 303,
        RentalApplicationCreditCardFailure = 304,
        CreditCardAuthorizationFailure = 305,
        ApplicationFeeCreditCardPaymentWithoutPropertySet = 306,

        // Renters Insurance related code
        InsurancePolicyBindForbidden = 401,
        InsurancePolicyBindInvalidAddress = 402,
        InsuranceMoratorium = 403,

        // Rental Application related codes
        RentalApplicationAlreadySubmittedError = 501,
        RentalApplicationNoLongerExistsError = 502,

        // Open api marketplace JWT exchange errors
        JWTExchangeUserNotEligible = 503,
        JWTExchangeTokenInvalid = 504,
        JWTExchangeKeyAlreadyExists = 505,
        JWTExchangeKeyCreationFailed = 506,
        JWTExchangePartnerPermissionsChanged = 507,
        JWTExchangeAuthenticationFailure = 508,
        JWTExchangeJWTAlreadyExchanged = 509,

        ApplicantCannotBeDeletedError = 510,
        ApplicantHistoryCannotBeDeletedError = 511,

        TaskTitleInvalidLength = 601,

        // Esignatures related codes
        EsignaturesTrialAccountForbidden = 701,

        // Applicant Center related codes
        ApplicantUserWithEmailAlreadyExists = 801,
        InvalidApplicantUserTypeLogin = 802,
        
        //Screening related codes
        TwoPhaseScreeningNotCompleted = 901
    }
}
