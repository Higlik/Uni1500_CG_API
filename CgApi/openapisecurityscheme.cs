using Microsoft.OpenApi.Models;

internal class openapisecurityscheme : OpenApiSecurityScheme
{
    public string name { get; set; }
    public object type { get; set; }
    public string scheme { get; set; }
    public string bearerformat { get; set; }
    public object  { get; set; }
    public string description { get; set; }
}