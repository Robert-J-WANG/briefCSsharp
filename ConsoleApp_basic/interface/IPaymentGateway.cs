namespace ConsoleApp_basic;

public interface IPaymentGateway
{
    void Charge(decimal amount);
}