namespace Core.Security.Attributes;

public class FeaturePlanAccessAttribute : PermissionAccessAttribute
{
    public SubscriptionFeature SubscriptionFeature { get; set; }

    public FeaturePlanAccessAttribute(SubscriptionFeature subscriptionFeature)
    {
        SubscriptionFeature = subscriptionFeature;
    }
}