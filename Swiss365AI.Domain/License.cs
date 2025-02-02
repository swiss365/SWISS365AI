using System;

public class License
{
    public int Id { get; set; }
    public string LicenseKey { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime ExpiryDate { get; set; }
}