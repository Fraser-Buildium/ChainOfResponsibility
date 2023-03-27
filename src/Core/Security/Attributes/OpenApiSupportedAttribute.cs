namespace Core.Security.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class OpenApiSupportedAttribute : Attribute
{
    public OpenApiSupportedAttribute(RoleAccessLevel openApiMaxAcl)
    {
        OpenApiMaxAcl = openApiMaxAcl;
    }
        
    public RoleAccessLevel OpenApiMaxAcl { get; }
}