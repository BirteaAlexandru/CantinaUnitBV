using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using Domain;
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
        public async Task<ICollection<OrderResponse>> GetAllOrders()
        {
            var users = await _orderRepository.GetOrderAsync();

            return users.Select(p => new OrderResponse
            {
                Id = p.Id,
                User = p.User,
                RecipesOrder= p.RecipesOrders,
            }).ToList();
        }
        public async Task<OrderResponse> GetOrderById(long? id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            return new OrderResponse
            {
                Id = order.Id,
                User = order.User,
                RecipesOrder = order.RecipesOrders,
            };
        }

        public async Task AddOrder(OrderRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var order = new Order()
            {
                UserId = request.UserId,
            };

            await _orderRepository.AddAsync(order);

            await scope.SaveAsync();
            await scope.CommitAsync();


        }
        public async Task AddRecipeOrder(long orderId, long recipeId)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var recipeOrder = new RecipesOrder()
            {
                OrderId= orderId,
                RecipeId= recipeId
            };

            await _recipeOrderRepository.AddAsync(recipeOrder);

            await scope.SaveAsync();
            await scope.CommitAsync();


        }

        public async Task UpdateOrder(long orderId, OrderUpdateRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new Exception($"Cannot find order with Id {orderId}");
            }

            order.User = request.User;
            order.RecipesOrders = request.RecipesOrder;


            await _orderRepository.UpdateAsync(order);

            await scope.SaveAsync();
            await scope.CommitAsync();
        }

        public async Task<bool> DeleteOrder(long? id)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var order = await _orderRepository.GetOrderByIdAsync(id);
            _orderRepository.Delete(order);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return true;
        }


    }
}
