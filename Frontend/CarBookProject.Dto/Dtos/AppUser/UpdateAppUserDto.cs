﻿namespace CarBookProject.Dto.Dtos.AppUser
{
    public class UpdateAppUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public int Age { get; set; }
        public int LicenseIssuanceYear { get; set; }
    }
}
