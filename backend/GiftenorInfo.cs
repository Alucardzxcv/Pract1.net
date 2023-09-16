using System;
using System.Collections.Generic;


namespace backend
{
    public class ExternalDataResponse
{
    public List<ExternalDataResult> Results { get; set; }
}

public class ExternalDataResult
{
    public string Id { get; set; }
    public string Content_Description { get; set; }
    // Agrega aquí cualquier otra propiedad que necesites
}
}