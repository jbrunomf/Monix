using Microsoft.EntityFrameworkCore;
using Monix.Api.Data;
using Monix.Core.Handlers;
using Monix.Core.Models;
using Monix.Core.Requests.Categories;
using Monix.Core.Requests.Transactions;
using Monix.Core.Responses;

namespace Monix.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {

                var transaction = new Transaction()
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    CreatedAt = DateTime.Now,
                    PaidOrReceivedAt = request.PaidOrReceivedAt,
                    Type = request.Type,
                    Title = request.Title
                };

                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();
                return new Response<Transaction?>(transaction, 200, "Transação criada com sucesso");
            }
            catch (Exception)
            {
                return new Response<Transaction?>(null, 500, "Não foi possível criar a transação");
            }
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            var transaction = await context
                .Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(null, 404, "não foi possível atualizar a transação.");

            transaction.Amount = request.Amount;
            transaction.CategoryId = request.CategoryId;
            transaction.Type = request.Type;
            transaction.Title = request.Title;
            transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;

            context.Transactions.Update(transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(transaction, 200, "Transação  atualizada com sucesso!");
        }


        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            var transaction = context.Transactions.FirstOrDefault(x => x.Id == request.Id && x.UserId == request.UserId);
            context.Remove(transaction);

            return transaction is null
                ? new Response<Transaction?>(null, 500, "Erro ao atualizar transação")
                : new Response<Transaction?>(transaction, 200, "Transação removida com sucesso");

        }

        public Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
