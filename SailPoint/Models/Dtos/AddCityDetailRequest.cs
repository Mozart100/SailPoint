namespace SailPoint.Models.Dtos;

public class AddCityDetailRequest
{
    public string City { get; set; }
}


public class AddCityDetailResponse
{
    public int Id { get; set; }
    public string City { get; set; }
}