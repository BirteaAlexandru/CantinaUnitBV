using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using Domain;
using Domain.Base;
using Domain.Search;
using Microsoft.Extensions.Logging;


namespace ApplicationServices.Services.Orders

{
    public class OrderService: Service, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRecipeOrderRepository _recipeOrderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, ILogger<OrderService> logger) : base(logger)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<PartialCollectionResponse<OrderResponse>> GetAllOrders(SearchArgs searchArgs)
        {
            var orders = await _orderRepository.GetOrderAsync(searchArgs);

            var orderResponse= orders.Select(p => new OrderResponse
            {
                Id = p.Id,
                User = p.User,
                RecipesOrder= p.RecipesOrders,
            }).ToList();

            return new PartialCollectionResponse<OrderResponse>
            {
                Values = orderResponse,
                Offset = orders.Offset,
                Limit = orders.Limit,
                RecordsFiltered = orders.Count,
                RecordsTotal = await _orderRepository.CountAsync()
            };
        }
        public async Task<Result<OrderResponse>> GetOrderById(long? id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return Result.Failure<OrderResponse>($"Cannot find order with Id {id}");
            }

            var result= new OrderResponse
            {
                Id = order.Id,
                User = order.User,
                RecipesOrder = order.RecipesOrders,
            };

            return Result.Success(result);
        }

        public async Task<Result> AddOrder(OrderRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var orderOrError = Order.Create(request.UserId);

            if (orderOrError.IsFailure)
            {
                return Result.Failure(orderOrError.Error);
            }

            await _orderRepository.AddAsync(orderOrError.Value);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success("The order was created successfully");

        }
        public async Task<Result> AddRecipeOrder(long orderId, long recipeId)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var recipeOrder = RecipesOrder.Create(orderId, recipeId);

            if (recipeOrder.IsFailure)
            {
                return Result.Failure(recipeOrder.Error);
            }

            await _recipeOrderRepository.AddAsync(recipeOrder.Value);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success();
        }

        public async Task<Result> UpdateOrder(long orderId, OrderUpdateRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new Exception($"Cannot find order with Id {orderId}");
            }

            var orderOrError = order.Update(request.User, request.RecipesOrder);

            if (orderOrError.IsFailure)
            {
                return Result.Failure(orderOrError.Error);
            }
            
            await _orderRepository.UpdateAsync(order);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success();

        }

        public async Task<Result> DeleteOrder(long? id)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                throw new Exception($"Cannot find order with Id {id}");
            }

            _orderRepository.Delete(order);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success();
        }


    }
}
