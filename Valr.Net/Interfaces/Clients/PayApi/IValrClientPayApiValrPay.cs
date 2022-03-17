using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Objects.Models.Pay;

namespace Valr.Net.Interfaces.Clients.PayApi;

public interface IValrClientPayApiValrPay
{
    /// <summary>
    /// Initiate an instant payment using VALR Pay
    /// <para><a href="https://docs.valr.com/#3b9fbd53-cf42-419d-9fd2-971c14b189b2" /></para>
    /// </summary>
    /// <param name="paymentIdentifierType">Which identifier to use for the payment</param>
    /// <param name="recipientAccountId">The chosen identifier</param>
    /// <param name="currency">The currency in which payment is made. Currently only ZAR is supported</param>
    /// <param name="amount">Value of the currency to be paid</param>
    /// <param name="recipientNote">A note to the recipient</param>
    /// <param name="senderNote">A note for the sender</param>
    /// <param name="anonymous">Can be true or false. Default is false i.e. payment is not anonymous</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Transaction Id</returns>
    Task<WebCallResult<ValrPaymentResponse>> CreatePaymentAsync(ValrPaymentIdentifierType paymentIdentifierType, string recipientAccountId, string currency, decimal amount,
        string recipientNote, string senderNote, bool anonymous = false, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Retrieves all the payment limits applicable to your account
    /// <para><a href="https://docs.valr.com/#a6fbee20-b283-4693-91f1-7a35e81deee8" /></para>
    /// </summary>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Payment limits information</returns>
    Task<WebCallResult<ValrPaymentLimitResponse>> GetPaymentLimitsAsync(long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get your account's unique VALR PayID
    /// <para><a href="https://docs.valr.com/#16783a18-d56c-48c3-a491-1db883df43b8" /></para>
    /// </summary>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>VALR PayID</returns>
    Task<WebCallResult<ValrPaymentIdResponse>> GetPaymentIdAsync(long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Fetches a list of all payments made from to the current users account
    /// <para><a href="https://docs.valr.com/#04abb3b3-6c1e-49fd-b599-5e04fb8d204a" /></para>
    /// </summary>
    /// <param name="status">Array of status to filter by</param>
    /// <param name="skip">Number of items to skip from the list</param>
    /// <param name="limit">Limit the number of items returned</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Collection of payments</returns>
    Task<WebCallResult<ICollection<ValrPaymentHistoryResponse>>> GetPaymentHistoryAsync(ValrPaymentStatus[]? status = null, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default);


    /// <summary>
    /// Get the payment details by specifying the payment id
    /// <para><a href="https://docs.valr.com/#cf7e6c2d-cab7-4ee0-b895-e413f3210efb" /></para>
    /// </summary>
    /// <param name="id">The id of the payment</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Details of a single payment</returns>
    Task<WebCallResult<ValrPaymentHistoryResponse>> GetPaymentDetailsAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default);

    /// <summary>
    /// Get the payment details by specifying the payment id
    /// <para><a href="https://docs.valr.com/#cf7e6c2d-cab7-4ee0-b895-e413f3210efb" /></para>
    /// </summary>
    /// <param name="transactionId">The transaction id of the payment</param>
    /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Status of a single payment</returns>
    Task<WebCallResult<ValrPaymentStatusResponse>> GetPaymentStatusAsync(string transactionId, long? receiveWindow = null, CancellationToken ct = default);
}