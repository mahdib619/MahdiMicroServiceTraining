namespace Financial.Application.Dtos.Payment;

public class GetPaymentDto
{
    public int StudentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }
    public bool IsSuccess { get; set; }
    public string Description { get; set; }
}
