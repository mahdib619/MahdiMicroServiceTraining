using University.Application.Dtos.StudentBalance;

namespace University.Application.Contracts.SyncDataServices;

public interface IStudentBalanceDataClient
{
    Task<GetStudentBalanceInfoDto> GetStudentBalanceInfo(string studentNumber, DateTime? startDate = null, DateTime? endDate = null);
}
