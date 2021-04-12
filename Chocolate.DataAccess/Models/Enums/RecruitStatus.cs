namespace Chocolate.DataAccess.Models.Enums
{
    public enum RecruitStatus : byte
    {
        Unopened = 1,
        Reviewed = 2,
        Interviewing = 3,
        Interviewed = 4,
        Rejected = 5,
        Blacklisted = 6,
        Hired = 7
    }
}
