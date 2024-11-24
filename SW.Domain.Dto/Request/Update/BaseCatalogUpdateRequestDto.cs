using SW.Domain.Dto.Interfaces;

namespace SW.Domain.Dto.Request.Update;

public class BaseCatalogUpdateRequestDto : ICatalogBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
}